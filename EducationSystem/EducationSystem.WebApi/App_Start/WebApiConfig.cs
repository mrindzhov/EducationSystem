using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;

namespace EducationSystem.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            EnableCorsAttribute corsAttribute = new EnableCorsAttribute("*", "*", "GET,POST");
            config.EnableCors(corsAttribute);

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
