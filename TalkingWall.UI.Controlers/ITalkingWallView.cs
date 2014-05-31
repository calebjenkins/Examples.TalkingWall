using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkingWall.Domain;

namespace TalkingWall.UI.Controlers
{
    public interface ITalkingWallView
    {
        event EventHandler PageLoad;
        event EventHandler PostMessageClick;
        event EventHandler ClearMessagesClick;
        bool IsPostBack { get; }
        void BindData(ICollection<WallMessage> messages);
        string Name { get; set; }
        string Message { get; set; }
    }
}
