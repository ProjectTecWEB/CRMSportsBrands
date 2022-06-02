using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class PracticeDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Client> Client { get; set; }

        public PracticeDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetSection("Database").GetSection("ConnectionString").Value;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}