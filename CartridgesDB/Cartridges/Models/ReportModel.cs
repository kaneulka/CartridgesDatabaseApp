using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models
{
    public class ReportModel
    {
        public CartridgeModel Cartridge { get; set; }
        public PrinterModel Printer { get; set; }
        public List<Request> Requests { get; set; }
        [Display(Name = "Начальная дата")]
        public DateTime StartedRange { get; set; }
        [Display(Name = "Конечная дата")]
        public DateTime EndedRange { get; set; }
    }

    public class GlobalReportModel
    {
        public CartridgeModel Cartridge { get; set; }
        public List<PrinterModel> Printers { get; set; }
        public List<Request> Requests { get; set; }
    }
}
