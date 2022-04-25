using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models
{
    public class BillViewModel
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }
        [Required(ErrorMessage = "Не указано сооружение")]
        [Display(Name = "Тип")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Номер счета")]
        [Display(Name = "Сооружение")]
        public int BillNumber { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime AddedDate { get; set; }
        [Display(Name = "Дата изменения")]
        public DateTime ModifiedDate { get; set; }
    }
}
