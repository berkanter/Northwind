using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Concrete;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
	public class NorthwindContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-74IPDAA\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
		}

		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<User> Users { get; set; }
	}
}