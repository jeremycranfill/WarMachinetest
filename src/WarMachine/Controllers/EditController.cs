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
using WarMachine.ViewModels;

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
            editSolo.factionName = editModel.Faction;
            editSolo.FA = editModel.FA;
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






            if (editModel.spellIDS != null)
            {
                foreach (var spell in editModel.spellIDS)
                {

                    if (!editModel.currenntSpellIDs.Contains(spell))
                    {
                        SoloSpell NewSoloSpell = new SoloSpell();
                        NewSoloSpell.SpellID = spell;
                        NewSoloSpell.SoloID = editModel.soloID;
                        context.SoloSpells.Add(NewSoloSpell);
                        context.SaveChanges();
                    }




                    foreach (var spells in editModel.currenntSpellIDs)
                    {

                        if (!editModel.weapIDS.Contains(spells))
                        {

                            SoloSpell soloSpell = (from s in context.SoloSpells where s.SpellID == spell where s.SoloID == editModel.soloID select s).FirstOrDefault<SoloSpell>();
                            context.SoloSpells.Remove(soloSpell);
                            context.SaveChanges();
                        }

                    }
                }
            }


            else
            {

                // delete all solo abils
                var soloSpells = context.SoloSpells.Where(c => c.SoloID == editModel.soloID).ToList();

                foreach (var Spell in soloSpells)
                {
                    context.SoloSpells.Remove(Spell);
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



                currenntAbilIDs = context.UnitAbilities.Where(c => c.UnitID == UnitId).Select(x => x.AbilityID).ToList(),
                currenntSpellIDs = context.UnitSpells.Where(c => c.UnitID == UnitId).Select(x => x.SpellID).ToList(),
                currenntWeaponIDs = context.UnitWeapons.Where(c => c.UnitID == UnitId).Select(x => x.WeaponId).ToList()




            };

            ViewModel.SelecCurrenttWeapons();
            ViewModel.SelectCurrenntSpells();
            ViewModel.SelectCurrentAbillities();


            return View("EditUnit", ViewModel);
        }













        [HttpPost]
        public IActionResult Unit(EditUnitViewModel editModel)
        {

            UnitModel editUnit = context.Units.Single(c => c.ID == editModel.soloID);



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
            editUnit.factionName = editModel.Faction;
            context.SaveChanges();

            editModel.currenntAbilIDs = context.UnitAbilities.Where(c => c.UnitID == editUnit.ID).Select(x => x.AbilityID).ToList();
            editModel.currenntSpellIDs = context.UnitSpells.Where(c => c.UnitID == editUnit.ID).Select(x => x.SpellID).ToList();
            editModel.currenntWeaponIDs = context.UnitWeapons.Where(c => c.UnitID == editUnit.ID).Select(x => x.WeaponId).ToList();






                    if (editModel.abilIDS != null)
                    {



                        foreach (var abil in editModel.abilIDS)
                        {

                            if (!editModel.currenntAbilIDs.Contains(abil))
                            {

                                UnitAbiliity NewSoloAbility = new UnitAbiliity();
                                NewSoloAbility.AbilityID = abil;
                                NewSoloAbility.UnitID = editModel.soloID;
                                context.UnitAbilities.Add(NewSoloAbility);
                                context.SaveChanges();

                            }




                            foreach (var currentAbil in editModel.currenntAbilIDs)
                            {

                                if (!editModel.abilIDS.Contains(currentAbil))
                                {

                                    UnitAbiliity soloabil = (from s in context.UnitAbilities where s.AbilityID == currentAbil where s.UnitID == editModel.soloID select s).FirstOrDefault<UnitAbiliity>();
                                    context.UnitAbilities.Remove(soloabil);
                                    context.SaveChanges();
                                }


                            }


                        }

                    }

                    else
                    {

                        // delete all solo abils
                        var soloAbils = context.UnitAbilities.Where(c => c.UnitID == editModel.soloID).ToList();

                        foreach (var Abil in soloAbils)
                        {
                            context.UnitAbilities.Remove(Abil);
                            context.SaveChanges();

                        }


                    }














                    if (editModel.weapIDS != null)
                    {
                        foreach (var weap in editModel.weapIDS)
                        {

                            if (!editModel.currenntWeaponIDs.Contains(weap))
                            {
                                UnitWeapon NewSoloWeapon = new UnitWeapon();
                                NewSoloWeapon.WeaponId = weap;
                                NewSoloWeapon.UnitID = editModel.soloID;
                                context.UnitWeapons.Add(NewSoloWeapon);
                                context.SaveChanges();
                            }




                            foreach (var weaps in editModel.currenntWeaponIDs)
                            {

                                if (!editModel.weapIDS.Contains(weaps))
                                {

                                    UnitWeapon soloWeap = (from s in context.UnitWeapons where s.WeaponId == weap where s.UnitID == editModel.soloID select s).FirstOrDefault<UnitWeapon>();
                                    context.UnitWeapons.Remove(soloWeap);
                                    context.SaveChanges();
                                }

                            }
                        }
                    }


                    else
                    {

                        // delete all solo abils
                        var soloWeaps = context.UnitWeapons.Where(c => c.UnitID == editModel.soloID).ToList();

                        foreach (var Weap in soloWeaps)
                        {
                            context.UnitWeapons.Remove(Weap);
                            context.SaveChanges();

                        }


                    }






                    if (editModel.spellIDS != null)
                    {
                        foreach (var spell in editModel.spellIDS)
                        {

                            if (!editModel.currenntSpellIDs.Contains(spell))
                            {
                                UnitSpell NewSoloSpell = new UnitSpell();
                                NewSoloSpell.SpellID = spell;
                                NewSoloSpell.UnitID = editModel.soloID;
                                context.UnitSpells.Add(NewSoloSpell);
                                context.SaveChanges();
                            }




                            foreach (var spells in editModel.currenntSpellIDs)
                            {

                                if (!editModel.spellIDS.Contains(spells))
                                {

                                    UnitSpell soloSpell = (from s in context.UnitSpells where s.SpellID == spell where s.UnitID == editModel.soloID select s).FirstOrDefault<UnitSpell>();
                                    context.UnitSpells.Remove(soloSpell);
                                    context.SaveChanges();
                                }

                            }
                        }
                    }


                    else
                    {

                        // delete all solo abils
                        var soloSpells = context.UnitSpells.Where(c => c.UnitID == editModel.soloID).ToList();

                        foreach (var Spell in soloSpells)
                        {
                            context.UnitSpells.Remove(Spell);
                            context.SaveChanges();

                        }


                    }



                 



                return Redirect("/View/Unit/" + editModel.soloID);

            }









        [HttpGet]
        [Route("Edit/Warjack/{SoloId}")]

        public IActionResult Warjack(int SoloId)
        {

            Warjack editModel = context.Warjacks.Single(c => c.ID == SoloId);
          


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
                


                currenntAbilIDs = context.UnitAbilities.Where(c => c.UnitID == SoloId).Select(x => x.AbilityID).ToList(),
                currenntSpellIDs = context.UnitSpells.Where(c => c.UnitID == SoloId).Select(x => x.SpellID).ToList(),
                currenntWeaponIDs = context.UnitWeapons.Where(c => c.UnitID == SoloId).Select(x => x.WeaponId).ToList()




            };

            ViewModel.SelecCurrenttWeapons();
            ViewModel.SelectCurrenntSpells();
            ViewModel.SelectCurrentAbillities();


            return View("EditWarjack", ViewModel);
        }






        [HttpPost]
        public IActionResult Warjack(EditWarjackViewModel editModel)
        {
            Warjack editWarjack = context.Warjacks.Single(c => c.ID == editModel.soloID);



            editWarjack.ARM = editModel.ARM;
            editWarjack.CMD = editModel.CMD;
            editWarjack.DEF = editModel.DEF;
            editWarjack.FA = editModel.FA;
            editWarjack.MAT = editModel.MAT;
            editWarjack.RAT = editModel.RAT;
            editWarjack.Name = editModel.Name;
            editWarjack.SPD = editModel.SPD;
            editWarjack.PointCost = editModel.PointCost;
            editWarjack.STR = editModel.STR;
            editWarjack.factionName = editModel.Faction;
            editWarjack.Size = editModel.Size;
            context.SaveChanges();

            editModel.currenntAbilIDs = context.WarjackAbilities.Where(c => c.WarjackID == editWarjack.ID).Select(x => x.AbillityID).ToList();
         
            editModel.currenntWeaponIDs = context.WarjackWeapons.Where(c => c.WarjackId == editWarjack.ID).Select(x => x.WeaponId).ToList();






            if (editModel.abilIDS != null)
            {



                foreach (var abil in editModel.abilIDS)
                {

                    if (!editModel.currenntAbilIDs.Contains(abil))
                    {

                        WarjackAbillity NewSoloAbility = new WarjackAbillity();
                        NewSoloAbility.AbillityID = abil;
                        NewSoloAbility.WarjackID = editModel.soloID;
                        context.WarjackAbilities.Add(NewSoloAbility);
                        context.SaveChanges();

                    }




                    foreach (var currentAbil in editModel.currenntAbilIDs)
                    {

                        if (!editModel.abilIDS.Contains(currentAbil))
                        {

                            WarjackAbillity soloabil = (from s in context.WarjackAbilities where s.AbillityID == currentAbil where s.WarjackID == editModel.soloID select s).FirstOrDefault<WarjackAbillity>();
                            context.WarjackAbilities.Remove(soloabil);
                            context.SaveChanges();
                        }


                    }


                }

            }

            else
            {

                // delete all solo abils
                var soloAbils = context.WarjackAbilities.Where(c => c.WarjackID == editModel.soloID).ToList();

                foreach (var Abil in soloAbils)
                {
                    context.WarjackAbilities.Remove(Abil);
                    context.SaveChanges();

                }


            }














            if (editModel.weapIDS != null)
            {
                foreach (var weap in editModel.weapIDS)
                {

                    if (!editModel.currenntWeaponIDs.Contains(weap))
                    {
                        WarjackWeapon NewSoloWeapon = new WarjackWeapon();
                        NewSoloWeapon.WeaponId = weap;
                        NewSoloWeapon.WarjackId = editModel.soloID;
                        context.WarjackWeapons.Add(NewSoloWeapon);
                        context.SaveChanges();
                    }




                    foreach (var weaps in editModel.currenntWeaponIDs)
                    {

                        if (!editModel.weapIDS.Contains(weaps))
                        {

                            WarjackWeapon soloWeap = (from s in context.WarjackWeapons where s.WeaponId == weap where s.WarjackId == editModel.soloID select s).FirstOrDefault<WarjackWeapon>();
                            context.WarjackWeapons.Remove(soloWeap);
                            context.SaveChanges();
                        }

                    }
                }
            }


            else
            {

                // delete all solo abils
                var soloWeaps = context.WarjackWeapons.Where(c => c.WarjackId == editModel.soloID).ToList();

                foreach (var Weap in soloWeaps)
                {
                    context.WarjackWeapons.Remove(Weap);
                    context.SaveChanges();

                }


            }













            return Redirect("/View/Warjack/" + editModel.soloID);

        }



        [HttpGet]
        [Route("Edit/WarBeast/{SoloId}")]

        public IActionResult WarBeast(int SoloId)
        {

            WarBeast editModel = context.WarBeasts.Single(c => c.ID == SoloId);



            EditWarBeastViewModel ViewModel = new
             EditWarBeastViewModel
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



                currenntAbilIDs = context.UnitAbilities.Where(c => c.UnitID == SoloId).Select(x => x.AbilityID).ToList(),
                currenntSpellIDs = context.UnitSpells.Where(c => c.UnitID == SoloId).Select(x => x.SpellID).ToList(),
                currenntWeaponIDs = context.UnitWeapons.Where(c => c.UnitID == SoloId).Select(x => x.WeaponId).ToList()




            };

            ViewModel.SelecCurrenttWeapons();
            ViewModel.SelectCurrenntSpells();
            ViewModel.SelectCurrentAbillities();


            return View("EditWarBeast", ViewModel);
        }






        [HttpPost]
        [Route("Edit/WarBeast/{SoloId}")]
        public IActionResult WarBeast(EditWarBeastViewModel editModel)
        {
            WarBeast editWarBeast = context.WarBeasts.Single(c => c.ID == editModel.soloID);



            editWarBeast.ARM = editModel.ARM;
            editWarBeast.CMD = editModel.CMD;
            editWarBeast.DEF = editModel.DEF;
            editWarBeast.FA = editModel.FA;
            editWarBeast.MAT = editModel.MAT;
            editWarBeast.RAT = editModel.RAT;
            editWarBeast.Name = editModel.Name;
            editWarBeast.SPD = editModel.SPD;
            editWarBeast.PointCost = editModel.PointCost;
            editWarBeast.STR = editModel.STR;
            editWarBeast.factionName = editModel.Faction;
            editWarBeast.Size = editModel.Size;
            context.SaveChanges();

            editModel.currenntAbilIDs = context.WarbeastAbillities.Where(c => c.WarBeastid == editWarBeast.ID).Select(x => x.AbillityId).ToList();
            editModel.currenntSpellIDs = context.WarbeastSpells.Where(c => c.WarbeastId == editWarBeast.ID).Select(x => x.Spellid).ToList();
            editModel.currenntWeaponIDs = context.WarbeastWeapons.Where(c => c.WarbeastID == editWarBeast.ID).Select(x => x.WeaponId).ToList();






            if (editModel.abilIDS != null)
            {



                foreach (var abil in editModel.abilIDS)
                {

                    if (!editModel.currenntAbilIDs.Contains(abil))
                    {

                        WarBeastAbillity NewSoloAbility = new WarBeastAbillity();
                        NewSoloAbility.AbillityId = abil;
                        NewSoloAbility.WarBeastid = editModel.soloID;
                        context.WarbeastAbillities.Add(NewSoloAbility);
                        context.SaveChanges();

                    }




                    foreach (var currentAbil in editModel.currenntAbilIDs)
                    {

                        if (!editModel.abilIDS.Contains(currentAbil))
                        {

                            WarBeastAbillity soloabil = (from s in context.WarbeastAbillities where s.AbillityId == currentAbil where s.WarBeastid == editModel.soloID select s).FirstOrDefault<WarBeastAbillity>();
                            context.WarbeastAbillities.Remove(soloabil);
                            context.SaveChanges();
                        }


                    }


                }

            }

            else
            {

                // delete all solo abils
                var soloAbils = context.WarbeastAbillities.Where(c => c.WarBeastid == editModel.soloID).ToList();

                foreach (var Abil in soloAbils)
                {
                    context.WarbeastAbillities.Remove(Abil);
                    context.SaveChanges();

                }


            }














            if (editModel.weapIDS != null)
            {
                foreach (var weap in editModel.weapIDS)
                {

                    if (!editModel.currenntWeaponIDs.Contains(weap))
                    {
                        WarbeastWeapon NewSoloWeapon = new WarbeastWeapon();
                        NewSoloWeapon.WeaponId = weap;
                        NewSoloWeapon.WarbeastID = editModel.soloID;
                        context.WarbeastWeapons.Add(NewSoloWeapon);
                        context.SaveChanges();
                    }




                    foreach (var weaps in editModel.currenntWeaponIDs)
                    {

                        if (!editModel.weapIDS.Contains(weaps))
                        {

                            WarbeastWeapon soloWeap = (from s in context.WarbeastWeapons where s.WeaponId == weap where s.WarbeastID == editModel.soloID select s).FirstOrDefault<WarbeastWeapon>();
                            context.WarbeastWeapons.Remove(soloWeap);
                            context.SaveChanges();
                        }

                    }
                }
            }


            else
            {

                // delete all solo abils
                var soloWeaps = context.WarbeastWeapons.Where(c => c.WarbeastID == editModel.soloID).ToList();

                foreach (var Weap in soloWeaps)
                {
                    context.WarbeastWeapons.Remove(Weap);
                    context.SaveChanges();

                }


            }



            if (editModel.spellIDS != null)
            {
                foreach (var spell in editModel.spellIDS)
                {

                    if (!editModel.currenntSpellIDs.Contains(spell))
                    {
                        WarbeastSpell NewSoloSpell = new WarbeastSpell();
                        NewSoloSpell.Spellid = spell;
                        NewSoloSpell.WarbeastId = editModel.soloID;
                        context.WarbeastSpells.Add(NewSoloSpell);
                        context.SaveChanges();
                    }




                    foreach (var spells in editModel.currenntSpellIDs)
                    {

                        if (!editModel.spellIDS.Contains(spells))
                        {

                            WarbeastSpell soloSpell = (from s in context.WarbeastSpells where s.Spellid == spell where s.WarbeastId == editModel.soloID select s).FirstOrDefault<WarbeastSpell>();
                            context.WarbeastSpells.Remove(soloSpell);
                            context.SaveChanges();
                        }

                    }
                }
            }


            else
            {

                // delete all solo abils
                var soloSpells = context.WarbeastSpells.Where(c => c.WarbeastId == editModel.soloID).ToList();

                foreach (var Spell in soloSpells)
                {
                    context.WarbeastSpells.Remove(Spell);
                    context.SaveChanges();

                }


            }












            return Redirect("/View/WarBeast/" + editModel.soloID);

        }













        [HttpGet]
        [Route("Edit/Warlock/{SoloId}")]

        public IActionResult Warlock(int SoloId)
        {

            Warlock editModel = context.Warlocks.Single(c => c.ID == SoloId);



            EditWarlockViewModel ViewModel = new
             EditWarlockViewModel
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
                Feat = editModel.Feat,



                currenntAbilIDs = context.WarlockAbillities.Where(c => c.WarlockId == SoloId).Select(x => x.AbillityId).ToList(),
                currenntSpellIDs = context.WarlockSpells.Where(c => c.WarlockId == SoloId).Select(x => x.SpellId).ToList(),
                currenntWeaponIDs = context.WarjackWeapons.Where(c => c.WarjackId == SoloId).Select(x => x.WeaponId).ToList()




            };

            ViewModel.SelecCurrenttWeapons();
            ViewModel.SelectCurrenntSpells();
            ViewModel.SelectCurrentAbillities();


            return View("EditWarlock", ViewModel);
        }












        [HttpPost]
        [Route("Edit/Warlock/{SoloId}")]
        public IActionResult Warlock(EditWarlockViewModel editModel)
        {
            Warlock editWarlock = context.Warlocks.Single(c => c.ID == editModel.soloID);



            editWarlock.ARM = editModel.ARM;
            editWarlock.CMD = editModel.CMD;
            editWarlock.DEF = editModel.DEF;
            editWarlock.FA = editModel.FA;
            editWarlock.MAT = editModel.MAT;
            editWarlock.RAT = editModel.RAT;
            editWarlock.Name = editModel.Name;
            editWarlock.SPD = editModel.SPD;
            editWarlock.PointCost = editModel.PointCost;
            editWarlock.STR = editModel.STR;
            editWarlock.factionName = editModel.Faction;
            editWarlock.Feat = editModel.Feat;
            context.SaveChanges();

            editModel.currenntAbilIDs = context.WarlockAbillities.Where(c => c.WarlockId == editWarlock.ID).Select(x => x.AbillityId).ToList();
            editModel.currenntSpellIDs = context.WarlockSpells.Where(c => c.WarlockId == editWarlock.ID).Select(x => x.SpellId).ToList();
            editModel.currenntWeaponIDs = context.WarlockWeapons.Where(c => c.WarlockId == editWarlock.ID).Select(x => x.WeaponId).ToList();






            if (editModel.abilIDS != null)
            {



                foreach (var abil in editModel.abilIDS)
                {

                    if (!editModel.currenntAbilIDs.Contains(abil))
                    {

                        WarlockAbillity NewSoloAbility = new WarlockAbillity();
                        NewSoloAbility.AbillityId = abil;
                        NewSoloAbility.WarlockId = editModel.soloID;
                        context.WarlockAbillities.Add(NewSoloAbility);
                        context.SaveChanges();

                    }




                    foreach (var currentAbil in editModel.currenntAbilIDs)
                    {

                        if (!editModel.abilIDS.Contains(currentAbil))
                        {

                            WarlockAbillity soloabil = (from s in context.WarlockAbillities where s.AbillityId == currentAbil where s.WarlockId == editModel.soloID select s).FirstOrDefault<WarlockAbillity>();
                            context.WarlockAbillities.Remove(soloabil);
                            context.SaveChanges();
                        }


                    }


                }

            }

            else
            {

                // delete all solo abils
                var soloAbils = context.WarlockAbillities.Where(c => c.WarlockId == editModel.soloID).ToList();

                foreach (var Abil in soloAbils)
                {
                    context.WarlockAbillities.Remove(Abil);
                    context.SaveChanges();

                }


            }














            if (editModel.weapIDS != null)
            {
                foreach (var weap in editModel.weapIDS)
                {

                    if (!editModel.currenntWeaponIDs.Contains(weap))
                    {
                        WarlockWeapon NewSoloWeapon = new WarlockWeapon();
                        NewSoloWeapon.WeaponId = weap;
                        NewSoloWeapon.WarlockId = editModel.soloID;
                        context.WarlockWeapons.Add(NewSoloWeapon);
                        context.SaveChanges();
                    }




                    foreach (var weaps in editModel.currenntWeaponIDs)
                    {

                        if (!editModel.weapIDS.Contains(weaps))
                        {

                            WarlockWeapon soloWeap = (from s in context.WarlockWeapons where s.WeaponId == weap where s.WarlockId == editModel.soloID select s).FirstOrDefault<WarlockWeapon>();
                            context.WarlockWeapons.Remove(soloWeap);
                            context.SaveChanges();
                        }

                    }
                }
            }


            else
            {

                // delete all solo abils
                var soloWeaps = context.WarlockWeapons.Where(c => c.WarlockId == editModel.soloID).ToList();

                foreach (var Weap in soloWeaps)
                {
                    context.WarlockWeapons.Remove(Weap);
                    context.SaveChanges();

                }


            }



            if (editModel.spellIDS != null)
            {
                foreach (var spell in editModel.spellIDS)
                {

                    if (!editModel.currenntSpellIDs.Contains(spell))
                    {
                        WarlockSpell NewSoloSpell = new WarlockSpell();
                        NewSoloSpell.SpellId = spell;
                        NewSoloSpell.WarlockId = editModel.soloID;
                        context.WarlockSpells.Add(NewSoloSpell);
                        context.SaveChanges();
                    }




                    foreach (var spells in editModel.currenntSpellIDs)
                    {

                        if (!editModel.spellIDS.Contains(spells))
                        {

                            WarlockSpell soloSpell = (from s in context.WarlockSpells where s.SpellId == spell where s.WarlockId == editModel.soloID select s).FirstOrDefault<WarlockSpell>();
                            context.WarlockSpells.Remove(soloSpell);
                            context.SaveChanges();
                        }

                    }
                }
            }


            else
            {

                // delete all solo abils
                var soloSpells = context.WarlockSpells.Where(c => c.WarlockId == editModel.soloID).ToList();

                foreach (var Spell in soloSpells)
                {
                    context.WarlockSpells.Remove(Spell);
                    context.SaveChanges();

                }


            }












            return Redirect("/View/Warlock/" + editModel.soloID);

        }








        [HttpGet]
        [Route("Edit/Warcaster/{SoloId}")]

        public IActionResult Warcaster(int SoloId)
        {

            Warcaster editModel = context.Warcasters.Single(c => c.ID == SoloId);



            EditWarcasterViewModel ViewModel = new
             EditWarcasterViewModel
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
                Feat = editModel.Feat,



                currenntAbilIDs = context.WarcasterAbilities.Where(c => c.WarcasterId == SoloId).Select(x => x.AbilityId).ToList(),
                currenntSpellIDs = context.WarcasterSpells.Where(c => c.WarcasterId == SoloId).Select(x => x.SpellId).ToList(),
                currenntWeaponIDs = context.WarcasterWeapons.Where(c => c.WarcsaterId == SoloId).Select(x => x.WeaponId).ToList()




            };

            ViewModel.SelecCurrenttWeapons();
            ViewModel.SelectCurrenntSpells();
            ViewModel.SelectCurrentAbillities();


            return View("EditWarcaster", ViewModel);
        }












        [HttpPost]
        [Route("Edit/Warcaster/{SoloId}")]
        public IActionResult Warcaster(EditWarcasterViewModel editModel)
        {
            Warcaster editWarcaster = context.Warcasters.Single(c => c.ID == editModel.soloID);



            editWarcaster.ARM = editModel.ARM;
            editWarcaster.CMD = editModel.CMD;
            editWarcaster.DEF = editModel.DEF;
            editWarcaster.FA = editModel.FA;
            editWarcaster.MAT = editModel.MAT;
            editWarcaster.RAT = editModel.RAT;
            editWarcaster.Name = editModel.Name;
            editWarcaster.SPD = editModel.SPD;
            editWarcaster.PointCost = editModel.PointCost;
            editWarcaster.STR = editModel.STR;
            editWarcaster.factionName = editModel.Faction;
            editWarcaster.Feat = editModel.Feat;
            context.SaveChanges();

            editModel.currenntAbilIDs = context.WarcasterAbilities.Where(c => c.WarcasterId == editWarcaster.ID).Select(x => x.AbilityId).ToList();
            editModel.currenntSpellIDs = context.WarcasterSpells.Where(c => c.WarcasterId == editWarcaster.ID).Select(x => x.SpellId).ToList();
            editModel.currenntWeaponIDs = context.WarcasterWeapons.Where(c => c.WarcsaterId == editWarcaster.ID).Select(x => x.WeaponId).ToList();






            if (editModel.abilIDS != null)
            {



                foreach (var abil in editModel.abilIDS)
                {

                    if (!editModel.currenntAbilIDs.Contains(abil))
                    {

                        WarcasterAbility NewSoloAbility = new WarcasterAbility();
                        NewSoloAbility.AbilityId = abil;
                        NewSoloAbility.WarcasterId = editModel.soloID;
                        context.WarcasterAbilities.Add(NewSoloAbility);
                        context.SaveChanges();

                    }




                    foreach (var currentAbil in editModel.currenntAbilIDs)
                    {

                        if (!editModel.abilIDS.Contains(currentAbil))
                        {

                            WarcasterAbility soloabil = (from s in context.WarcasterAbilities where s.AbilityId == currentAbil where s.WarcasterId == editModel.soloID select s).FirstOrDefault<WarcasterAbility>();
                            context.WarcasterAbilities.Remove(soloabil);
                            context.SaveChanges();
                        }


                    }


                }

            }

            else
            {

                // delete all solo abils
                var soloAbils = context.WarcasterAbilities.Where(c => c.WarcasterId == editModel.soloID).ToList();

                foreach (var Abil in soloAbils)
                {
                    context.WarcasterAbilities.Remove(Abil);
                    context.SaveChanges();

                }


            }














            if (editModel.weapIDS != null)
            {
                foreach (var weap in editModel.weapIDS)
                {

                    if (!editModel.currenntWeaponIDs.Contains(weap))
                    {
                        WarcasterWeapon NewSoloWeapon = new WarcasterWeapon();
                        NewSoloWeapon.WeaponId = weap;
                        NewSoloWeapon.WarcsaterId = editModel.soloID;
                        context.WarcasterWeapons.Add(NewSoloWeapon);
                        context.SaveChanges();
                    }




                    foreach (var weaps in editModel.currenntWeaponIDs)
                    {

                        if (!editModel.weapIDS.Contains(weaps))
                        {

                            WarcasterWeapon soloWeap = (from s in context.WarcasterWeapons where s.WeaponId == weap where s.WarcsaterId == editModel.soloID select s).FirstOrDefault<WarcasterWeapon>();
                            context.WarcasterWeapons.Remove(soloWeap);
                            context.SaveChanges();
                        }

                    }
                }
            }


            else
            {

                // delete all solo abils
                var soloWeaps = context.WarcasterWeapons.Where(c => c.WarcsaterId == editModel.soloID).ToList();

                foreach (var Weap in soloWeaps)
                {
                    context.WarcasterWeapons.Remove(Weap);
                    context.SaveChanges();

                }


            }



            if (editModel.spellIDS != null)
            {
                foreach (var spell in editModel.spellIDS)
                {

                    if (!editModel.currenntSpellIDs.Contains(spell))
                    {
                        WarcasterSpell NewSoloSpell = new WarcasterSpell();
                        NewSoloSpell.SpellId = spell;
                        NewSoloSpell.WarcasterId = editModel.soloID;
                        context.WarcasterSpells.Add(NewSoloSpell);
                        context.SaveChanges();
                    }




                    foreach (var spells in editModel.currenntSpellIDs)
                    {

                        if (!editModel.spellIDS.Contains(spells))
                        {

                            WarcasterSpell soloSpell = (from s in context.WarcasterSpells where s.SpellId == spell where s.WarcasterId == editModel.soloID select s).FirstOrDefault<WarcasterSpell>();
                            context.WarcasterSpells.Remove(soloSpell);
                            context.SaveChanges();
                        }

                    }
                }
            }


            else
            {

                // delete all solo abils
                var soloSpells = context.WarcasterSpells.Where(c => c.WarcasterId == editModel.soloID).ToList();

                foreach (var Spell in soloSpells)
                {
                    context.WarcasterSpells.Remove(Spell);
                    context.SaveChanges();

                }


            }












            return Redirect("/View/Warcaster/" + editModel.soloID);

        }





        [HttpGet]
        [Route("Edit/Spell/{id}")]
        public IActionResult Spell(int id)
        {

            Spell editSpell = context.Spells.Single(c => c.ID == id);

            EditSpellViewModel ViewModel = new EditSpellViewModel()
            {

                AOE = editSpell.AOE,
                Cost = editSpell.Cost,
                Description = editSpell.Description,
                Duration = editSpell.Duration,
                Name = editSpell.Name,
                OFF = editSpell.OFF,
                POW = editSpell.POW,
                RNG = editSpell.RNG,
                soloID = editSpell.ID
              };

            return View("EditSpell", ViewModel);



        }




        [HttpPost]
        [Route("Edit/Spell/{id}")]
        public IActionResult Spell(EditSpellViewModel editModel)
        {

            Spell editSpell = context.Spells.Single(c => c.ID == editModel.soloID);
            editSpell.Name = editModel.Name;
            editSpell.OFF = editModel.OFF;
            editSpell.POW = editModel.POW;
            editSpell.RNG = editModel.RNG;
            editSpell.isAnimi = editModel.isAnimi;
            editSpell.Cost = editModel.Cost;
            editSpell.Description = editModel.Description;
            editSpell.AOE = editModel.AOE;

            context.SaveChanges();

            return Redirect("/View/Spell/" + editModel.soloID);



        }

         [HttpGet]
        [Route("Edit/Weapon/{id}")]
        public IActionResult Weapon(int id)
        {

            Weapon weapon = context.Weapons.Single(c => c.ID == id);

            EditWeaponViewModel editWweapon = new EditWeaponViewModel()
            {
                Name = weapon.Name,
                POW = weapon.POW,
                RNG = weapon.RNG,
                ROF = weapon.ROF,
                Type = weapon.Type,
                Soloid = weapon.ID

            };




            return View("EditWeapon", editWweapon);




        }


        [HttpPost]
        [Route("Edit/Weapon/{id}")]
        public IActionResult Weapon(EditWeaponViewModel editModel)
        {

            Weapon editWeap = context.Weapons.Single(c => c.ID == editModel.Soloid);

            editWeap.Name = editModel.Name;
            editWeap.POW = editModel.POW;
            editWeap.RNG = editModel.RNG;
            editWeap.ROF = editModel.ROF;
            editWeap.Type = editModel.Type;
            context.SaveChanges();

            return Redirect("/View/Weapon/" + editModel.Soloid);


        







        }



        [HttpGet]
        [Route("Edit/Abillity/{SoloId}")]
        public IActionResult Abillity(int SoloId)
        {

            Ability Ability = context.Abilities.Single(c => c.ID == SoloId);

            EditAbillityViewModel editAbillity = new EditAbillityViewModel()
            {
                Name = Ability.Name,
               Description = Ability.Description
            };




            return View("EditAbillity", editAbillity);



        }




        [HttpPost]
        [Route("Edit/Abillity/{SoloId}")]
        public IActionResult Abillity(EditAbillityViewModel editModel)
        {

            Ability editAbil = context.Abilities.Single(c => c.ID == editModel.SoloId);

            editAbil.Name = editModel.Name;
            editAbil.Description = editModel.Description;
            context.SaveChanges();

            return Redirect("/View/Abillity/" + editModel.SoloId);




           





        }







    }
}
