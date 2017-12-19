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
    class RequestActivity : Activity
    {

        //input fields
        private string usern;
        private string titlen;
        private string messageb;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Layout
            SetContentView(Resource.Layout.Request);

            Button readJson2  = FindViewById<Button>(Resource.Id.readJson2);
            Button sendData = FindViewById<Button>(Resource.Id.sendData);
            var editText = FindViewById<EditText>(Resource.Id.editText);
            var editText2 = FindViewById<EditText>(Resource.Id.editText2);
            var editText3 = FindViewById<EditText>(Resource.Id.editText3);
            TextView textView = FindViewById<TextView>(Resource.Id.textView);


            //save input
            editText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                usern = e.Text.ToString();

            };

            editText2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                titlen = e.Text.ToString();

            };

            editText3.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                messageb = e.Text.ToString();

            };


            // Get JSON
            readJson2.Click += async delegate
            {
                using (var client = new HttpClient())
                {
                    // send a GET request
                    var uri = "http://46.101.195.246:3000/api/technicalRequest";
                    var result = await client.GetStringAsync(uri);

                    //handling the answer
                    var posts = JsonConvert.DeserializeObject<List<PostBackend>>(result);

                    // generate the output
                    var post = posts.Last();
                    textView.Text = "Uusin viesti:\n\n" + post;
                }
            };

           

            // Post JSON
            sendData.Click += async delegate
            {
                using (var client = new HttpClient())
                {
                    // Create a new post
                    var novoPost = new PostBackend
                    {
                        user = usern,
                        title = titlen,
                        message = messageb
                    };

                    // create the request content and define Json
                    var json = JsonConvert.SerializeObject(novoPost);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    //  send a POST request
                    var uri = "http://46.101.195.246:3000/api/technicalRequest";
                    var result = await client.PostAsync(uri, content);

                    // on error throw a exception
                    result.EnsureSuccessStatusCode();

                    // handling the answer
                    var resultString = await result.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<PostBackend>(resultString);

                    // display the output in TextView
                    //textView.Text = post.ToString();
                }
            };
            
        }

    }

}