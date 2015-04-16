using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace WilderMindApp.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "RepliesRoute",
                routeTemplate: "api/topics/{topicid}/replies/{id}",
                defaults: new { controller = "replies", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
               name: "TopicsApi",
               routeTemplate: "api/topics/{id}",
               defaults: new { controller = "topics", id = RouteParameter.Optional }
               );

            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
              );
        }
    }
}