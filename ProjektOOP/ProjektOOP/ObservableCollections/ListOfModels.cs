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
    public class ListOfModels
    {
        public static ObservableCollection<CarModels> ModelList { get; set; } = GetEngine();

        public static ObservableCollection<CarModels> GetEngine()
        {
            ProjektContext context = new ContextFactory().CreateDbContext();

            ObservableCollection<CarModels> collection = new ObservableCollection<CarModels>(context.CarModels);

            foreach (CarModels model in collection)
            {
                model.Engine = context.Engine.Find(model.EngineId);
                model.Chassis = context.Chassis.Find(model.MakerId);
                model.Maker = context.CarMakers.Find(model.MakerId);
            }

            return collection;
        }

        public static void Add(CarModels model) => ModelList.Add(model);

        public static void Remove(CarModels model) => ModelList.Remove(model);

        public static void Edit(CarModels model, CarModels newmodel)
        {
            CarModels listModel = ModelList.FirstOrDefault(i => i == model);
            if (listModel != null)
            {

            }
            CollectionViewSource.GetDefaultView(ModelList).Refresh();
        }
    }
}
