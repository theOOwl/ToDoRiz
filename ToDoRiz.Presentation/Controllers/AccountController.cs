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
        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login()
        //{
        //    return RedirectToAction(nameof(Index));
        //}
        #endregion
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserDTOs userDTOs)
        {
            await _userService.CreateUser(userDTOs);
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region LogOut

        #endregion

    }
}
