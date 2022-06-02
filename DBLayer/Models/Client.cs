﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class Client: Entity
    {
        public string fullName { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int Ranking { get; set; }
        public string IdClient { get; set; }

    }
}
