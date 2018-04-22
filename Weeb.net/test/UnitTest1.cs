using System;
using Xunit;
using Weeb.net;
using System.Threading.Tasks;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            WeebClient client = new WeebClient();
            //token here
            string token = "";
            Task.Run(async () =>
            {
                // Actual test code here.
                await client.Authenticate(token, TokenType.Bearer);
                var img = await client.GetRandomAsync("hug", new string[] { }, FileType.Gif,false, NsfwSearch.False);
                Assert.NotNull(img);
            }).GetAwaiter().GetResult();
        }
    }
}
