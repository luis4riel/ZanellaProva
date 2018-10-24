using Zanella.MF7.WebAPI.App_Start;
using Zanella.MF7.WebAPI.IoC;
using Zanella.MF7.WebAPI.Logger;
using Zanella.MF7.Aplicacao.Mapping;
using SimpleInjector.Integration.WebApi;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Zanella.MF7.WebAPI.Startup))]

namespace Zanella.MF7.WebAPI
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SimpleInjectorContainer.Initialize();
            AutoMapperInitializer.Initialize();

            HttpConfiguration config = new HttpConfiguration()
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver
                (SimpleInjectorContainer.ContainerInstance)
            };

            WebApiConfig.Register(config);

            OAuthConfig.ConfigureOAuth(app);

            config.MessageHandlers.Add(new CustomLogHandler());

            app.UseWebApi(config);
        }
    }
}