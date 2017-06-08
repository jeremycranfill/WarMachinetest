using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.ViewModels
{
    public class BasedModelViewModel
    {



        public BasedModelViewModel() { }
        public BasedModelViewModel(IList<Ability> abills, IList<Weapon> weapons, IList<Spell> spells)
        {

            allAbills = new List<SelectListItem>();
            foreach(var abil in abills)
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




            



        }


        [Required]
        public string Name { get; set; }

        [Required]
        public string FA { get; set; }

        [Required]
        public int SPD { get; set; }

        [Required]
        public int STR { get; set; }

        [Required]
        public int MAT { get; set; }

        [Required]
        public int RAT { get; set; }

        [Required]
        public int DEF { get; set; }

        [Required]
        public int ARM { get; set; }

        [Required]
        public int CMD { get; set; }
        
        [Required]
        public int PointCost { get; set; }

        public List<SelectListItem> allAbills { get; set; }
        public List<int> abilIDS { get; set; }

        public IList<SelectListItem> allWeaps { get; set; }
        public List<int>weapIDS { get; set; }

       public IList<SelectListItem> allSpells { get; set; }
       public IList<int> spellIDS { get; set; }






    }
}
