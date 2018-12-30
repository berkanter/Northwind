using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.MvcWebUI.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Northwind.MvcWebUI.Controllers
{
	public class AccountController : Controller
	{
		private IUserService _userService;

		public AccountController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Login(LoginViewModel loginView)
		{
			if (!ModelState.IsValid)
			{
				TempData["Message"] = "Username or Password Error";
				return View();
			}

			var user = _userService.GetUser(new Entities.Concrete.User { UserName = loginView.UserName, Password = loginView.Password });

			if (user == null)
			{
				TempData["Message"] = "Not a Valid User";
				return View();
			}
			else
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(ClaimTypes.Role, user.Role)
				};


				var identity = new ClaimsIdentity(claims, "DefaultCookie");

				var principal = new ClaimsPrincipal(identity);


				HttpContext.SignInAsync("DefaultCookie", principal, new AuthenticationProperties { IsPersistent = loginView.RememberMe }).Wait();

				if (user.Role.ToLower() == "admin")
					return Redirect("/Admin/Index");
			}

			return Redirect("/Home/Index");
		}

		[Authorize]
		public IActionResult Logout()
		{
			HttpContext.SignOutAsync().Wait();
			return Redirect("/Home/Index");
		}
	}
}