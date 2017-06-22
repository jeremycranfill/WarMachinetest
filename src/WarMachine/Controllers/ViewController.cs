using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarMachine.Models;
using WarMachine.Data;
using WarMachine.Models.WarModels;
using WarMachine.Models.Joins;
using WarMachine.Helpers;

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
        [Route("View/Abillity/{AbilityID}")]
        public IActionResult Ability(int AbilityId)
        {
           Ability abil  = context.Abilities.Single(c=> c.ID == AbilityId);

            ViewBag.Props = abil.GetProps();
            ViewBag.PropData = Helper.GetPropData(abil.GetProps(), abil);
            ViewBag.Type = "Ability";


            return View("SingleABility", abil);


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



            ViewBag.Props = Spell.GetProps();
            ViewBag.PropData = Helper.GetPropData(Spell.GetProps(), Spell);
            ViewBag.Type = "Spell";


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



            ViewBag.Props = weapon.GetProps();
            ViewBag.PropData = Helper.GetPropData(weapon.GetProps(), weapon);
            ViewBag.Type = "weapon";


            return View("SingleWeapon", weapon);








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




            List<UnitWeapon> unitWeapons = context.UnitWeapons.Where(c => c.UnitID == UnitID).ToList();
            List<Weapon> Weapons = new List<Weapon>();

            foreach (UnitWeapon weapon in unitWeapons)
            {

                Weapons.Add(context.Weapons.Single(c => c.ID == weapon.WeaponId));



            }

            unit.Weapons = Weapons;








            ViewBag.Props = unit.GetProps();
            ViewBag.PropData = Helper.GetPropData(unit.GetProps(), unit);
            ViewBag.Type = "Unit";


            return View("SingleUnit", unit);



        }





        public IActionResult Solo()
        {

            List<SoloModel> soloList = context.Solos.ToList();
            return View("Solos",soloList);

            

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



            ViewBag.Props = warjack.GetProps();
            ViewBag.PropData = Helper.GetPropData(warjack.GetProps(), warjack);
            ViewBag.Type = "Warjack";


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





            ViewBag.Props = warbeast.GetProps();
            ViewBag.PropData = Helper.GetPropData(warbeast.GetProps(), warbeast);
            ViewBag.Type = "Warbeast";


            return View("Warbeast", warbeast);

        }




        public IActionResult Warlock()
        {

            List<Warlock> warlockList = context.Warlocks.ToList();
            return View("Warlocks", warlockList);



        }


        [HttpGet]
        [Route("View/Warlock/{WarlockId}")]

        public IActionResult Warlock(int  warlockId)
        {

            //create new model
            Warlock warlock = context.Warlocks.Single(c => c.ID == warlockId);


            //get list of abilitiy IDS for the model
            List<WarlockAbillity> lockAbils = context.WarlockAbillities.Where(c => c.WarlockId == warlockId).ToList();
            //create list to hold abils
            List<Ability> abilList = new List<Ability>();


            //add each ability to list.
            foreach (WarlockAbillity abil in lockAbils)
            {

                abilList.Add(context.Abilities.Single(c => c.ID == abil.AbillityId));


            }

            //set solo abilities to list we just made
            warlock.Abilities = abilList;


            List<WarlockWeapon> lockWeapons = context.WarlockWeapons.Where(c => c.WarlockId == warlockId).ToList();

            List<Weapon> Weapons = new List<Weapon>();

            foreach (WarlockWeapon weapon in lockWeapons)
            {

                Weapons.Add(context.Weapons.Single(c => c.ID == weapon.WeaponId));



            }

            warlock.Weapons = Weapons;

            List<WarlockSpell> lockSpells = context.WarlockSpells.Where(c => c.WarlockId == warlockId).ToList();

            List<Spell> Spells = new List<Spell>();

            foreach (WarlockSpell spell in lockSpells)
            {

                Spells.Add(context.Spells.Single(c => c.ID == spell.WarlockId));



            }

            warlock.Spells = Spells;





            ViewBag.Props = warlock.GetProps();
            ViewBag.PropData = Helper.GetPropData(warlock.GetProps(), warlock);
            ViewBag.Type = "Warlock";


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
            List<WarcasterAbility> casterAbils = context.WarcasterAbilities.Where(c => c.WarcasterId == WarcasterId).ToList();
            //create list to hold abils
            List<Ability> abilList = new List<Ability>();


            //add each ability to list.
            foreach (WarcasterAbility abil in casterAbils)
            {

                abilList.Add(context.Abilities.Single(c => c.ID == abil.AbilityId));


            }

            //set solo abilities to list we just made
            Warcaster.Abilities = abilList;


            List<WarcasterWeapon> lockWeapons = context.WarcasterWeapons.Where(c => c.WarcsaterId == WarcasterId).ToList();

            List<Weapon> Weapons = new List<Weapon>();

            foreach (WarcasterWeapon weapon in lockWeapons)
            {

                Weapons.Add(context.Weapons.Single(c => c.ID == weapon.WeaponId));



            }

            Warcaster.Weapons = Weapons;

            List<WarcasterSpell> lockSpells = context.WarcasterSpells.Where(c => c.WarcasterId == WarcasterId).ToList();

            List<Spell> Spells = new List<Spell>();

            foreach (WarcasterSpell spell in lockSpells)
            {

                Spells.Add(context.Spells.Single(c => c.ID == spell.WarcasterId));



            }

            Warcaster.Spells = Spells;





            


            ViewBag.Props = Warcaster.GetProps();
            ViewBag.PropData = Helper.GetPropData(Warcaster.GetProps(), Warcaster);
            ViewBag.Type = "Warcaster";


            return View("Warcaster", Warcaster);

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






            List<SoloWeapon> soloWeaps = context.SoloWeapons.Where(c => c.SoloID == SoloId).ToList();

            List<Weapon> Weapons = new List<Weapon>();

            foreach (SoloWeapon spell in soloWeaps)
            {

                Weapons.Add(context.Weapons.Single(c => c.ID == spell.WeaponID));



            }

            solo.Weapons = Weapons;








            ViewBag.Props = solo.GetProps();
            ViewBag.PropData = Helper.GetPropData(solo.GetProps(),solo);
            ViewBag.Type = "Solo";


            return View("SingleSolo", solo);

        }







    }
}
