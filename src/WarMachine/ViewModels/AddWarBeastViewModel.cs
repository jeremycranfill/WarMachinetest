using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;
using static WarMachine.Models.WarModels.WarBeast;

namespace WarMachine.ViewModels
{
    public class AddWarBeastViewModel : SoloViewModel
    {
        public AddWarBeastViewModel() { }
        public AddWarBeastViewModel(IList<Ability> abills, IList<Weapon> weapons, IList<Spell> spells) 
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

        }

    



    public sizes Size { get; set; }
        public int Fury { get; set;}
        public int Threshold { get; set; }




    }
}
