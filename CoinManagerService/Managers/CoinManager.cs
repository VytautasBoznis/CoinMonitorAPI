using System.Collections.Generic;
using System.Linq;
using CoinManagerInterfaces;
using CoinMonitroDomainLayer.Contexts;
using CoinMonitroDomainLayer.Entities;

namespace CoinManagerService.Managers
{
	public class CoinManager: ICoinManager
	{
		private readonly ICexManager _cexManager;

		public CoinManager(ICexManager cexManager)
		{
			_cexManager = cexManager;
		}

		public bool AddKeySecretPayr(int userId, string key, string secret)
		{
			using (var db = new UserContext())
			{
				User user = db.Users.FirstOrDefault(u => u.UserId == userId);

				if (user != null)
				{
					user.KeysAndSecrets.Add(new KeyAndSecret
					{
						Key = key,
						Secret = secret
					});

					db.SaveChanges();
					return true;
				}
				return false;
			}
		}

		public List<KeyAndSecret> GetAllKeyAndSecretPayrs(int userId)
		{
			using (var db = new UserContext())
			{
				List<KeyAndSecret> keys = db.KeysAndSecrets.Where(ks => ks.UserId == userId).ToList();
				
				return keys;
			}
		}

		public List<CoinModel> GetAllCoinModels(int userId)
		{
			using (var db = new UserContext())
			{
				List<CoinModel> models = db.CoinModels.Where(cm => cm.UserId == userId).ToList();
				
				foreach (var model in models)
				{
					model.Price = _cexManager.GetLastPrice(model.PairFrom, model.PairTo);
				}

				return models;
			}
		}

		public bool AddCoinModel(int userId, string nameFrom, string nameTo, decimal amount)
		{
			using (var db = new UserContext())
			{
				User user = db.Users.FirstOrDefault(u => u.UserId == userId);

				if (user != null)
				{
					user.CoinModel.Add(new CoinModel
					{
						PairFrom = nameFrom,
						PairTo = nameTo,
						Amount = amount
					});
					
					db.SaveChanges();
					return true;
				}
				return false;
			}
		}
	}
}
