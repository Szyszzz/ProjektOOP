using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOP.Model
{
    public class CarModels
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Country { get; set; }
        public int ProductionYear { get; set; }
        public decimal Price { get; set; }
        public string? CarClass { get; set;}
        public int MakerId { get; set; }
        [NotMapped] public CarMakers Maker { get; set; }
        public int ChassisId { get; set; }
        [NotMapped] public Chassis Chassis { get; set; }
        public int EngineId { get; set; }
        [NotMapped] public Engine Engine { get; set; }
    }
}
