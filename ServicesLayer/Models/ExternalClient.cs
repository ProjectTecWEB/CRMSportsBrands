using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Models
{
    public class ExternalClient 
    {
        public int n = 10;

        double[] x;
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Dictionary<string,string> street_name { get; set; }
        public IList<string> Roles { get; set; }

        public string phone_number { get; set; }
    }
 
}
