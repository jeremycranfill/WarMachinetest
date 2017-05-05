using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarMachine.Models;
using WarMachine.Data;
using WarMachine.Models.WarModels;

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



        public IActionResult Solo()
        {

            List<SoloModel> soloList = context.Solos.ToList();
            return View(soloList);



        }


        [HttpGet]
        [Route("View/Solo/{SoloId}")]

        public IActionResult Solo(int SoloId)
        {

            return View();

        }



        public IActionResult Rule()
        {

            List<RuleModel> ruleList = context.Rules.ToList();
            return View(ruleList);



        }


    







    }
}
