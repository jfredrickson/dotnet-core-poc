using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSandbox.Models;

namespace CoreSandbox.Data
{
    public class DatabaseInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Widgets.Any())
            {
                return; // DB has been initialized
            }

            var widgets = new Widget[]
            {
                new Widget { Name = "alpha" },
                new Widget { Name = "beta" },
                new Widget { Name = "gamma" }
            };
            foreach (Widget w in widgets)
            {
                context.Widgets.Add(w);
            }
            context.SaveChanges();
        }
    }
}
