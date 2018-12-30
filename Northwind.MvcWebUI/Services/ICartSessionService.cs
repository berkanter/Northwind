using Northwind.Entities.Concrete;

namespace Northwind.MvcWebUI.Services
{
	public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}