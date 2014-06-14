using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingWall.Controllers;
using TalkingWall.Domain.Services;
using Rhino.Mocks;
using TalkingWall.Domain;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using TalkingWall.ViewModels;

namespace TalkingWall.UI.MVC.Tests
{
    [TestClass]
    public class When_WallMessageController_Create_
    {

        WallMessage _testMessage;
        IWallMessageRepository repo;
        Collection<WallMessage> messages;

        [TestInitialize]
        public void setup()
        {
            repo = MockRepository.GenerateMock<IWallMessageRepository>();
            messages = new Collection<WallMessage>() {
                    new WallMessage() { Message="Test 1", Name="Joe Smith", TimeStamp = DateTime.MinValue}
                };

            _testMessage = new WallMessage() { Message = "Test 2", Name = "John Smith", TimeStamp = DateTime.MaxValue };
        }

        [TestMethod]
        public void should_add_data_to_repo()
        {

            IWallMessageRepository repo = new FakeRepo_InMemoryCollection();
            WallController controller = new WallController(repo);


            var view = controller.Create(_testMessage) as ViewResult;
            Assert.AreEqual("Index", view.ViewName);


            var vm = (WallViewModel)view.ViewData.Model;

            Assert.AreEqual(1, vm.Messages.Count);
            Assert.AreEqual("Test 2", vm.Messages[0].Message);   
        }

        [TestMethod]
        public void should_keep_username_and_clear_message()
        {
            IWallMessageRepository repo = new FakeRepo_InMemoryCollection();
            WallController controller = new WallController(repo);

           
            var view = controller.Create(_testMessage) as ViewResult;
            Assert.AreEqual("Index", view.ViewName);


            var vm = (WallViewModel)view.ViewData.Model;
            Assert.AreEqual(vm.Name, _testMessage.Name);
            Assert.AreEqual(vm.Message, string.Empty);

            Assert.AreEqual(1, vm.Messages.Count);
            Assert.AreEqual("Test 2", vm.Messages[0].Message);            
        }
    }
}