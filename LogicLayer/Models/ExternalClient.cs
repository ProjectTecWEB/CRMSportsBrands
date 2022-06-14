using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class ExternalClient
    {
     
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<string> Roles { get; set; }
        public Dictionary<string, string> street_name { get; set; }
        public string phone_number { get; set; }
            
        
    }
       
 }
 
 
