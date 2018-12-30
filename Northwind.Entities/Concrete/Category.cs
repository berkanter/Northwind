using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Entities.Concrete
{
	public class Category : IEntity
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }

		[Column(TypeName = "image")]
		public byte[] Picture { get; set; }
	}
}