using System;
using System.Collections.Generic;
using System.Text;

namespace BackingServices.Models
{
    public class ClientesMo
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string valid_us_ssn { get; set; }
        public string invalid_us_ssn { get; set; }
    }
}