using DBLayer;
using DBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class UnitOfWork
    {
        private CRMSportsBrandsDBContext _context;

        private ClientRepository _clientRepository;
        private AddressRepository _addressRepository;

        public ClientRepository ClientRepository
        {
            get
            {
                return _clientRepository;
            }
        }
        public AddressRepository addressRepository
        {
            get
            {
                return _addressRepository;
            }
        }

        public UnitOfWork(CRMSportsBrandsDBContext context)
        {
            _context = context;
            _clientRepository = new ClientRepository(_context);
            _addressRepository = new AddressRepository(_context);
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void Save()
        {
            try
            {
                BeginTransaction();
                _context.SaveChanges();
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                throw;
            }
        }
    }
}
