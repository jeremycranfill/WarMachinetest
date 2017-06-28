using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models;
using WarMachine.Models.WarModels;

namespace WarMachine.Data
{
    public  class DataSeeder
    {
        private ModelDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public DataSeeder(ModelDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }




        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("jeremy.cranfill@gmail.com") == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "jcranfill",
                    Email = "jeremy.cranfill@gmail.com"
                };

                await _userManager.CreateAsync(user, "P@ssw0rd!");
            }
        }








        public static void Initialize(ModelDbContext context)
        {
            if (context.Factions.Any())
            { return; }

            var Factions = new Faction[]
                {

                    new Faction {Name = "Cryx",  },
                    new Faction {Name = "Cygnar" },
                    new Faction {Name="Ret" },
                    new Faction {Name="Convergence" },
                    new Faction {Name="Menoth" },
                    new Faction {Name="Khador" },
                    new Faction {Name="Mercs" },
                    new Faction {Name="Trolls" },
                    new Faction {Name="Skorne" },
                    new Faction {Name="Circle" },
                    new Faction {Name="Legion" },
                    new Faction {Name="Minions" },






                };

            foreach (var faction in Factions)
            {
                context.Factions.Add(faction);


            }

            context.SaveChanges();

        }




    }
}
