using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WarMachine.ViewModels;
using WarMachine.Models;
using WarMachine.Data;
using WarMachine.Models.ManageViewModels;
using WarMachine.Models.WarModels;
using WarMachine.Models.Joins;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WarMachine.Controllers
{
    public class AddController : Controller
    {

        private readonly ModelDbContext context;
        public AddController(ModelDbContext dbContext) { context = dbContext; } 
            
            
            // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Model()
        {

            var ViewModel = new AddModelViewModel();
            
            return View(ViewModel);


        }


        [HttpPost]
        public IActionResult Model(AddModelViewModel model)
        {

            string ViewName = model.AddType;

            return RedirectToAction(ViewName);


        }


        public IActionResult AddUnit()
        {

            return View();


        }



        [HttpPost]
        public IActionResult AddUnit(AddUnitViewModel model)
        {

            if (ModelState.IsValid)
                {


                UnitModel newUnit = new UnitModel();

                newUnit.Name = model.Name;
                newUnit.ARM = model.ARM;
                newUnit.CMD = model.CMD;
                newUnit.DEF = model.DEF;
                newUnit.FA = model.FA;
                newUnit.MAT = model.MAT;
                newUnit.MaxUnit = model.MaxUnit;
                newUnit.MinUnit = model.MinUnit;
                newUnit.PointCost = model.PointCost;
                newUnit.RAT = model.RAT;
                newUnit.SPD = model.SPD;
                newUnit.STR = model.STR;
                newUnit.FA = model.FA;
                context.Units.Add(newUnit);
                context.SaveChanges();
                return Redirect("/");
                              

                 }



            return View(model);



        }




        public IActionResult Warjack()
        {


            AddWarjackViewModel view = new AddWarjackViewModel

            (

            context.Abilities.ToList(),

            context.Weapons.ToList(),
            context.Spells.ToList()

            );






            return View("AddWarjack", view);


        }



        [HttpPost]
        public IActionResult Warjack(AddWarjackViewModel model)
        {

            if (ModelState.IsValid)
            {



                Warjack newJack = new Warjack();


                newJack.Name = model.Name;
                newJack.ARM = model.ARM;
                newJack.CMD = model.CMD;
                newJack.DEF = model.DEF;
                newJack.FA = model.FA;
                newJack.MAT = model.MAT;
                newJack.PointCost = model.PointCost;
                newJack.RAT = model.RAT;
                newJack.SPD = model.SPD;
                newJack.STR = model.STR;
                newJack.FA = model.FA;
                newJack.Size = model.Size;

                context.Warjacks.Add(newJack);
                context.SaveChanges();

                if (model.abilIDS != null)
                {
                    foreach (var abil in model.abilIDS)
                    {

                        SoloAbility NewSoloAbility = new SoloAbility();
                        NewSoloAbility.AbilityID = abil;
                        NewSoloAbility.SoloID = newJack.ID;
                        context.SoloAbilities.Add(NewSoloAbility);
                        context.SaveChanges();


                    }
                }


                if (model.weapIDS != null)
                {
                    foreach (var weap in model.weapIDS)
                    {

                        SoloWeapon NewSoloWeapon = new SoloWeapon();
                        NewSoloWeapon.WeaponID = weap;
                        NewSoloWeapon.SoloID = newJack.ID;
                        context.SoloWeapons.Add(NewSoloWeapon);
                        context.SaveChanges();


                    }
                }

                if (model.spellIDS != null)
                {
                    foreach (var spell in model.spellIDS)
                    {

                        SoloSpell NewSoloSpell = new SoloSpell();
                        NewSoloSpell.SpellID = spell;
                        NewSoloSpell.SoloID = newJack.ID;
                        context.SoloSpells.Add(NewSoloSpell);
                        context.SaveChanges();


                    }
                }




                return Redirect("/");


            }

            return View("Warjack", model);



        }











        public IActionResult Solo()
        {


            SoloViewModel soloView = new SoloViewModel
                
            (

            context.Abilities.ToList(),
           
            context.Weapons.ToList(),
            context.Spells.ToList()

            );

           
            
                     


            return View("AddSolo", soloView);


        }

        [HttpPost]
        public IActionResult Solo(SoloViewModel model)
        {

            if (ModelState.IsValid)
            {
               

          
                SoloModel newSolo = new SoloModel();

                
                newSolo.Name = model.Name;
                newSolo.ARM = model.ARM;
                newSolo.CMD = model.CMD;
                newSolo.DEF = model.DEF;
                newSolo.FA = model.FA;
                newSolo.MAT = model.MAT;
                newSolo.PointCost = model.PointCost;
                newSolo.RAT = model.RAT;
                newSolo.SPD = model.SPD;
                newSolo.STR = model.STR;
                newSolo.FA = model.FA;

                context.Solos.Add(newSolo);
                context.SaveChanges();

                if (model.abilIDS != null)
                {
                    foreach (var abil in model.abilIDS)
                    {

                        SoloAbility NewSoloAbility = new SoloAbility();
                        NewSoloAbility.AbilityID = abil;
                        NewSoloAbility.SoloID = newSolo.ID;
                        context.SoloAbilities.Add(NewSoloAbility);
                        context.SaveChanges();


                    }
                }


                if (model.weapIDS != null)
                {
                    foreach (var weap in model.weapIDS)
                    {

                        SoloWeapon NewSoloWeapon = new SoloWeapon();
                        NewSoloWeapon.WeaponID = weap;
                        NewSoloWeapon.SoloID = newSolo.ID;
                        context.SoloWeapons.Add(NewSoloWeapon);
                        context.SaveChanges();


                    }
                }

                if (model.spellIDS != null)
                {
                    foreach (var spell in model.spellIDS)
                    {

                        SoloSpell NewSoloSpell = new SoloSpell();
                        NewSoloSpell.SpellID = spell;
                        NewSoloSpell.SoloID = newSolo.ID;
                        context.SoloSpells.Add(NewSoloSpell);
                        context.SaveChanges();


                    }
                }




                return Redirect("/");


            }

            return View("AddSolo",model);



        }








        public IActionResult Spell()
        {
            return View("AddSpell");

        }

        [HttpPost]
        public IActionResult Spell(AddSpellViewModel model)
        {
           if (ModelState.IsValid)
            {
                Spell newSpell = new Spell ();

                newSpell.AOE = model.AOE;
                newSpell.Cost = model.Cost;
                newSpell.Duration = model.Duration;
                newSpell.Name = model.Name;
                newSpell.OFF = model.OFF;
                newSpell.POW = model.POW;
                newSpell.RNG = model.RNG;
                newSpell.Description = model.Description;
                context.Spells.Add(newSpell);
                context.SaveChanges();
                return Redirect("/");



            }
            return View("AddSpell", model);
        }



        public IActionResult Ability()
        {
            

            return View("AddAbility");

        }


        [HttpPost]
        public IActionResult Ability(AddAbilityViewModel model)

        {

            if (ModelState.IsValid)
            {
                Ability newAbility = new Ability();
                newAbility.Description = model.Description;
                newAbility.Name = model.Name;
                context.Abilities.Add(newAbility);
                context.SaveChanges();
                return Redirect("/");
            }

            return View("AddAbility", model);

        }



        public IActionResult Weapon()
        {


            return View("AddWeapon");

        }

        [HttpPost]
        public IActionResult Weapon(AddWeaponViewModel model)
        {

            if (ModelState.IsValid)
            {
                Weapon newWeapon = new Weapon();

                newWeapon.Name = model.Name;
                newWeapon.POW = model.POW;
                newWeapon.RNG = model.RNG;
                newWeapon.Type = model.Type;
                context.Weapons.Add(newWeapon);
                context.SaveChanges();
                return Redirect("/");


            }


            return View("AddWeapon", model);

        }




        public IActionResult Rule()
        {


            return View("AddRule");

        }


        [HttpPost]
        public IActionResult Rule(AddRuleViewModel model)

        {

            if (ModelState.IsValid)
            {
                RuleModel newRule = new RuleModel();
                newRule.Text = model.Text;
                newRule.Name = model.Name;
                context.Rules.Add(newRule);
                context.SaveChanges();
                return Redirect("/");
            }

            return View("AddRule", model);

        }


    









    }

}
