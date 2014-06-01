using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingWall.UI.Presenters;
using Rhino.Mocks;
using System.Collections.Generic;
using TalkingWall.Domain;

namespace TalkingWall.UI.Presenter.Tests.MainPage
{
    [TestClass]
    public class MainPage_When_Post_Is_Clicked
    {
        ITalkingWallView _view;
        ICollection<WallMessage> _messages;
        WallMessage _testMessage;
        MockRepository mocks;


        [TestInitialize]
        public void SetUp()
        {
            _messages = MockRepository.GenerateMock<ICollection<WallMessage>>();
            _testMessage = new WallMessage() { Name = "Joe Smith", Message = "Test Message", TimeStamp = DateTime.MinValue };
            _view = MockRepository.GenerateMock<ITalkingWallView>();

        }

        [TestMethod]
        public void Presenter_Should_Add_New_Message_To_Message_Collection_and_BindDate()
        {
            
            _view.Expect(x => x.Name).Return(_testMessage.Name).Repeat.Once();
            _view.Expect(x => x.Message).Return(_testMessage.Message).Repeat.Once();

            _messages.Expect(x => x.Add(Arg<WallMessage>.Is.Anything)).Repeat.Once();

            _view.Expect(x => x.BindData(_messages)).Repeat.Once();

            MainPagePresenter presenter = new MainPagePresenter(_view, _messages);
            _view.Raise(x => x.PostMessageClick += null, this, EventArgs.Empty);

            _view.VerifyAllExpectations();
            _messages.VerifyAllExpectations();
        }
    }
}
