using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalkingWall.Domain;
using TalkingWall.UI.Presenters;

namespace TalkingWall
{
    public partial class defaultPage : System.Web.UI.Page, ITalkingWallView
    {
        MainPagePresenter presenter;
        public event EventHandler PageLoad;
        public event EventHandler PostMessageClick;
        public event EventHandler ClearMessagesClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new MainPagePresenter((ITalkingWallView)this, Global.Messages);
        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            PostMessageClick.Raise();
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            ClearMessagesClick.Raise();
        }

        public void BindData(ICollection<WallMessage> messages)
        {
            WallRepeater.DataSource = messages.Reverse();
            WallRepeater.DataBind();

            WallGrid.DataSource = messages.Reverse();
            WallGrid.DataBind();
        }

        public string Name
        {
            get { return this.WallName.Text; }
            set { this.WallName.Text = value; }
        }

        public string Message
        {
            get { return this.WallInput.Text; }
            set { WallInput.Text = value; }
        }
    }
}