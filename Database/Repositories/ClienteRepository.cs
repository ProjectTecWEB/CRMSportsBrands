using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ClienteRepository
    {
        private CsmSportDbContext _context;

        public ClienteRepository(CsmSportDbContext context)
        {
            _context = context;
        }

        public async Task<List<Clientes>> GetAll()
        {
            return await _context.Set<Clientes>().ToListAsync();
        }

        public Clientes CreateUser(Clientes user)
        {
            _context.Set<Clientes>().Add(user);
            return user;
        }

        public Clientes GetById(Guid id)
        {
            return _context.Set<Clientes>().Find(id);
        }

        public Clientes UpdateUser(Clientes user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return user;
        }

        public Clientes DeleteUser(Clientes user)
        {
            _context.Set<Clientes>().Remove(user);
            return user;
        }
    }
}
