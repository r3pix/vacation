using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PresenceSystem.Entities;

namespace Vacation.Entities
{
    public class PresenceSystemDbContext : DbContext
    {

        private string _connectionString = "Server=(localdb)\\LocalDB;Database=Vacation;" +
                                           "Trusted_Connection=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<Department>Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<ListOfPresence>ListOfPresences  { get; set; }
        public DbSet<Place>Places { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
