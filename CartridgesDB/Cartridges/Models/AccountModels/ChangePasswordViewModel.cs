using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models.AccountModels
{
    public class ChangePasswordViewModel
    {
        [HiddenInput]
        public string Id { get; set; }
        [Display(Name = "Пользователь")]
        public string UserName { get; set; }
        [Display(Name = "Новый пароль")]
        [Required(ErrorMessage = "Не указан пароль")]
        [Remote(action: "CheckPassword", controller: "Account", ErrorMessage = "Пароль должен соcтоять из заглавных и строчных латинских символов, цифр и содержать хотя бы один знак. Длина пароля должна быть не менее 6.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
