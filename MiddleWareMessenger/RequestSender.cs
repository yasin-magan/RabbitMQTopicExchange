using MiddleWareMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiddleWareMessenger
{
    public class RequestSender
    {
        public async Task<string> PostRequestAync(Delivery delivery)
        {
            var json = JsonSerializer.Serialize(delivery);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:7181/api/Delivery";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result.ToString();
        }
    }
}
