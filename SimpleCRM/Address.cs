using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SimpleCRM
{
    public class Address
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string Code { get; set; }
        public string AddressComplement { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public async Task<string> GetAddressRequest(string code)
        {
            string url = $"https://viacep.com.br/ws/{code}/json/";
            using HttpClient client = new HttpClient();
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var requestResponse = await response.Content.ReadAsStringAsync();
                        return requestResponse;
                    }
                    else
                    {
                        Console.WriteLine($"Erro: {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }
    }
}
