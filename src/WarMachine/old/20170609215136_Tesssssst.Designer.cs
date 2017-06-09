using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WarMachine.Data;

namespace WarMachine.Migrations
{
    [DbContext(typeof(ModelDbContext))]
    [Migration("20170609215136_Tesssssst")]
    partial class Tesssssst
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

            modelBuilder.Entity("WarMachine.Models.Joins.WarBeastAbillity", b =>
                {
                    b.Property<int>("AbillityId");

                    b.Property<int>("WarBeastid");

                    b.Property<int?>("AbilityID");

                    b.HasKey("AbillityId", "WarBeastid");

                    b.HasIndex("AbilityID");

                    b.HasIndex("WarBeastid");

                    b.ToTable("WarbeastAbillities");
                });

            modelBuilder.Entity("WarMachine.Models.Joins.WarbeastSpell", b =>
                {
                    b.Property<int>("Spellid");

                    b.Property<int>("WarbeastId");

                    b.HasKey("Spellid", "WarbeastId");

                    b.HasIndex("Spellid");

                    b.HasIndex("WarbeastId");

                    b.ToTable("WarbeastSpells");
                });

            modelBuilder.Entity("WarMachine.Models.Joins.WarbeastWeapon", b =>
                {
                    b.Property<int>("WeaponId");

                    b.Property<int>("WarbeastID");

                    b.HasKey("WeaponId", "WarbeastID");

                    b.HasIndex("WarbeastID");

                    b.HasIndex("WeaponId");

                    b.ToTable("WarbeastWeapons");
                });

            modelBuilder.Entity("WarMachine.Models.Joins.WarjackAbillity", b =>
                {
                    b.Property<int>("AbillityID");

                    b.Property<int>("WarjackID");

                    b.HasKey("AbillityID", "WarjackID");

                    b.HasIndex("AbillityID");

                    b.HasIndex("WarjackID");

                    b.ToTable("WarjackAbilities");
                });

