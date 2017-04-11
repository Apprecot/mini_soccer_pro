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
    public class HomeActivity : AppCompatActivity, IBaseView
    {
        private ProgressBar pb;
        private TextView tv;
        private SynchronizationContext uiThread;

        public void Execute(Action action)
        {
            RunOnUiThread(action);
        }

        public void ShowError()
        {
                pb.Visibility = Android.Views.ViewStates.Gone;
                tv.Text = "Timed Out";
        }

        public void ShowUrl(Url url)
        {
            pb.Visibility = Android.Views.ViewStates.Gone;
            tv.Text = url.brandsimages_base_url;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_home);

            StrictMode.SetVmPolicy(new StrictMode.VmPolicy.Builder().DetectActivityLeaks().PenaltyLog().Build());

            StrictMode.SetThreadPolicy(new StrictMode.ThreadPolicy.Builder().DetectAll().PenaltyLog().Build());

            //tv = FindViewById<TextView>(Resource.Id.tv);
            //pb = FindViewById<ProgressBar>(Resource.Id.pb);

            pb.Visibility = Android.Views.ViewStates.Visible;

            var presenter = new BasePresenter(this);
            presenter.Start();

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_home);

            //_bottomBar = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            //var api = new Api();

            //api.GetPost(1).Subscribe((post) => {
            //    Console.WriteLine(post.title);
            //});

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