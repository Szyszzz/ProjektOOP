﻿using ProjektOOP.Context;
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
                listChassis.ChassisName = newChassis.ChassisName;
                listChassis.Weight = newChassis.Weight;
                listChassis.Lenght = newChassis.Lenght;
                listChassis.Width = newChassis.Width;
                listChassis.Height = newChassis.Height;
                listChassis.Doors = newChassis.Doors;
            }
            CollectionViewSource.GetDefaultView(ChassisList).Refresh();
        }
    }
}
