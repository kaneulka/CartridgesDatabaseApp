using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models.AccountModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Логин должен быть не короче 3 символов")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [Remote(action: "CheckPassword", controller: "Account", ErrorMessage = "Пароль должен соcтоять из заглавных и строчных латинских символов, цифр и содержать хотя бы один знак. Длина пароля должна быть не менее 6.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
