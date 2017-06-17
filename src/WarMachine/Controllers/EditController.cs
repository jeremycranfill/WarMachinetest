using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarMachine.Models.WarModels;
using WarMachine.Data;
using WarMachine.ViewModels.Edit;
using WarMachine.Models.Joins;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WarMachine.Controllers
{
    public class EditController : Controller
    {

        private readonly ModelDbContext context;
        public EditController(ModelDbContext dbContext) { context = dbContext; }





        public IActionResult Index()
        {

            IList<SoloModel> solos = context.Solos.ToList();
            return Redirect("View");


        }



        [HttpGet]
        [Route("Edit/Solo/{SoloId}")]

        public IActionResult Solo(int SoloId)
        {


            List<Ability> AbilityList = context.Abilities.ToList();
            SoloModel editSolo = context.Solos.Single(c => c.ID == SoloId);

            EditSoloViewModel ViewModel = new
            EditSoloViewModel
           (

            context.Abilities.ToList(),
            context.Weapons.ToList(),
            context.Spells.ToList()
            )


            {

                ARM = editSolo.ARM,
                CMD = editSolo.CMD,
                DEF = editSolo.DEF,
                FA = editSolo.FA,
                MAT = editSolo.MAT,
                RAT = editSolo.RAT,
                Name = editSolo.Name,
                SPD = editSolo.SPD,
                PointCost = editSolo.PointCost,
                STR = editSolo.STR,
                soloID = editSolo.ID,
                currenntAbilIDs = context.SoloAbilities.Where(c => c.SoloID == SoloId).Select(x => x.AbilityID).ToList(),
                currenntSpellIDs = context.SoloSpells.Where(c => c.SoloID == SoloId).Select(x => x.SpellID).ToList(),
                currenntWeaponIDs = context.SoloWeapons.Where(c => c.SoloID == SoloId).Select(x => x.WeaponID).ToList()




            };

            ViewModel.SelecCurrenttWeapons();
            ViewModel.SelectCurrenntSpells();
            ViewModel.SelectCurrentAbillities();


            return View("EditSolo", ViewModel);

        }


        [HttpPost]
        public IActionResult Solo(EditSoloViewModel editModel)
        {

            SoloModel editSolo = context.Solos.Single(c => c.ID == editModel.soloID);



            editModel.currenntAbilIDs = context.SoloAbilities.Where(c => c.SoloID == editModel.soloID).Select(i => i.AbilityID).ToList();
            editModel.currenntWeaponIDs = context.SoloWeapons.Where(c => c.SoloID == editModel.soloID).Select(x => x.WeaponID).ToList();
            editModel.currenntSpellIDs = context.SoloSpells.Where(c => c.SoloID == editModel.soloID).Select(x => x.SpellID).ToList();



            editSolo.ARM = editModel.ARM;
            editSolo.CMD = editModel.CMD;
            editSolo.DEF = editModel.DEF;
            editSolo.FA = editModel.FA;
            editSolo.MAT = editModel.MAT;
            editSolo.RAT = editModel.RAT;
            editSolo.Name = editModel.Name;
            editSolo.SPD = editModel.SPD;
            editSolo.PointCost = editModel.PointCost;
            editSolo.STR = editModel.STR;
            context.SaveChanges();




            if (editModel.abilIDS != null)
            {



                foreach (var abil in editModel.abilIDS)
                {

                    if (!editModel.currenntAbilIDs.Contains(abil))
                    {

                        SoloAbility NewSoloAbility = new SoloAbility();
                        NewSoloAbility.AbilityID = abil;
                        NewSoloAbility.SoloID = editModel.soloID;
                        context.SoloAbilities.Add(NewSoloAbility);
                        context.SaveChanges();

                    }




                    foreach (var currentAbil in editModel.currenntAbilIDs)
                    {

                        if (!editModel.abilIDS.Contains(currentAbil))
                        {

                            SoloAbility soloabil = (from s in context.SoloAbilities where s.AbilityID == currentAbil where s.SoloID == editModel.soloID select s).FirstOrDefault<SoloAbility>();
                            context.SoloAbilities.Remove(soloabil);
                            context.SaveChanges();
                        }


                    }


                }

            }

            else
            {

                // delete all solo abils
                var soloAbils = context.SoloAbilities.Where(c => c.SoloID == editModel.soloID).ToList();

                foreach (var Abil in soloAbils)
                {
                    context.SoloAbilities.Remove(Abil);
                    context.SaveChanges();

                }


            }














            if (editModel.weapIDS != null)
            {
                foreach (var weap in editModel.weapIDS)
                {

                    if (!editModel.currenntWeaponIDs.Contains(weap))
                    {
                        SoloWeapon NewSoloWeapon = new SoloWeapon();
                        NewSoloWeapon.WeaponID = weap;
                        NewSoloWeapon.SoloID = editModel.soloID;
                        context.SoloWeapons.Add(NewSoloWeapon);
                        context.SaveChanges();
                    }




                    foreach (var weaps in editModel.currenntWeaponIDs)
                    {

                        if (!editModel.weapIDS.Contains(weaps))
                        {

                            SoloWeapon soloWeap = (from s in context.SoloWeapons where s.WeaponID == weap where s.SoloID == editModel.soloID select s).FirstOrDefault<SoloWeapon>();
                            context.SoloWeapons.Remove(soloWeap);
                            context.SaveChanges();
                        }

                    }
                }
            }


            else
            {

                // delete all solo abils
                var soloWeaps = context.SoloWeapons.Where(c => c.SoloID == editModel.soloID).ToList();

                foreach (var Weap in soloWeaps)
                {
                    context.SoloWeapons.Remove(Weap);
                    context.SaveChanges();

                }


            }
















            return Redirect("/View/Solo/" + editSolo.ID);

            }

        


        [HttpGet]
        [Route("Edit/Unit/{UnitId}")]

        public IActionResult Unit(int UnitId)
        {

            UnitModel editUnit = context.Units.Single(c => c.ID == UnitId);
            List<Ability> AbilityList = context.Abilities.ToList();


            EditUnitViewModel ViewModel = new
             EditUnitViewModel
            (

             context.Abilities.ToList(),
             context.Weapons.ToList(),
             context.Spells.ToList()
             )


            {

                ARM = editUnit.ARM,
                CMD = editUnit.CMD,
                DEF = editUnit.DEF,
                FA = editUnit.FA,
                MAT = editUnit.MAT,
                RAT = editUnit.RAT,
                Name = editUnit.Name,
                SPD = editUnit.SPD,
                PointCost = editUnit.PointCost,
                STR = editUnit.STR,
                soloID = editUnit.ID,
                MaxUnit = editUnit.MaxUnit,
                MinUnit = editUnit.MinUnit,


                currenntAbilIDs = context.SoloAbilities.Where(c => c.SoloID == UnitId).Select(x => x.AbilityID).ToList(),
                currenntSpellIDs = context.SoloSpells.Where(c => c.SoloID == UnitId).Select(x => x.SpellID).ToList(),
                currenntWeaponIDs = context.SoloWeapons.Where(c => c.SoloID == UnitId).Select(x => x.WeaponID).ToList()




            };

            ViewModel.SelecCurrenttWeapons();
            ViewModel.SelectCurrenntSpells();
            ViewModel.SelectCurrentAbillities();


            return View("EditUnit", ViewModel);
        }






        [HttpPost]
        public IActionResult Unit(EditUnitViewModel editModel)
        {
            if (ModelState.IsValid)
            { 

            UnitModel editUnit = context.Units.Single(c => c.ID == editModel.ID);



            editUnit.ARM = editModel.ARM;
            editUnit.CMD = editModel.CMD;
            editUnit.DEF = editModel.DEF;
            editUnit.FA = editModel.FA;
            editUnit.MAT = editModel.MAT;
            editUnit.RAT = editModel.RAT;
            editUnit.Name = editModel.Name;
            editUnit.SPD = editModel.SPD;
            editUnit.PointCost = editModel.PointCost;
            editUnit.STR = editModel.STR;
            editUnit.MaxUnit = editModel.MaxUnit;
            editUnit.MinUnit = editModel.MaxUnit;



                if (editModel.abilIDS != null)
                {
                    foreach (var abil in editModel.abilIDS)
                    {

                        UnitAbiliity newAbility = new UnitAbiliity();
                        newAbility.AbilityID = abil;
                        newAbility.UnitID = editUnit.ID;
                        context.UnitAbilities.Add(newAbility);
                        context.SaveChanges();


                    }
                }


                if (editModel.weapIDS != null)
                {
                    foreach (var weap in editModel.weapIDS)
                    {

                        UnitWeapon NewSoloWeapon = new UnitWeapon();
                        NewSoloWeapon.WeaponId = weap;
                        NewSoloWeapon.UnitID = editModel.ID;
                        context.UnitWeapons.Add(NewSoloWeapon);
                        context.SaveChanges();


                    }
                }

                if (editModel.spellIDS != null)
                {
                    foreach (var spell in editModel.spellIDS)
                    {

                        UnitSpell NewSoloSpell = new UnitSpell();
                        NewSoloSpell.SpellID = spell;
                        NewSoloSpell.UnitID = editModel.ID;
                        context.UnitSpells.Add(NewSoloSpell);
                        context.SaveChanges();


                    }
                }









                context.SaveChanges();


            return Redirect("/View/Unit");
        }


            return View("EditUnit", editModel);

        }






        [HttpGet]
        [Route("Edit/Warjack/{modelId}")]

        public IActionResult Warjack(int modelId)
        {

            Warjack editModel = context.Warjacks.Single(c => c.ID == modelId);
          


            EditWarjackViewModel ViewModel = new
             EditWarjackViewModel
            (

             context.Abilities.ToList(),
             context.Weapons.ToList(),
             context.Spells.ToList()
             )


            {

                ARM = editModel.ARM,
                CMD = editModel.CMD,
                DEF = editModel.DEF,
                FA = editModel.FA,
                MAT = editModel.MAT,
                RAT = editModel.RAT,
                Name = editModel.Name,
                SPD = editModel.SPD,
                PointCost = editModel.PointCost,
                STR = editModel.STR,
                soloID = editModel.ID,
                Size = editModel.Size,            
                


                currenntAbilIDs = context.UnitAbilities.Where(c => c.UnitID == modelId).Select(x => x.AbilityID).ToList(),
                currenntSpellIDs = context.UnitSpells.Where(c => c.UnitID == modelId).Select(x => x.SpellID).ToList(),
                currenntWeaponIDs = context.UnitWeapons.Where(c => c.UnitID == modelId).Select(x => x.WeaponId).ToList()




            };

            ViewModel.SelecCurrenttWeapons();
            ViewModel.SelectCurrenntSpells();
            ViewModel.SelectCurrentAbillities();


            return View("EditWarjack", ViewModel);
        }






        [HttpPost]
        public IActionResult Warjack(EditWarjackViewModel editModel)
        {
            if (ModelState.IsValid)
            {

                Warjack originalModel = context.Warjacks.Single(c => c.ID == editModel.ID);



                originalModel.ARM = editModel.ARM;
                originalModel.CMD = editModel.CMD;
                originalModel.DEF = editModel.DEF;
                originalModel.FA = editModel.FA;
                originalModel.MAT = editModel.MAT;
                originalModel.RAT = editModel.RAT;
                originalModel.Name = editModel.Name;
                originalModel.SPD = editModel.SPD;
                originalModel.PointCost = editModel.PointCost;
                originalModel.STR = editModel.STR;




              



                context.SaveChanges();


                return Redirect("/View/Warjack");
            }


            return View("Warjack", editModel);

        }














    }
}
