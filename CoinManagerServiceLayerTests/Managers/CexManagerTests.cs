using NUnit.Framework;
using CoinManagerService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinManagerService.Managers.Tests
{
	[TestFixture()]
	public class CexManagerTests
	{
		[Test()]
		public void GetLastPriceTest()
		{
			CexManager cexManager = new CexManager();

			decimal price = cexManager.GetLastPrice("BTC", "USD");

			if(price == 0)
				Assert.Fail("Failed to fetch price");
		}
	}
}