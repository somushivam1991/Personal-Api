using Newtonsoft.Json.Serialization;
using SierraPacific.Bootstrapper;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using LoggingExtensions.Logging;
using LoggingExtensions.NLog;

namespace SierraPacific.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = ApiDependencyResolver.Get();
            // Web API routes
            config.MapHttpAttributeRoutes();

            Log.InitializeWith<NLogLog>();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // e.g propertyName
        }
    }
}
