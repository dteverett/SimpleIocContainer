using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoCContainer;

namespace SimpleWebApp.Ioc
{
    public static class Bootstrap
    {
        public static void Configure(SimpleIocContainer container)
        {
            //container.Register<HomeController, HomeController>();
        }
    }
}