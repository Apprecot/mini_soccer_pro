using MiniSoccerPro.Network;
using System;

namespace MiniSoccerPro.IViews
{
    public interface IBaseView
    {
        void ShowUrl(Url url);
        void ShowError();
        void ExecuteOnMainThread(Action action);
    }
}
