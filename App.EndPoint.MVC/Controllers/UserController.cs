using App.Domain.Core.AppService;
using App.Domain.Core.Entities;
using App.EndPoint.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly SignInManager<User> _signInManager;
        public UserController(IUserAppService userAppService, SignInManager<User> signInManager)
        {
            _userAppService = userAppService;
            _signInManager = signInManager; 
        }
        [HttpGet]
        public async Task<IActionResult> Register(CancellationToken cToken)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user, CancellationToken cToken)
        {
            if (!ModelState.IsValid)
                return View(user);
            if (string.IsNullOrWhiteSpace(user.PasswordHash) || string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Email))
            {
                ModelState.AddModelError(string.Empty, "فیلدهای خالی رو پر کنید.");
                return View(user);
            }
            var result = await _userAppService.Register(user, cToken);

            if (result.Succeeded)
            {

                return RedirectToAction("Login", "User");
            }


            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(User user, CancellationToken cToken)
        {
            if (!ModelState.IsValid)
                return View(user);
            if (string.IsNullOrWhiteSpace(user.PasswordHash) || string.IsNullOrWhiteSpace(user.UserName))
            {
                ModelState.AddModelError(string.Empty, "فیلدهای خالی رو پر کنید.");
                return View(user);
            }
            var result = await _userAppService.Login(user.UserName, user.PasswordHash, cToken);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور اشتباه است.");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cToken)
        {
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
