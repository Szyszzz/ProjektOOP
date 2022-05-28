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
    public class ListOfMakers
    {
        public static ObservableCollection<CarMakers> MakersList { get; set; } = GetMakers();

        public static ObservableCollection<CarMakers> GetMakers()
        {
            ProjektContext context = new ContextFactory().CreateDbContext();
            return new ObservableCollection<CarMakers>(context.CarMakers);
        }

        public static void Add(CarMakers maker) => MakersList.Add(maker);

        public static void Remove(CarMakers maker) => MakersList.Remove(maker);

        public static void Edit(CarMakers maker, string newMakerName)
        {
            CarMakers listMaker = MakersList.FirstOrDefault(i => i == maker);
            if (listMaker != null)
            {
                listMaker.MakerName = newMakerName;
            }
            CollectionViewSource.GetDefaultView(MakersList).Refresh();
        }
    }
}
