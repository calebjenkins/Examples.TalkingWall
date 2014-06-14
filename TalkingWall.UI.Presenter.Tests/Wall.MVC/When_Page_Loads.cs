using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingWall.Controllers;
using TalkingWall.Domain;
using System.Collections.ObjectModel;
using Rhino.Mocks;
using TalkingWall.Domain.Services;

namespace TalkingWall.UI.Presenter.Tests.Wall.MVC
{
    [TestClass]
    public class When_Page_Loads
    {

        [TestMethod]
        public void Controller_Should_Inject_Data()
        {
            
            ICollection<WallMessage> msgs = MockRepository.GenerateMock<ICollection<WallMessage>>();
            IWallMessageRepository repo = MockRepository.GenerateMock<IWallMessageRepository>();

            WallController controller = new WallController(repo);

            var actionResult =  controller.Index();

            

            
            // _view.Raise(x => x.PageLoad += null, this, EventArgs.Empty);

            // _view.VerifyAllExpectations();
        }
    }
}
