using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOP.Model
{
    public class Chassis
    {
        public int ChassisID { get; set; }
        public int MakerID { get; set; }
        public string ChassisName { get; set; }
        public int Weight { get; set; }
        public int Lenght { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public byte Doors { get; set; }
    }
}
