using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using MarsoApi.Controllers;
namespace MarsoApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                
            );
            //config.Formatters.XmlFormatter.UseXmlSerializer = true;
            ////// ELIMINAMOS EL FORMATEADOR DE RESPUESTAS XML
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            ////// HABILITAMOS EL FORMATEADOR DE RESPUESTAS JSON
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
    }
}
