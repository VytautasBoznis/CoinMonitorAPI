using CoinMonitroDomainLayer.Api;

namespace CoinManagerInterfaces
{
	public interface ICexManager
	{
		decimal GetLastPrice(string from, string to);
	}
}
