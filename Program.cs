using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shortcut
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            string key = Environment.GetEnvironmentVariable("X-RAPIDAPI-KEY");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://wft-geo-db.p.rapidapi.com/v1/geo/cities/397/distance?toCityId=408"),
                Headers =
                {
                    { "x-rapidapi-key", key },
                    { "x-rapidapi-host", "wft-geo-db.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}
