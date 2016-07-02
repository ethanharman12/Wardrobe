[assembly: WebActivator.PostApplicationStartMethod(typeof(Wardrobe.API.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Wardrobe.API.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using Wardrobe.Core.Interfaces.Services;
    using Wardrobe.Core.Services;
    using Wardrobe.Core.Interfaces.Repositories;
    using Wardrobe.Infrastructure.Repositories;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IClosetService, ClosetService>(Lifestyle.Scoped);
            container.Register<IClosetRepository, ClosetRepository>(Lifestyle.Scoped);
        }
    }
}