using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkingWall.Domain
{
    public class WallMessage
    {
        public DateTime TimeStamp { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

    }
}
