using System.Collections.Generic;

namespace InstagramApiExperiment.Models
{
    public class Comments
    {
        public int count { get; set; }
    }

    public class From
    {
        public string username { get; set; }
    }

    public class Caption
    {
        public string created_time { get; set; }
        public string text { get; set; }
        public From from { get; set; }
        public string id { get; set; }
    }

    public class Likes
    {
        public int count { get; set; }
    }

    public class LowResolution
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class StandardResolution
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Images
    {
        public LowResolution low_resolution { get; set; }
        public Thumbnail thumbnail { get; set; }
        public StandardResolution standard_resolution { get; set; }
    }
    
    public class Videos
    {
        public LowResolution low_resolution { get; set; }
        public StandardResolution standard_resolution { get; set; }
        public object users_in_photo { get; set; }
        public string filter { get; set; }
        public List<string> tags { get; set; }
        public Comments comments { get; set; }
        public Caption caption { get; set; }
        public Likes likes { get; set; }
        public string link { get; set; }
        public User user { get; set; }
        public string created_time { get; set; }
        public Images images { get; set; }
        public string id { get; set; }
        public object location { get; set; }
    }

    public class Datum
    {
        public string type { get; set; }
        public List<object> users_in_photo { get; set; }
        public string filter { get; set; }
        public List<string> tags { get; set; }
        public Comments comments { get; set; }
        public Caption caption { get; set; }
        public Likes likes { get; set; }
        public string link { get; set; }
        public User user { get; set; }
        public string created_time { get; set; }
        public Images images { get; set; }
        public string id { get; set; }
        public object location { get; set; }
        public Videos videos { get; set; }
    }

    public class RootObject
    {
        public List<Datum> data { get; set; }
    }
}
