using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models
{
    public class DepartmentViewModel
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }
        [Required(ErrorMessage = "Не указан отдел")]
        [Display(Name = "Отдел")]
        public string Name { get; set; }
        [Display(Name = "Другие имена")]
        public string OtherNames { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime AddedDate { get; set; }
        [Display(Name = "Дата изменения")]
        public DateTime ModifiedDate { get; set; }
    }
}
