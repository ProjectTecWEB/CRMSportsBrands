using BackingServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BackingServices.Services
{
    public class ClientsService
    {
        public async Task<ClientesMo> GetIdNumberServiceAsync()
        {
            try
            {
                Console.WriteLine("Pidiendo info de Carnet");
                using (HttpClient client = new HttpClient())
                {
                    string idNumberURL = "https://random-data-api.com/api/users/random_user?size=10";

                    HttpResponseMessage response = await client.GetAsync(idNumberURL);
                    if (response.IsSuccessStatusCode)
                    {
                        string idNumberBody = await response.Content.ReadAsStringAsync();
                        ClientesMo idNumber = JsonConvert.DeserializeObject<ClientesMo>(idNumberBody);
                        return idNumber;
                    }
                    else
                    {
                        throw new Exception("HUBO FALLAS al pedir info de Carnet");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HUBO FALLAS al pedir info de Carnet");
                Console.WriteLine(ex.Message + ex.StackTrace);
                throw;
            }
        }
    }
}
