using System.Collections.Generic;
using CoinMonitroDomainLayer.Entities;

namespace CoinManagerInterfaces
{
	public interface ICoinManager
	{
		bool AddKeySecretPayr(int userId, string key, string secret);
		List<KeyAndSecret> GetAllKeyAndSecretPayrs(int userId);
		List<CoinModel> GetAllCoinModels(int userId);
		bool AddCoinModel(int userId, string nameFrom, string nameTo, decimal amount);
	}
}
