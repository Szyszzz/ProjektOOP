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
    public class ListOfChassis
    {
        public static ObservableCollection<Chassis> ChassisList { get; set; } = GetChassis();

        public static ObservableCollection<Chassis> GetChassis()
        {
            ProjektContext context = new ContextFactory().CreateDbContext();
            return new ObservableCollection<Chassis>(context.Chassis);
        }

        public static void Add(Chassis chassis) => ChassisList.Add(chassis);

        public static void Remove(Chassis chassis) => ChassisList.Remove(chassis);

        public static void Edit(Chassis chassis, Chassis newChassis)
        {
            Chassis listChassis = ChassisList.FirstOrDefault(i => i == chassis);
            if (listChassis != null)
            {
                if (listChassis.ChassisName != null)
                    listChassis.ChassisName = newChassis.ChassisName;

                if (listChassis.Weight < 0)
                    listChassis.Weight = newChassis.Weight;

                if (listChassis.Lenght < 0)
                    listChassis.Lenght = newChassis.Lenght;

                if (listChassis.Width < 0)
                    listChassis.Width = newChassis.Width;

                if (listChassis.Height < 0)
                    listChassis.Height = newChassis.Height;

                if (listChassis.Doors < 0)
                    listChassis.Doors = newChassis.Doors;
            }
            CollectionViewSource.GetDefaultView(ChassisList).Refresh();
        }
    }
}
