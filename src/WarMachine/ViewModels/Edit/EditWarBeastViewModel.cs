using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;
using static WarMachine.Models.WarModels.WarBeast;

namespace WarMachine.ViewModels.Edit
{
    public class EditWarBeastViewModel : EditSoloViewModel
    {

        public EditWarBeastViewModel() { }

        public EditWarBeastViewModel(IList<Ability> abills, IList<Weapon> weapons, IList<Spell> spells)
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

                allWeaps.Add(item);
            }


            currenntAbilIDs = new List<int>();
            currenntSpellIDs = new List<int>();
            currenntWeaponIDs = new List<int>();

        }




        [Required]
        public int Fury { get; set; }

        [Required]
        public int Threshold { get; set; }

        [Required]
        public sizes Size { get; set; }




}






}



