using System.Web.Http;
using Unity;
using Unity.WebApi;
using CoinManagerInterfaces;
using CoinManagerService.Managers;

namespace CoinMonitorAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
			
			container.RegisterType<IAccountManager, AccountManager>();
	        container.RegisterType<ICoinManager, CoinManager>();
	        container.RegisterType<ICexManager, CexManager>();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}