using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Northwind.MvcWebUI.Models;

namespace Northwind.MvcWebUI.ViewComponents
{
	public class UserSummaryViewComponent:ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            UserDetailsViewModel model = new UserDetailsViewModel
            {
               UserName = HttpContext.User.Identity.Name
            };
            return View(model);
        }
    }
}