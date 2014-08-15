using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkingWall.Data;
using TalkingWall.Domain;

namespace TalkingWall.UI.Presenters
{
    public class MainPagePresenter
    {
        ITalkingWallView _view;
        IWallData data;
        // ICollection<WallMessage> _messages;
        public MainPagePresenter(IWallData WallData)//  ICollection<WallMessage> messages)
        {
            data = WallData;
        }

        public void Initialize(ITalkingWallView view)
        {
            _view = view;
            _view.PageLoad += view_PageLoad;
            _view.ClearMessagesClick += view_ClearMessagesClick;
            _view.PostMessageClick += view_PostMessageClick;
        }

        void view_PageLoad(object sender, EventArgs e)
        {
            if (!_view.IsPostBack)
            {
                _view.BindData(data.Messages);
            }
        }

        void view_PostMessageClick(object sender, EventArgs e)
        {
            var msg = new WallMessage() { Message = _view.Message, Name = _view.Name, TimeStamp = DateTime.Now };
            data.Messages.Add(msg);
            _view.BindData(data.Messages);
        }

        void view_ClearMessagesClick(object sender, EventArgs e)
        {
            data.Messages.Clear();
            _view.BindData(data.Messages);
        }
    }
}