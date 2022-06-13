using Newtonsoft.Json;
using ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public class ExternalClientService
    {
        public async Task<ExternalClient> GetClientServiceAsync()
        {
            try
            {
                Console.WriteLine("Pidiendo la información del cliente");
                using (HttpClient client = new HttpClient())
                {
                    string URL = "https://random-data-api.com/api/users/random_user?size=10";

                    HttpResponseMessage response = await client.GetAsync(URL);
                    if (response.IsSuccessStatusCode)
                    {
                        string externalClientBody = await response.Content.ReadAsStringAsync();
                        
                        ExternalClient externalclient = JsonConvert.DeserializeObject<ExternalClient>(externalClientBody);
                        return externalclient;
                    }
                    else
                    {
                        throw new Exception("HUBO FALLAS al pedir la información del cliente");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HUBO FALLAS al pedir la información del cliente");
                Console.WriteLine(ex.Message + ex.StackTrace);
                throw;
            }
        }
    }
}
