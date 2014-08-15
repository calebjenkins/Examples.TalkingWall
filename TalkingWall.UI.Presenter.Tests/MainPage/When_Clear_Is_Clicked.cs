using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingWall.UI.Presenters;
using Rhino.Mocks;
using System.Collections.Generic;
using TalkingWall.Domain;
using TalkingWall.Data;
using System.Collections.ObjectModel;

namespace TalkingWall.UI.Presenter.Tests.MainPage
{
    [TestClass]
    public class When_Clear_Is_Clicked
    {
        ITalkingWallView _view;
        ICollection<WallMessage> _messages;
        IWallData _data;
        MockRepository mocks;


        [TestInitialize]
        public void SetUp()
        {
            _messages = new Collection<WallMessage>(); // MockRepository.GenerateMock<ICollection<WallMessage>>();
            _data = MockRepository.GenerateMock<IWallData>();
            _view = MockRepository.GenerateMock<ITalkingWallView>();

        }

        [TestMethod]
        public void Presenter_Should_Clear_Messages_and_BindDate()
        {

            
            _data.Expect(x => x.Messages.Clear()).Repeat.Once();
         //   _data.Expect(x => x.Messages).Return(_messages).Repeat.Any;

            _view.Expect(x => x.BindData(_messages)).Repeat.Once();

            MainPagePresenter presenter = new MainPagePresenter(_data);
            presenter.Initialize(_view);
            _view.Raise(x => x.ClearMessagesClick += null, this, EventArgs.Empty);

            _view.VerifyAllExpectations();
            // _messages.VerifyAllExpectations();
        }
    }
}
