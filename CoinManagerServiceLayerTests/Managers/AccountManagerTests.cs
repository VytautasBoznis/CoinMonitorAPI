using NUnit.Framework;

namespace CoinManagerService.Managers.Tests
{
	[TestFixture()]
	public class AccountManagerTests
	{
		[Test()]
		public void LoginTest()
		{
			AccountManager accountManager = new AccountManager();

			int accountId = accountManager.Login("admin@admin", "test");

			if (accountId != 1)
				Assert.Fail("Failed to login");

			accountId = accountManager.Login("admin@admin", "asdasdasd");

			if (accountId == 1)
				Assert.Fail("Logged in with bad password");

			accountId = accountManager.Login("asdasdasdad@admin", "test");

			if (accountId != -1)
				Assert.Fail("Logged in with incorect email");
		}

		[Test()]
		public void RegisterTest()
		{
			AccountManager accountManager = new AccountManager();

			bool result = accountManager.Register("test@test", "test", "test");

			if (result)
			{
				result = accountManager.Register("test@test", "987", "asdasd");

				if (result)
				{
					Assert.Fail("Created user with not matching passwords");
				}
			}
			else
			{
				Assert.Fail("Failed to create user");
			}
		}
	}
}