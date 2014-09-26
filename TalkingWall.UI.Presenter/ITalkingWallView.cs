using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkingWall.Domain;

namespace TalkingWall.UI.Presenter
{
    public interface ITalkingWallView
    {
        string Message { get; set; }
        string Name { get; set; }
        event EventHandler PostMessage;
        event EventHandler ClearMessages;
        void BindMessage(Collection<WallMessage> Messages);
        event EventHandler PageLoad;
        bool IsPostBack { get; }
    }
}
