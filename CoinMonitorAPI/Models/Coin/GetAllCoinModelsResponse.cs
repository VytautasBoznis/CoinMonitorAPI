using System.Collections.Generic;
using CoinMonitroDomainLayer.Entities;

namespace CoinMonitorAPI.Models.Coin
{
	public class GetAllCoinModelsResponse: BaseResponseModel
	{
		public GetAllCoinModelsResponse()
		{
			AllCoinModels = new List<CoinModel>();
		}

		public List<CoinModel> AllCoinModels { get; set; }
	}
}