using Cartridges.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models
{
    public class RequestViewModel
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime AddedDate { get; set; }
        [Display(Name = "Дата изменения")]
        public DateTime ModifiedDate { get; set; }
        [Remote(action: "CheckPosition", controller: "Request", ErrorMessage = "Не выбран картридж")]
        [Display(Name = "Картридж")]
        public long CartridgeModelId { get; set; }
        public CartridgeModelViewModel CartridgeModel { get; set; }
        [Remote(action: "CheckPosition", controller: "Request", ErrorMessage = "Не выбрано сооружение")]
        [Display(Name = "Сооружение")]
        public long BuildingId { get; set; }
        public BuildingViewModel Building { get; set; }
        [Remote(action: "CheckPosition", controller: "Request", ErrorMessage = "Не выбран отдел")]
        [Display(Name = "Отдел")]
        public long DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }
        [Required(ErrorMessage = "Не введено помещение")]
        [Display(Name = "Номер помещения")]
        public string Room { get; set; }
        [Required(ErrorMessage = "Не ввден инвентарный номер принтера")]
        [Display(Name = "Инвентарный номер принтера")]
        public string InventoryNumber { get; set; }
        [Remote(action: "CheckPosition", controller: "Request", ErrorMessage = "Не выбран принтер")]
        [Display(Name = "Принтер")]
        public long PrinterModelId { get; set; }

        public List<CartridgeModel> Cartridges { get; set; }
        public List<PrinterModel> Printers { get; set; }
        public List<Department> Departments { get; set; }
        public List<Building> Buildings { get; set; }
        public List<CartridgeModelPrinterModel> CPM { get; set; }
        public string CartridgeModelName { get; set; }
        public string PrinterModelName { get; set; }
        public string DepartmentName { get; set; }
        public string BuildingName { get; set; }
        public string CartridgeNomNum { get; set; }
        public bool Defective { get; set; }
    }
}
