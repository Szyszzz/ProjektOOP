using ProjektOOP.Context;
using ProjektOOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOP.Services
{
    public class EditService
    {
        private ProjektContext context;

        public EditService()
        {
            context = new ContextFactory().CreateDbContext();
        }

        public void EditMakers(CarMakers targetToChange, string newName)
        {
            targetToChange.MakerName = newName;
            context.CarMakers.Update(targetToChange);
            context.SaveChanges();
        }

        public void EditChassis(Chassis targetToChange, Chassis newChassis)
        {
            targetToChange.ChassisName = newChassis.ChassisName;
            targetToChange.Width = newChassis.Width;
            targetToChange.Lenght = newChassis.Lenght;
            targetToChange.Height = newChassis.Height;
            targetToChange.Weight = newChassis.Weight;
            targetToChange.Doors = newChassis.Doors;
            context.Chassis.Update(targetToChange);
            context.SaveChanges();
        }

        public void EditEngine(Engine targetToChange, Engine newEngine)
        {
            targetToChange.EngineName = newEngine.EngineName;
            targetToChange.Displacement = newEngine.Displacement;
            targetToChange.Cylinders = newEngine.Cylinders;
            targetToChange.MaxRPM = newEngine.MaxRPM;
            targetToChange.IdleRPM = newEngine.IdleRPM;
            targetToChange.PeakTorque = newEngine.PeakTorque;
            context.Engine.Update(targetToChange);
            context.SaveChanges();
        }

        public void EditModel(CarModels t, CarModels n)
        {
            t.ModelName = n.ModelName;
            t.Country = n.Country;
            t.ProductionYear = n.ProductionYear;
            t.Price = n.Price;
            t.CarClass = n.CarClass;
            t.MakerId = n.MakerId;
            t.Maker = n.Maker;
            t.Engine = n.Engine;
            t.EngineId = n.EngineId;
            t.Chassis = n.Chassis;
            t.ChassisId = n.ChassisId;

            context.CarModels.Update(t);
            context.SaveChanges();
        }
    }
}
