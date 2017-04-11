using MiniSoccerPro.IViews;
using MiniSoccerPro.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
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
			   .ObserveOn(SynchronizationContext.Current)
              .Timeout(TimeSpan.FromMilliseconds(100))
              .Subscribe((url) => {
                  _view.ShowUrl(url);
              }, (error) => {
                  _view.ShowError();
              });
        }
    }
}
