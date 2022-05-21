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
        public CarMakers CarMakers { get; set; }
        public CarModels CarModels { get; set; }
        public Engine Engine { get; set; }
        public Chassis Chassis { get; set; }

        public ProjektContext(DbContextOptions<ProjektContext> options) : base(options)
        {
            
        }
    }
}
