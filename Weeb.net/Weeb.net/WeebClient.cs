using System;
using System.Threading.Tasks;
using Weeb.net.Data;

namespace Weeb.net
{
    public class WeebClient
    {
        private WeebHttp _weebHttp;
        internal const string WeebNetVersion = "1.0.0-alpha.1";

        //https://docs.weeb.sh/
        
        public async void Authenticate(string token)
        {
            _weebHttp = new WeebHttp(token);
            var welcome = await _weebHttp.Welcome();
            Console.WriteLine($"Connected to Weeb Api version: {welcome.Version}\nUsing Weeb.net wrapper {WeebNetVersion}");
        }

        public async Task<TypesData> GetTypesAsync(bool hidden = false)
        {
            return await _weebHttp.GetTypes(hidden);
        }
    }
}