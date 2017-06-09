using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarMachine.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarbeastAbillities",
                columns: table => new
                {
                    AbillityId = table.Column<int>(nullable: false),
                    WarBeastid = table.Column<int>(nullable: false),
                    AbilityID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarbeastAbillities", x => new { x.AbillityId, x.WarBeastid });
                    table.ForeignKey(
                        name: "FK_WarbeastAbillities_Abilities_AbilityID",
                        column: x => x.AbilityID,
                        principalTable: "Abilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarbeastAbillities_WarBeasts_WarBeastid",
                        column: x => x.WarBeastid,
                        principalTable: "WarBeasts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarbeastSpells",
                columns: table => new
                {
                    Spellid = table.Column<int>(nullable: false),
                    WarbeastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarbeastSpells", x => new { x.Spellid, x.WarbeastId });
                    table.ForeignKey(
                        name: "FK_WarbeastSpells_Spells_Spellid",
                        column: x => x.Spellid,
                        principalTable: "Spells",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarbeastSpells_WarBeasts_WarbeastId",
                        column: x => x.WarbeastId,
                        principalTable: "WarBeasts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarbeastWeapons",
                columns: table => new
                {
                    WeaponId = table.Column<int>(nullable: false),
                    WarbeastID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarbeastWeapons", x => new { x.WeaponId, x.WarbeastID });
                    table.ForeignKey(
                        name: "FK_WarbeastWeapons_WarBeasts_WarbeastID",
                        column: x => x.WarbeastID,
                        principalTable: "WarBeasts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarbeastWeapons_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarjackAbilities",
                columns: table => new
                {
                    AbillityID = table.Column<int>(nullable: false),
                    WarjackID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarjackAbilities", x => new { x.AbillityID, x.WarjackID });
                    table.ForeignKey(
                        name: "FK_WarjackAbilities_Abilities_AbillityID",
                        column: x => x.AbillityID,
                        principalTable: "Abilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarjackAbilities_Warjacks_WarjackID",
                        column: x => x.WarjackID,
                        principalTable: "Warjacks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarjackWeapons",
                columns: table => new
                {
                    WeaponId = table.Column<int>(nullable: false),
                    WarjackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarjackWeapons", x => new { x.WeaponId, x.WarjackId });
                    table.ForeignKey(
                        name: "FK_WarjackWeapons_Warjacks_WarjackId",
                        column: x => x.WarjackId,
                        principalTable: "Warjacks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarjackWeapons_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarbeastAbillities_AbilityID",
                table: "WarbeastAbillities",
                column: "AbilityID");

            migrationBuilder.CreateIndex(
                name: "IX_WarbeastAbillities_WarBeastid",
                table: "WarbeastAbillities",
                column: "WarBeastid");

            migrationBuilder.CreateIndex(
                name: "IX_WarbeastSpells_Spellid",
                table: "WarbeastSpells",
                column: "Spellid");

            migrationBuilder.CreateIndex(
                name: "IX_WarbeastSpells_WarbeastId",
                table: "WarbeastSpells",
                column: "WarbeastId");

            migrationBuilder.CreateIndex(
                name: "IX_WarbeastWeapons_WarbeastID",
                table: "WarbeastWeapons",
                column: "WarbeastID");

            migrationBuilder.CreateIndex(
                name: "IX_WarbeastWeapons_WeaponId",
                table: "WarbeastWeapons",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_WarjackAbilities_AbillityID",
                table: "WarjackAbilities",
                column: "AbillityID");

            migrationBuilder.CreateIndex(
                name: "IX_WarjackAbilities_WarjackID",
                table: "WarjackAbilities",
                column: "WarjackID");

            migrationBuilder.CreateIndex(
                name: "IX_WarjackWeapons_WarjackId",
                table: "WarjackWeapons",
                column: "WarjackId");

            migrationBuilder.CreateIndex(
                name: "IX_WarjackWeapons_WeaponId",
                table: "WarjackWeapons",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarbeastAbillities");

            migrationBuilder.DropTable(
                name: "WarbeastSpells");

            migrationBuilder.DropTable(
                name: "WarbeastWeapons");

            migrationBuilder.DropTable(
                name: "WarjackAbilities");

            migrationBuilder.DropTable(
                name: "WarjackWeapons");
        }
    }
}
