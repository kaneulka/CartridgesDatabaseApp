using Cartridges.Data;
using Cartridges.Ser.BillSer;
using Cartridges.Ser.CartridgeModelPrinterModelSer;
using Cartridges.Ser.CartridgeModelSer;
using Cartridges.Ser.PrinterCompanySer;
using Cartridges.Ser.PrinterModelSer;
using Cartridges.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Controllers
{
    public class CartridgeModelController : Controller
    {
        private readonly ICartridgeModelService cartridgeModelService;
        private readonly ICartridgeModelPrinterModelService cartridgeModelPrinterModelService;
        private readonly IPrinterModelService printerModelService;
        private readonly IBillService billService;
        public CartridgeModelController(ICartridgeModelService cartridgeModelService,
            IPrinterModelService printerModelService,
            ICartridgeModelPrinterModelService cartridgeModelPrinterModelService,
            IBillService billService)
        {
            this.cartridgeModelService = cartridgeModelService;
            this.printerModelService = printerModelService;
            this.cartridgeModelPrinterModelService = cartridgeModelPrinterModelService;
            this.billService = billService;
        }

        [HttpGet]
        public IActionResult CartridgeModels(int? sortType = 0)
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                List<CartridgeModel> cartridgeModel = cartridgeModelService.GetCartridgeModels().ToList();
                List<PrinterModel> printers = printerModelService.GetPrinterModels().ToList();
                List<CartridgeModelPrinterModel> lcpm = cartridgeModelPrinterModelService.GetAll().ToList();
                switch (sortType)
                {
                    case 0:
                        cartridgeModel = cartridgeModel.OrderBy(e => e.Name).ToList();
                        break;
                    case 1:
                        cartridgeModel = cartridgeModel.OrderByDescending(e => e.Name).ToList();
                        break;
                    case 8:
                        cartridgeModel = cartridgeModel.OrderBy(e => e.Quantity).ToList();
                        break;
                    case 9:
                        cartridgeModel = cartridgeModel.OrderByDescending(e => e.Quantity).ToList();
                        break;

                }
                List<CartridgeModelViewModel> lbvm = new List<CartridgeModelViewModel>();
                foreach (var b in cartridgeModel)
                {
                    CartridgeModelViewModel bvm = new CartridgeModelViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        NomenclatureNumber = b.NomenclatureNumber,
                        AddedDate = b.AddedDate,
                        ModifiedDate = b.ModifiedDate,
                        Quantity = b.Quantity,
                        PrintersFullName = "",
                        BillName = b.Bill.Name + " " + b.Bill.BillNumber
                    };
                    foreach (var printer in printers.Where(p => lcpm.Where(cpm => cpm.CartridgeModelId == b.Id).Select(cpm => cpm.PrinterModelId).Contains(p.Id)))
                    {
                        bvm.PrintersFullName += printer.PrinterCompany.Name + " " + printer.Name + "; ";
                    }
                    lbvm.Add(bvm);
                }

                return View(lbvm);
            }
            return StatusCode(403);
        }

        [HttpGet]
        public IActionResult AddCartridgeModel()
        {
            if (User.IsInRole("admin"))
            {
                CartridgeModelViewModel model = new CartridgeModelViewModel();
                if (printerModelService.CheckPrinterModelsExist())
                {
                    model.PrinterModels = printerModelService.GetPrinterModels().ToList();
                }
                model.PrinterModels = printerModelService.GetPrinterModels().OrderByDescending(p=> p.PrinterCompany.Name).ToList();
                model.Bills = billService.GetBills().ToList();
                return PartialView("_AddCartridgeModel", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult AddCartridgeModel(CartridgeModelViewModel model, List<long> printerModelIds)
        {
            if (User.IsInRole("admin"))
            {
                CartridgeModel cartridgeModelEntity = new CartridgeModel
                {
                    Name = model.Name,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Quantity = model.Quantity,
                    NomenclatureNumber = model.NomenclatureNumber,
                    BillId = model.BillId
                };
                if (ModelState.IsValid)
                {
                    cartridgeModelService.InsertCartridgeModel(cartridgeModelEntity);
                    if (printerModelIds.Count > 0)
                    {
                        List<CartridgeModelPrinterModel> lcmpm = new List<CartridgeModelPrinterModel>();
                        foreach (var pmId in printerModelIds)
                        {
                            lcmpm.Add(new CartridgeModelPrinterModel { PrinterModelId = pmId, CartridgeModelId = cartridgeModelEntity.Id });
                        }
                        cartridgeModelPrinterModelService.InsertSome(lcmpm);
                    }
                    if (cartridgeModelEntity.Id > 0) return RedirectToAction("CartridgeModels");
                }
                return PartialView("_AddCartridgeModel", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult EditCartridgeModel(long? id)
        {
            if (User.IsInRole("admin"))
            {
                CartridgeModelViewModel model = new CartridgeModelViewModel();
                if (id.HasValue && id != 0)
                {
                    CartridgeModel cartridgeModel = cartridgeModelService.GetCartridgeModel((long)id);
                    model.PrinterModels = printerModelService.GetPrinterModels().OrderByDescending(p => p.PrinterCompany.Name).ToList();
                    model.Name = cartridgeModel.Name;
                    model.Quantity = cartridgeModel.Quantity;
                    model.NomenclatureNumber = cartridgeModel.NomenclatureNumber;
                    model.BillId = cartridgeModel.BillId;
                    model.Bills = billService.GetBills().ToList();
                    if (cartridgeModelPrinterModelService.IsExist(cartridgeModel.Id, 0))
                    {
                        model.CheckedPrinterModels = cartridgeModelPrinterModelService.GetAll().Where(cpm => cpm.CartridgeModelId == cartridgeModel.Id).Select(cpm=> cpm.PrinterModelId).ToList();
                    }
                    if (printerModelService.CheckPrinterModelsExist())
                    {
                        model.PrinterModels = printerModelService.GetPrinterModels().ToList();
                    }
                }

                return PartialView("_EditCartridgeModel", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult EditCartridgeModel(CartridgeModelViewModel model, List<long> printerModelIds)
        {
            if (User.IsInRole("admin"))
            {
                CartridgeModel cartridgeModelEntity = cartridgeModelService.GetCartridgeModel(model.Id);
                cartridgeModelEntity.Name = model.Name;
                cartridgeModelEntity.ModifiedDate = DateTime.Now;
                cartridgeModelEntity.Quantity = model.Quantity;
                cartridgeModelEntity.NomenclatureNumber = model.NomenclatureNumber;
                cartridgeModelEntity.BillId = model.BillId;

                if (ModelState.IsValid)
                {
                    cartridgeModelService.UpdateCartridgeModel(cartridgeModelEntity);
                    if (printerModelIds.Count() > 0)
                    {
                        List<CartridgeModelPrinterModel> lcpm = cartridgeModelPrinterModelService.GetAll().Where(cpm => cpm.CartridgeModelId == cartridgeModelEntity.Id).ToList();
                        if (lcpm.Count() > 0) cartridgeModelPrinterModelService.DeleteSome(lcpm);
                        List<CartridgeModelPrinterModel> lcpmToAdd = new List<CartridgeModelPrinterModel>();
                        foreach (var cpi in printerModelIds) lcpmToAdd.Add(new CartridgeModelPrinterModel { PrinterModelId = cpi, CartridgeModelId = cartridgeModelEntity.Id });
                        cartridgeModelPrinterModelService.InsertSome(lcpmToAdd);
                    }
                    if (cartridgeModelEntity.Id > 0) return RedirectToAction("CartridgeModels");
                }
                return PartialView("_EditCartridgeModel", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult DeleteCartridgeModel(long? id)
        {
            if (User.IsInRole("admin"))
            {
                CartridgeModelViewModel model = new CartridgeModelViewModel();
                if (id.HasValue && id != 0)
                {
                    CartridgeModel cartridgeModel = cartridgeModelService.GetCartridgeModel((long)id);
                    model.Name = cartridgeModel.Name;
                }
                return PartialView("_DeleteCartridgeModel", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult DeleteCartridgeModel(long id)
        {
            if (User.IsInRole("admin"))
            {
                cartridgeModelService.DeleteCartridgeModel(id);
                return RedirectToAction("CartridgeModels");
            }
            else
            {
                return StatusCode(403);
            }
        }


        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckBill(long billId)
        {
            if (billId == 0)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

    }
}
