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

        [HttpGet]
        public IActionResult Solo(int SoloID)
        {
            IList<SoloAbility> CurrentAbilities = context.SoloAbilities.Where(c => c.SoloID == SoloID).ToList();

            IList<Ability> allAbilities = context.Abilities.ToList();

            AddAbilitySolo ViewModel = new AddAbilitySolo(allAbilities);
            ViewModel.SoloID = SoloID;









            return View("Solo", ViewModel);

        }

        [HttpPost]
        public IActionResult Solo(AddAbilitySolo model)
        {


            if (ModelState.IsValid)
            {
                IList<SoloAbility> existingItems = context.SoloAbilities
                .Where(cm => cm.SoloID == model.SoloID)
                .Where(cm => cm.AbilityID == model.AbilityID).ToList();

                if (existingItems.Count < 1)
                {
                    SoloAbility NewSoloAbility = new SoloAbility();
                    NewSoloAbility.AbilityID = model.AbilityID;
                    NewSoloAbility.SoloID = model.SoloID;
                    context.SoloAbilities.Add(NewSoloAbility);
                    context.SaveChanges();
                    
                    return Redirect("/View/Solo/" + model.SoloID);



                }


               


            }


            return View("Solo", model);





        }
    }
}

