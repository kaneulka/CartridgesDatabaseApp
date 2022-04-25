using Cartridges.Data;
using Cartridges.Web.Models.AccountModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cartridges.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckLogin(string userName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userName);

            return Json(user == null ? true : false);
        }
        public IActionResult CheckLoginNotConfirmOrNotExist(string userName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userName);

            if (user == null) return Json(false);

            return Json(user.EmailConfirmed == true ? true : false);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckPassword(string password)
        {
            bool checkedPwd = true;

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");

            MatchCollection matches = regex.Matches(password);

            if (matches.Count <= 0)
            {
                checkedPwd = false;
            }

            return Json(checkedPwd);
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.IsInRole("admin"))
            {
                RegisterViewModel model = new RegisterViewModel();
                return PartialView("_Register", model);
            }
            else
            {
                return StatusCode(403);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        Email = model.UserName + "@cartridges.coi",
                        UserName = model.UserName,
                        EmailConfirmed = true,
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Action(
                            "ConfirmEmail",
                            "Account",
                            new { userId = user.Id, code },
                            protocol: HttpContext.Request.Scheme
                            );
                        await _userManager.AddToRoleAsync(user, "user");
                        
                        return RedirectToAction("Users");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                return View("_Register", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return PartialView("_Login", model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RememberMe = true;

                var user = await _userManager.FindByNameAsync(model.UserName);

                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return Json(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff(string returnUrl)
        {
            await _signInManager.SignOutAsync();
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public async Task<IActionResult> YourAccount()
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                if (User.Identity.IsAuthenticated)
                {
                    ClaimsPrincipal currentUser = this.User;
                    User user = await _userManager.GetUserAsync(currentUser);
                    AccountViewModel model = new AccountViewModel
                    {
                        Id = user.Id,
                        UserName = user.UserName
                    };
                    return View(model);
                }
                else
                {
                    return StatusCode(401);
                }
            }
            else
            {
                return StatusCode(403);
            }
        }
        [HttpPost]
        public async Task<IActionResult> YourAccount(AccountViewModel model)
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                ClaimsPrincipal currentUser = this.User;
                User user = await _userManager.GetUserAsync(currentUser);
                user.UserName = model.UserName;
                if (ModelState.IsValid)
                {
                    if (model.NewPassword != null && model.OldPassword != null)
                    {
                        IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                        if (result.Succeeded)
                        {
                            await _userManager.UpdateAsync(user);
                            return RedirectToAction("YourAccount", "Account");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                if (error.Code == "PasswordMismatch")
                                {
                                    ModelState.AddModelError("OldPassword", "Неправильно введен старый пароль!");
                                }
                                if (error.Code == "PasswordRequiresNonAlphanumeric")
                                {
                                    ModelState.AddModelError("NewPassword", "Пароль должен состоять из A-Z, a-z, 0-9 и должен иметь один не алфавитно-цифровой символ");
                                }
                                ModelState.AddModelError(string.Empty, error.Description);
                            }

                        }
                    }
                    else
                    {
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("YourAccount", "Account");
                    }
                }
                return View(model);
            }
            else
            {
                return StatusCode(403);
            }
        }


        public IActionResult Users(int sortType = 0)
        {
            if (User.IsInRole("admin"))
            {
                List<AccountViewModel> model = new List<AccountViewModel>();
                _userManager.Users.ToList().ForEach(u =>
                {
                    AccountViewModel user = new AccountViewModel
                    {
                        Id = u.Id,
                        UserName = u.UserName
                    };
                    model.Add(user);
                });

                switch (sortType)
                {
                    case 0:
                        model = model.OrderBy(b => b.UserName).ToList();
                        break;
                    case 1:
                        model = model.OrderByDescending(b => b.UserName).ToList();
                        break;
                }
                ViewBag.SortType = sortType;

                return View(model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        public async Task<IActionResult> EditUser(string id)
        {
            if (User.IsInRole("admin"))
            {
                User user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                AccountViewModel model = new AccountViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
                return PartialView("_EditUser", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(AccountViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    User user = await _userManager.FindByIdAsync(model.Id);
                    if (user != null)
                    {
                        user.Email = model.UserName + "@cartridges.coi";
                        user.UserName = model.UserName;

                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Users");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                }
                return PartialView("_EditUser", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (User.IsInRole("admin"))
            {
                AccountViewModel model = new AccountViewModel();
                if (id != null)
                {
                    User user = await _userManager.FindByIdAsync(id);
                    model.UserName = user.UserName;
                }
                return PartialView("_DeleteUser", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(AccountViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(user);
                }
                return RedirectToAction("Users");
            }
            else
            {
                return StatusCode(403);
            }
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            if (User.IsInRole("admin"))
            {
                User user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, UserName = user.UserName };
                return PartialView("_ChangePassword", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    User user = await _userManager.FindByIdAsync(model.Id);
                    if (user != null)
                    {
                        var _passwordValidator =
                            HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                        var _passwordHasher =
                            HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

                        IdentityResult result =
                            await _passwordValidator.ValidateAsync(_userManager, user, model.Password);
                        if (result.Succeeded)
                        {
                            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                            await _userManager.UpdateAsync(user);
                            return RedirectToAction("Users");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Пользователь не найден");
                    }
                }
                return PartialView("_ChangePassword", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUserRoles(string userId)
        {
            if (User.IsInRole("admin"))
            {
                User user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var allRoles = _roleManager.Roles.ToList();
                    ChangeRoleViewModel model = new ChangeRoleViewModel
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        UserRoles = userRoles,
                        AllRoles = allRoles
                    };
                    return PartialView("_EditUserRoles", model);
                }

                return NotFound();
            }
            else
            {
                return StatusCode(403);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditUserRoles(string userId, List<string> roles)
        {
            if (User.IsInRole("admin"))
            {
                User user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var allRoles = _roleManager.Roles.ToList();
                    var addedRoles = roles.Except(userRoles);
                    var removedRoles = userRoles.Except(roles);
                    await _userManager.AddToRolesAsync(user, addedRoles);
                    await _userManager.RemoveFromRolesAsync(user, removedRoles);
                    return RedirectToAction("Users");
                }
                return NotFound();
            }
            else
            {
                return StatusCode(403);
            }
        }
    }
}