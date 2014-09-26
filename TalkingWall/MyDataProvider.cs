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
    public class MyDataProvider : IWallData
    {
        public Collection<WallMessage> Messages
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
    }
}
