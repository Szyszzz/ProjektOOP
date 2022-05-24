using Microsoft.EntityFrameworkCore;
using ProjektOOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOP.Context
{
    public class ProjektContext : DbContext
    {
        public DbSet<CarMakers> CarMakers { get; set; }
        public DbSet<CarModels> CarModels { get; set; }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<Chassis> Chassis { get; set; }

        public ProjektContext(DbContextOptions<ProjektContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarMakers>().ToTable("CarMakers");
            modelBuilder.Entity<CarModels>().ToTable("CarModels");
            modelBuilder.Entity<Engine>().ToTable("Engine");
            modelBuilder.Entity<Chassis>().ToTable("Chassis");
        }
    }
}
