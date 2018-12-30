using Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Northwind.MvcWebUI.Models
{
	public class ProductListViewModel
    {
        public int CurrentCategory { get; internal set; }
        public int CurrentPage { get; internal set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public List<Product> Products { get; internal set; }
		public List<Category> Categories { get; internal set; }
    }
}