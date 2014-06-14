using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using TalkingWall.Domain;
using TalkingWall.Domain.Services;

namespace TalkingWall.Data
{
    public class MessageRepository : IWallMessageRepository
    {
        public static Collection<WallMessage> staticMessages
        {
            get
            {
                if (HttpContext.Current.Application["wall"] == null)
                    HttpContext.Current.Application["wall"] = new Collection<WallMessage>();


                return (Collection<WallMessage>)HttpContext.Current.Application["wall"];
            }
            set
            {
                HttpContext.Current.Application["wall"] = value;
            }
        }

        public Collection<WallMessage> Messages
        {
            get
            {
                return MessageRepository.staticMessages;
            }
            set
            {
                MessageRepository.staticMessages = value;
            }
        }
      
    }
}