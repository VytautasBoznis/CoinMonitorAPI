using System.Collections.Generic;
using CoinManagerInterfaces;
using CoinMonitroDomainLayer.Entities;
using NUnit.Framework;

namespace CoinManagerService.Managers.Tests
{
	[TestFixture()]
	public class CoinManagerTests
	{
		[Test()]
		public void AddKeySecretPayrTest()
		{
			CexManager cexManager = new CexManager();
			CoinManager coinManager = new CoinManager(cexManager);

			bool response = coinManager.AddKeySecretPayr(1, "test", "test");

			if (response)
			{
				response = coinManager.AddKeySecretPayr(0, "test", "test");

				if (response)
				{
					Assert.Fail("Added key without account.");
				}

			}
			else
			{
				Assert.Fail("Did not add key.");
			}
		}

		[Test()]
		public void GetAllKeyAndSecretPayrsTest()
		{
			CexManager cexManager = new CexManager();
			CoinManager coinManager = new CoinManager(cexManager);

			List<KeyAndSecret> response = coinManager.GetAllKeyAndSecretPayrs(1);

			if (response.Count > 0)
			{
				response = coinManager.GetAllKeyAndSecretPayrs(0);

				if (response.Count > 0)
				{
					Assert.Fail("Returned unknown lists.");
				}

			}
			else
			{
				Assert.Fail("Failed to get lists.");
			}
		}

		[Test()]
		public void GetAllCoinModelsTest()
		{
			CexManager cexManager = new CexManager();
			CoinManager coinManager = new CoinManager(cexManager);

			List<CoinModel> response = coinManager.GetAllCoinModels(1);

			if (response.Count > 0)
			{
				response = coinManager.GetAllCoinModels(0);

				if (response.Count > 0)
				{
					Assert.Fail("Returned unknown lists.");
				}

			}
			else
			{
				Assert.Fail("Failed to get lists.");
			}
		}

		[Test()]
		public void AddCoinModelTest()
		{
			CexManager cexManager = new CexManager();
			CoinManager coinManager = new CoinManager(cexManager);

			bool response = coinManager.AddCoinModel(1,"USD","BTC", 1);

			if (response)
			{
				response = coinManager.AddCoinModel(0, "USD", "BTC", 1);

				if (response)
				{
					Assert.Fail("Added key without account.");
				}

			}
			else
			{
				Assert.Fail("Did not add key.");
			}
		}
	}
}