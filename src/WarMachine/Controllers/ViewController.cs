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
        [Route("View/Ability/{AbilityID}")]
        public IActionResult Ability(int AbilityId)
        {
           Ability abil  = context.Abilities.Single(c=> c.ID == AbilityId);


            return View("SingleAbility",abil );


        }





        public IActionResult Spell()
        {
            List<Spell> spellList = context.Spells.ToList();


            return View(spellList);



        }

        [Route("View/Spell/{SpellID}")]
        public IActionResult Spell(int SpellID)
        {
           
            Spell Spell = context.Spells.Single(c => c.ID == SpellID);


            return View("SingleSpell", Spell);



        }






        public IActionResult Weapon()
        {
            List<Weapon> weaponList = context.Weapons.ToList();
            return View(weaponList);

        }
        [Route("View/Weapon/{WeaponID}")]
        public IActionResult Weapon(int WeaponID)
        {
            Weapon weapon = context.Weapons.Single(c => c.ID == WeaponID);
            return View("SingleWeapon",weapon);

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


           
        List<UnitAbiliity> unitAbils = context.UnitAbilities.Where(c => c.UnitID == UnitID).ToList();

            List<Ability> abilList = new List<Ability>();

            foreach (UnitAbiliity abil in unitAbils)
            {

                abilList.Add(context.Abilities.Single(c => c.ID == abil.AbilityID));


            }
            unit.Abilities = abilList;


            List<UnitSpell> unitSpells = context.UnitSpells.Where(c => c.UnitID == UnitID).ToList();

            List<Spell> Spells = new List<Spell>();

            foreach (UnitSpell spell in unitSpells)
            {

                Spells.Add(context.Spells.Single(c => c.ID == spell.UnitID));



            }

            unit.Spells = Spells;











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

            //create new model
            SoloModel solo = context.Solos.Single(c => c.ID == SoloId);


            //get list of abilitiy IDS for the model
            List<SoloAbility> soloAbils = context.SoloAbilities.Where(c => c.SoloID == SoloId).ToList();
            //create list to hold abils
            List<Ability> abilList = new List<Ability>();


            //add each ability to listif any


            foreach (SoloAbility abil in soloAbils)
            {

                abilList.Add(context.Abilities.Single(c => c.ID == abil.AbilityID));


            }

            //set solo abilities to list we just made
            solo.Abilities = abilList;


            List<SoloSpell> soloSpells = context.SoloSpells.Where(c => c.SoloID == SoloId).ToList();

            List<Spell> Spells = new List<Spell>();

            foreach (SoloSpell spell in soloSpells)
            {

                Spells.Add(context.Spells.Single(c => c.ID == spell.SpellID));



            }

            solo.Spells = Spells;






            return View("SingleSolo", solo);

        }




        public IActionResult Warjack()
        {

            List<Warjack> jackList = context.Warjacks.ToList();
            return View("Warjacks", jackList);



        }



        [HttpGet]
        [Route("View/Warjack/{WarjackId}")]

        public IActionResult Warjack(int WarjackId)
        {

            //create new model
            Warjack warjack = context.Warjacks.Single(c => c.ID == WarjackId);


            //get list of abilitiy IDS for the model
            List<WarjackAbillity> jackAbils = context.WarjackAbilities.Where(c => c.WarjackID == WarjackId).ToList();
            //create list to hold abils
            List<Ability> abilList = new List<Ability>();


            //add each ability to list.
            foreach (WarjackAbillity abil in jackAbils)
            {

                abilList.Add(context.Abilities.Single(c => c.ID == abil.AbillityID));


            }

            //set solo abilities to list we just made
            warjack.Abilities = abilList;


            List<WarjackWeapon> jackWeapons = context.WarjackWeapons.Where(c => c.WarjackId == WarjackId).ToList();

            List<Weapon> Weapons = new List<Weapon>();

            foreach (WarjackWeapon weapon in jackWeapons)
            {

                Weapons.Add(context.Weapons.Single(c => c.ID == weapon.WeaponId));



            }

            warjack.Weapons = Weapons;






            return View("Warjack", warjack);

        }




        public IActionResult Warbeast()
        {

            List<WarBeast> beastlist = context.WarBeasts.ToList();
            return View("Warbeasts", beastlist);



        }

        [HttpGet]
        [Route("View/Warbeast/{WarbeastId}")]

        public IActionResult Warbeast(int warbeastId)
        {

            //create new model
            WarBeast warbeast = context.WarBeasts.Single(c => c.ID == warbeastId);


            //get list of abilitiy IDS for the model
            List<WarBeastAbillity> beastAbils = context.WarbeastAbillities.Where(c => c.WarBeastid == warbeastId).ToList();
            //create list to hold abils
            List<Ability> abilList = new List<Ability>();


            //add each ability to list.
            foreach (WarBeastAbillity abil in beastAbils)
            {

                abilList.Add(context.Abilities.Single(c => c.ID == abil.AbillityId));


            }

            //set solo abilities to list we just made
            warbeast.Abilities = abilList;


            List<WarbeastWeapon> beastWeapons = context.WarbeastWeapons.Where(c => c.WarbeastID == warbeastId).ToList();

            List<Weapon> Weapons = new List<Weapon>();

            foreach (WarbeastWeapon weapon in beastWeapons)
            {

                Weapons.Add(context.Weapons.Single(c => c.ID == weapon.WeaponId));



            }

            warbeast.Weapons = Weapons;

            List<WarbeastSpell> beastSpells = context.WarbeastSpells.Where(c => c.WarbeastId == warbeastId).ToList();

            List<Spell> Spells = new List<Spell>();

            foreach (WarbeastSpell spell in beastSpells)
            {

                Spells.Add(context.Spells.Single(c => c.ID == spell.WarbeastId));



            }

            warbeast.Spells = Spells;








            return View("Warbeast", warbeast);

        }




        public IActionResult Warlock()
        {

            List<Warlock> warlockList = context.Warlocks.ToList();
            return View("Warlocks", warlockList);



        }


        [HttpGet]
        [Route("View/Warlock/{WarlockId}")]

        public IActionResult Warlock(int warlockId)
        {

            //create new model
            Warlock warlock = context.Warlocks.Single(c => c.ID == warlockId);


            //get list of abilitiy IDS for the model
            List<SoloAbility> lockAbils = context.SoloAbilities.Where(c => c.SoloID == warlockId).ToList();
            //create list to hold abils
            List<Ability> abilList = new List<Ability>();


            //add each ability to list.
            foreach (SoloAbility abil in lockAbils)
            {

                abilList.Add(context.Abilities.Single(c => c.ID == abil.AbilityID));


            }

            //set solo abilities to list we just made
            warlock.Abilities = abilList;


            List<SoloWeapon> lockWeapons = context.SoloWeapons.Where(c => c.SoloID == warlockId).ToList();

            List<Weapon> Weapons = new List<Weapon>();

            foreach (SoloWeapon weapon in lockWeapons)
            {

                Weapons.Add(context.Weapons.Single(c => c.ID == weapon.WeaponID));



            }

            warlock.Weapons = Weapons;

            List<SoloSpell> lockSpells = context.SoloSpells.Where(c => c.SoloID == warlockId).ToList();

            List<Spell> Spells = new List<Spell>();

            foreach (SoloSpell spell in lockSpells)
            {

                Spells.Add(context.Spells.Single(c => c.ID == spell.SoloID));



            }

            warlock.Spells = Spells;








            return View("Warlock", warlock);

        }


        public IActionResult Warcaster()
        {

            List<Warcaster> casterList = context.Warcasters.ToList();
            return View("Warcasters", casterList);



        }


        [HttpGet]
        [Route("View/Warcaster/{WarcasterId}")]

        public IActionResult Warcaster(int WarcasterId)
        {

            //create new model
            Warcaster Warcaster = context.Warcasters.Single(c => c.ID == WarcasterId);


            //get list of abilitiy IDS for the model
            List<SoloAbility> casterAbils = context.SoloAbilities.Where(c => c.SoloID == WarcasterId).ToList();
            //create list to hold abils
            List<Ability> abilList = new List<Ability>();


            //add each ability to list.
            foreach (SoloAbility abil in casterAbils)
            {

                abilList.Add(context.Abilities.Single(c => c.ID == abil.AbilityID));


            }

            //set solo abilities to list we just made
            Warcaster.Abilities = abilList;


            List<SoloWeapon> lockWeapons = context.SoloWeapons.Where(c => c.SoloID == WarcasterId).ToList();

            List<Weapon> Weapons = new List<Weapon>();

            foreach (SoloWeapon weapon in lockWeapons)
            {

                Weapons.Add(context.Weapons.Single(c => c.ID == weapon.WeaponID));



            }

            Warcaster.Weapons = Weapons;

            List<SoloSpell> lockSpells = context.SoloSpells.Where(c => c.SoloID == WarcasterId).ToList();

            List<Spell> Spells = new List<Spell>();

            foreach (SoloSpell spell in lockSpells)
            {

                Spells.Add(context.Spells.Single(c => c.ID == spell.SoloID));



            }

            Warcaster.Spells = Spells;








            return View("Warcaster", Warcaster);

        }

    }
}
