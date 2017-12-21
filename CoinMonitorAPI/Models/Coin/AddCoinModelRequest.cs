namespace CoinMonitorAPI.Models.Coin
{
	public class AddCoinModelRequest
	{
		public int userId { get; set; }
		public string nameFrom { get; set; }
		public string nameTo { get; set; }
		public decimal amount { get; set; }
	}
}