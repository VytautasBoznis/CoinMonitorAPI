namespace CoinManagerInterfaces
{
	public interface IAccountManager
	{
		int Login(string email, string password);
		bool Register(string email, string password, string passwordRepeat);
	}
}
