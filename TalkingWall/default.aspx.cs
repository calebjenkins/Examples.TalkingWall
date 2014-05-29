using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalkingWall.Domain;

namespace TalkingWall
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                WallGrid.DataSource = Global.Messages;
                WallGrid.DataBind();
            }
        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            var msg = new WallMessage() { Message = WallInput.Text, Name=WallName.Text, TimeStamp = DateTime.Now };
            Global.Messages.Add(msg);
            WallGrid.DataSource = Global.Messages;
            WallGrid.DataBind();
        }
    }
}