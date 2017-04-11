using System;
using System.Reactive.Disposables;

namespace MiniSoccerPro.Extensions
{
    public static class ObservableExtesions
    {
        public static TDisposable DisposeWith<TDisposable>(this TDisposable observable, CompositeDisposable disposables) where TDisposable : class, IDisposable
        {
            if (observable != null)
                disposables.Add(observable);

            return observable;
        }
    }
}
