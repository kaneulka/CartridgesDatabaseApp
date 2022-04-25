using Cartridges.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models
{
    public class PrinterModelViewModel
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }
        [Required(ErrorMessage = "Не указана модель принтера")]
        [Display(Name = "Модель принтера")]
        public string Name { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime AddedDate { get; set; }
        [Display(Name = "Дата изменения")]
        public DateTime ModifiedDate { get; set; }

        //Printer Company
        public string PrinterCompanyName { get; set; }
        public long PrinterCompanyId { get; set; }
        public List<CartridgeModel> CartridgeModels { get; set; }
        public List<long> CheckedCartridgeModels { get; set; }
    }
}
