using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SierraPacific.Api.Owin;
using System;
using System.Web.Http;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(SierraPacific.Api.Startup))]
namespace SierraPacific.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);
            ConfigureSecurityMiddlewares(app);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            config.EnableSwagger(c => c.SingleApiVersion("v1", "Sierra Pacific API"))
               .EnableSwaggerUi();
        }

        public void ConfigureSecurityMiddlewares(IAppBuilder app)
        {

            var authType = "SierraPacific.Identity";
            var authServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true, // To Do: Move https and expiration to config
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),

                AuthenticationType = authType,
                TokenEndpointPath = new PathString("/token"),
                Provider = new AuthorizationServerProvider(),
            };

            // middle ware for token generation and consumption
            app.UseOAuthBearerTokens(authServerOptions);

        }

    }
}