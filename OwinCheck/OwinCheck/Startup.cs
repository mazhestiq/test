using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using OwinCheck;

[assembly:OwinStartup(typeof(Startup))]

namespace OwinCheck
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                return context.Response.WriteAsync("Hello from Owin and .net 4.6.1");
            });
        }
    }
}