﻿using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
                DependencyResolver.SetResolver(new Infrastructure.NinjectDependencyResolver());
            
        }

        //Call everytime there is an exceoption
        //Put a break point an make sure it stops there
        protected void Application_Error()
        {
            Logger l = new Logger();
            Exception exception = Server.GetLastError();
            l.LogToEvent(exception.Message);
            using (StreamWriter w = File.AppendText("C:\\Temp\\log.txt"))
            {
                l.LogToFile(exception.Message, w);
            }
        }
    }
}
