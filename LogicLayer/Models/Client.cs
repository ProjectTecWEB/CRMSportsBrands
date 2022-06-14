using System;


namespace LogicLayer.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }

        public string secondName { get; set; }
        public string firstLastName { get; set; }

        public string secondLastName { get; set; }
        public int Ci{ get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Ranking { get; set; }
        public string IdClient { get; set; }
    }
}
