using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models.AccountModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [Display(Name = "Логин")]
        [Remote(action: "CheckLoginNotConfirmOrNotExist", controller: "Account", ErrorMessage = "Пользователь не существует")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
