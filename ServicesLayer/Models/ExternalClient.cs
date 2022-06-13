using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Models
{
    public class ExternalClient
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string street_name { get; set; }
        public IList<string> Roles { get; set; }

        public int phone_number { get; set; }
    }
}
