using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkingWall.Domain;
using TalkingWall.Domain.Services;

namespace TalkingWall.UI.Presenters
{
    public class MainPagePresenter
    {
        ITalkingWallView _view;
        IWallMessageRepository _messageRepo;
        public MainPagePresenter(ITalkingWallView view, IWallMessageRepository messageRepository)
        {
            _view = view;
            _messageRepo = messageRepository;
            _view.PageLoad += view_PageLoad;
            _view.ClearMessagesClick += view_ClearMessagesClick;
            _view.PostMessageClick += view_PostMessageClick;
        }

        void view_PageLoad(object sender, EventArgs e)
        {
            if (!_view.IsPostBack)
            {
                _view.BindData(_messageRepo.Messages);
            }
        }

        void view_PostMessageClick(object sender, EventArgs e)
        {
            var msg = new WallMessage() { Message = _view.Message, Name = _view.Name, TimeStamp = DateTime.Now };
            _messageRepo.Messages.Add(msg);
            _view.BindData(_messageRepo.Messages);
        }

        void view_ClearMessagesClick(object sender, EventArgs e)
        {
            _messageRepo.Messages.Clear();
            _view.BindData(_messageRepo.Messages);
        }
    }
}