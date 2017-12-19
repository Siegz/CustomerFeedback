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

namespace Droid_Rest1
{
    [Activity(Label = "MenuActivity", Icon = "@drawable/iconSmall", Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class MenuActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Menu);

            //Initializing button from layout
            Button blog = FindViewById<Button>(Resource.Id.blog);
            Button request = FindViewById<Button>(Resource.Id.request);
            Button feedback = FindViewById<Button>(Resource.Id.feedback);

            blog.Click += delegate {
                StartActivity(typeof(MainActivity));
            };

            request.Click += delegate {
                StartActivity(typeof(RequestActivity));
            };

            feedback.Click += delegate {
                StartActivity(typeof(FeedbackActivity));
            };
        }
    }
}