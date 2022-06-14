using System;
using Database.Repositories;

namespace Database
{
    public class UnitOfWork
    {
        private CsmSportDbContext _context;

        private ClienteRepository _userRepository;

        public ClienteRepository UserRepository
        {
            get
            {
                return _userRepository;
            }
        }

        public UnitOfWork(CsmSportDbContext context)
        {
            _context = context;
            _userRepository = new ClienteRepository(_context);
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
