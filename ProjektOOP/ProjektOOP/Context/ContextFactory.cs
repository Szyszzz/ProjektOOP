using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOP.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ProjektContext>
    {
        public ProjektContext CreateDbContext(string[] args = null)
        {
            var optionBuilder = new DbContextOptionsBuilder<ProjektContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CarsBuilder;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new ProjektContext(optionBuilder.Options);
        }
    }
}
