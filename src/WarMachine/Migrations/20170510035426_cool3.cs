using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarMachine.Migrations
{
    public partial class cool3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoloSpells",
                columns: table => new
                {
                    SpellID = table.Column<int>(nullable: false),
                    SoloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoloSpells", x => new { x.SpellID, x.SoloID });
                    table.ForeignKey(
                        name: "FK_SoloSpells_Solos_SoloID",
                        column: x => x.SoloID,
                        principalTable: "Solos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoloSpells_Spells_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spells",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoloWeapons",
                columns: table => new
                {
                    WeaponID = table.Column<int>(nullable: false),
                    SoloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoloWeapons", x => new { x.WeaponID, x.SoloID });
                    table.ForeignKey(
                        name: "FK_SoloWeapons_Solos_SoloID",
                        column: x => x.SoloID,
                        principalTable: "Solos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoloWeapons_Weapons_WeaponID",
                        column: x => x.WeaponID,
                        principalTable: "Weapons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitAbilities",
                columns: table => new
                {
                    UnitID = table.Column<int>(nullable: false),
                    AbilityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitAbilities", x => new { x.UnitID, x.AbilityID });
                    table.ForeignKey(
                        name: "FK_UnitAbilities_Abilities_AbilityID",
                        column: x => x.AbilityID,
                        principalTable: "Abilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitAbilities_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitSpells",
                columns: table => new
                {
                    SpellID = table.Column<int>(nullable: false),
                    UnitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitSpells", x => new { x.SpellID, x.UnitID });
                    table.ForeignKey(
                        name: "FK_UnitSpells_Spells_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spells",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitSpells_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitWeapons",
                columns: table => new
                {
                    UnitID = table.Column<int>(nullable: false),
                    WeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitWeapons", x => new { x.UnitID, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_UnitWeapons_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitWeapons_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoloSpells_SoloID",
                table: "SoloSpells",
                column: "SoloID");

            migrationBuilder.CreateIndex(
                name: "IX_SoloSpells_SpellID",
                table: "SoloSpells",
                column: "SpellID");

            migrationBuilder.CreateIndex(
                name: "IX_SoloWeapons_SoloID",
                table: "SoloWeapons",
                column: "SoloID");

            migrationBuilder.CreateIndex(
                name: "IX_SoloWeapons_WeaponID",
                table: "SoloWeapons",
                column: "WeaponID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitAbilities_AbilityID",
                table: "UnitAbilities",
                column: "AbilityID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitAbilities_UnitID",
                table: "UnitAbilities",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitSpells_SpellID",
                table: "UnitSpells",
                column: "SpellID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitSpells_UnitID",
                table: "UnitSpells",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitWeapons_UnitID",
                table: "UnitWeapons",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitWeapons_WeaponId",
                table: "UnitWeapons",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoloSpells");

            migrationBuilder.DropTable(
                name: "SoloWeapons");

            migrationBuilder.DropTable(
                name: "UnitAbilities");

            migrationBuilder.DropTable(
                name: "UnitSpells");

            migrationBuilder.DropTable(
                name: "UnitWeapons");
        }
    }
}
