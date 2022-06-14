﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class Client: Entity
    {
        public string firstName { get; set; }

        public string secondName { get; set; }
        public string firstLastName { get; set; }

        public string secondLastName { get; set; }

        public int Id { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int Ranking { get; set; }
       

    }
}
