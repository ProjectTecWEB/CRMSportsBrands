using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using DBLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.Repositories
{
    public class ClientRepository
    {
        private CRMSportsBrandsDBContext _context;

        public ClientRepository(CRMSportsBrandsDBContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Set<Client>().ToListAsync();
        }

        public Client CreateClient(Client client)
        {
            _context.Set<Client>().Add(client);
            return client;
        }

        public Client GetById(Guid id)
        {
            return _context.Set<Client>().Find(id);
        }

        public Client UpdateClient(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            return client;
        }

        public Client DeleteClient(Client client)
        {
            _context.Set<Client>().Remove(client);
            return client;
        }
    }
}
