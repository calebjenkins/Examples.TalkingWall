using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkingWall.Domain;

namespace TalkingWall.UI.Controlers
{
    public class MainPagePresenter
    {
        ITalkingWallView _view;
        ICollection<WallMessage> _messages;
        public MainPagePresenter(ITalkingWallView view, ICollection<WallMessage> messages)
        {
            _view = view;
            _messages = messages;
            _view.PageLoad += view_PageLoad;
            _view.ClearMessagesClick += view_ClearMessagesClick;
            _view.PostMessageClick += view_PostMessageClick;
        }

        void view_PostMessageClick(object sender, EventArgs e)
        {
            var msg = new WallMessage() { Message = _view.Message, Name = _view.Name, TimeStamp = DateTime.Now };
            _messages.Add(msg);
            _view.BindData(_messages);
        }

        void view_ClearMessagesClick(object sender, EventArgs e)
        {
            _messages.Clear();
            _view.BindData(_messages);
        }

        void view_PageLoad(object sender, EventArgs e)
        {
            if (!_view.IsPostBack)
            {
                _view.BindData(_messages);
            }
        }
    }
}