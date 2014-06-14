using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using TalkingWall.Domain;

namespace TalkingWall.ViewModels
{
    public class WallViewModel
    {
        public WallViewModel()
        {
            Name = String.Empty;
            Message = String.Empty;
            Messages = new Collection<WallMessage>();
        }

        public WallViewModel(WallMessage wallMessage, Collection<WallMessage> messageCollection)
        {
            Name = wallMessage.Name;
            Message = wallMessage.Message;
            Messages = messageCollection;
        }
        public string Name { get; set; }
        public string Message { get; set; }
       public Collection<WallMessage> Messages{ get; set; }
    }
}