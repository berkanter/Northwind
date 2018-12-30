using Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Northwind.Business.Abstract
{
	public interface ICartService
	{
		void AddToCart(Cart cart, Product product);
		void RemoveFromCart(Cart cart, int productId);
		List<CartLine> List(Cart cart);
	}
}