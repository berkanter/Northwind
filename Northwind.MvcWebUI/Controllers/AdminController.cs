using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.MvcWebUI.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private IUserService _userService;
		private IProductService _productService;
		private ICategoryService _categoryService;

		public AdminController(IUserService userService, IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_userService = userService;
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Users()
		{
			var userList = _userService.GetAll();

			return View(userList);
		}

		public IActionResult UserDelete(int id)
		{
			User user = _userService.GetUser(new User { UserId = id });
			_userService.Delete(user);

			TempData["Message"] = "Delete User " + user.FirstName + " " + user.LastName;

			return Redirect("/Admin/Users");
		}

		public IActionResult UserAdd()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult UserAdd(User user)
		{
			_userService.AddUser(user);
			TempData["Message"] = "Add User " + user.FirstName + " " + user.LastName;
			return View();
		}

		public IActionResult Products()
		{
			var products = _productService.GetAll();

			return View(products);
		}

		public IActionResult ProductDelete(int id)
		{
			_productService.Delete(id);
			TempData["Message"] = "Delete Product ";

			return Redirect("/Admin/Products");
		}

		public IActionResult ProductAdd()
		{
			var categories = _categoryService.GetAll();
			return View(categories);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ProductAdd(Product product)
		{
			_productService.Add(product);
			TempData["Message"] = "Add Product :  " + product.ProductName;
			return Redirect("/Admin/ProductAdd");
		}
	}
}