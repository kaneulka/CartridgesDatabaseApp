using Cartridges.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models
{
    public class CartridgeModelViewModel
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }
        [Required(ErrorMessage = "Не указана модель картриджа")]
        [Display(Name = "Модель картриджа")]
        public string Name { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime AddedDate { get; set; }
        [Display(Name = "Дата изменения")]
        public DateTime ModifiedDate { get; set; }
        [Required(ErrorMessage = "Не указано число картриджей")]
        [Display(Name = "Количество картриджей")]
        public long Quantity { get; set; }
        [Required(ErrorMessage = "Не указан инвентарный номер картриджа")]
        [Display(Name = "Номенклатурный номер картриджа")]
        public string NomenclatureNumber { get; set; }
        public string PrintersFullName { get; set; }

        public List<PrinterCompany> PrinterCompanies { get; set; }
        public List<PrinterModel> PrinterModels { get; set; }
        public List<long> CheckedPrinterModels { get; set; }

        //Принтер
        public long PrinterModelId { get; set; }
        public PrinterModelViewModel PrinterModel { get; set; }

        //Bill
        [Remote(action: "CheckBill", controller: "CartridgeModel", ErrorMessage = "Не выбран счет")]
        [Display(Name = "Номер счета")]
        public long BillId { get; set; }
        public BillViewModel Bill { get; set; }
        public List<Bill> Bills { get; set; }
        public string BillName { get; set; }
    }
}
