using Cartridges.Ser.BillSer;
using Cartridges.Ser.BuildingSer;
using Cartridges.Ser.CartridgeModelPrinterModelSer;
using Cartridges.Ser.CartridgeModelSer;
using Cartridges.Ser.DepartmentSer;
using Cartridges.Ser.PrinterCompanySer;
using Cartridges.Ser.PrinterModelSer;
using Cartridges.Ser.RequestSer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using Cartridges.Data;
using Cartridges.Ser.CartridgeIncomeSer;
using Microsoft.AspNetCore.Authorization;

namespace Cartridges.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class DBController : Controller
    {
        private readonly ICartridgeModelService cartridgeModelService;
        private readonly ICartridgeModelPrinterModelService cartridgeModelPrinterModelService;
        private readonly IPrinterCompanyService printerCompanyService;
        private readonly IPrinterModelService printerModelService;
        private readonly IBillService billService;
        IWebHostEnvironment _appEnvironment;

        public DBController(ICartridgeModelService cartridgeModelService,
            IPrinterCompanyService printerCompanyService,
            IPrinterModelService printerModelService,
            ICartridgeModelPrinterModelService cartridgeModelPrinterModelService,
            IBillService billService,
            IWebHostEnvironment appEnvironment
            )
        {
            this.cartridgeModelService = cartridgeModelService;
            this.printerCompanyService = printerCompanyService;
            this.printerModelService = printerModelService;
            this.cartridgeModelPrinterModelService = cartridgeModelPrinterModelService;
            this.billService = billService;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return View();
            }
            return StatusCode(403);
        }

        [HttpPost]
        public async Task<IActionResult> UploadDB(IFormFile uploadedFile)
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

                    List<PrinterModel> printerModels = printerModelService.GetPrinterModels().ToList();
                    List<CartridgeModelPrinterModel> lcpm = cartridgeModelPrinterModelService.GetAll().ToList();
                    List<CartridgeModel> cartridgeModels = cartridgeModelService.GetCartridgeModels().ToList();
                    List<PrinterCompany> printerCompanies = printerCompanyService.GetPrinterCompanies().ToList();
                    List<Bill> bills = billService.GetBills().ToList();
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

                        string cartridgeNomNum = row.GetCell(1).ToString().Trim();
                        int billNum = Convert.ToInt32(row.GetCell(2).ToString().Trim());
                        int cartridgeQuantity = Convert.ToInt32(row.GetCell(3).ToString().Trim());
                        string printerCompanyName = row.GetCell(4).ToString().Trim();
                        string printerModelNames = row.GetCell(5).ToString().Trim();

                        List<string> splitedPrinterModelNames = printerModelNames.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        List<PrinterModel> selectedPrinters = printerModels.Where(p => splitedPrinterModelNames.Contains(p.Name)).ToList();



                        Bill bill = bills.SingleOrDefault(b => b.BillNumber == billNum);
                        if (cartridgeModels.Exists(c => c.Name == cartridgeName && c.Bill == bills.SingleOrDefault(b => b.BillNumber == billNum)))
                        {
                            CartridgeModel cartridgeModel = cartridgeModels.SingleOrDefault(c => c.Name == cartridgeName && c.Bill == bills.SingleOrDefault(b => b.BillNumber == billNum));
                            if (cartridgeModel.Quantity != cartridgeQuantity)
                            {
                                cartridgeModels.Remove(cartridgeModel);
                                cartridgeModel.Quantity = cartridgeQuantity;
                                cartridgeModel.ModifiedDate = DateTime.Now;
                                cartridgeModels.Add(cartridgeModel);
                                //cartridgesToUpdate.Add(cartridgeModel);
                                cartridgeModelService.UpdateCartridgeModel(cartridgeModel);
                            }
                            foreach (var printerName in splitedPrinterModelNames)
                            {
                                if (!printerModels.Exists(p=> p.Name == printerName && p.PrinterCompany.Name == printerCompanyName))
                                {
                                    PrinterCompany printerCompany = new PrinterCompany();
                                    if (!printerCompanies.Select(pc=> pc.Name).Contains(printerCompanyName))
                                    {
                                        printerCompany.Name = printerCompanyName;
                                        printerCompany.AddedDate = DateTime.Now;
                                        printerCompany.ModifiedDate = DateTime.Now;
                                        printerCompanyService.InsertPrinterCompany(printerCompany);
                                        printerCompanies.Add(printerCompany);
                                    }
                                    else
                                    {
                                        printerCompany = printerCompanies.SingleOrDefault(pc => pc.Name == printerCompanyName);
                                    }
                                    PrinterModel printer = new PrinterModel
                                    {
                                        Name = printerName,
                                        AddedDate = DateTime.Now,
                                        ModifiedDate = DateTime.Now,
                                        PrinterCompanyId = printerCompany.Id
                                    };
                                    printerModelService.InsertPrinterModel(printer);
                                    printerModels.Add(printer);
                                    selectedPrinters.Add(printer);
                                }
                            }
                            foreach (var printer in selectedPrinters
                              .Where(p => !lcpm.Where(cpm => cpm.CartridgeModelId == cartridgeModel.Id)
                                  .Select(cpm => cpm.PrinterModelId).Contains(p.Id)))//Проверка на наличие такого
                            {
                                CartridgeModelPrinterModel cpm = new CartridgeModelPrinterModel
                                {
                                    PrinterModelId = printer.Id,
                                    CartridgeModelId = cartridgeModel.Id
                                };
                                cartridgeModelPrinterModelService.Insert(cpm);
                                lcpm.Add(cpm);
                            }
                        }
                        else
                        {
                            CartridgeModel cartridgeModel = new CartridgeModel
                            {
                                AddedDate = DateTime.Now,
                                ModifiedDate = DateTime.Now,
                                Name = cartridgeName,
                                Quantity = cartridgeQuantity,
                                BillId = bills.SingleOrDefault(b => b.BillNumber == billNum).Id,
                                NomenclatureNumber = cartridgeNomNum
                            };
                            cartridgeModelService.InsertCartridgeModel(cartridgeModel);
                            cartridgeModels.Add(cartridgeModel);

                            foreach (var printerName in splitedPrinterModelNames)
                            {
                                if (!printerModels.Exists(p => p.Name == printerName && p.PrinterCompany.Name == printerCompanyName))
                                {
                                    PrinterCompany printerCompany = new PrinterCompany();
                                    if (!printerCompanies.Select(pc => pc.Name).Contains(printerCompanyName))
                                    {
                                        printerCompany.Name = printerCompanyName;
                                        printerCompany.AddedDate = DateTime.Now;
                                        printerCompany.ModifiedDate = DateTime.Now;
                                        printerCompanyService.InsertPrinterCompany(printerCompany);
                                        printerCompanies.Add(printerCompany);
                                    }
                                    else
                                    {
                                        printerCompany = printerCompanies.SingleOrDefault(pc => pc.Name == printerCompanyName);
                                    }
                                    PrinterModel printer = new PrinterModel
                                    {
                                        Name = printerName,
                                        AddedDate = DateTime.Now,
                                        ModifiedDate = DateTime.Now,
                                        PrinterCompanyId = printerCompany.Id
                                    };
                                    printerModelService.InsertPrinterModel(printer);
                                    printerModels.Add(printer);
                                    selectedPrinters.Add(printer);
                                }
                            }
                            foreach (var printer in selectedPrinters
                                .Where(p => !lcpm.Where(cpm => cpm.CartridgeModelId == cartridgeModel.Id)
                                    .Select(cpm => cpm.PrinterModelId).Contains(p.Id)))//Проверка на наличие такого
                            {
                                CartridgeModelPrinterModel cpm = new CartridgeModelPrinterModel
                                {
                                    PrinterModelId = printer.Id,
                                    CartridgeModelId = cartridgeModel.Id
                                };
                                cartridgeModelPrinterModelService.Insert(cpm);
                                lcpm.Add(cpm);
                            }
                        }
                    } while (true);
                }
                return RedirectToAction("Index");
            }
            return StatusCode(406);
            }
            return StatusCode(403);
        }

        [HttpPost]
        public IActionResult ReturnDBFile()
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                string path = _appEnvironment.WebRootPath + "/Files/DBUpdateFile.xlsx";
                string type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return PhysicalFile(path, type);
            }
            return StatusCode(403);
        }
    }
}