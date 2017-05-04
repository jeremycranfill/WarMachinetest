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

        public ModelDbContext(DbContextOptions<ModelDbContext> options)
                : base(options) {   }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            modelBuilder.Entity<RuleModel>().HasKey(i => i.ID);
            modelBuilder.Entity<Ability>().HasKey(c => c.ID);
            modelBuilder.Entity<Spell>().HasKey(c => c.ID);
            modelBuilder.Entity<Weapon>().HasKey(c => c.ID);
            modelBuilder.Entity<UnitModel>().HasKey(c => c.ID);
            modelBuilder.Entity<SoloModel>().HasKey(c => c.ID);
            modelBuilder.Entity<SoloAbility>().HasKey(c => new { c.AbilityID, c.SoloID });

            
            modelBuilder.Entity<SoloModel>().HasMany<SoloAbility>(i => i.SoloAbilities);
            modelBuilder.Entity<Ability>().HasMany<SoloAbility>(i => i.SoloAbilities);





        }
    }
}
