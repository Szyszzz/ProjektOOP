using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOP.Model
{
    public class Engine
    {
        public int Id { get; set; }
        public int MakerId { get; set; }
        public string EngineName { get; set; }
        public int Displacement { get; set; }
        public int Cylinders { get; set; }
        public int PeakTorque { get; set; }
        public int MaxRPM { get; set; }
        public int IdleRPM { get; set; }
    }
}
