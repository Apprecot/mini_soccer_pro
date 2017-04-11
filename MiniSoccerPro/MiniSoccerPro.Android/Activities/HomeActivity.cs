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
using Android.Support.Design.Widget;
using static Android.Support.Design.Widget.BottomNavigationView;
using System.Reactive.Linq;
using MiniSoccerPro.Droid.Fragments;

namespace MiniSoccerPro.Droid.Activities
{
    [Activity(Label = "", MainLauncher =true)]
    public class HomeActivity : AppCompatActivity
    {
        private BottomNavigationView _bottomBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_home);

            _bottomBar = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            var api = new Api();

            api.GetPost(1).Subscribe((post) => {
                Console.WriteLine(post.title);
            });

            Observable.FromEventPattern<NavigationItemSelectedEventArgs>(
              handler => _bottomBar.NavigationItemSelected += handler,
              handler => _bottomBar.NavigationItemSelected -= handler
              )
              .Select(x => x.EventArgs)
              .Subscribe((args) =>
              {
                  switch(args.Item.ItemId)
                  {
                      case Resource.Id.action_team:
                          break;
                      case Resource.Id.action_tournaments:
                          break;
                      case Resource.Id.action_transfers:
                          SupportFragmentManager.BeginTransaction()
                            .SetTransitionStyle((int)FragmentTransit.FragmentFade)
                            .Replace(Resource.Id.fl_content, new MyTransfersFragment())
                            .Commit();
                          break;
                      case Resource.Id.action_stats:
                          break;
                      case Resource.Id.action_profile:
                          break;
                  }
              });
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }
    }
}