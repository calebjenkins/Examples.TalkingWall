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
    public class FakeRepo_InMemoryCollection : IWallMessageRepository
    {

        public FakeRepo_InMemoryCollection()
        {
            Messages = new Collection<WallMessage>();
        }

        public Collection<WallMessage> Messages { get; set; }

    }
}
