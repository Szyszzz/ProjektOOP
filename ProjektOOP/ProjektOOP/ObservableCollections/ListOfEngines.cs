using ProjektOOP.Context;
using ProjektOOP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjektOOP.ObservableCollections
{
    public class ListOfEngines
    {
        public static ObservableCollection<Engine> EngineList { get; set; } = GetEngine();

        public static ObservableCollection<Engine> GetEngine()
        {
            ProjektContext context = new ContextFactory().CreateDbContext();
            return new ObservableCollection<Engine>(context.Engine);
        }

        public static void Add(Engine engine) => EngineList.Add(engine);

        public static void Remove(Engine engine) => EngineList.Remove(engine);

        public static void Edit(Engine engine, Engine newEngine)
        {
            Engine listEngine = EngineList.FirstOrDefault(i => i == engine);
            if (listEngine != null)
            {
                listEngine.EngineName = newEngine.EngineName;
                listEngine.Displacement = newEngine.Displacement;
                listEngine.Cylinders = newEngine.Cylinders;
                listEngine.PeakTorque = newEngine.PeakTorque;
                listEngine.MaxRPM = newEngine.MaxRPM;
                listEngine.IdleRPM = newEngine.IdleRPM;
            }
            CollectionViewSource.GetDefaultView(EngineList).Refresh();
        }
    }
}
