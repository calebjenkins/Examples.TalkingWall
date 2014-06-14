using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkingWall.Domain;

namespace TalkingWall.UI.Presenters
{
    public interface ITalkingWallView
    {
        event EventHandler PageLoad;
        event EventHandler PostMessageClick;
        event EventHandler ClearMessagesClick;
        bool IsPostBack { get; }
        void BindData(Collection<WallMessage> messages);
        string Name { get; set; }
        string Message { get; set; }
    }
}
