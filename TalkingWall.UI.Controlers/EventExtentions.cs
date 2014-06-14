using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkingWall.Domain;

namespace TalkingWall.UI.Presenters
{
    public static class EventExtentions
    {
        public static void Raise(this EventHandler eventHandler)
        {
            if (eventHandler != null)
            {
                eventHandler(null, null);
            }
        }
        public static void Raise(this EventHandler eventHandler, object sender, EventArgs e)
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        public static void Raise<T>(this EventHandler<T> eventHandler,
            object sender, T e) where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }
    }
}
