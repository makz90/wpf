using System;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace GitHubUsers
{
    public class Utilities
    {
        public async Task<List<T>> GetListOfType<T>(string url)
        {
            var data = await GetJsonResponse(url);
            return JsonConvert.DeserializeObject<List<T>>(data);
        }

        private async Task<string> GetJsonResponse(string url)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetStringAsync(url);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return string.Empty;
        }
    }
}