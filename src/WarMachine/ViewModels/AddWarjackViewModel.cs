using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;
using static WarMachine.Models.WarModels.Warjack;

namespace WarMachine.ViewModels
{
    public class AddWarjackViewModel : SoloViewModel
    {
        public AddWarjackViewModel() { }
        public AddWarjackViewModel(IList<Ability> abills, IList<Weapon> weapons, IList<Spell> spells) : base()
        {}
       
            
            
            public Sizes Size { get; set; }




    }
}
