using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Entities.Concrete;
using Northwind.MvcWebUI.Models;
using Northwind.MvcWebUI.Services;
using System;

namespace Northwind.MvcWebUI.Controllers
{
	public class CartController : Controller
    {
		private ICartSessionService _cartSessionService;
		private ICartService _cartService;
		private IProductService _productService;

		public CartController(
			ICartSessionService cartSessionService,
			ICartService cartService,
			IProductService productService)
		{
			_cartSessionService = cartSessionService;
			_cartService = cartService;
			_productService = productService;
		}

		public ActionResult AddToCart(int id)
		{
			var productToBeAdded = _productService.GetById(id);

			var cart = _cartSessionService.GetCart();

			_cartService.AddToCart(cart, productToBeAdded);

			_cartSessionService.SetCart(cart);

			TempData.Add("Message", String.Format("Your product, {0}, was successfully added to the cart!", productToBeAdded.ProductName));

			return RedirectToAction("Index", "Product");
		}

		public ActionResult List()
		{
			var cart = _cartSessionService.GetCart();
			CartListViewModel cartListViewModel = new CartListViewModel
			{
				Cart = cart
			};
			return View(cartListViewModel);
		}

		public ActionResult Remove(int id)
		{
			var cart = _cartSessionService.GetCart();
			_cartService.RemoveFromCart(cart, id);
			_cartSessionService.SetCart(cart);
			TempData.Add("Message", String.Format("Your product was successfully removed from the cart!"));
			return RedirectToAction("List");
		}

		[Authorize]
		public ActionResult Complete()
		{
			var shippingDetailsViewModel = new ShippingDetailsViewModel
			{
				ShippingDetails = new ShippingDetails()
			};

			return View(shippingDetailsViewModel);
		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult Complete(ShippingDetails shippingDetails)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			TempData.Add("Message", String.Format("Thank you {0}, you order is in process", shippingDetails.FirstName));

			HttpContext.Session.Remove("cart");

			return Redirect("/Home/Index");
		}
	}
}