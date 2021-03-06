﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;
using static WarMachine.ViewModels.BasedModelViewModel;

using WarMachine.Data;

namespace WarMachine.Models.WarModels
{
    public abstract class BaseModel
    {
        
        public string Name { get; set; }
        public IList<Weapon> Weapons { get; set; }
        public IList<Spell> Spells { get; set; }
        public IList<Ability> Abilities { get; set; }

        public  int SPD { get; set; }
        public int STR { get; set; }
        public int MAT { get; set; }
        public int RAT { get; set; }
        public int DEF { get; set; }
        public int ARM { get; set; }
        public int CMD { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }



        public int PointCost { get; set; }
        public string FA { get; set; }
        public Faction Faction { get; set; }

        public FactionName factionName { get; set; }
      


        virtual public  IList<String> GetProps()

        {
            IList<string> Props =
                new[] { "Name", "SPD", "STR", "MAT", "RAT", "DEF", "ARM", "CMD", "PointCost", "FA", "factionName" };
            return Props;


        }


        virtual public void Delete(ModelDbContext context)
        { }


    }

}

