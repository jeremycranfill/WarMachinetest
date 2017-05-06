using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarMachine.Models;
using WarMachine.Data;
using WarMachine.Models.WarModels;
using WarMachine.Models.Joins;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WarMachine.Controllers
{
    public class ViewController : Controller
    {

        private readonly ModelDbContext context;
        public ViewController(ModelDbContext dbContext) { context = dbContext; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Ability()
        {
            IList<Ability> abilityList = context.Abilities.ToList();

           
            return View(abilityList);

        
        
        }

        public IActionResult Spell()
        {
            List<Spell> spellList = context.Spells.ToList();


            return View(spellList);



        }

        public IActionResult Weapon()
        {
            List<Weapon> weaponList = context.Weapons.ToList();
            return View(weaponList);

        }

        public IActionResult Unit()
        {
            List<UnitModel> unitList = context.Units.ToList();

            return View(unitList);

        }

        [Route("View/Unit/{UnitID}")]
        public IActionResult Unit(int UnitID)
        {
            UnitModel unit = context.Units.Single(c => c.ID == UnitID);


           
           /*/   TODO add abilities to view List<SoloAbility> soloAbils = context.SoloAbilities.Where(c => c.SoloID == SoloId).ToList();

            List<Ability> abilList = new List<Ability>();

            foreach (SoloAbility abil in soloAbils)
            {

                abilList.Add(context.Abilities.Single(c => c.ID == abil.AbilityID));


            }
            solo.Abilities = abilList;

    /*/ 








            return View("Singleunit", unit);
       
                
                
              }





        public IActionResult Solo()
        {

            List<SoloModel> soloList = context.Solos.ToList();
            return View("Solos",soloList);



        }


        [HttpGet]
        [Route("View/Solo/{SoloId}")]

        public IActionResult Solo(int SoloId)
        {

            SoloModel solo = context.Solos.Single(c => c.ID == SoloId);
            List<SoloAbility> soloAbils = context.SoloAbilities.Where(c => c.SoloID == SoloId).ToList();

            List<Ability> abilList = new List<Ability>();

            foreach (SoloAbility abil in soloAbils)
            {

                abilList.Add(context.Abilities.Single(c => c.ID == abil.AbilityID));


            }
            solo.Abilities = abilList;



            return View("SingleSolo", solo);

        }



        public IActionResult Rule()
        {

            List<RuleModel> ruleList = context.Rules.ToList();
            return View(ruleList);



        }


    







    }
}
