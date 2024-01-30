using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace _7DaysOfCode.Services
{
    public class ApiService
    {
        public static T Get<T>(string apiUrl)
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            else
            {
                Console.WriteLine($"Erro na chamada à API. Código: {response.StatusCode}, Mensagem: {response.ErrorMessage}");
                return default(T);
            }
        }
    }
}