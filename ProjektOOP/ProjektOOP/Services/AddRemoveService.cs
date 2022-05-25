using ProjektOOP.Context;
using ProjektOOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOP.Services
{
    public class AddRemoveService
    {
        private ProjektContext context;

        public AddRemoveService()
        {
            context = new ContextFactory().CreateDbContext();
        }

        public void AddMaker(CarMakers maker)
        {
            context.CarMakers.Add(maker);
            context.SaveChanges();
        }

        public void AddModel(CarModels model)
        {
            context.CarModels.Add(model);
            context.SaveChanges();
        }

        public void AddChassis(Chassis chassis)
        {
            context.Chassis.Add(chassis);
            context.SaveChanges();
        }

        public void AddEngine(Engine engine)
        {
            context.Engine.Add(engine);
            context.SaveChanges();
        }

        public void RemoveMaker(CarMakers maker)
        {
            context.CarMakers.Remove(maker);
            context.SaveChanges();
        }

        public void RemoveModel(CarModels model)
        {
            context.CarModels.Remove(model);
            context.SaveChanges();
        }

        public void RemoveChassis(Chassis chassis)
        {
            context.Chassis.Remove(chassis);
            context.SaveChanges();
        }

        public void RemoveEngine(Engine engine)
        {
            context.Engine.Remove(engine);
            context.SaveChanges();
        }
    }
}
