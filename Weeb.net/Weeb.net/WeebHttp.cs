using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weeb.net.Data;

namespace Weeb.net
{
    internal class WeebHttp
    {
        private const string BaseUrl = "https://api.weeb.sh/";
        private string _token;
        private readonly HttpClient _client;

        /// <summary>
        /// Initialize the Weeb.api wrapper using your API token
        /// </summary>
        /// <param name="token">Your weeb api token</param>
        public WeebHttp(string token)
        {
            _token = token;
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = true
            };
            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl),
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        internal async Task<WelcomeData> Welcome()
        {
            //get result
            var result = await _client.GetStringAsync(Endpoints.Images);
            //convert from json to usable c# objects
            return JsonConvert.DeserializeObject<WelcomeData>(result);
            
        }

        internal async Task<TypesData> GetTypes(bool hidden)
        {
            var result = await _client.GetStringAsync(Endpoints.Types+$"?hidden={hidden}");
            return JsonConvert.DeserializeObject<TypesData>(result);
        }

        internal async Task<TagsData> GetTags(bool hidden)
        {
            var result = await _client.GetStringAsync(Endpoints.Tags+$"?hidden={hidden}");
            return JsonConvert.DeserializeObject<TagsData>(result);
        }

        internal async Task<RandomData> GetRandomImage(string type, string tags, bool hidden, bool nsfw)
        {
            string query = "";
            if (!string.IsNullOrWhiteSpace(type))
                query += $"&type={type}";
            if (!string.IsNullOrWhiteSpace(tags))
                query += $"&tags={tags}";
            query += $"&hidden={hidden}&nsfw={nsfw}";
            query = query.Substring(1, query.Length);
            query = "?" + query;

            var result = await _client.GetStringAsync(Endpoints.Random + query);
            return JsonConvert.DeserializeObject<RandomData>(result);
        }
    }
}