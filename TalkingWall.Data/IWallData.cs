using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkingWall.Domain;

namespace TalkingWall.Data
{
    public interface IWallData
    {
        Collection<WallMessage> Messages { get;set;}
    }
}
