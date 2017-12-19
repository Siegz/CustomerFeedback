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
    [Activity(Label = "Feedbacktest", Icon = "@drawable/iconSmall", Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    class FeedbackActivity : Activity
    {

        //input fields
        private float rating;
        private string messageb;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Layout
            SetContentView(Resource.Layout.Feedback);

            Button sendData2 = FindViewById<Button>(Resource.Id.sendData2);
            var editText4 = FindViewById<EditText>(Resource.Id.editText4);
            RatingBar ratingbar = FindViewById<RatingBar>(Resource.Id.ratingbar);


            //save input

            ratingbar.RatingBarChange += (o, e) => {
                Toast.MakeText(this, "New Rating: " + ratingbar.Rating.ToString(), ToastLength.Short).Show();
                rating = ratingbar.Rating;
            };

            editText4.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                messageb = e.Text.ToString();

            };


            // Post JSON
            sendData2.Click += async delegate
            {
                using (var client = new HttpClient())
                {
                    // Create a new post
                    var novoPost = new PostBackend
                    {
                        grade = rating,
                        message = messageb
                    };

                    // create the request content and define Json
                    var json = JsonConvert.SerializeObject(novoPost);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    //  send a POST request
                    var uri = "http://46.101.195.246:3000/api/feedback";
                    var result = await client.PostAsync(uri, content);

                    // on error throw a exception
                    result.EnsureSuccessStatusCode();

                    // handling the answer
                    var resultString = await result.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<PostBackend>(resultString);

                }
            };

        }

    }
}