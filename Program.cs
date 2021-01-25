using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shortcut
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter cities: ");
            string cities = Console.ReadLine();
            string[] citiesList = cities.Split(", ");
            Console.WriteLine($"{citiesList[0]} - {citiesList[1]}");
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://wft-geo-db.p.rapidapi.com/v1/geo/cities/397/distance?toCityId=408"),
                Headers =
                {
                    { "x-rapidapi-key", "2ffecdcd93msh93292245ad8c723p1692fbjsna9d303ed7f73" },
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
