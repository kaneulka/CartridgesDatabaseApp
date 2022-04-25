using Cartridges.Data;
using Cartridges.Ser.CartridgeModelPrinterModelSer;
using Cartridges.Ser.CartridgeModelSer;
using Cartridges.Ser.PrinterCompanySer;
using Cartridges.Ser.PrinterModelSer;
using Cartridges.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Controllers
{
    public class PrinterController : Controller
    {
        private readonly ICartridgeModelService cartridgeModelService;
        private readonly ICartridgeModelPrinterModelService cartridgeModelPrinterModelService;
        private readonly IPrinterCompanyService printerCompanyService;
        private readonly IPrinterModelService printerModelService;
        public PrinterController(ICartridgeModelService cartridgeModelService,
            ICartridgeModelPrinterModelService cartridgeModelPrinterModelService,
            IPrinterCompanyService printerCompanyService, 
            IPrinterModelService printerModelService)
        {
            this.cartridgeModelService = cartridgeModelService;
            this.cartridgeModelPrinterModelService = cartridgeModelPrinterModelService;
            this.printerCompanyService = printerCompanyService;
            this.printerModelService = printerModelService;
        }

        //Printer Creators
        [HttpGet]
        public IActionResult PrinterCompanies(int? sortType = 0)
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                List<PrinterCompany> printerCompany = printerCompanyService.GetPrinterCompanies().ToList();
                switch (sortType)
                {
                    case 0:
                        printerCompany = printerCompany.OrderBy(e => e.Name).ToList();
                        break;
                    case 1:
                        printerCompany = printerCompany.OrderByDescending(e => e.Name).ToList();
                        break;

                }
                List<PrinterCompanyViewModel> lbvm = new List<PrinterCompanyViewModel>();
                foreach (var b in printerCompany)
                {
                    PrinterCompanyViewModel bvm = new PrinterCompanyViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        AddedDate = b.AddedDate,
                        ModifiedDate = b.ModifiedDate
                    };
                    lbvm.Add(bvm);
                }

                return View(lbvm);
            }
            return StatusCode(403);
        }

        [HttpGet]
        public IActionResult AddPrinterCompany()
        {
            if (User.IsInRole("admin"))
            {
                PrinterCompanyViewModel model = new PrinterCompanyViewModel();
                return PartialView("_AddPrinterCompany", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult AddPrinterCompany(PrinterCompanyViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                PrinterCompany printerCompanyEntity = new PrinterCompany
                {
                    Name = model.Name,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                if (ModelState.IsValid)
                {
                    printerCompanyService.InsertPrinterCompany(printerCompanyEntity);
                    if (printerCompanyEntity.Id > 0) return RedirectToAction("PrinterCompanies");
                }
                return PartialView("_AddPrinterCompany", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult EditPrinterCompany(long? id)
        {
            if (User.IsInRole("admin"))
            {
                PrinterCompanyViewModel model = new PrinterCompanyViewModel();
                if (id.HasValue && id != 0)
                {
                    PrinterCompany printerCompany = printerCompanyService.GetPrinterCompany((long)id);
                    model.Name = printerCompany.Name;
                }

                return PartialView("_EditPrinterCompany", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult EditPrinterCompany(PrinterCompanyViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                PrinterCompany printerCompanyEntity = printerCompanyService.GetPrinterCompany(model.Id);
                printerCompanyEntity.Name = model.Name;
                printerCompanyEntity.ModifiedDate = DateTime.Now;

                if (ModelState.IsValid)
                {
                    printerCompanyService.UpdatePrinterCompany(printerCompanyEntity);
                    if (printerCompanyEntity.Id > 0) return RedirectToAction("PrinterCompanies");
                }
                return PartialView("_EditPrinterCompany", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult DeletePrinterCompany(long? id)
        {
            if (User.IsInRole("admin"))
            {
                PrinterCompanyViewModel model = new PrinterCompanyViewModel();
                if (id.HasValue && id != 0)
                {
                    PrinterCompany printerCompany = printerCompanyService.GetPrinterCompany((long)id);
                    model.Name = printerCompany.Name;
                }
                return PartialView("_DeletePrinterCompany", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult DeletePrinterCompany(long id)
        {
            if (User.IsInRole("admin"))
            {
                printerCompanyService.DeletePrinterCompany(id);
                return RedirectToAction("PrinterCompanies");
            }
            else
            {
                return StatusCode(403);
            }
        }


        //Printer Models
        [HttpGet]
        public IActionResult PrinterModels(long printerCompanyId, int? sortType = 0)
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                List<PrinterModel> printerModels = new List<PrinterModel>();
                ViewBag.PrinterCompany = printerCompanyService.GetPrinterCompany(printerCompanyId);
                if (printerCompanyId > 0)
                {
                    printerModels = printerModelService.GetPrinterModels().Where(p => p.PrinterCompanyId == printerCompanyId).ToList();
                }
                else
                {
                    printerModels = printerModelService.GetPrinterModels().ToList();
                }
                switch (sortType)
                {
                    case 0:
                        printerModels = printerModels.OrderBy(e => e.Name).ToList();
                        break;
                    case 1:
                        printerModels = printerModels.OrderByDescending(e => e.Name).ToList();
                        break;

                }
                List<PrinterModelViewModel> lbvm = new List<PrinterModelViewModel>();
                foreach (var b in printerModels)
                {
                    PrinterModelViewModel bvm = new PrinterModelViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        AddedDate = b.AddedDate,
                        ModifiedDate = b.ModifiedDate,
                        PrinterCompanyName = b.PrinterCompany.Name
                    };
                    lbvm.Add(bvm);
                }

                return View(lbvm);
            }
            return StatusCode(403);
        }

        [HttpGet]
        public IActionResult AddPrinterModel(long printerCompanyId)
        {
            if (User.IsInRole("admin"))
            {
                PrinterModelViewModel model = new PrinterModelViewModel();
                model.PrinterCompanyId = printerCompanyId;
                if (cartridgeModelService.CheckCartridgeModelsExist())
                {
                    model.CartridgeModels = cartridgeModelService.GetCartridgeModels().ToList();
                }
                return PartialView("_AddPrinterModel", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult AddPrinterModel(PrinterModelViewModel model, List<long> cartridgeModelIds)
        {
            if (User.IsInRole("admin"))
            {
                PrinterModel printerModelEntity = new PrinterModel
                {
                    Name = model.Name,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    PrinterCompanyId = model.PrinterCompanyId
                };
                if (ModelState.IsValid)
                {
                    printerModelService.InsertPrinterModel(printerModelEntity);
                    if (printerModelEntity.Id > 0)
                    {
                        if (cartridgeModelIds.Count>0)
                        {
                            List<CartridgeModelPrinterModel> lcmpm = new List<CartridgeModelPrinterModel>();
                            foreach(var cmi in cartridgeModelIds)
                            {
                                lcmpm.Add(new CartridgeModelPrinterModel { PrinterModelId = printerModelEntity.Id, CartridgeModelId = cmi });
                            }
                            cartridgeModelPrinterModelService.InsertSome(lcmpm);
                        }
                        return RedirectToAction("PrinterModels", new { printerCompanyId = printerModelEntity.PrinterCompanyId });
                    }
                }
                return PartialView("_AddPrinterModel", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult EditPrinterModel(long? id)
        {
            if (User.IsInRole("admin"))
            {
                PrinterModelViewModel model = new PrinterModelViewModel();
                if (id.HasValue && id != 0)
                {
                    PrinterModel printerModel = printerModelService.GetPrinterModel((long)id);
                    model.Name = printerModel.Name;
                    if (cartridgeModelPrinterModelService.IsExist(0, printerModel.Id))
                    {
                        model.CheckedCartridgeModels = cartridgeModelPrinterModelService.GetAll().Where(cpm => cpm.PrinterModelId == printerModel.Id).Select(cpm=> cpm.CartridgeModelId).ToList();
                    }
                    if (cartridgeModelService.CheckCartridgeModelsExist())
                    {
                        model.CartridgeModels = cartridgeModelService.GetCartridgeModels().ToList();
                    }
                }

                return PartialView("_EditPrinterModel", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult EditPrinterModel(PrinterModelViewModel model, List<long> cartridgeModelIds)
        {
            if (User.IsInRole("admin"))
            {
                PrinterModel printerModelEntity = printerModelService.GetPrinterModel(model.Id);
                printerModelEntity.Name = model.Name;
                printerModelEntity.ModifiedDate = DateTime.Now;

                if (ModelState.IsValid)
                {
                    printerModelService.UpdatePrinterModel(printerModelEntity);
                    if (cartridgeModelIds.Count() > 0)
                    {
                        List<CartridgeModelPrinterModel> lcpm = cartridgeModelPrinterModelService.GetAll().Where(cpm => cpm.PrinterModelId == printerModelEntity.Id).ToList();
                        if (lcpm.Count() > 0) cartridgeModelPrinterModelService.DeleteSome(lcpm);
                        List<CartridgeModelPrinterModel> lcpmToAdd = new List<CartridgeModelPrinterModel>();
                        foreach (var cpi in cartridgeModelIds) lcpmToAdd.Add(new CartridgeModelPrinterModel { PrinterModelId = printerModelEntity.Id, CartridgeModelId = cpi });
                        cartridgeModelPrinterModelService.InsertSome(lcpmToAdd);
                    }
                    if (printerModelEntity.Id > 0) return RedirectToAction("PrinterModels", new { printerCompanyId = printerModelEntity.PrinterCompanyId });
                }
                return PartialView("_EditPrinterModel", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult DeletePrinterModel(long? id)
        {
            if (User.IsInRole("admin"))
            {
                PrinterModelViewModel model = new PrinterModelViewModel();
                if (id.HasValue && id != 0)
                {
                    PrinterModel printerModel = printerModelService.GetPrinterModel((long)id);
                    model.Name = printerModel.Name;
                }
                return PartialView("_DeletePrinterModel", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult DeletePrinterModel(long id)
        {
            if (User.IsInRole("admin"))
            {
                PrinterModel pm = printerModelService.GetPrinterModel(id);
                long printerCompanyId = pm.PrinterCompanyId;
                printerModelService.DeletePrinterModel(pm.Id);
                return RedirectToAction("PrinterModels", new { printerCompanyId });
            }
            else
            {
                return StatusCode(403);
            }
        }
    }
}
