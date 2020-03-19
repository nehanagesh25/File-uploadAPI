using Microsoft.Owin.Security.OAuth;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace CovertusWebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            log4net.Config.XmlConfigurator.Configure();
            config.EnableCors();
            // Web API configuration and services
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            //  EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            // config.MapHttpAttributeRoutes();

        }
    }
}
