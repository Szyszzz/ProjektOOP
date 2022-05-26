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
            using (context)
            {
                targetToChange.MakerName = newName;
                context.SaveChanges();
            }
        }
    }
}
