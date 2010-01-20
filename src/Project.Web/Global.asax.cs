using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;
using Project.Core.Controllers;
using Project.Core.Lib.Infrastructure;

namespace Project.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;
            var relativeFilePath = context.Request.AppRelativeCurrentExecutionFilePath;
            if (RouteRegistrar.DefaultRoutes.Contains(relativeFilePath))
            {
                context.RewritePath(string.Format("~/{0}/{1}", RouteRegistrar.DefaultController, RouteRegistrar.DefaultAction));
            }
        }

        protected override IKernel CreateKernel()
        {
            return ServiceLocator.BuildKernel();            
        }

        protected override void OnApplicationStarted()
        {
            RouteRegistrar.RegisterRoutes(RouteTable.Routes);
            RegisterAllControllersIn(typeof(ApplicationController).Assembly);
        }
    }
}