using System;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

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
                using (var client = new HttpClient())
                {
                    using (var r = await client.GetAsync(new Uri(url)))
                    {
                        string result = await r.Content.ReadAsStringAsync();
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return string.Empty;
        }
    }
}