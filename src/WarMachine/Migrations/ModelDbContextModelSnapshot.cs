using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WarMachine.Data;

namespace WarMachine.Migrations
{
    [DbContext(typeof(ModelDbContext))]
    partial class ModelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WarMachine.Models.WarModels.Ability", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.RuleModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.SoloModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ARM");

                    b.Property<int>("CMD");

                    b.Property<int>("DEF");

                    b.Property<int>("FA");

                    b.Property<string>("Faction");

                    b.Property<int>("MAT");

                    b.Property<string>("Name");

                    b.Property<int>("PointCost");

                    b.Property<int>("RAT");

                    b.Property<int>("SPD");

                    b.Property<int>("STR");

                    b.HasKey("ID");

                    b.ToTable("Solos");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Spell", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AOE");

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Duration");

                    b.Property<string>("Name");

                    b.Property<bool>("OFF");

                    b.Property<int>("POW");

                    b.Property<string>("RNG");

                    b.HasKey("ID");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.UnitModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ARM");

                    b.Property<int>("CMD");

                    b.Property<int>("DEF");

                    b.Property<int>("FA");

                    b.Property<string>("Faction");

                    b.Property<int>("MAT");

                    b.Property<int>("MaxUnit");

                    b.Property<int>("MinUnit");

                    b.Property<string>("Name");

                    b.Property<int>("PointCost");

                    b.Property<int>("RAT");

                    b.Property<int>("SPD");

                    b.Property<int>("STR");

                    b.HasKey("ID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Weapon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("POW");

                    b.Property<int>("RNG");

                    b.Property<int>("ROF");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("Weapons");
                });
        }
    }
}
