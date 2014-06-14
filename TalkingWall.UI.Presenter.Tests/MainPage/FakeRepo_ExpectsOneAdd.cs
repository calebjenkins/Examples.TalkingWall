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
            if (_messages.Count != 1)
            {
                throw new Exception("Was expecing 1 new message, instead " + _messages.Count.ToString());
            }
        }
    }
}
