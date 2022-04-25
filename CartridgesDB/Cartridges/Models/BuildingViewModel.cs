using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models
{
    public class BuildingViewModel
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }
        [Required(ErrorMessage ="Не указано сооружение")]
        [Display(Name = "Сооружение")]
        public string Name { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime AddedDate { get; set; }
        [Display(Name = "Дата изменения")]
        public DateTime ModifiedDate { get; set; }
        [Display(Name = "Другие названия")]
        public string OtherNames { get; set; }
    }
}
