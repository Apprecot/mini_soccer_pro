using MiniSoccerPro.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSoccerPro.IViews
{
    public interface IBaseView
    {
        void ShowUrl(Url url);
        void ShowError();
    }
}