            modelBuilder.Entity("WarMachine.Models.Joins.WarjackWeapon", b =>
                {
                    b.Property<int>("WeaponId");

                    b.Property<int>("WarjackId");

                    b.HasKey("WeaponId", "WarjackId");

                    b.HasIndex("WarjackId");

                    b.HasIndex("WeaponId");

                    b.ToTable("WarjackWeapons");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Ability", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("SoloModelID");

                    b.Property<int?>("UnitModelID");

                    b.Property<int?>("WarBeastID");

                    b.Property<int?>("WarcasterID");

                    b.Property<int?>("WarjackID");

                    b.Property<int?>("WarlockID");

                    b.HasKey("ID");

                    b.HasIndex("SoloModelID");

                    b.HasIndex("UnitModelID");

                    b.HasIndex("WarBeastID");

                    b.HasIndex("WarcasterID");

                    b.HasIndex("WarjackID");

                    b.HasIndex("WarlockID");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Faction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Factions");
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

                    b.Property<string>("FA");

                    b.Property<int?>("FactionID");

                    b.Property<int>("MAT");

                    b.Property<string>("Name");

                    b.Property<int>("PointCost");

                    b.Property<int>("RAT");

                    b.Property<int>("SPD");

                    b.Property<int>("STR");

                    b.Property<int>("factionName");

                    b.HasKey("ID");

                    b.HasIndex("FactionID");

                    b.ToTable("Solos");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Spell", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AOE");

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<string>("Name");

                    b.Property<bool>("OFF");

                    b.Property<int>("POW");

                    b.Property<string>("RNG");

                    b.Property<int?>("SoloModelID");

                    b.Property<int?>("UnitModelID");

                    b.Property<int?>("WarBeastID");

                    b.Property<int?>("WarcasterID");

                    b.Property<int?>("WarjackID");

                    b.Property<int?>("WarlockID");

                    b.Property<bool>("isAnimi");

                    b.HasKey("ID");

                    b.HasIndex("SoloModelID");

                    b.HasIndex("UnitModelID");

                    b.HasIndex("WarBeastID");

                    b.HasIndex("WarcasterID");

                    b.HasIndex("WarjackID");

                    b.HasIndex("WarlockID");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.UnitModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ARM");

                    b.Property<int>("CMD");

                    b.Property<int>("DEF");

                    b.Property<string>("FA");

                    b.Property<int?>("FactionID");

                    b.Property<int>("MAT");

                    b.Property<int>("MaxUnit");

                    b.Property<int>("MinUnit");

                    b.Property<string>("Name");

                    b.Property<int>("PointCost");

                    b.Property<int>("RAT");

                    b.Property<int>("SPD");

                    b.Property<int>("STR");

                    b.Property<int>("factionName");

                    b.HasKey("ID");

                    b.HasIndex("FactionID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.WarBeast", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ARM");

                    b.Property<int>("CMD");

                    b.Property<int>("DEF");

                    b.Property<string>("FA");

                    b.Property<int?>("FactionID");

                    b.Property<int>("Fury");

                    b.Property<int>("MAT");

                    b.Property<string>("Name");

                    b.Property<int>("PointCost");

                    b.Property<int>("RAT");

                    b.Property<int>("SPD");

                    b.Property<int>("STR");

                    b.Property<int>("Size");

                    b.Property<int>("Threshhold");

                    b.Property<int>("factionName");

                    b.HasKey("ID");

                    b.HasIndex("FactionID");

                    b.ToTable("WarBeasts");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Warcaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ARM");

                    b.Property<int>("CMD");

                    b.Property<int>("DEF");

                    b.Property<int?>("FactionID");

                    b.Property<string>("Feat");

                    b.Property<int>("Focus");

                    b.Property<int>("MAT");

                    b.Property<string>("Name");

                    b.Property<int>("PointCost");

                    b.Property<int>("RAT");

                    b.Property<int>("SPD");

                    b.Property<int>("STR");

                    b.Property<int>("WarjackPoints");

                    b.Property<int>("factionName");

                    b.HasKey("ID");

                    b.HasIndex("FactionID");

                    b.ToTable("Warcasters");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Warjack", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ARM");

                    b.Property<int>("CMD");

                    b.Property<int>("DEF");

                    b.Property<string>("FA");

                    b.Property<int?>("FactionID");

                    b.Property<int>("MAT");

                    b.Property<string>("Name");

                    b.Property<int>("PointCost");

                    b.Property<int>("RAT");

                    b.Property<int>("SPD");

                    b.Property<int>("STR");

                    b.Property<int>("Size");

                    b.Property<int>("factionName");

                    b.HasKey("ID");

                    b.HasIndex("FactionID");

                    b.ToTable("Warjacks");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Warlock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ARM");

                    b.Property<int>("CMD");

                    b.Property<int>("DEF");

                    b.Property<int?>("FactionID");

                    b.Property<string>("Feat");

                    b.Property<int>("Fury");

                    b.Property<int>("MAT");

                    b.Property<string>("Name");

                    b.Property<int>("PointCost");

                    b.Property<int>("RAT");

                    b.Property<int>("SPD");

                    b.Property<int>("STR");

                    b.Property<int>("WarbeastPoints");

                    b.Property<int>("factionName");

                    b.HasKey("ID");

                    b.HasIndex("FactionID");

                    b.ToTable("Warlocks");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Weapon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("POW");

                    b.Property<int>("RNG");

                    b.Property<int>("ROF");

                    b.Property<int?>("SoloModelID");

                    b.Property<int>("Type");

                    b.Property<int?>("UnitModelID");

                    b.Property<int?>("WarBeastID");

                    b.Property<int?>("WarcasterID");

                    b.Property<int?>("WarjackID");

                    b.Property<int?>("WarlockID");

                    b.HasKey("ID");

                    b.HasIndex("SoloModelID");

                    b.HasIndex("UnitModelID");

                    b.HasIndex("WarBeastID");

                    b.HasIndex("WarcasterID");

                    b.HasIndex("WarjackID");

                    b.HasIndex("WarlockID");

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

            modelBuilder.Entity("WarMachine.Models.Joins.WarBeastAbillity", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Ability", "Ability")
                        .WithMany()
                        .HasForeignKey("AbilityID");

                    b.HasOne("WarMachine.Models.WarModels.WarBeast", "WarBeast")
                        .WithMany()
                        .HasForeignKey("WarBeastid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarMachine.Models.Joins.WarbeastSpell", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Spell", "Spell")
                        .WithMany()
                        .HasForeignKey("Spellid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarMachine.Models.WarModels.WarBeast", "Warbeast")
                        .WithMany()
                        .HasForeignKey("WarbeastId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarMachine.Models.Joins.WarbeastWeapon", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.WarBeast", "Warbeast")
                        .WithMany()
                        .HasForeignKey("WarbeastID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarMachine.Models.WarModels.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarMachine.Models.Joins.WarjackAbillity", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Ability", "Abillity")
                        .WithMany()
                        .HasForeignKey("AbillityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarMachine.Models.WarModels.Warjack", "Warjack")
                        .WithMany()
                        .HasForeignKey("WarjackID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarMachine.Models.Joins.WarjackWeapon", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Warjack", "Warjack")
                        .WithMany()
                        .HasForeignKey("WarjackId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarMachine.Models.WarModels.Weapon", "Weapon")
                        .WithMany()
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

                    b.HasOne("WarMachine.Models.WarModels.WarBeast")
                        .WithMany("Abilities")
                        .HasForeignKey("WarBeastID");

                    b.HasOne("WarMachine.Models.WarModels.Warcaster")
                        .WithMany("Abilities")
                        .HasForeignKey("WarcasterID");

                    b.HasOne("WarMachine.Models.WarModels.Warjack")
                        .WithMany("Abilities")
                        .HasForeignKey("WarjackID");

                    b.HasOne("WarMachine.Models.WarModels.Warlock")
                        .WithMany("Abilities")
                        .HasForeignKey("WarlockID");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.SoloModel", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionID");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Spell", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.SoloModel")
                        .WithMany("Spells")
                        .HasForeignKey("SoloModelID");

                    b.HasOne("WarMachine.Models.WarModels.UnitModel")
                        .WithMany("Spells")
                        .HasForeignKey("UnitModelID");

                    b.HasOne("WarMachine.Models.WarModels.WarBeast")
                        .WithMany("Spells")
                        .HasForeignKey("WarBeastID");

                    b.HasOne("WarMachine.Models.WarModels.Warcaster")
                        .WithMany("Spells")
                        .HasForeignKey("WarcasterID");

                    b.HasOne("WarMachine.Models.WarModels.Warjack")
                        .WithMany("Spells")
                        .HasForeignKey("WarjackID");

                    b.HasOne("WarMachine.Models.WarModels.Warlock")
                        .WithMany("Spells")
                        .HasForeignKey("WarlockID");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.UnitModel", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionID");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.WarBeast", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionID");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Warcaster", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionID");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Warjack", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionID");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Warlock", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionID");
                });

            modelBuilder.Entity("WarMachine.Models.WarModels.Weapon", b =>
                {
                    b.HasOne("WarMachine.Models.WarModels.SoloModel")
                        .WithMany("Weapons")
                        .HasForeignKey("SoloModelID");

                    b.HasOne("WarMachine.Models.WarModels.UnitModel")
                        .WithMany("Weapons")
                        .HasForeignKey("UnitModelID");

                    b.HasOne("WarMachine.Models.WarModels.WarBeast")
                        .WithMany("Weapons")
                        .HasForeignKey("WarBeastID");

                    b.HasOne("WarMachine.Models.WarModels.Warcaster")
                        .WithMany("Weapons")
                        .HasForeignKey("WarcasterID");

                    b.HasOne("WarMachine.Models.WarModels.Warjack")
                        .WithMany("Weapons")
                        .HasForeignKey("WarjackID");

                    b.HasOne("WarMachine.Models.WarModels.Warlock")
                        .WithMany("Weapons")
                        .HasForeignKey("WarlockID");
                });
        }
    }
}
