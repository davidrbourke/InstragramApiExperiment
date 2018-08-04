namespace InstagramApiExperiment.Models
{
    public class ByTag
    {
        public string access_token { get; set; }
        public string TagName { get; set; }
        public string Message { get; set; }
        public RootObject Root { get; set; }
    }
}
