using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarMachine.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WarMachine.Controllers
{
    public class DeleteController : Controller
    {
        

            private readonly ModelDbContext context;
            public DeleteController(ModelDbContext dbContext) { context = dbContext; }




            [HttpGet]
        public IActionResult Index(string Type, string name, int ID)
        {
            ViewBag.ID = ID;
            ViewBag.Type = Type;
            ViewBag.Name = name;

            return View();
        }

         [HttpPost]
         public IActionResult Delete(string Type,  int ID)
         {
            if (Type == "Solo")
            {
                var deleteThis = context.Solos.Single(c => c.ID == ID);
                deleteThis.Delete(context);
                return Redirect("/");
                

            }



            if (Type == "Unit")
            {
                var deleteThis = context.Units.Single(c => c.ID == ID);
                deleteThis.Delete(context);
                return Redirect("/");


            }

            if (Type == "Warbeast")
            {
                var deleteThis = context.WarBeasts.Single(c => c.ID == ID);
                deleteThis.Delete(context);
                return Redirect("/");


            }


            if (Type == "Warjack")
            {
                var deleteThis = context.Warjacks.Single(c => c.ID == ID);
                deleteThis.Delete(context);
                return Redirect("/");


            }

            if (Type == "Warlock")
            {
                var deleteThis = context.Warlocks.Single(c => c.ID == ID);
                deleteThis.Delete(context);
                return Redirect("/");


            }

            if (Type == "Warcaster")
            {
                var deleteThis = context.Warcasters.Single(c => c.ID == ID);
                deleteThis.Delete(context);
                return Redirect("/");


            }

            if (Type == "Abillity")
            {
                var deleteThis = context.Abilities.Single(c => c.ID == ID);
                deleteThis.Delete(context);
                return Redirect("/");


            }


            if (Type == "Weapon")
            {
                var deleteThis = context.Weapons.Single(c => c.ID == ID);
                deleteThis.Delete(context);
                return Redirect("/");


            }

            if (Type == "Spell")
            {
                var deleteThis = context.Spells.Single(c => c.ID == ID);
                deleteThis.Delete(context);
                return Redirect("/");


            }


            return Redirect("/");

        }



        


    }
}
