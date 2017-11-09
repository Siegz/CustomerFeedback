using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;
using Android.App;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using Android.Webkit;

namespace Droid_Rest1
{
    // icon, title 
    [Activity(Label = "Blogitest", Icon = "@drawable/iconSmall", Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Layout
            SetContentView(Resource.Layout.Main);

            Button readJson = FindViewById<Button>(Resource.Id.readJson);
            //TextView textView = FindViewById<TextView>(Resource.Id.textView);
            WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
            //ListView listView = FindViewById<ListView>(Resource.Id.listView);





            // Get JSON
            readJson.Click += async delegate
            {
                using (var client = new HttpClient())
                {
                    // send a GET request
                    var uri = "http://www.devatus.fi/wp-json/wp/v2/posts";
                    var result = await client.GetStringAsync(uri);

                    //handling the answer
                    var posts = JsonConvert.DeserializeObject<List<Post>>(result);

                    // generate the output
                    // test two posts
                    var post =posts.First();
                    var post2 = posts.Last();
                    //textView.Text = "Blogiviestit:\n\n" + post + post2;
                    localWebView.LoadData(post.ToString() + post2.ToString(), "text/html", null);
                }
            };

        }

    }

}

