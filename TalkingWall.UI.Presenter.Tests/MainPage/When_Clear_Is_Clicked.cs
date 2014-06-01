using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingWall.UI.Presenters;
using Rhino.Mocks;
using System.Collections.Generic;
using TalkingWall.Domain;

namespace TalkingWall.UI.Presenter.Tests.MainPage
{
    [TestClass]
    public class When_Clear_Is_Clicked
    {
        ITalkingWallView _view;
        ICollection<WallMessage> _messages;
        MockRepository mocks;


        [TestInitialize]
        public void SetUp()
        {
            _messages = MockRepository.GenerateMock<ICollection<WallMessage>>();
            _view = MockRepository.GenerateMock<ITalkingWallView>();

        }

        [TestMethod]
        public void Presenter_Should_Clear_Messages_and_BindDate()
        {

            
            _messages.Expect(x => x.Clear()).Repeat.Once();

            _view.Expect(x => x.BindData(_messages)).Repeat.Once();

            MainPagePresenter presenter = new MainPagePresenter(_view, _messages);
            _view.Raise(x => x.ClearMessagesClick += null, this, EventArgs.Empty);

            _view.VerifyAllExpectations();
            _messages.VerifyAllExpectations();
        }
    }
}
