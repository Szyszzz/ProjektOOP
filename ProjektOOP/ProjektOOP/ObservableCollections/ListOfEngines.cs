using ProjektOOP.Context;
using ProjektOOP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
                ? Application.Current.Windows.OfType<T>().Any()
                : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        public static void Add(Engine engine)
        {
            if(IsWindowOpen<EnginesWindow>())
                EngineList.Add(engine);
        }

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
