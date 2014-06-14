using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingWall.UI.Presenters;
using Rhino.Mocks;
using System.Collections.Generic;
using TalkingWall.Domain;
using TalkingWall.Domain.Services;
using System.Collections.ObjectModel;

namespace TalkingWall.UI.Presenter.Tests.MainPage
{
    [TestClass]
    public class MainPage_When_Post_Is_Clicked
    {
        ITalkingWallView _view;
        IWallMessageRepository _messageRepo;
        WallMessage _testMessage;


        [TestInitialize]
        public void SetUp()
        {
            _testMessage = new WallMessage() { Name = "Joe Smith", Message = "Test Message", TimeStamp = DateTime.MinValue };
            _view = MockRepository.GenerateMock<ITalkingWallView>();

        }

        [TestMethod]
        public void Presenter_Should_Add_New_Message_To_Message_Collection()
        {
            _view = MockRepository.GenerateMock<ITalkingWallView>();
            
            _view.Expect(x => x.Name).Return(_testMessage.Name).Repeat.Once();
            _view.Expect(x => x.Message).Return(_testMessage.Message).Repeat.Once();

           
            var _fakeRepo = new FakeRepo_ExpectsOneAdd();

            MainPagePresenter presenter = new MainPagePresenter(_view, _fakeRepo);
            _view.Raise(x => x.PostMessageClick += null, this, EventArgs.Empty);

            _fakeRepo.Verify();
        }
    }
    public class FakeRepo_ExpectsOneAdd : IWallMessageRepository
    {

        bool calledOnce = false;
        public FakeRepo_ExpectsOneAdd()
        {
            _messages = new Collection<WallMessage>();
        }

        Collection<WallMessage> _messages;
        public Collection<WallMessage> Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                if (_messages.Count == 1)
                    throw new Exception("Was only expecting 1 add, not a 2nd one");

                _messages = value;
            }
        }

        public void Verify()
        {
            if(_messages.Count != 1)
            {
                throw new Exception("Was expecing 1 new message, instead " + _messages.Count.ToString());
            }
        }
    }
}
