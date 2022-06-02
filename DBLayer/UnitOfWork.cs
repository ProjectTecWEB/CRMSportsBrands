using Database;
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
        private PracticeDbContext _context;

        private ClientRepository _clientRepository;

        public ClientRepository ClientRepository
        {
            get
            {
                return _clientRepository;
            }
        }

        public UnitOfWork(PracticeDbContext context)
        {
            _context = context;
            _clientRepository = new ClientRepository(_context);
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
