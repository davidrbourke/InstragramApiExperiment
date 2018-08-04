using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InstagramApiExperiment.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace InstagramApiExperiment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string clientId = _configuration["ClientId"];
            string redirectUri = _configuration["RedirectUri"];
            ViewBag.ClientId = clientId;
            ViewBag.RedirectUri = redirectUri;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InstagramUserDetails([FromForm] Code code)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.instagram.com");
            string clientId = _configuration["ClientId"];
            string redirectUri = _configuration["RedirectUri"];
            string clientSecret = _configuration["INSTAPPCLIENTSECRET"];

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
                new KeyValuePair<string, string>("code", code.InstagramCode)
            });

            var result = await client.PostAsync("/oauth/access_token", content);

            string resultContent = await result.Content.ReadAsStringAsync();

            OAuthToken token = Newtonsoft.Json.JsonConvert.DeserializeObject<OAuthToken>(resultContent);

            return View(token);
        }

        
        [HttpPost]
        public async Task<IActionResult> ByTag([FromForm] ByTag tag)
        {

            if (string.IsNullOrWhiteSpace(tag.TagName))
            {
                tag.Message = "Search by tag - no tag";
                return View("ByTag", tag);
            }
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.instagram.com");

            string parameters = $"/v1/tags/{tag.TagName}/media/recent?access_token={tag.access_token}";

            var result = await client.GetAsync(parameters);

            string resultContent = await result.Content.ReadAsStringAsync();

            RootObject response = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(resultContent);
            tag.Root = response;

            return View("ByTag", tag);
        }
        
    }
}
