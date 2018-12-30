using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Northwind.MvcWebUI.Controllers
{
	public class HomeController : Controller
	{
		private ICategoryService _categoryService;

		public HomeController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{
			List<Category> categories = _categoryService.GetAll();

			return View(categories);
		}

		public ActionResult Login()
		{
			return View();
		}
	}
}