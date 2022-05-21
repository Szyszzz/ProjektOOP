using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOP.Model
{
    public class CarModels
    {
        public int CarID { get; set; }
        public int MakerID { get; set; }
        public int ChassisID { get; set; }
        public int EngineID { get; set; }
        public string ModelName { get; set; }
        public string Country { get; set; }
        public int ProductionYear { get; set; }
        public double Price { get; set; }
    }
}
