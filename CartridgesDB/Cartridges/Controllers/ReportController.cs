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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportController : Controller
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        private readonly ICartridgeModelService cartridgeModelService;
        private readonly ICartridgeModelPrinterModelService cartridgeModelPrinterModelService;
        private readonly IPrinterModelService printerModelService;
        private readonly IRequestService requestService;

        public ReportController(ICartridgeModelService cartridgeModelService,
            IPrinterModelService printerModelService,
            ICartridgeModelPrinterModelService cartridgeModelPrinterModelService,
            IRequestService requestService)
        {
            this.cartridgeModelService = cartridgeModelService;
            this.printerModelService = printerModelService;
            this.cartridgeModelPrinterModelService = cartridgeModelPrinterModelService;
            this.requestService = requestService;
        }
        public IActionResult Index()
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                return View();
            }
            else return StatusCode(403);
        }

        [HttpPost]
        public IActionResult DatabaseReport(ReportModel rangeDates)
        {
            if (User.IsInRole("admin"))
            {
                var dataTable = new DataTable("CartridgeReport");
                dataTable.Columns.Add("Модель картриджа", typeof(string));
                dataTable.Columns.Add("Номенклатурный номер картриджа", typeof(int));
                dataTable.Columns.Add("Модель принтера", typeof(string));
                dataTable.Columns.Add("Колличество служебок", typeof(int));
                List<Request> requests = requestService.GetRequests().Where(r => r.AddedDate >= rangeDates.StartedRange && r.AddedDate <= rangeDates.EndedRange).ToList();
                List<CartridgeModel> cartridges = cartridgeModelService.GetCartridgeModels().Where(c => requests.Select(r => r.CartridgeModelId).Contains(c.Id)).ToList();
                List<PrinterModel> printers = printerModelService.GetPrinterModels().Where(p => requests.Select(r => r.PrinterModelId).Contains(p.Id)).ToList();
                List<ReportModel> reports = new List<ReportModel>();

                foreach (var request in requests)
                {
                    if (reports.Where(r => r.Cartridge.Id == request.CartridgeModelId
                        && r.Printer.Id == request.PrinterModelId)
                        .ToList().Count > 0)
                    {
                        ReportModel report = reports.SingleOrDefault(r => r.Cartridge.Id == request.CartridgeModelId && r.Printer.Id == request.PrinterModelId);
                        int index = reports.IndexOf(report);
                        reports[index].Requests.Add(request);
                    }
                    else
                    {
                        ReportModel report = new ReportModel
                        {
                            Cartridge = cartridges.SingleOrDefault(c => c.Id == request.CartridgeModelId),
                            Printer = printers.SingleOrDefault(p => p.Id == request.PrinterModelId)
                        };
                        report.Requests = new List<Request>();
                        report.Requests.Add(request);
                        reports.Add(report);
                    }
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Report " + rangeDates.StartedRange + "-" + rangeDates.EndedRange);
                    worksheet.Cells["A1"].LoadFromDataTable(dataTable, PrintHeaders: true);
                    var i = 1;
                    foreach (var report in reports)
                    {
                        i++;
                        worksheet.Cells[i, 1].Value = report.Cartridge.Name + " " + report.Cartridge.Bill.Name;
                        worksheet.Cells[i, 2].Value = report.Cartridge.NomenclatureNumber;
                        worksheet.Cells[i, 3].Value = report.Printer.PrinterCompany.Name + " " + report.Printer.Name;
                        worksheet.Cells[i, 4].Value = report.Requests.Count;
                    }
                    return File(package.GetAsByteArray(), XlsxContentType, DateTime.Now + " report.xlsx");
                }
            }
            return StatusCode(403);
        }

        [HttpPost]
        public IActionResult DatabaseReportForLastMonth()
        {
            if (User.IsInRole("admin"))
            {
                var timeRange = new ReportModel { EndedRange = DateTime.Now, StartedRange = DateTime.Now.AddMonths(-1) };
                return DatabaseReport(timeRange);
            }
            return StatusCode(403);
        }
        [HttpPost]
        public IActionResult DatabaseReportForLastYear()
        {
            if (User.IsInRole("admin"))
            {
                var timeRange = new ReportModel { EndedRange = DateTime.Now, StartedRange = DateTime.Now.AddYears(-1) };
                return DatabaseReport(timeRange);
            }
            return StatusCode(403);
        }


        [HttpPost]
        public IActionResult GlobalDatabaseReport()
        {
            if (User.IsInRole("admin") )
            {
                var dataTable = new DataTable("CartridgeReport");
            dataTable.Columns.Add("Модель картриджа", typeof(string));
            dataTable.Columns.Add("Номенклатурный номер картриджа", typeof(int));
            dataTable.Columns.Add("Модели принтеров", typeof(string));
            dataTable.Columns.Add("Колличество картриджей", typeof(int));
            dataTable.Columns.Add("Колличество служебок", typeof(int));
            List<Request> requests = requestService.GetRequests().ToList();
            List<CartridgeModel> cartridges = cartridgeModelService.GetCartridgeModels().ToList();
            List<PrinterModel> printers = printerModelService.GetPrinterModels().ToList();
            List<CartridgeModelPrinterModel> lcpm = cartridgeModelPrinterModelService.GetAll().ToList();
            List<GlobalReportModel> reports = new List<GlobalReportModel>();

            foreach (var cartridge in cartridges)
            {
                GlobalReportModel report = new GlobalReportModel
                {
                    Cartridge = cartridge,
                    Printers = printers.Where(p => lcpm.Where(cpm => cpm.CartridgeModelId == cartridge.Id).Select(cpm => cpm.PrinterModelId).Contains(p.Id)).ToList(),
                    Requests = requests.Where(r=> r.CartridgeModelId == cartridge.Id).ToList()
                };
                reports.Add(report);
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Global Report ");
                worksheet.Cells["A1"].LoadFromDataTable(dataTable, PrintHeaders: true);
                var i = 1;
                foreach (var report in reports)
                {
                    i++;
                    string printersName = "";
                    report.Printers.ForEach(p => printersName += p.PrinterCompany.Name + " " + p.Name);
                    worksheet.Cells[i, 1].Value = report.Cartridge.Name + " " + report.Cartridge.Bill.Name;
                    worksheet.Cells[i, 2].Value = report.Cartridge.NomenclatureNumber;
                    worksheet.Cells[i, 3].Value = printersName;
                    worksheet.Cells[i, 4].Value = report.Cartridge.Quantity;
                    worksheet.Cells[i, 5].Value = report.Requests.Count;
                }
                return File(package.GetAsByteArray(), XlsxContentType, DateTime.Now + " global report.xlsx");
            }
            }
            return StatusCode(403);
        }
    }
}
