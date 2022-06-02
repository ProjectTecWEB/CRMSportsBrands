using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using DBLayer.Models;

namespace LogicLayer.Managers
{
    public class ClientManager
    {
        private UnitOfWork _uow;
        public ClientManager(UnitOfWork uow)
        {
            _uow = uow;
          
        }

        public List<LogicLayer.Models.Client> GetClients()
        {
            List < DBLayer.Models.Client> clientFromDB = _uow.ClientRepository.GetAll().Result;
            List<LogicLayer.Models.Client> mappedClients = new List<LogicLayer.Models.Client>();

            foreach (DBLayer.Models.Client client in clientFromDB)
            {
                mappedClients.Add(new LogicLayer.Models.Client()
                {
                    fullName = client.fullName,
                    Id = client.Id,
                    Address = client.Address,
                    PhoneNumber = client.PhoneNumber,
                    Ranking = client.Ranking,
                    IdClient =client.IdClient
                    
                }); 
            }

            return mappedClients;
        }
        public Client PostClient(Client client)
        {

            _uow.ClientRepository.CreateClient(client);
            _uow.Save();
            return client;
        }
        public Client UpdateClient(Client client)
        {
            _uow.ClientRepository.UpdateClient(client);
            _uow.Save();
            return client;
        }
        public Client DeleteClient(Client client)
        {
            _uow.ClientRepository.DeleteClient(client);
            _uow.Save();
            return client;
        }
    }
}

