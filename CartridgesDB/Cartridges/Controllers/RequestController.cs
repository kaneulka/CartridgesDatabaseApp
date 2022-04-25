using Cartridges.Data;
using Cartridges.Ser.BillSer;
using Cartridges.Ser.BuildingSer;
using Cartridges.Ser.CartridgeModelPrinterModelSer;
using Cartridges.Ser.CartridgeModelSer;
using Cartridges.Ser.DepartmentSer;
using Cartridges.Ser.PrinterCompanySer;
using Cartridges.Ser.PrinterModelSer;
using Cartridges.Ser.RequestSer;
using Cartridges.Web.Models;
using Cartridges.Web.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Word;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Cartridges.Web.Controllers
{
    public class RequestController : Controller
    {
        private readonly ICartridgeModelService cartridgeModelService;
        private readonly ICartridgeModelPrinterModelService cartridgeModelPrinterModelService;
        private readonly IPrinterModelService printerModelService;
        private readonly IBillService billService;
        private readonly IRequestService requestService;
        private readonly IDepartmentService departmentService;
        private readonly IBuildingService buildingService;
        IWebHostEnvironment _appEnvironment;

        public RequestController(ICartridgeModelService cartridgeModelService,
            IPrinterCompanyService printerCompanyService,
            IPrinterModelService printerModelService,
            ICartridgeModelPrinterModelService cartridgeModelPrinterModelService,
            IBillService billService,
            IRequestService requestService,
            IDepartmentService departmentService,
            IWebHostEnvironment appEnvironment,
            IBuildingService buildingService)
        {
            this.cartridgeModelService = cartridgeModelService;
            this.printerModelService = printerModelService;
            this.cartridgeModelPrinterModelService = cartridgeModelPrinterModelService;
            this.billService = billService;
            this.requestService = requestService;
            this.departmentService = departmentService;
            this.buildingService = buildingService;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public IActionResult Requests(int page = 1, int sortType = 0, string searchString = null, string failedDocxs = "")
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                IEnumerable<Request> requests;
                if (searchString == null)
                {
                    requests = requestService.GetRequests();
                }
                else
                {
                    searchString = searchString.ToUpper();
                    requests = requestService.GetRequests().Where(s => s.Name.ToUpper().Contains(searchString)
                        || s.Department.Name.ToString().ToUpper().Contains(searchString)
                        || s.AddedDate.ToString().ToUpper().Contains(searchString)
                        || s.Building.Name.ToString().ToUpper().Contains(searchString)
                        || s.CartridgeModel.Name.ToString().ToUpper().Contains(searchString)
                        || s.PrinterModel.Name.ToString().ToUpper().Contains(searchString)
                        || s.PrinterModel.PrinterCompany.Name.ToString().ToUpper().Contains(searchString)
                    );
                }

                switch (sortType)
                {
                    case 0:
                        requests = requests.OrderByDescending(b => b.AddedDate);
                        break;
                    case 1:
                        requests = requests.OrderBy(b => b.AddedDate);
                        break;
                    case 2:
                        requests = requests.OrderByDescending(b => b.ModifiedDate);
                        break;
                    case 3:
                        requests = requests.OrderBy(b => b.ModifiedDate);
                        break;
                    case 4:
                        requests = requests.OrderBy(b => b.Name);
                        break;
                    case 5:
                        requests = requests.OrderByDescending(b => b.Name);
                        break;
                }
                ViewBag.SortType = sortType;

                int pageSize = 20;

                List<RequestViewModel> listRequests = new List<RequestViewModel>();

                var count = requests.Count();
                var items = requests.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                items.ForEach(u =>
                {
                    RequestViewModel request = new RequestViewModel
                    {
                        Id = u.Id,
                        Name = u.Name,
                        AddedDate = u.AddedDate,
                        ModifiedDate = u.ModifiedDate,
                        InventoryNumber = u.InventoryNumber,
                        CartridgeModelName = u.CartridgeModel.Name,
                        PrinterModelName = u.PrinterModel.PrinterCompany.Name + " " + u.PrinterModel.Name,
                        DepartmentName = u.Department.Name,
                        BuildingName = u.Building.Name,
                        Room = u.Room,
                        Defective = u.Defective
                    };
                    listRequests.Add(request);
                });

                List<string> failedDocxRequests = new List<string>();
                if (failedDocxs != "")
                {
                    failedDocxRequests = failedDocxs.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }


                RequestsViewModel viewModel = new RequestsViewModel
                {
                    PageViewModel = pageViewModel,
                    Requests = listRequests,
                    FailedUploadingDocxs = failedDocxRequests,
                };

                ViewBag.SortType = sortType;
                ViewBag.Page = page;
                ViewBag.SearchString = searchString;
                return View(viewModel);
            }
            else return StatusCode(403);
        }

        [HttpGet]
        public IActionResult AddRequest()
        {
            if (User.IsInRole("admin"))
            {
                RequestViewModel model = new RequestViewModel();
                model.CPM = cartridgeModelPrinterModelService.GetAll().ToList();
                model.Printers = printerModelService.GetPrinterModels().Where(p => model.CPM.Select(cp => cp.PrinterModelId).Contains(p.Id)).OrderBy(cp=> cp.PrinterCompany.Name).ToList();
                model.Departments = departmentService.GetDepartments().OrderBy(d => d.Name).ToList();
                model.Buildings = buildingService.GetBuildings().OrderBy(d => d.Name).ToList();
                return PartialView("_AddRequest", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        public JsonResult GetCartridges(long printerId)
        {
            if (User.IsInRole("admin"))
            {
                List<CartridgeModelPrinterModel> lcpm = cartridgeModelPrinterModelService.GetAll().Where(cp => cp.PrinterModelId == printerId).ToList();
                List<CartridgeModel> cartridges = cartridgeModelService.GetCartridgeModels().Where(c => lcpm.Select(cp => cp.CartridgeModelId).Contains(c.Id) && c.Quantity > 0).ToList();
                List<CartridgeModelViewModel> cartridgesToReturn = new List<CartridgeModelViewModel>();
                foreach(var cartridge in cartridges)
                {
                    CartridgeModelViewModel cmvm = new CartridgeModelViewModel
                    {
                        Id = cartridge.Id,
                        Name = cartridge.Name,
                        BillName = cartridge.Bill.BillNumber + "-" + cartridge.Bill.Name
                    };
                    cartridgesToReturn.Add(cmvm);
                }
                return Json(cartridgesToReturn, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic) });
            }
            else
            {
                return Json("403 - Forbidden");
            }
            
        }

        [HttpPost]
        public IActionResult AddRequest(RequestViewModel model, long cartridgeId, long printerId)
        {
            if (User.IsInRole("admin"))
            {
                Request requestEntity = new Request
                {
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    BuildingId = model.BuildingId,
                    DepartmentId = model.DepartmentId,
                    Room = model.Room,
                    InventoryNumber = model.InventoryNumber,
                    PrinterModelId = model.PrinterModelId,
                    CartridgeModelId = model.CartridgeModelId,
                    Defective = false
                };
                PrinterModel printer = printerModelService.GetPrinterModel(model.PrinterModelId);
                string printerModelName = printer.PrinterCompany.Name + " " + printer.Name;
                string departmentName = departmentService.GetDepartment(model.DepartmentId).Name;
                string buildingName = buildingService.GetBuilding(model.BuildingId).Name;
                string billName = cartridgeModelService.GetCartridgeModel(model.CartridgeModelId).Bill.Name;
                requestEntity.Name = printerModelName + " " + departmentName + "-" + buildingName + "-" + model.Room + " " + billName;
                if (ModelState.IsValid)
                {
                    requestService.InsertRequest(requestEntity);
                    CartridgeModel cartridge = cartridgeModelService.GetCartridgeModel(requestEntity.CartridgeModelId);
                    cartridge.Quantity--;
                    cartridgeModelService.UpdateCartridgeModel(cartridge);
                    if (requestEntity.Id > 0) return RedirectToAction("Requests");
                }
                return PartialView("_AddRequest", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult DeleteRequest(long? id)
        {
            if (User.IsInRole("admin"))
            {
                RequestViewModel model = new RequestViewModel();
                if (id.HasValue && id != 0)
                {
                    Request request = requestService.GetRequest((long)id);
                    model.Name = request.Name;
                    model.AddedDate = request.AddedDate;
                }
                return PartialView("_DeleteRequest", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult DeleteRequest(long id)
        {
            if (User.IsInRole("admin"))
            {
                Request request = requestService.GetRequest(id);
                CartridgeModel cartridge = cartridgeModelService.GetCartridgeModel(request.CartridgeModelId);
                cartridge.Quantity++;
                cartridgeModelService.UpdateCartridgeModel(cartridge);
                requestService.DeleteRequest(id);
                return RedirectToAction("Requests");
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult RequestInfo(long? id)
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                RequestViewModel model = new RequestViewModel();
                if (id.HasValue && id != 0)
                {
                    Request request = requestService.GetRequest((long)id);
                    model.Name = request.Name;
                    model.AddedDate = request.AddedDate;
                    model.BuildingName = buildingService.GetBuilding(request.BuildingId).Name;
                    CartridgeModel cartridge = cartridgeModelService.GetCartridgeModel(request.CartridgeModelId);
                    model.CartridgeModelName = cartridge.Name;
                    model.CartridgeNomNum = cartridge.NomenclatureNumber + " " + cartridge.Bill.Name + "-" + cartridge.Bill.BillNumber;
                    model.Room = request.Room;
                    model.DepartmentName = request.Department.Name;
                    PrinterModel printer = printerModelService.GetPrinterModel(request.PrinterModelId);
                    model.PrinterModelName = printer.PrinterCompany.Name + " " + printer.Name;
                    model.InventoryNumber = request.InventoryNumber;
                    model.Defective = request.Defective;
                }
                else return StatusCode(400);
                return PartialView("_RequestInfo", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromDocs(IFormFileCollection uploadedFiles, bool isBill102 = false)
        {
            if (User.IsInRole("admin"))
            {
                List<Building> buildings = buildingService.GetBuildings().ToList();
                List<Department> departments = departmentService.GetDepartments().ToList();
                List<PrinterModel> printers = printerModelService.GetPrinterModels().ToList(); 
                Bill bill = isBill102 ? billService.GetBills().SingleOrDefault(b => b.BillNumber == 102) : billService.GetBills().SingleOrDefault(b => b.BillNumber == 105);
                List<CartridgeModel> cartridges = cartridgeModelService.GetCartridgeModels().Where(c=> c.BillId == bill.Id).ToList();
                List<CartridgeModelPrinterModel> CPM = cartridgeModelPrinterModelService.GetAll().Where(cpm=> cartridges.Select(c=> c.Id).Contains(cpm.CartridgeModelId)).ToList();
                List<string> failedRequests = new List<string>();
                List<CartridgeModel> cartridgesToUpdate = new List<CartridgeModel>();

                foreach (var uploadedFile in uploadedFiles)
                {
                    if (uploadedFile != null)
                    {
                        string path = _appEnvironment.WebRootPath + "/Files/RequestDoc";
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                        using (var stream = new FileStream(path, FileMode.Open))
                        {
                            XWPFDocument doc = new XWPFDocument(stream);
                            string docText = "";
                            for(var i = 0; i < doc.Paragraphs.Count(); i++)
                            {
                                docText += doc.Paragraphs[i].ParagraphText.ToString() + " ";
                            }
                            List<string> wordElemsOfDoc = new List<string>();
                            List<string> wordElemsOfDocBeforeTrim = docText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            RequestViewModel requestViewModel = new RequestViewModel();
                            string buildingName = "";
                            string roomName = "";
                            string departmentName = "";
                            string inventorNumber = "";
                            PrinterModel printer = new PrinterModel();

                            foreach(var w in wordElemsOfDocBeforeTrim)
                            {
                                wordElemsOfDoc.Add(w.Trim(new char[] { '.', ',', ':', '\n' , '\t', '(', ')'}));
                            }

                            //Отдел
                            if (wordElemsOfDoc.IndexOf("отдела") > 0)
                            {
                                departmentName = wordElemsOfDoc[wordElemsOfDoc.LastIndexOf("отдела") - 1];
                            }
                            else
                            {
                                int index = wordElemsOfDoc.IndexOf("отдела");
                                departmentName = !wordElemsOfDoc[index - 1].Contains("начальник") ? wordElemsOfDoc[index - 1] : wordElemsOfDoc[index + 1];
                            }

                            if (departmentName == "5")
                            {
                                departmentName = wordElemsOfDoc[wordElemsOfDoc.LastIndexOf("отделения") - 1];
                            }


                            //Building - room
                            int roomPrevIndex = wordElemsOfDoc.IndexOf("помещении") > 0 ? wordElemsOfDoc.IndexOf("помещении") : wordElemsOfDoc.IndexOf("пом");
                            roomName = wordElemsOfDoc[roomPrevIndex + 1].Contains("№") ? wordElemsOfDoc[roomPrevIndex + 2] : wordElemsOfDoc[roomPrevIndex + 1];
                            int buildingIndex = wordElemsOfDoc.IndexOf(roomName);
                            buildingName = wordElemsOfDoc[buildingIndex + 1].Contains("соор") ? wordElemsOfDoc[buildingIndex + 2] : wordElemsOfDoc[buildingIndex + 1]; //убрал "ужения"

                            //InvenNum & Printer
                            int invIndex = wordElemsOfDoc.IndexOf("инвентарный") > 0 ? wordElemsOfDoc.IndexOf("инвентарный") : -1;// wordElemsOfDoc.IndexOf("инв" );
                            invIndex = wordElemsOfDoc.IndexOf("инв") > 0 ? wordElemsOfDoc.IndexOf("инв") : wordElemsOfDoc.IndexOf("инв.");
                            if (wordElemsOfDoc[invIndex + 1].Contains("№"))
                            {
                                if (wordElemsOfDoc[invIndex + 2].Contains("устройства"))
                                {
                                    inventorNumber = wordElemsOfDoc[invIndex + 3];
                                }
                                else
                                {
                                    inventorNumber = wordElemsOfDoc[invIndex + 2];
                                }
                            }
                            else
                            {
                                inventorNumber = wordElemsOfDoc[invIndex + 1];
                            }
                            string fst = wordElemsOfDoc[invIndex - 4] + " " + wordElemsOfDoc[invIndex - 3] + " " + wordElemsOfDoc[invIndex - 2] + " " + wordElemsOfDoc[invIndex - 1];
                            foreach(var p in printers)
                            {
                                if (fst.Contains(p.Name))
                                {
                                    printer = p;
                                    continue;
                                }
                            }
                            if(cartridges.Where(c => CPM.Where(cp=> cp.CartridgeModelId == c.Id).Select(cp=> cp.PrinterModelId).Contains(printer.Id)).Count() == 0)
                            {
                                failedRequests.Add(uploadedFile.FileName);
                                continue;
                            }
                            CartridgeModel cartridge = cartridges.SingleOrDefault(c => CPM.FirstOrDefault(cp => cp.PrinterModelId == printer.Id).CartridgeModelId == c.Id);
                            if (cartridge.Quantity == 0)
                            {
                                failedRequests.Add(uploadedFile.FileName);
                                continue;
                            }
                            else
                            {
                                cartridges.Remove(cartridge);
                            }
                            requestViewModel.InventoryNumber = inventorNumber;
                            requestViewModel.AddedDate = DateTime.Now;
                            requestViewModel.ModifiedDate = DateTime.Now;
                            requestViewModel.CartridgeModelId = cartridge.Id;
                            requestViewModel.PrinterModelId = printer.Id;
                            Building building = buildings.SingleOrDefault(b => (b.Name + " " + b.OtherNames).ToUpper().Contains(buildingName.ToUpper()));  //.SingleOrDefault(b => b.Name.ToUpper() == buildingName.ToUpper() || b.OtherNames.ToUpper().Contains(buildingName.ToUpper()));
                            requestViewModel.BuildingId = building.Id;
                            requestViewModel.Room = roomName;
                            Department department = departments.SingleOrDefault(b => (b.Name + " " + b.OtherNames).ToUpper().Contains(departmentName.ToUpper()));  //.SingleOrDefault(b => b.Name.ToUpper() == departmentName.ToUpper() || b.OtherNames.ToUpper().Contains(departmentName.ToUpper()));
                            requestViewModel.DepartmentId = department.Id;
                            requestViewModel.Name = printer.PrinterCompany.Name + " " + printer.Name + " " + department.Name + "-" + building.Name + "-" + requestViewModel.Room + " " + cartridge.Bill.Name;
                            if(TryValidateModel(requestViewModel))
                            {
                                Request requestEntity = new Request
                                {
                                    Name = requestViewModel.Name,
                                    AddedDate = requestViewModel.AddedDate,
                                    ModifiedDate = requestViewModel.ModifiedDate,
                                    BuildingId = requestViewModel.BuildingId,
                                    DepartmentId = requestViewModel.DepartmentId,
                                    Room = requestViewModel.Room,
                                    InventoryNumber = requestViewModel.InventoryNumber,
                                    PrinterModelId = requestViewModel.PrinterModelId,
                                    CartridgeModelId = requestViewModel.CartridgeModelId,
                                    Defective = false
                                };
                                requestService.InsertRequest(requestEntity);
                                if (cartridgesToUpdate.Select(c=> c.Id).Contains(cartridge.Id))
                                {
                                    cartridgesToUpdate.SingleOrDefault(c => c.Id == cartridge.Id).Quantity--;
                                    cartridge.Quantity--;
                                }
                                else
                                {
                                    cartridge.Quantity--;
                                    cartridgesToUpdate.Add(cartridge);
                                }
                                cartridges.Add(cartridge);
                            }
                        }
                        cartridgeModelService.UpdateCartridgeModels(cartridgesToUpdate);
                    }
                }
                string failedDocxs = "";
                foreach (var d in failedRequests)
                {
                    failedDocxs += d + ";";
                }
                return RedirectToAction("Requests", "Request", new { failedDocxs = failedDocxs });
            }
            else
            {
                return StatusCode(403);
            }
        }


        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckPosition(long PrinterModelId, 
            long DepartmentId,
            long BuildingId,
            long CartridgeModelId
            )
        {
            List<long> allParams = new List<long>();
            allParams.AddRange(new List<long> { PrinterModelId, DepartmentId, BuildingId, CartridgeModelId });
            long param = allParams.SingleOrDefault(p => p != 0);
            if (param == 0)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        } 
        
        [HttpPost]
        public IActionResult SwitchDefectiveValue(long requestId, int page = 1, int sortType = 0, string searchString = null)
        {
            Request request = requestService.GetRequests().SingleOrDefault(r => r.Id == requestId);
            if (request.Defective == null)
            {
                request.Defective = true;
            }
            else
            {
                request.Defective = !request.Defective;
            }
            requestService.UpdateRequest(request);
            return RedirectToAction("Requests", "Request", new { searchString, page, sortType });
        }
        [HttpPost]
        public IActionResult Copy(long requestId, int page = 1, int sortType = 0, string searchString = null)
        {
            Request oldRequest = requestService.GetRequests().SingleOrDefault(r => r.Id == requestId);
            CartridgeModel cartridge = cartridgeModelService.GetCartridgeModel(oldRequest.CartridgeModelId);
            if (cartridge.Quantity != 0)
            {
                Request newRequest = new Request()
                {
                    AddedDate = oldRequest.AddedDate,
                    ModifiedDate = oldRequest.ModifiedDate,
                    BuildingId = oldRequest.BuildingId,
                    DepartmentId = oldRequest.DepartmentId,
                    Room = oldRequest.Room,
                    InventoryNumber = oldRequest.InventoryNumber,
                    PrinterModelId = oldRequest.PrinterModelId,
                    CartridgeModelId = oldRequest.CartridgeModelId,
                    Defective = false,
                    Name = oldRequest.Name
                };
                requestService.InsertRequest(newRequest);
                cartridge.Quantity--;
                cartridgeModelService.UpdateCartridgeModel(cartridge);
            }
            return RedirectToAction("Requests", "Request", new { searchString, page, sortType });
        }
    }
}
