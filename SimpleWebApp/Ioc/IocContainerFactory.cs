using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoCContainer;
using System.Web.Mvc;


namespace SimpleWebApp.Ioc
{
    public class IocContainerFactory : DefaultControllerFactory 
    {
        private readonly IContainer container;

        public IocContainerFactory(IContainer container)
        {
            this.container = container;
        }

        protected IController GetControllerInstance(Type controllerType)
        {
            return container.Resolve(controllerType) as Controller;
        }
    }
}