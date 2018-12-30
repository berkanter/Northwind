using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Northwind.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public ActionResult<List<Product>> Get()
		{
			return _productService.GetAll();
		}

		[HttpGet("{productId}")]
		public ActionResult<Product> Get(int productId)
		{
			return _productService.GetById(productId);
		}

		[HttpGet("ByCategory/{categoryId}")]
		public ActionResult<List<Product>> GetByCategoryId(int categoryId)
		{
			return _productService.GetByCategory(categoryId);
		}

		[HttpPost]
		public string Post(Product product)
		{
			_productService.Add(product);

			return "Add Product Succes";
		}
	}
}