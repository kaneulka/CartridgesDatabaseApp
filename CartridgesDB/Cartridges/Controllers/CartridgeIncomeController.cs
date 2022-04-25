using Cartridges.Data;
using Cartridges.Ser.BillSer;
using Cartridges.Ser.BuildingSer;
using Cartridges.Ser.CartridgeIncomeSer;
using Cartridges.Ser.CartridgeModelPrinterModelSer;
using Cartridges.Ser.CartridgeModelSer;
using Cartridges.Ser.DepartmentSer;
using Cartridges.Ser.PrinterCompanySer;
using Cartridges.Ser.PrinterModelSer;
using Cartridges.Ser.RequestSer;
using Cartridges.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Controllers
{
    public class CartridgeIncomeController : Controller
    {
        private readonly ICartridgeModelService cartridgeModelService;
        private readonly ICartridgeIncomeService cartridgeIncomeService;
        private readonly IBillService billService;
        IWebHostEnvironment _appEnvironment;

        public CartridgeIncomeController(ICartridgeModelService cartridgeModelService,
            IBillService billService,
            IWebHostEnvironment appEnvironment,
            ICartridgeIncomeService cartridgeIncomeService)
        {
            this.cartridgeIncomeService = cartridgeIncomeService;
            this.cartridgeModelService = cartridgeModelService;
            this.billService = billService;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index(int? sortType = 0)
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                List<CartridgeIncome> cartridgeIncome = cartridgeIncomeService.GetCartridgeIncomes().ToList();
                switch (sortType)
                {
                    case 0:
                        cartridgeIncome = cartridgeIncome.OrderBy(e => e.Name).ToList();
                        break;
                    case 1:
                        cartridgeIncome = cartridgeIncome.OrderByDescending(e => e.Name).ToList();
                        break;
                    case 2:
                        cartridgeIncome = cartridgeIncome.OrderBy(e => e.AddedDate).ToList();
                        break;
                    case 3:
                        cartridgeIncome = cartridgeIncome.OrderByDescending(e => e.AddedDate).ToList();
                        break;

                }
                List<CartridgeIncomeViewModel> lbvm = new List<CartridgeIncomeViewModel>();
                foreach (var b in cartridgeIncome)
                {
                    CartridgeIncomeViewModel bvm = new CartridgeIncomeViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        AddedDate = b.AddedDate,
                        CartridgeName = b.CartridgeModel.Name,
                        IncomeQuantity = b.IncomeQuantity
                    };
                    lbvm.Add(bvm);
                }

                return View(lbvm.OrderByDescending(c=> c.AddedDate).ToList());
            }
            return StatusCode(403);
        }
        [HttpGet]
        public IActionResult AddCartridgeIncome()
        {
            if (User.IsInRole("admin"))
            {
                CartridgeIncomeViewModel model = new CartridgeIncomeViewModel();
                model.Cartridges = cartridgeModelService.GetCartridgeModels().OrderBy(c=> c.Name).ToList();
                return PartialView("_AddCartridgeIncome", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult AddCartridgeIncome(CartridgeIncomeViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                CartridgeModel cartridge = cartridgeModelService.GetCartridgeModel(model.CartridgeModelId);
                CartridgeIncome cartridgeIncomeEntity = new CartridgeIncome { Name = DateTime.Now + " " + cartridge.Name + " " + cartridge.Bill.Name, AddedDate = DateTime.Now, ModifiedDate = DateTime.Now, CartridgeModelId = model.CartridgeModelId, IncomeQuantity = model.IncomeQuantity };
                if (ModelState.IsValid)
                {
                    cartridgeIncomeService.InsertCartridgeIncome(cartridgeIncomeEntity);
                    cartridge.Quantity += cartridgeIncomeEntity.IncomeQuantity;
                    cartridgeModelService.UpdateCartridgeModel(cartridge);
                    if (cartridgeIncomeEntity.Id > 0)
                        return RedirectToAction("Index");
                }
                return PartialView("_AddCartridgeIncome", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult DeleteCartridgeIncome(long? id)
        {
            if (User.IsInRole("admin"))
            {
                CartridgeIncomeViewModel model = new CartridgeIncomeViewModel();
                if (id.HasValue && id != 0)
                {
                    CartridgeIncome cartridgeIncome = cartridgeIncomeService.GetCartridgeIncome((long)id);
                    model.Name = cartridgeIncome.Name;
                }
                return PartialView("_DeleteCartridgeIncome", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult DeleteCartridgeIncome(long id)
        {
            if (User.IsInRole("admin"))
            {
                var cartridgeIncome = cartridgeIncomeService.GetCartridgeIncome(id);
                var cartridge = cartridgeModelService.GetCartridgeModel(cartridgeIncome.CartridgeModelId);
                cartridge.Quantity = cartridge.Quantity <= cartridgeIncome.IncomeQuantity ? 0 : cartridge.Quantity - cartridgeIncome.IncomeQuantity;
                cartridgeModelService.UpdateCartridgeModel(cartridge);
                cartridgeIncomeService.DeleteCartridgeIncome(id);
                return RedirectToAction("Index");
            }
            else
            {
                return StatusCode(403);
            }
        }



        [HttpPost]
        public async Task<IActionResult> CartridgeIncomes(IFormFile uploadedFile)
        {
            if (User.IsInRole("admin"))
            {
                if (uploadedFile != null)
                {
                    string path = _appEnvironment.WebRootPath + "/Files/DBUpdate";
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    List<string> failedCartridges = new List<string>();
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        string sFileExtension = Path.GetExtension(uploadedFile.FileName).ToLower();
                        ISheet sheet;
                        uploadedFile.CopyTo(stream);
                        stream.Position = 0;
                        if (sFileExtension == ".xls")
                        {
                            HSSFWorkbook hssfwb = new HSSFWorkbook(stream);
                            sheet = hssfwb.GetSheetAt(0);
                        }
                        else
                        {
                            XSSFWorkbook xssfwb = new XSSFWorkbook(stream);
                            sheet = xssfwb.GetSheetAt(0);
                        }

                        List<CartridgeModel> cartridgeModels = cartridgeModelService.GetCartridgeModels().ToList();
                        List<Bill> bills = billService.GetBills().ToList();
                        List<CartridgeModel> cartridgesToUpdate = new List<CartridgeModel>();

                        var i = 0;
                        var ending = sheet.PhysicalNumberOfRows;

                        do
                        {
                            i++;
                            IRow row = sheet.GetRow(i);
                            string cartridgeName = "";
                            if (i < ending)
                            {
                                cartridgeName = row.GetCell(0).ToString().Trim();
                                if (cartridgeName == "") break;
                            }
                            else { break; }

                            int billNum = Convert.ToInt32(row.GetCell(1).ToString().Trim());
                            int cartridgeQuantity = Convert.ToInt32(row.GetCell(2).ToString().Trim());

                            Bill bill = bills.SingleOrDefault(b => b.BillNumber == billNum);
                            CartridgeModel cartridgeModel = cartridgeModels.SingleOrDefault(c => c.Name == cartridgeName && c.Bill == bill);
                            if (cartridgeModel != null)
                            {
                                cartridgeModels.Remove(cartridgeModel);
                                cartridgeModel.Quantity += cartridgeQuantity;
                                cartridgeModel.ModifiedDate = DateTime.Now;
                                cartridgesToUpdate.Add(cartridgeModel);
                                cartridgeModels.Add(cartridgeModel);

                                CartridgeIncome cartridgeIncome = new CartridgeIncome
                                {
                                    AddedDate = DateTime.Now,
                                    CartridgeModelId = cartridgeModel.Id,
                                    ModifiedDate = DateTime.Now,
                                    Name = DateTime.Now + " " + cartridgeModel.Name + " " + cartridgeModel.Bill.Name,
                                    IncomeQuantity = cartridgeQuantity
                                };
                                cartridgeIncomeService.InsertCartridgeIncome(cartridgeIncome);
                            }
                        } while (true);
                        cartridgeModelService.UpdateCartridgeModels(cartridgesToUpdate);
                    }
                    return RedirectToAction("Index");
                }
                return StatusCode(406);
            }
            else
            {
                return StatusCode(403);
            }
        }


        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckPosition(long CartridgeModelId)
        {
            if (CartridgeModelId == 0)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        [HttpPost]
        public IActionResult ReturnIncomeFile()
        {

            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                string path = _appEnvironment.WebRootPath + "/Files/CartIncome.xlsx";
                string type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return PhysicalFile(path, type);
            }
            return StatusCode(403);
        }
    }
}
