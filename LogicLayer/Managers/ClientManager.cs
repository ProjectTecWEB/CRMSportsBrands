﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using DBLayer.Models;
using ServicesLayer.Services;

namespace LogicLayer.Managers
{
    public class ClientManager
    {
        private UnitOfWork _uow;
        private ExternalClientService _externalClientService;

        private string code;
        public ClientManager(UnitOfWork uow, ExternalClientService externalClientService)
        {
            _uow = uow;
            code = "";
            _externalClientService = externalClientService;

        }

        public List<LogicLayer.Models.Client> GetClients()
        {
            List<DBLayer.Models.Client> clientFromDB = _uow.ClientRepository.GetAll().Result;
            List<LogicLayer.Models.Client> mappedClients = new List<LogicLayer.Models.Client>();

            foreach (DBLayer.Models.Client client in clientFromDB)
            {
                mappedClients.Add(new LogicLayer.Models.Client()
                {
                    IdClient = client.IdClient,
                    firstId = client.firstId,
                    firstName = client.firstName,
                    secondName = client.secondName,
                    firstLastName = client.firstLastName,
                    secondLastName = client.secondLastName,
                    Id = client.Id,
                    Address = client.Address,
                    PhoneNumber = client.PhoneNumber,
                    Ranking = client.Ranking,
                    

                });
            }

            return mappedClients;
        }
        public LogicLayer.Models.Client PostClient(LogicLayer.Models.Client client)
        {

            DBLayer.Models.Client clientToCreate = new DBLayer.Models.Client()
            {
                IdClient = genCode(client),
                firstId = Guid.NewGuid(),
                firstName = client.firstName,
                secondName = client.secondName,
                firstLastName = client.firstLastName,
                secondLastName = client.secondLastName,
                Id = client.Id,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber,
                Ranking = client.Ranking

            };
            _uow.ClientRepository.CreateClient(clientToCreate);
            _uow.Save();
            return new LogicLayer.Models.Client()
            {
                firstId = clientToCreate.firstId,
                IdClient = clientToCreate.IdClient,
                firstName = clientToCreate.firstName,
                secondName = clientToCreate.secondName,
                firstLastName = clientToCreate.firstLastName,
                secondLastName = clientToCreate.secondLastName,
                Id = clientToCreate.Id,
               
                Address = clientToCreate.Address,
                PhoneNumber = clientToCreate.PhoneNumber,
                Ranking = clientToCreate.Ranking
            };
        }

        private string genCode(LogicLayer.Models.Client client)
        {
            code = client.firstName.Substring(0, 1) + client.firstLastName.Substring(0, 1) + client.secondLastName.Substring(0, 1) + "-" + client.Id.ToString();
            return code;
        }
        private string genExCode(LogicLayer.Models.ExternalClient client)
        {
            code = client.FirstName.Substring(0, 1) + client.LastName.Substring(0, 1) + "-" + client.Id.ToString();
            return code;
        }

        public LogicLayer.Models.Client UpdateClient(LogicLayer.Models.Client client)
        {
            DBLayer.Models.Client clientToUpdate = _uow.ClientRepository.GetById(client.firstId);
            clientToUpdate.firstName = client.firstName;
            clientToUpdate.secondName = client.secondName;
            clientToUpdate.firstLastName = client.firstLastName;
            clientToUpdate.secondLastName = client.secondLastName;
            clientToUpdate.Id = client.Id;
            clientToUpdate.Address = client.Address;
            clientToUpdate.PhoneNumber = client.PhoneNumber;
            clientToUpdate.Ranking = client.Ranking;

            _uow.ClientRepository.UpdateClient(clientToUpdate);
            _uow.Save();
            return new LogicLayer.Models.Client()
            {
                IdClient = clientToUpdate.IdClient,
                firstName = clientToUpdate.firstName,
                secondName = clientToUpdate.secondName,
                firstLastName = clientToUpdate.firstLastName,
                secondLastName = clientToUpdate.secondLastName,
                Id = clientToUpdate.Id,
                firstId = clientToUpdate.firstId,
                Address = clientToUpdate.Address,
                PhoneNumber = clientToUpdate.PhoneNumber,
                Ranking = clientToUpdate.Ranking
            };
        }
        public LogicLayer.Models.Client DeleteClient(LogicLayer.Models.Client client)
        {
            DBLayer.Models.Client clientToDelete = _uow.ClientRepository.GetById(client.firstId);
            _uow.ClientRepository.DeleteClient(clientToDelete);
            _uow.Save();
            return new LogicLayer.Models.Client()
            {
                IdClient = clientToDelete.IdClient,
                firstName = clientToDelete.firstName,
                secondName = clientToDelete.secondName,
                firstLastName = clientToDelete.firstLastName,
                secondLastName = clientToDelete.secondLastName,
                Id = clientToDelete.Id,
                Address = clientToDelete.Address,
                PhoneNumber = clientToDelete.PhoneNumber,
                Ranking = clientToDelete.Ranking
            };
        }

        public LogicLayer.Models.ExternalClient GetExternalClient()
        {
            ServicesLayer.Models.ExternalClient externalClientFromService = _externalClientService.GetClientServiceAsync().Result;
            return new LogicLayer.Models.ExternalClient()
            {
                Id = externalClientFromService.id,
                FirstName = externalClientFromService.first_name,
                LastName = externalClientFromService.last_name,
                street_name = externalClientFromService.street_name,
                phone_number = externalClientFromService.phone_number
            };

    
  
        }
        public LogicLayer.Models.Client PostExternalClient(LogicLayer.Models.ExternalClient client)
        {

            DBLayer.Models.Client clientExternalToCreate = new DBLayer.Models.Client()
            {
                IdClient = genExCode(client),
                firstId = Guid.NewGuid(),
                firstName = client.FirstName,
                secondName = "",
                firstLastName = client.LastName,
                secondLastName = "",
                Id = client.Id,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber,
                Ranking = genRanking(client)

            };
            _uow.ClientRepository.CreateClient(clientExternalToCreate);
            _uow.Save();
            return new LogicLayer.Models.Client()
            {
                firstId = clientExternalToCreate.firstId,
                IdClient = clientExternalToCreate.IdClient,
                firstName = clientExternalToCreate.firstName,
                secondName = clientExternalToCreate.secondName,
                firstLastName = clientExternalToCreate.firstLastName,
                secondLastName = clientExternalToCreate.secondLastName,
                Id = clientExternalToCreate.Id,

                Address = clientExternalToCreate.Address,
                PhoneNumber = clientExternalToCreate.PhoneNumber,
                Ranking = clientExternalToCreate.Ranking
            };
        }

        private int genRanking(LogicLayer.Models.ExternalClient client)
        {
            
            if(client.plan == "Basic"){

                return 1;
            }else if(client.plan == "Professional")
            {
                return 5;
            }
            return 3 ;
        }
    }
}

