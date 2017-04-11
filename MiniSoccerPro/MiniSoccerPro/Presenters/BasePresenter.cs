using MiniSoccerPro.IViews;
using MiniSoccerPro.Network;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

namespace MiniSoccerPro.Presenters
{
    public class BasePresenter
    {
        IBaseView _view;

        public BasePresenter(IBaseView view)
        {
            _view = view;
        }

        public void Start()
        {
            var api = new Api();

            api.GetPost(1)
              .SubscribeOn(NewThreadScheduler.Default)
              .Timeout(TimeSpan.FromMilliseconds(10000))
              .Subscribe((url) => {
                  _view.Execute(() => _view.ShowUrl(url));
              }, (error) => {
                  _view.Execute(()=>_view.ShowError());
              });
        }
    }
}
