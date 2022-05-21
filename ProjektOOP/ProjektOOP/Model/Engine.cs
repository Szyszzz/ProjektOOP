using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOP.Model
{
    public class Engine
    {
        public int EngineID { get; set; }
        public int MakerID { get; set; }
        public string EngineName { get; set; }
        public int Displacement { get; set; }
        public byte Cylinders { get; set; }
        public int PeakTorque { get; set; }
        public int MaxRPM { get; set; }
        public int IdleRPM { get; set; }
    }
}
