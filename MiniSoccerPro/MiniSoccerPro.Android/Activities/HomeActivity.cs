using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using MiniSoccerPro.Network;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using Android.Widget;
using MiniSoccerPro.Presenters;
using MiniSoccerPro.IViews;
using System.Threading;

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

            tv = FindViewById<TextView>(Resource.Id.tv);
            pb = FindViewById<ProgressBar>(Resource.Id.pb);

            pb.Visibility = Android.Views.ViewStates.Visible;

            var presenter = new BasePresenter(this);
            presenter.Start();
        }
    }
}