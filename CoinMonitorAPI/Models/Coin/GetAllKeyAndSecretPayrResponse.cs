using System.Collections.Generic;
using CoinMonitroDomainLayer.Entities;

namespace CoinMonitorAPI.Models.Coin
{
	public class GetAllKeyAndSecretPayrResponse: BaseResponseModel
	{
		public GetAllKeyAndSecretPayrResponse()
		{
			AllKeyAndSecrets = new List<KeyAndSecret>();
		}

		public List<KeyAndSecret> AllKeyAndSecrets { get; set; }
	}
}