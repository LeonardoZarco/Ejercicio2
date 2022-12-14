﻿using API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.WebHost;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        //public static string UrlPrefix { get { return "api"; } }
          public static string UrlPrefixRelative { get { return "~/api"; } }

        //public static void Register(HttpConfiguration config)
        //{
        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );
        //}
    }
}
