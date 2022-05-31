using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using ServicesLayer.Models;
using System.Collections.Generic;
using ServicesLayer.Exceptions;
namespace Services
{
    public class ClientsServices
    {
        public async Task<string> GetClientsServiceAsync()
        {
            try
            {
                Console.WriteLine("Pidientod datos");
                using (HttpClient clien = new HttpClient()) ;
                {

                    string clientsURL = "https://random-data-api.com/api/users/random_user?size=10";
                    HttpResponseMessage response = await clien.GetAsync(clientsURL);
                    if (response.IsSuccessStatusCode)
                    {
                        string clientBody = await response.Content.ReadAsStringAsync();
                        Clients clients = JsonConvert.DeserializeObject<Clients>(clientsURL);
                        return clientsURL.valid_us_ssn;

                    }
            }
        }
    }
}
