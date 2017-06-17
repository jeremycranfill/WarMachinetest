using WarMachine.Models;
using Microsoft.EntityFrameworkCore;
using WarMachine.Models.ManageViewModels;
using WarMachine.Models.WarModels;
using WarMachine.Models.Joins;

namespace WarMachine.Data
{
    public class ModelDbContext : DbContext
    {
        public DbSet<UnitModel> Units { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<SoloModel> Solos { get; set; }
        public DbSet<RuleModel> Rules { get; set; }
        public DbSet<SoloAbility> SoloAbilities { get; set; }
        public DbSet<SoloSpell> SoloSpells { get; set; }
        public DbSet<SoloWeapon> SoloWeapons { get; set; }
        public DbSet<UnitAbiliity> UnitAbilities { get; set; }
        public DbSet<UnitWeapon> UnitWeapons { get; set; }
        public DbSet<UnitSpell> UnitSpells { get; set; } 
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Warjack> Warjacks { get; set; }
        public DbSet<WarBeast> WarBeasts { get; set; }
        public DbSet<Warlock> Warlocks { get; set; }
        public DbSet<Warcaster> Warcasters { get; set; }

        public DbSet<WarjackAbillity> WarjackAbilities { get; set; }
        public DbSet<WarjackWeapon> WarjackWeapons { get; set; }

        public DbSet<WarbeastSpell> WarbeastSpells { get; set; }
        public DbSet<WarBeastAbillity> WarbeastAbillities { get; set; }
        public DbSet<WarbeastWeapon> WarbeastWeapons { get; set; }

        public DbSet<WarcasterAbility> WarcasterAbilities { get; set; }
        public DbSet<WarcasterWeapon> WarcasterWeapons { get; set; }
        public DbSet<WarcasterSpell> WarcasterSpells { get; set; }

        public DbSet<WarlockAbillity> WarlockAbillities { get; set; }
        public DbSet<WarlockWeapon> WarlockWeapons { get; set; }
        public DbSet<WarlockSpell> WarlockSpells { get; set; }




        public ModelDbContext(DbContextOptions<ModelDbContext> options)
                : base(options) {   }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WarBeast>().HasKey(c => c.ID);
            modelBuilder.Entity<Warjack>().HasKey(c => c.ID);
            modelBuilder.Entity<Ability>().HasKey(c => c.ID);
            modelBuilder.Entity<Spell>().HasKey(c => c.ID);
            modelBuilder.Entity<Weapon>().HasKey(c => c.ID);
            modelBuilder.Entity<UnitModel>().HasKey(c => c.ID);
            modelBuilder.Entity<SoloModel>().HasKey(c => c.ID);
            modelBuilder.Entity<Faction>().HasKey(c => c.ID);
            modelBuilder.Entity<SoloAbility>().HasKey(c => new { c.AbilityID, c.SoloID });

            modelBuilder.Entity<SoloSpell>().HasKey(c => new { c.SpellID, c.SoloID });

            modelBuilder.Entity<SoloWeapon>().HasKey(c => new { c.WeaponID  , c.SoloID });

            modelBuilder.Entity<UnitAbiliity>().HasKey(c => new { c.UnitID, c.AbilityID });

            modelBuilder.Entity<UnitWeapon>().HasKey(c => new { c.UnitID, c.WeaponId });

            modelBuilder.Entity<UnitSpell>().HasKey(c => new { c.SpellID, c.UnitID });

            modelBuilder.Entity<WarBeastAbillity>().HasKey(c => new { c.AbillityId, c.WarBeastid });
            modelBuilder.Entity<WarbeastSpell>().HasKey(c => new { c.Spellid, c.WarbeastId });
            modelBuilder.Entity<WarbeastWeapon>().HasKey(c => new { c.WeaponId, c.WarbeastID });

            modelBuilder.Entity<WarjackAbillity>().HasKey(c => new { c.AbillityID, c.WarjackID });
            modelBuilder.Entity<WarjackWeapon>().HasKey(c => new { c.WeaponId, c.WarjackId });

            modelBuilder.Entity<WarcasterAbility>().HasKey(c => new { c.AbilityId, c.WarcasterId });
            modelBuilder.Entity<WarcasterSpell>().HasKey(c => new { c.SpellId, c.WarcasterId });
            modelBuilder.Entity<WarcasterWeapon>().HasKey(c => new { c.WeaponId, c.WarcsaterId });

            modelBuilder.Entity<WarlockAbillity>().HasKey(c => new { c.AbillityId, c.WarlockId });
            modelBuilder.Entity<WarlockSpell>().HasKey(c => new { c.SpellId, c.WarlockId });
            modelBuilder.Entity<WarlockWeapon>().HasKey(c => new { c.WeaponId, c.WarlockId });








            modelBuilder.Entity<SoloModel>().HasMany<SoloAbility>(i => i.SoloAbilities);
            modelBuilder.Entity<SoloModel>().HasMany<SoloSpell>(i => i.SoloSpells);
            modelBuilder.Entity<SoloModel>().HasMany<SoloWeapon>(i => i.SoloWeapons);


            modelBuilder.Entity<UnitModel>().HasMany<UnitAbiliity>(i => i.UnitAbillities);
            modelBuilder.Entity<UnitModel>().HasMany<UnitSpell>(i => i.UnitSpells);
            modelBuilder.Entity<UnitModel>().HasMany<UnitWeapon>(i => i.UnitWeapons);

            modelBuilder.Entity<WarBeast>().HasMany<WarbeastSpell>(i => i.WarbeastSpells);
            modelBuilder.Entity<WarBeast>().HasMany<WarbeastWeapon>(i => i.WarbeastWeapons);
            modelBuilder.Entity<WarBeast>().HasMany<WarBeastAbillity>(i => i.WarbeastAbiliities);

            modelBuilder.Entity<Warjack>().HasMany<WarjackWeapon>(i => i.WarjackWeapons);
            modelBuilder.Entity<Warjack>().HasMany<WarjackAbillity>(i => i.WarjackAbilities);

            modelBuilder.Entity<Warlock>().HasMany<WarlockSpell>(i => i.WarlockSpells);
            modelBuilder.Entity<Warlock>().HasMany<WarlockAbillity>(i => i.WarlockAbillities);
            modelBuilder.Entity<Warlock>().HasMany<WarlockWeapon>(i => i.WarlockWeapons);







            modelBuilder.Entity<Ability>().HasMany<SoloAbility>(i => i.SoloAbilities);
            modelBuilder.Entity<Ability>().HasMany<UnitAbiliity>(i => i.UnitAbillities);
            modelBuilder.Entity<Ability>().HasMany<WarlockAbillity>(i => i.WarlockAbillities);
            modelBuilder.Entity<Ability>().HasMany<WarcasterAbility>(i => i.WarcasterAbillities);
            modelBuilder.Entity<Ability>().HasMany<WarjackAbillity>(i => i.WarjackAbillities);
            modelBuilder.Entity<Ability>().HasMany<WarlockAbillity>(i => i.WarlockAbillities);

            modelBuilder.Entity<Spell>().HasMany<SoloSpell>(s => s.SoloSpells);
            modelBuilder.Entity<Spell>().HasMany<UnitSpell>(s => s.UnitSpells);
            modelBuilder.Entity<Spell>().HasMany<WarlockSpell>(s => s.WarlockSpells);
            modelBuilder.Entity<Spell>().HasMany<WarcasterSpell>(s => s.WarcasterSpells);
            modelBuilder.Entity<Spell>().HasMany<WarbeastSpell>(s => s.WarBeastSpells);





            modelBuilder.Entity<Weapon>().HasMany<SoloWeapon>(w => w.SoloWeapons);
            modelBuilder.Entity<Weapon>().HasMany<UnitWeapon>(w => w.UnitWeapons);
            modelBuilder.Entity<Weapon>().HasMany<WarjackWeapon>(w => w.WarjackWeapons);
            modelBuilder.Entity<Weapon>().HasMany<WarbeastWeapon>(w => w.WarbeastWeapons);
            modelBuilder.Entity<Weapon>().HasMany<WarcasterWeapon>(w => w.WarcasterWeapons);
            modelBuilder.Entity<Weapon>().HasMany<WarlockWeapon>(w => w.WarlockWeapons);



            modelBuilder.Entity<SoloModel>().HasOne<Faction>(i => i.Faction);
            modelBuilder.Entity<UnitModel>().HasOne<Faction>(i => i.Faction);
            modelBuilder.Entity<WarBeast>().HasOne<Faction>(i => i.Faction);
            modelBuilder.Entity<WarBeast>().HasOne<Faction>(i => i.Faction);
           









        }
    }
}
