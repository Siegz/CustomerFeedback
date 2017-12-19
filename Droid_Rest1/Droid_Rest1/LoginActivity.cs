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
    [Activity(Label = "POIApplication", Icon = "@drawable/iconSmall", Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            //Initializing button from layout
            Button login = FindViewById<Button>(Resource.Id.login);

            //Login button click action
            login.Click += (object sender, EventArgs e) => {
                Android.Widget.Toast.MakeText(this, "Login Test!", Android.Widget.ToastLength.Short).Show();
            };

            login.Click += delegate {
                StartActivity(typeof(MenuActivity));
            };

        }
    }
}