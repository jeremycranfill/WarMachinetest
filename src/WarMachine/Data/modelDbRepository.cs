using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Data
{
    public  class modelDbRepository
    {
        public modelDbRepository(ModelDbContext context)
        {
            _context = context;
        }


        ModelDbContext _context;


        public  IEnumerable<SoloModel> getSolosByName(string Name)
        {
            IEnumerable<SoloModel> solos;

            solos = _context.Solos.Where(c => c.Name.ToLower().Contains(Name.ToLower()));

            return solos;

        }


        public IEnumerable<UnitModel> getUnitsByName(string Name)
        {
            IEnumerable<UnitModel> units;

            units = _context.Units.Where(c => c.Name.ToLower().Contains(Name.ToLower()));

            return units;

        }

        public IEnumerable<Warlock> getWarlocksByName(string Name)
        {
            IEnumerable<Warlock> Warlocks;

            Warlocks = _context.Warlocks.Where(c => c.Name.ToLower().Contains(Name.ToLower()));

            return Warlocks;

        }
        public IEnumerable<Warcaster> getWarcastersByName(string Name)
        {
            IEnumerable<Warcaster> Warcasters;

            Warcasters = _context.Warcasters.Where(c => c.Name.ToLower().Contains(Name.ToLower()));

            return Warcasters;

        }

        public IEnumerable<Warjack> getWarjacksByName(string Name)
        {
            IEnumerable<Warjack> Warjacks;

            Warjacks = _context.Warjacks.Where(c => c.Name.ToLower().Contains(Name.ToLower()));

            return Warjacks;

        }

        public IEnumerable<WarBeast> getWarBeastsByName(string Name)
        {
            IEnumerable<WarBeast> WarBeasts;

            WarBeasts = _context.WarBeasts.Where(c => c.Name.ToLower().Contains(Name.ToLower()));

            return WarBeasts;

        }

        public IEnumerable<Spell> getSpellsByName(string Name)
        {
            IEnumerable<Spell> Spells;

            Spells = _context.Spells.Where(c => c.Name.ToLower().Contains(Name.ToLower()));

            return Spells;

        }
        public IEnumerable<Ability> getAbillitiesByName(string Name)
        {
            IEnumerable<Ability> abils;

            abils = _context.Abilities.Where(c => c.Name.ToLower().Contains(Name.ToLower()));

            return abils;

        }



    }
}
