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
            for (int i = 0; i < citiesList.Length; i++)
            {
                string uri = String.Format("https://api.opencagedata.com/geocode/v1/json?q={0}&key={1}&language=en&pretty=1&no_annotations=1", citiesList[i], key);
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(uri),
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
}
