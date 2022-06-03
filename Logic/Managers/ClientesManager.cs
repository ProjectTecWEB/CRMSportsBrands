using System;
using System.Collections.Generic;
using System.Text;
using BackingServices.Services;
using Database;

namespace Logic.Managers
{
    public class ClientesManager
    {
        private UnitOfWork _uow;
        private ClientsService _idNumberService;
        public ClientesManager(UnitOfWork uow, ClientsService idNumberService)
        {
            _uow = uow;
            _idNumberService = idNumberService;
        }

        public List<Logic.Models.Clientes> GetClientes() 
        {
            List<Database.Models.Clientes> userFromDB = _uow.ClienteRepository.GetAll().Result;
            List<Logic.Models.Clientes> mappedClientes = new List<Logic.Models.Clientes>();

            foreach (Database.Models.Clientes user in userFromDB)
            {
                mappedClientes.Add(new Logic.Models.Clientes()
                {
                    Name = user.Name,
                    LastName = user.LastName
                }); ;
            }

            return mappedClientes;
        }

        public Logic.Models.IdNumber GetSSN() 
        {
            BackingServices.Models.ClientesMo idNumberFromService = _idNumberService.GetIdNumberServiceAsync().Result;

            return new Logic.Models.IdNumber()
            {
                Id = idNumberFromService.id,
                InvalidUsSsn = idNumberFromService.invalid_us_ssn,
                Uid = idNumberFromService.uid,
                ValidUsSsn = idNumberFromService.valid_us_ssn
            };
        }
    }
}
