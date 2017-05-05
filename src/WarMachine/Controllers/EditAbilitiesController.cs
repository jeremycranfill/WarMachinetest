using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarMachine.Data;
using System.Collections;
using WarMachine.Models.Joins;
using WarMachine.Models.WarModels;
using WarMachine.ViewModels;
using WarMachine.ViewModels.Add;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WarMachine.Controllers
{
    public class EditAbilitiesController : Controller
    {
        // GET: /<controller>/

        private readonly ModelDbContext context;
        public EditAbilitiesController(ModelDbContext dbContext) { context = dbContext; }




        public IActionResult Index()
        {
            return View();

        }


        public IActionResult Solo(int SoloID)
        {
          IList<SoloAbility> CurrentAbilities = context.SoloAbilities.Where(c => c.SoloID == SoloID).ToList();

            IList<Ability> allAbilities = context.Abilities.ToList();

            AddAbilitySolo ViewModel = new AddAbilitySolo(allAbilities);
              
             







            return View();

        }









    }
}
