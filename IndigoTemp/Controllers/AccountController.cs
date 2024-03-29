﻿using IndigoTemp.Models;
using IndigoTemp.ViewModels;
using IndigoTemp.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IndigoTemp.Controllers
{
	[AutoValidateAntiforgeryToken]
	public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {

            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM registerVM)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			AppUser user = new AppUser()
			{
				Name = registerVM.Name,
				Email = registerVM.Email,
				Surname = registerVM.Surname,
				UserName = registerVM.Username
			};
			var result = await _userManager.CreateAsync(user, registerVM.Password);

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View();
			}
			await _signInManager.SignInAsync(user, false);
		
			return RedirectToAction(nameof(Index), "Home");
		}

			public IActionResult Login()
        {
            return View();
        }
        //public IActionResult Login()
        //{
        //    return View();
        //}
        public IActionResult Logout()
        {
            return View();
        }
    }
}
