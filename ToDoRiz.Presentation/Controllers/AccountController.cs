using Application.DTO.LoginDTO;
using Application.DTO.RegisterDTO;
using Application.DTO.UsersDTO;
using Application.Service.ServiceInterface;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ToDoRiz.Presentation.Controllers
{
    public class AccountController : Controller
    {
        #region ctor
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion
        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTOs loginDTOs)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindUserByMobile(loginDTOs.Mobile.Trim());

                if (user != null)
                {
                    var claims = new List<Claim>
                    {

                          new (ClaimTypes.MobilePhone, user.Mobile),
                          new (ClaimTypes.Name, user.FullName),
                    };

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(claimIdentity);

                    var authProps = new AuthenticationProperties();
                    //authProps.IsPersistent = model.RememberMe;

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);

                    return RedirectToAction("Index", "Home");

                }
            }
            TempData["ErrorMessage"] = "کاربری با مشخصات وارد شده یافت نشده است.";
            return View();
        }
        #endregion
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTOs registerDTOs)
        {
            if (ModelState.IsValid)
            {
                var mobile = await _userService.FindUserByMobile(registerDTOs.Mobile.Trim());

                if (mobile == null)
                {
                    //Add User To DataBase
                    await _userService.CreateUser(registerDTOs);
                    return RedirectToAction("Index", "Home");
                }
                     
            }
            return View();
        }
        #endregion
        #region LogOut
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        #endregion

    }
}
