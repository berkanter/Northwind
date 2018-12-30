using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.MvcWebUI.Models;
using System;
using System.Linq;

namespace Northwind.MvcWebUI.Controllers
{
	public class ProductController : Controller
    {
		private IProductService _productService;
		private ICategoryService _categoryService;

		public ProductController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}

		public ActionResult Index(int page = 1, int category = 0)
		{
			int pageSize = 10;
			var products = _productService.GetByCategory(category);
			ProductListViewModel model = new ProductListViewModel
			{
				Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
				PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
				PageSize = pageSize,
				CurrentCategory = category,
				CurrentPage = page,
				Categories = _categoryService.GetAll()
			};
			return View(model);
		}
	}
}