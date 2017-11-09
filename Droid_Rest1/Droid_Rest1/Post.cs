using Newtonsoft.Json;
using System.Collections.Generic;

namespace Droid_Rest1
{
    public class Post
    {

        public string date { get; set; }
        public title title { get; set; }
        public Content Content { get; set; }

        //public List<Content> content { get; set; }
        //public string Title { get; set; }
        //public int UserId { get; set; }
        //[JsonProperty("content")]
        //public string Content { get; set; }
        //public string Rendered { get; set; }

        public override string ToString()
        {
            return string.Format(
                "<b>Date: {0}</b>\n<h1>{1}</h1>\n{2}",
                date, title.rendered, Content.rendered);
        }
    }

    //Sub-elements
    public class title
    {
        public string rendered { get; set; }
    }

    public class Content
    {
        public string rendered { get; set; }
    }
}