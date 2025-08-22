using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> user;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> user , SignInManager<User> signInManager)
        {
            this.user = user;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginViewModel loginViewModel)
        {

            var selectedUser = user.Users.FirstOrDefault(a => a.UserName == loginViewModel.UserName);
            if (selectedUser == null) {
                return View();
            }
           var result =await signInManager.PasswordSignInAsync(selectedUser, loginViewModel.Password, true, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

              
        }

        public IActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegiserViewModel viewModel)
        {

          var result =await  user.CreateAsync(new Models.User()
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email,

            },viewModel.Password);

            if (result.Succeeded)
            {

                return RedirectToAction("Login");
            }

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


    }
}
