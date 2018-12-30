using System.Collections.Generic;
using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Concrete
{
	public class UserManager : IUserService
	{
		private IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public void AddUser(User user)
		{
			_userDal.Add(user);
		}

		public void Delete(User user)
		{
			_userDal.Delete(user);
		}

		public List<User> GetAll()
		{
			return _userDal.GetList();
		}

		public User GetUser(User user)
		{
			if (user.UserId != 0)
				return _userDal.Get(p => p.UserId == user.UserId);
			else
				return _userDal.Get(p => p.UserName == user.UserName && p.Password == user.Password);
		}
	}
}