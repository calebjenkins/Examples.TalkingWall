using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingWall.UI.Presenters;
using Rhino.Mocks;
using System.Collections.Generic;
using TalkingWall.Domain;

namespace TalkingWall.UI.Presenter.Tests.MainPage
{
    [TestClass]
    public class When_Page_Loads
    {
        ITalkingWallView _view;
        MockRepository mocks;


        [TestInitialize]
        public void SetUp()
        {
            _view = MockRepository.GenerateMock<ITalkingWallView>();

        }

        [TestMethod]
        public void Presenter_Should_Check_PostBack()
        {
            _view.Expect(x => x.IsPostBack).Return(true).Repeat.Once();
            MainPagePresenter presenter = new MainPagePresenter( null);
            presenter.Initialize(_view);
            _view.Raise(x => x.PageLoad += null, this, EventArgs.Empty);

            _view.VerifyAllExpectations();
        }
        [TestMethod]
        public void Presenter_Should_Bind_Data_when_not_postback()
        {
            _view.Expect(x => x.IsPostBack).Return(false).Repeat.Once();
            _view.Expect(x => x.BindData(null)).Repeat.Once();
            MainPagePresenter presenter = new MainPagePresenter( null);
            presenter.Initialize(_view);
            _view.Raise(x => x.PageLoad += null, this, EventArgs.Empty);
           
            _view.VerifyAllExpectations();
        }
        [TestMethod]
        public void Presenter_Should_Not_Bind_Data_when_postback()
        {
            _view.Expect(x => x.IsPostBack).Return(true).Repeat.Once();
            _view.Expect(x => x.BindData(null)).Repeat.Never();
            MainPagePresenter presenter = new MainPagePresenter( null);
            presenter.Initialize(_view);
            _view.Raise(x => x.PageLoad += null, this, EventArgs.Empty);

            _view.VerifyAllExpectations();
        }
    }
}
