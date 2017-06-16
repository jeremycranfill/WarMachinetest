using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models;
using WarMachine.Models.WarModels;

namespace WarMachine.ViewModels
{
    public class EditAbilityViewModel
    {

        //this might not be needed
  

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        //public List<SelectListItem> Abilities { get; set; } = new List<SelectListItem>();


        public int Soloid { get; set; }
    }
}
