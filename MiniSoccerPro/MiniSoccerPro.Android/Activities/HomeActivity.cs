using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using MiniSoccerPro.Network;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using Android.Widget;
using System.Threading;
using MiniSoccerPro.IViews;
using MiniSoccerPro.Presenters;

namespace MiniSoccerPro.Droid.Activities
{
    [Activity(Label = "", MainLauncher =true)]
    public class HomeActivity : AppCompatActivity 
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_home);

            StrictMode.SetVmPolicy(new StrictMode.VmPolicy.Builder().DetectActivityLeaks().PenaltyLog().Build());

            StrictMode.SetThreadPolicy(new StrictMode.ThreadPolicy.Builder().DetectAll().PenaltyLog().Build());

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_home);

            //_bottomBar = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            //Observable.FromEventPattern<NavigationItemSelectedEventArgs>(
            //  handler => _bottomBar.NavigationItemSelected += handler,
            //  handler => _bottomBar.NavigationItemSelected -= handler
            //  )
            //  .Select(x => x.EventArgs)
            //  .Subscribe((args) =>
            //  {
            //      switch (args.Item.ItemId)
            //      {
            //          case Resource.Id.action_team:
            //              break;
            //          case Resource.Id.action_tournaments:
            //              break;
            //          case Resource.Id.action_transfers:
            //              SupportFragmentManager.BeginTransaction()
            //                .SetTransitionStyle((int)FragmentTransit.FragmentFade)
            //                .Replace(Resource.Id.fl_content, new MyTransfersFragment())
            //                .Commit();
            //              break;
            //          case Resource.Id.action_stats:
            //              break;
            //          case Resource.Id.action_profile:
            //              break;
            //      }
            //  });
        }
    }
}