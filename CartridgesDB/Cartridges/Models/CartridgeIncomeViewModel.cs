using Cartridges.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models
{
    public class CartridgeIncomeViewModel
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }
        [Display(Name = "Партия")]
        public string Name { get; set; }
        //[Remote(action: "CheckPosition", controller: "CartridgeIncome", ErrorMessage = "Не выбран картридж")]
        //[Required(ErrorMessage = "Не указано колличество картриджей")]
        [Display(Name = "Количество картриджей")]
        public long IncomeQuantity { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime AddedDate { get; set; }
        [Display(Name = "Дата изменения")]
        public DateTime ModifiedDate { get; set; }
        //[Required(ErrorMessage = "Не выбран картридж")]
        [Display(Name = "Картридж")]
        public long CartridgeModelId { get; set; }
        public CartridgeModelViewModel CartridgeModel { get; set; }
        public List<CartridgeModel> Cartridges { get; set; }
        public string CartridgeName { get; set; }


    }
}
