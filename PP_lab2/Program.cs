using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PP_lab2
{
    internal class Program
    {
        private static string base_url = "https://openexchangerates.org/api/";
        public static string date = "2025-03-15"; //YYYY-MM-DD
        private static string app_id = "57e827d470e3487992da51c170351565";
        private static string url = $"{base_url}historical/{date}.json?app_id={app_id}";
        private static HttpClient client = new HttpClient();

        public static async Task<string> FetchExchangeRates()
        {
            HttpResponseMessage response = await client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }

        public static async Task DisplayExchangeRates()
        {
            string jsonResponse = await FetchExchangeRates();

            var options = new JsonSerializerOptions{
                PropertyNameCaseInsensitive = true
            };

            ExchangeRateData exchangeData = JsonSerializer.Deserialize<ExchangeRateData>(jsonResponse, options);
            Console.WriteLine(exchangeData.ToString());
        }

        static void Main(string[] args)
        {
            Task fetchTask = DisplayExchangeRates();
            fetchTask.Wait();
        }
    }
}