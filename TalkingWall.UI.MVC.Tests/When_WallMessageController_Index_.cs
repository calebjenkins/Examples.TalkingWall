using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingWall.Controllers;
using TalkingWall.Domain.Services;
using Rhino.Mocks;
using TalkingWall.Domain;
using System.Collections.ObjectModel;
using System.Web.Mvc;

namespace TalkingWall.UI.MVC.Tests
{
    [TestClass]
    public class When_WallMessageController_Index_
    {

        IWallMessageRepository repo;
        Collection<WallMessage> messages;

        [TestInitialize]
        public void setup()
        {
            repo = MockRepository.GenerateMock<IWallMessageRepository>();
            messages = new Collection<WallMessage>() {
                new WallMessage() { Message="Test 1", Name="Joe Smith", TimeStamp = DateTime.MinValue}
            };
        }

        [TestMethod]
        public void should_data_from_repo()
        {
            
            repo.Expect(x => x.Messages).Return(messages).Repeat.Once();

            WallController controller = new WallController(repo);
            var view = controller.Index() as ViewResult;
            var model = (Collection<WallMessage>) view.ViewData.Model;

            Assert.AreEqual(1, model.Count);
            Assert.AreEqual("Test 1", model[0].Message);

            repo.VerifyAllExpectations();
        }
    }
}
