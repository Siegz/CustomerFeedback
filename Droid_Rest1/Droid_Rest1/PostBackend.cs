using Newtonsoft.Json;
using System.Collections.Generic;

namespace Droid_Rest1
{
    public class PostBackend
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string user { get; set; }
        public float grade { get; set; }


        public override string ToString()
        {
            return string.Format(
                "Post Id: {0}\nTitle: {1}\nUsername: {2}\nBody: {3}",
                _id, title, user, message);
        }
    }
}