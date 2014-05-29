using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TalkingWall.Domain;

namespace TalkingWall
{
    public class Global : System.Web.HttpApplication
    {

        public static Collection<WallMessage> Messages
        {
            get
            {
                if (HttpContext.Current.Application["wall"] == null)
                    HttpContext.Current.Application["wall"] = new Collection<WallMessage>();


                return (Collection<WallMessage>)HttpContext.Current.Application["wall"];
            }
            set
            {
                HttpContext.Current.Application["wall"] = value;
            }
        }
        protected void Application_Start(object sender, EventArgs e)
        {
           Messages = new Collection<WallMessage>();
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