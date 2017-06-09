using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WarMachine.Data;

namespace WarMachine.Migrations
{
    [DbContext(typeof(ModelDbContext))]
    [Migration("20170510182409_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WarMachine.Models.Joins.SoloAbility", b =>
                {
                    b.Property<int>("AbilityID");

                    b.Property<int>("SoloID");

                    b.HasKey("AbilityID", "SoloID");

                    b.HasIndex("AbilityID");

                    b.HasIndex("SoloID");

                    b.ToTable("SoloAbilities");
                });

            modelBuilder.Entity("WarMachine.Models.Joins.SoloSpell", b =>
                {
                    b.Property<int>("SpellID");

                    b.Property<int>("SoloID");

                    b.HasKey("SpellID", "SoloID");

                    b.HasIndex("SoloID");

                    b.HasIndex("SpellID");

                    b.ToTable("SoloSpells");
                });

            modelBuilder.Entity("WarMachine.Models.Joins.SoloWeapon", b =>
                {
                    b.Property<int>("WeaponID");

                    b.Property<int>("SoloID");

                    b.HasKey("WeaponID", "SoloID");

                    b.HasIndex("SoloID");

                    b.HasIndex("WeaponID");

                    b.ToTable("SoloWeapons");
                });

            modelBuilder.Entity("WarMachine.Models.Joins.UnitAbiliity", b =>
                {
                    b.Property<int>("UnitID");

                    b.Property<int>("AbilityID");

                    b.HasKey("UnitID", "AbilityID");

                    b.HasIndex("AbilityID");

                    b.HasIndex("UnitID");

                    b.ToTable("UnitAbilities");
                });

            modelBuilder.Entity("WarMachine.Models.Joins.UnitSpell", b =>
                {
                    b.Property<int>("SpellID");

                    b.Property<int>("UnitID");

                    b.HasKey("SpellID", "UnitID");

                    b.HasIndex("SpellID");

                    b.HasIndex("UnitID");

                    b.ToTable("UnitSpells");
                });

            modelBuilder.Entity("WarMachine.Models.Joins.UnitWeapon", b =>
                {
                    b.Property<int>("UnitID");

                    b.Property<int>("WeaponId");

                    b.HasKey("UnitID", "WeaponId");

                    b.HasIndex("UnitID");

                    b.HasIndex("WeaponId");

                    b.ToTable("UnitWeapons");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Ability", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("SoloModelID");

                    b.Property<int?>("UnitModelID");

                    b.HasKey("ID");

                    b.HasIndex("SoloModelID");

                    b.HasIndex("UnitModelID");

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

            modelBuilder.Entity("WarMachine.Models.Joins.SoloAbility", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Ability", "Ability")
                        .WithMany("SoloAbilities")
                        .HasForeignKey("AbilityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarMachine.Models.WarModels.SoloModel", "Solo")
                        .WithMany("SoloAbilities")
                        .HasForeignKey("SoloID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarMachine.Models.Joins.SoloSpell", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.SoloModel", "Solo")
                        .WithMany("SoloSpells")
                        .HasForeignKey("SoloID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarMachine.Models.WarModels.Spell", "Spell")
                        .WithMany("SoloSpells")
                        .HasForeignKey("SpellID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarMachine.Models.Joins.SoloWeapon", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.SoloModel", "Solo")
                        .WithMany("SoloWeapons")
                        .HasForeignKey("SoloID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarMachine.Models.WarModels.Weapon", "Weapon")
                        .WithMany("SoloWeapons")
                        .HasForeignKey("WeaponID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarMachine.Models.Joins.UnitAbiliity", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Ability", "Ability")
                        .WithMany("UnitAbillities")
                        .HasForeignKey("AbilityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarMachine.Models.WarModels.UnitModel", "Unit")
                        .WithMany("UnitAbillities")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarMachine.Models.Joins.UnitSpell", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Spell", "Spell")
                        .WithMany("UnitSpells")
                        .HasForeignKey("SpellID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarMachine.Models.WarModels.UnitModel", "Unit")
                        .WithMany("UnitSpells")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarMachine.Models.Joins.UnitWeapon", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.UnitModel", "Unit")
                        .WithMany("UnitWeapons")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarMachine.Models.WarModels.Weapon", "Weapon")
                        .WithMany("UnitWeapons")
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Ability", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.SoloModel")
                        .WithMany("Abilities")
                        .HasForeignKey("SoloModelID");

                    b.HasOne("WarMachine.Models.WarModels.UnitModel")
                        .WithMany("Abilities")
                        .HasForeignKey("UnitModelID");
                });
        }
    }
}
