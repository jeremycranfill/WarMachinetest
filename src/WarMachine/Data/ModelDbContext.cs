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



            modelBuilder.Entity<SoloModel>().HasMany<SoloAbility>(i => i.SoloAbilities);
            modelBuilder.Entity<SoloModel>().HasMany<SoloSpell>(i => i.SoloSpells);
            modelBuilder.Entity<SoloModel>().HasMany<SoloWeapon>(i => i.SoloWeapons);

            






            modelBuilder.Entity<Ability>().HasMany<SoloAbility>(i => i.SoloAbilities);
            modelBuilder.Entity<Ability>().HasMany<UnitAbiliity>(i => i.UnitAbillities);

            modelBuilder.Entity<Spell>().HasMany<SoloSpell>(s => s.SoloSpells);
            modelBuilder.Entity<Spell>().HasMany<UnitSpell>(s => s.UnitSpells);

            modelBuilder.Entity<Weapon>().HasMany<SoloWeapon>(w => w.SoloWeapons);
            modelBuilder.Entity<Weapon>().HasMany<UnitWeapon>(w => w.UnitWeapons);



            modelBuilder.Entity<SoloModel>().HasOne<Faction>(i => i.Faction);
            modelBuilder.Entity<UnitModel>().HasOne<Faction>(i => i.Faction);
            modelBuilder.Entity<WarBeast>().HasOne<Faction>(i => i.Faction);
            modelBuilder.Entity<WarBeast>().HasOne<Faction>(i => i.Faction);
           









        }
    }
}
