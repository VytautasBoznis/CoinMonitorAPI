using System;
using CoinManagerInterfaces;
using CoinMonitroDomainLayer.Api;
using RestSharp;

namespace CoinManagerService.Managers
{
	public class CexManager: ICexManager
	{
		private readonly string CexApiURL = "https://cex.io/api/";
		private RestClient _client;

		public CexManager()
		{
			_client = new RestClient(CexApiURL);
		}

		public decimal GetLastPrice(string nameFrom, string nameTo)
		{
			decimal lastPrice = 0;

			RestRequest request = new RestRequest($"/last_price/{nameFrom}/{nameTo}");
			request.Method = Method.GET;

			var response = _client.Execute<LastPriceResponse>(request);

			if (response.IsSuccessful && response.Data != null)
			{
				lastPrice = response.Data.lprice;
			}

			return lastPrice;
		}

		public BalanceResponse GetUserBalance(string key, string secret)
		{
			RestRequest request = new RestRequest($"/balance/");
			request.Method = Method.POST;
			request.AddBody(new
			{
				key,
				signature = secret,
				nonce = DateTime.Now.Ticks
			});

			var response = _client.Execute<BalanceResponse>(request);

			if (response.IsSuccessful && response.Data != null)
			{
				return response.Data;
			}

			return null;
		}
	}
}
