using System.Linq;
using CoinManagerInterfaces;
using CoinMonitroDomainLayer.Contexts;
using CoinMonitroDomainLayer.Entities;

namespace CoinManagerService.Managers
{
	public class AccountManager: IAccountManager
	{
		public int Login(string email, string password)
		{
			using (var db = new UserContext())
			{
				User user = db.Users.FirstOrDefault(u => u.Email == email);

				if (user != null)
				{
					if (user.Password != password)
					{
						return -1;
					}

					return user.UserId;
				}

				return -1;
			}
		}

		public bool Register(string email, string password, string passwordRepeat)
		{
			if (password != passwordRepeat)
			{
				return false;
			}

			using (var db = new UserContext())
			{
				User user = new User
				{
					Email = email,
					Password = password
				};

				db.Users.Add(user);
				db.SaveChanges();
			}

			return true;
		}
	}
}
