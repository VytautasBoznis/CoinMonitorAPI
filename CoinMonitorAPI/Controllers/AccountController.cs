using System.Web.Http;
using System.Web.Http.Results;
using CoinManagerInterfaces;
using CoinMonitorAPI.Models.Account;

namespace CoinMonitorAPI.Controllers
{
    public class AccountController : ApiController
    {
	    private readonly IAccountManager _accountManager;
		
	    public AccountController(IAccountManager accountManager)
	    {
		    _accountManager = accountManager;
	    }

	    [Route("api/login")]
	    [HttpPost]
		public JsonResult<LoginResponse> Login([FromBody]LoginRequest loginRequest)
		{
			int userId = _accountManager.Login(loginRequest.Email, loginRequest.Password);

			var response = new LoginResponse
			{
				Success = userId > 0,
				UserId = userId
			};

			return Json(response);
		}

		[Route("api/register")]
		[HttpPost]
		public JsonResult<RegisterResponse> Register([FromBody]RegisterRequest registerRequest)
	    {
		    bool success = _accountManager.Register(registerRequest.Email, registerRequest.Password, registerRequest.PasswordRepeat);

		    var response = new RegisterResponse
			{
			    Success = success
			};

		    return Json(response);
	    }
	}
}
