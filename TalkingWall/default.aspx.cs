using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalkingWall.Domain;

namespace TalkingWall
{
    public partial class defaultPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RefreshData();
            }
        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            var msg = new WallMessage() { Message = WallInput.Text, Name = WallName.Text, TimeStamp = DateTime.Now };
            Global.Messages.Add(msg);
            RefreshData();
        }

        private void RefreshData()
        {
            WallGrid.DataSource = Global.Messages.Reverse();
            WallGrid.DataBind();

            WallRepeater.DataSource = Global.Messages.Reverse();
            WallRepeater.DataBind();
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            Global.Messages.Clear();
            RefreshData();
        }
    }
}