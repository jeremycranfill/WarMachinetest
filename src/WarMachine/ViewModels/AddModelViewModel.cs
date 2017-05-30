using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.ViewModels
{
    public class AddModelViewModel
    {

        public string AddType { get; set; }






        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

        public AddModelViewModel() {

            Categories.Add(new SelectListItem
            {
                Value = "AddUnit",
                Text = "Unit"
            });

            Categories.Add(new SelectListItem
            {
                Value = "Solo",
                Text = "Solo"
            });

            Categories.Add(new SelectListItem
            {
                Value = "Warjack",
                Text = "Warjack"
            });

            Categories.Add(new SelectListItem
            {
                Value = "WarBeast",
                Text = "WarBeast"
            });






        }

      










    }
}
