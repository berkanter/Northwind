using Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Northwind.MvcWebUI.Models
{
	public class CategoryListViewModel
    {
        public List<Category> Categories { get; internal set; }
    }
}