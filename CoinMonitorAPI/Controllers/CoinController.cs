using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using CoinManagerInterfaces;
using CoinMonitorAPI.Models.Coin;
using CoinMonitroDomainLayer.Entities;

namespace CoinMonitorAPI.Controllers
{
    public class CoinController : ApiController
    {
	    private readonly ICoinManager _coinManager;

	    public CoinController(ICoinManager coinManager)
	    {
		    _coinManager = coinManager;
	    }

	    [Route("api/AddKeySecretPayr")]
	    [HttpPost]
	    public JsonResult<AddKeySecretPayrResponse> AddKeySecretPayr([FromBody]AddKeySecretPayrRequest addKeySecretPayrRequest)
	    {
		    bool success = _coinManager.AddKeySecretPayr(addKeySecretPayrRequest.userId, addKeySecretPayrRequest.key, addKeySecretPayrRequest.secret);

		    var response = new AddKeySecretPayrResponse
			{
			    Success = success
		    };

		    return Json(response);
	    }

	    [Route("api/GetAllKeyAndSecretPayrs")]
	    [HttpPost]
	    public JsonResult<GetAllKeyAndSecretPayrResponse> GetAllKeyAndSecretPayrs([FromBody]GetAllKeyAndSecretPayrRequest getAllKeyAndSecretPayrRequest)
	    {
		    List<KeyAndSecret> list = _coinManager.GetAllKeyAndSecretPayrs(getAllKeyAndSecretPayrRequest.userId);

		    var response = new GetAllKeyAndSecretPayrResponse
			{
			    Success = list != null,
				AllKeyAndSecrets = list
			};

		    return Json(response);
	    }

	    [Route("api/GetAllCoinModels")]
	    [HttpPost]
	    public JsonResult<GetAllCoinModelsResponse> GetAllCoinModels([FromBody]GetAllCoinModelsRequest getAllCoinModels)
	    {
		    List<CoinModel> list = _coinManager.GetAllCoinModels(getAllCoinModels.userId);

		    var response = new GetAllCoinModelsResponse
			{
			    Success = list != null,
				AllCoinModels = list
		    };

		    return Json(response);
	    }

	    [Route("api/AddCoinModel")]
	    [HttpPost]
	    public JsonResult<AddCoinModelResponse> AddCoinModel([FromBody]AddCoinModelRequest addCoinModelRequest)
	    {
		    bool success = _coinManager.AddCoinModel(addCoinModelRequest.userId, addCoinModelRequest.nameFrom, addCoinModelRequest.nameTo, addCoinModelRequest.amount);

		    var response = new AddCoinModelResponse
			{
			    Success = success
		    };

		    return Json(response);
	    }
	}
}
