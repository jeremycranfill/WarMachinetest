using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarMachine.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WarMachine.Controllers
{
    
    public class SearchController : Controller
    {
       private ModelDbContext context;
        private modelDbRepository repository;

        public SearchController(ModelDbContext _context, modelDbRepository _repository)
        {
            context = _context;
            repository = _repository;

        }




        public IActionResult Index()


        {

            return View();


        }


        [HttpPost]
        public IActionResult Index(string Type, string Value)
        {
            ViewBag.Type = Type;
            switch (Type)
            {
                
                case "Solo":
                    return View("SearchResult", repository.getSolosByName(Value));
                case "Warcaster":
                    return View("SearchResult", repository.getWarcastersByName(Value));
                case "Warlock":
                    return View("SearchResult", repository.getWarlocksByName(Value));
                case "Warjack":
                    return View("SearchResult", repository.getWarjacksByName(Value));
                case "Warbeast":
                    return View("SearchResult", repository.getWarBeastsByName(Value));
                case "Unit":
                    return View("SearchResult", repository.getUnitsByName(Value));
                case "Spell":
                    return View("SpellResult", repository.getSpellsByName(Value));
                case "Abillity":
                    return View("AbillityResult", repository.getAbillitiesByName(Value));







                default:
                    break;

            }


            return Content(Value);

        }

    }
}
