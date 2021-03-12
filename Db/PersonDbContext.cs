using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opdracht5Maart.Models;
using Opdracht5Maart.DTO;

namespace Opdracht5Maart.Db
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<House> Houses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Opdracht5Maart.db");
    }
}
