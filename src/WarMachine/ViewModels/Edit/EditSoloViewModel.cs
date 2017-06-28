using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.ViewModels.Edit
{
    public class EditSoloViewModel : SoloViewModel
    {


        public EditSoloViewModel() { }

        public EditSoloViewModel(IList<Ability> abills, IList<Weapon> weapons, IList<Spell> spells)
        {

            allAbills = new List<SelectListItem>();
            foreach (var abil in abills)
            {
                var item = new SelectListItem
                {
                    Value = abil.ID.ToString(),
                    Text = abil.Name

                };

                allAbills.Add(item);
            }



            allWeaps = new List<SelectListItem>();
            foreach (var weapon in weapons)
            {
                var item = new SelectListItem
                {
                    Value = weapon.ID.ToString(),
                    Text = weapon.Name
                };

                allWeaps.Add(item);
            }

            allSpells = new List<SelectListItem>();
            foreach (var spell in spells)
            {
                var item = new SelectListItem
                {
                    Value = spell.ID.ToString(),
                    Text = spell.Name
                };

                allSpells.Add(item);
            }


            currenntAbilIDs = new List<int>();
            currenntSpellIDs = new List<int>();
            currenntWeaponIDs = new List<int>();

        }


        public int soloID { get; set; }

        public List<int> currenntAbilIDs { get; set; }
        public List<int> currenntSpellIDs { get; set; }
        public List<int> currenntWeaponIDs { get; set; }
        [Display(Name ="Abillities")]
        public List<int> AbilIDs { get; set; }
        [Display(Name = "Spells")]
        public List<int> SpellIDs { get; set; }
        [Display(Name = "Weapons")]
        public List<int> WeaponIDs { get; set; }



        public void SelecCurrenttWeapons()
        {
            foreach (var item in allWeaps)
            {
                if (currenntWeaponIDs.Contains(Int32.Parse(item.Value)))
                {
                    item.Selected = true;

                }
            }
        }



        public void SelectCurrentAbillities()
        {
            foreach (var item in allAbills)
            {
                if (currenntAbilIDs.Contains(Int32.Parse(item.Value)))
                {
                    item.Selected = true;

                }
            }
        }


        public void SelectCurrenntSpells()


        {
            foreach (var item in allSpells)
            {
                if (currenntSpellIDs.Contains(Int32.Parse(item.Value)))
                {
                    item.Selected = true;

                }
            }









        }
    }
}


