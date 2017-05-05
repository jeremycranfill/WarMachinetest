using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarMachine.Models.WarModels;
using WarMachine.Data;
using WarMachine.ViewModels.Edit;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WarMachine.Controllers
{
    public class EditController : Controller
    {

        private readonly ModelDbContext context;
        public EditController(ModelDbContext dbContext) { context = dbContext; }






        // GET: /<controller>/




        public IActionResult Index()
        {

            IList<SoloModel> solos = context.Solos.ToList();
            return View("SoloIndex", solos);


        }






        [HttpGet]
        [Route("Edit/Solo/{SoloId}")]

        public IActionResult Solo(int SoloId)
        {

         
            List<Ability> AbilityList = context.Abilities.ToList();
            SoloModel editSolo = context.Solos.Single(c => c.ID == SoloId);

            EditSoloViewModel ViewModel = new EditSoloViewModel(AbilityList)

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
                ID = editSolo.ID
                
                
                     
            };

            return View("EditSolo", ViewModel);
            
        }

        [HttpPost]
        public IActionResult Solo(EditSoloViewModel editModel)
        {

            SoloModel editSolo = context.Solos.Single(c => c.ID == editModel.ID);



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
               



            

            context.SaveChanges();

            return Redirect("/View/Solo");




        }






    }
}
