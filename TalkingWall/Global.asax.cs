using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using TalkingWall.Domain;
using TalkingWall.Domain.Services;

namespace TalkingWall
{
    public class Global : System.Web.HttpApplication
    {
 
        protected void Application_Start(object sender, EventArgs e)
        {
            //msgRepo = new WallMessageRepository();

           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
           FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
           BundleConfig.RegisterBundles(BundleTable.Bundles);            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}