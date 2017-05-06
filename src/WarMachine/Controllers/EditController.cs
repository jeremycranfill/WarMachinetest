﻿using System;
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

        [HttpGet]
        [Route("Edit/Unit/{UnitId}")]

        public IActionResult Unit(int UnitId)
        {


            List<Ability> AbilityList = context.Abilities.ToList();
            UnitModel editUnit = context.Units.Single(c => c.ID == UnitId);

            EditUnitViewModel ViewModel = new EditUnitViewModel(AbilityList)

            {

                ARM = editUnit.ARM,
                CMD = editUnit.CMD,
                DEF = editUnit.DEF,
                FA = editUnit.FA,
                MAT = editUnit.MAT,
                RAT = editUnit.RAT,
                Name = editUnit.Name,
                SPD = editUnit.SPD,
                PointCost = editUnit.PointCost,
                STR = editUnit.STR,
                ID = editUnit.ID,
                MaxUnit = editUnit.MaxUnit,
                MinUnit = editUnit.MinUnit



            };
            return View("EditUnit", ViewModel);
        }
        [HttpPost]
        public IActionResult Unit(EditUnitViewModel editModel)
        {

            UnitModel editUnit = context.Units.Single(c => c.ID == editModel.ID);



            editUnit.ARM = editModel.ARM;
            editUnit.CMD = editModel.CMD;
            editUnit.DEF = editModel.DEF;
            editUnit.FA = editModel.FA;
            editUnit.MAT = editModel.MAT;
            editUnit.RAT = editModel.RAT;
            editUnit.Name = editModel.Name;
            editUnit.SPD = editModel.SPD;
            editUnit.PointCost = editModel.PointCost;
            editUnit.STR = editModel.STR;
            editUnit.MaxUnit = editModel.MaxUnit;
            editUnit.MinUnit = editModel.MaxUnit;







            context.SaveChanges();

            return Redirect("/View/Unit");




        }
    }
}
