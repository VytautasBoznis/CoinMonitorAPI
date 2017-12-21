namespace CoinMonitorAPI.Models.Coin
{
	public class AddKeySecretPayrRequest
	{
		public int userId { get; set; }
		public string key { get; set; }
		public string secret { get; set; }
	}
}