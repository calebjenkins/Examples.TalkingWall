using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TalkingWall.Data;
using TalkingWall.Domain;
using TalkingWall.UI.Presenters;

namespace TalkingWall
{
    public class Global : System.Web.HttpApplication
    {
        public static IServiceLocator Container { get; private set; }
        private IServiceLocator configureContainer()
        {
            IUnityContainer container = new UnityContainer();
            container
                .RegisterType<MainPagePresenter>()
                .RegisterType<ITalkingWallView, defaultPage>(new PerThreadLifetimeManager())
                .RegisterType<IWallData, MyDataProvider>();

            return new UnityServiceLocator(container);
        }

      
        protected void Application_Start(object sender, EventArgs e)
        {
           Container = configureContainer();
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