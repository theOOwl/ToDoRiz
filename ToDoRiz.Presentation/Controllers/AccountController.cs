using Application.DTO.LoginDTO;
using Application.DTO.RegisterDTO;
using Application.DTO.UsersDTO;
using Application.Service.ServiceInterface;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

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

                if (user == null)
                {

                }

            }
            return RedirectToAction("Index" , "Home" );
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

        #endregion

    }
}
