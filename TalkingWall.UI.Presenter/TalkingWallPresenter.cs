using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkingWall.Domain;

namespace TalkingWall.UI.Presenter
{
    public class TalkingWallPresenter
    {
        ITalkingWallView view;
        Collection<WallMessage> Messages;

        /// <summary>
        /// Initializes a new instance of the TalkingWallPresenter class.
        /// </summary>
        /// <param name="view"></param>
        public TalkingWallPresenter(ITalkingWallView view, Collection<WallMessage> Messages)
        {
            this.view = view;
            this.Messages = Messages;
            view.PageLoad += view_PageLoad;

        }

        void view_PageLoad(object sender, EventArgs e)
        {
            if(!view.IsPostBack)
            {
                
            }
        }


    }

}
