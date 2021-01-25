using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shortcut
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string key = Environment.GetEnvironmentVariable("X-RAPIDAPI-KEY");
            Console.Write("Enter cities: ");
            string cities = Console.ReadLine();
            string[] citiesList = cities.Split(", ");
            Console.WriteLine($"{citiesList[0]} - {citiesList[1]}");
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://wft-geo-db.p.rapidapi.com/v1/geo/cities/200/distance?distanceUnit=KM&toCityId=300"),
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
