using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;

namespace MiniSoccerPro.Droid.Fragments
{
    public class MyTransfersFragment : Fragment
    {

        public MyTransfersFragment() { }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.fragment_transfers, container, false);

            var tabLayout = rootView.FindViewById<TabLayout>(Resource.Id.tabs);
            var viewpager = rootView.FindViewById<ViewPager>(Resource.Id.viewpager);

            tabLayout.SetupWithViewPager(viewpager);

            tabLayout.GetTabAt(0).SetIcon(Resource.Drawable.ic_player);
            tabLayout.GetTabAt(1).SetIcon(Resource.Drawable.ic_contract);
            tabLayout.GetTabAt(2).SetIcon(Resource.Drawable.ic_earth);
            tabLayout.GetTabAt(3).SetIcon(Resource.Drawable.ic_news);

            return rootView;
        }
    }
}