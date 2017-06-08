using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUsers
{
    public class Utilities
    {
        public static List<GitHubUser> GetGitHubUsersList(string url)
        {
            return JsonConvert.DeserializeObject<List<GitHubUser>>(GetJsonResponse(url));
        }

        public static List<GitHubRepo> GetReposList(string url)
        {
            return JsonConvert.DeserializeObject<List<GitHubRepo>>(GetJsonResponse(url));
        }

        private static string GetJsonResponse(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            return response.Content;
        }
    }
}
