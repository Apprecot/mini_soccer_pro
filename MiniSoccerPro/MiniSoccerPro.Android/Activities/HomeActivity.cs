using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using MiniSoccerPro.Network;

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

            var api = new Api();

            api.GetPost(1).Subscribe((post) => {
                Console.WriteLine(post.title);
            });
        }
    }
}