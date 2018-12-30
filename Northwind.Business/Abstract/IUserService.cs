using Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Northwind.Business.Abstract
{
	public interface IUserService
	{
		void AddUser(User user);
		User GetUser(User user);
		void Delete(User user);
		List<User> GetAll();
	}
}