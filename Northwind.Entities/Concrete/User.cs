using Core.Entities;
using System;

namespace Northwind.Entities.Concrete
{
	public class User : IEntity
	{
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public DateTime BirthDay { get; set; }
		public string Role { get; set; }
	}
}