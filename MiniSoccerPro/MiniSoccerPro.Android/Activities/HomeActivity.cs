using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using MiniSoccerPro.Network;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using Android.Widget;

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

            var api = new Api();

            var tv = FindViewById<TextView>(Resource.Id.tv);
            var pb = FindViewById<ProgressBar>(Resource.Id.pb);

            pb.Visibility = Android.Views.ViewStates.Visible;

            api.GetPost(1)
               .SubscribeOn(NewThreadScheduler.Default)
               .ObserveOn(Android.App.Application.SynchronizationContext)
               .Timeout(TimeSpan.FromMilliseconds(100))
               .Subscribe((post) => {
                pb.Visibility = Android.Views.ViewStates.Gone;
                tv.Text = post.brandsimages_base_url;
            }, (error)=> {
                pb.Visibility = Android.Views.ViewStates.Gone;
                tv.Text = "Timed Out";
            });

        }
    }
}