using System.Net.Http;
using System.Web.Http;
using CoinManagerService.Managers;
using NUnit.Framework;
using RestSharp;

namespace CoinMonitorAPI.Controllers.Tests
{
	[TestFixture()]
	public class AccountControllerTests
	{
		public class LoginModel
		{
			public string Email { get; set; }
			public string Password { get; set; }
		}

		public class LoginResponse
		{
			public bool Success { get; set; }
			public int UserId { get; set; }
		}

		[Test()]
		public void LoginTest()
		{
			var request = new LoginModel()
			{
				Email = "admin@admin",
				Password = "test"
			};

			RestClient client = new RestClient("http://localhost/CoinMonitorAPI/api");
			
			RestRequest restRequest = new RestRequest("/login", Method.POST);
			restRequest.RequestFormat = DataFormat.Json;
			restRequest.AddBody(request);

			var response = client.Execute<LoginResponse>(restRequest);

			if (response.Data == null || !response.Data.Success || response.Data.UserId != 1)
			{
				Assert.Fail();
			}

		}

		public class RegisterModel
		{
			public string Email { get; set; }
			public string Password { get; set; }
			public string PasswordRepeat { get; set; }
		}

		public class RegisterResponse
		{
			public bool Success { get; set; }
		}

		[Test()]
		public void RegisterTest()
		{
			var request = new RegisterModel()
			{
				Email = "test@tes",
				Password = "test",
				PasswordRepeat = "test"
			};

			RestClient client = new RestClient("http://localhost/CoinMonitorAPI/api");

			RestRequest restRequest = new RestRequest("/register", Method.POST);
			restRequest.RequestFormat = DataFormat.Json;
			restRequest.AddBody(request);

			var response = client.Execute<RegisterResponse>(restRequest);

			if (response.Data == null || !response.Data.Success)
			{
				Assert.Fail();
			}

		}
	}
}