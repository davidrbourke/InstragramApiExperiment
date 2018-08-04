using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstagramApiExperiment.Models
{
    public class OAuthToken
    {
        public string access_token { get; set; }
        public User user { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public string profile_picture { get; set; }
    }
}
