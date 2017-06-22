using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarMachine.Migrations
{
    public partial class Cooltest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarcasterAbilities",
                columns: table => new
                {
                    AbilityId = table.Column<int>(nullable: false),
                    WarcasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarcasterAbilities", x => new { x.AbilityId, x.WarcasterId });
                    table.ForeignKey(
                        name: "FK_WarcasterAbilities_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarcasterAbilities_Warcasters_WarcasterId",
                        column: x => x.WarcasterId,
                        principalTable: "Warcasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarcasterSpells",
                columns: table => new
                {
                    SpellId = table.Column<int>(nullable: false),
                    WarcasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarcasterSpells", x => new { x.SpellId, x.WarcasterId });
                    table.ForeignKey(
                        name: "FK_WarcasterSpells_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarcasterSpells_Warcasters_WarcasterId",
                        column: x => x.WarcasterId,
                        principalTable: "Warcasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarcasterWeapons",
                columns: table => new
                {
                    WeaponId = table.Column<int>(nullable: false),
                    WarcsaterId = table.Column<int>(nullable: false),
                    WarcasterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarcasterWeapons", x => new { x.WeaponId, x.WarcsaterId });
                    table.ForeignKey(
                        name: "FK_WarcasterWeapons_Warcasters_WarcasterID",
                        column: x => x.WarcasterID,
                        principalTable: "Warcasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarcasterWeapons_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarlockAbillities",
                columns: table => new
                {
                    AbillityId = table.Column<int>(nullable: false),
                    WarlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarlockAbillities", x => new { x.AbillityId, x.WarlockId });
                    table.ForeignKey(
                        name: "FK_WarlockAbillities_Abilities_AbillityId",
                        column: x => x.AbillityId,
                        principalTable: "Abilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarlockAbillities_Warlocks_WarlockId",
                        column: x => x.WarlockId,
                        principalTable: "Warlocks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarlockSpells",
                columns: table => new
                {
                    SpellId = table.Column<int>(nullable: false),
                    WarlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarlockSpells", x => new { x.SpellId, x.WarlockId });
                    table.ForeignKey(
                        name: "FK_WarlockSpells_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarlockSpells_Warlocks_WarlockId",
                        column: x => x.WarlockId,
                        principalTable: "Warlocks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarlockWeapons",
                columns: table => new
                {
                    WeaponId = table.Column<int>(nullable: false),
                    WarlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarlockWeapons", x => new { x.WeaponId, x.WarlockId });
                    table.ForeignKey(
                        name: "FK_WarlockWeapons_Warlocks_WarlockId",
                        column: x => x.WarlockId,
                        principalTable: "Warlocks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarlockWeapons_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarcasterAbilities_AbilityId",
                table: "WarcasterAbilities",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_WarcasterAbilities_WarcasterId",
                table: "WarcasterAbilities",
                column: "WarcasterId");

            migrationBuilder.CreateIndex(
                name: "IX_WarcasterSpells_SpellId",
                table: "WarcasterSpells",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_WarcasterSpells_WarcasterId",
                table: "WarcasterSpells",
                column: "WarcasterId");

            migrationBuilder.CreateIndex(
                name: "IX_WarcasterWeapons_WarcasterID",
                table: "WarcasterWeapons",
                column: "WarcasterID");

            migrationBuilder.CreateIndex(
                name: "IX_WarcasterWeapons_WeaponId",
                table: "WarcasterWeapons",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_WarlockAbillities_AbillityId",
                table: "WarlockAbillities",
                column: "AbillityId");

            migrationBuilder.CreateIndex(
                name: "IX_WarlockAbillities_WarlockId",
                table: "WarlockAbillities",
                column: "WarlockId");

            migrationBuilder.CreateIndex(
                name: "IX_WarlockSpells_SpellId",
                table: "WarlockSpells",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_WarlockSpells_WarlockId",
                table: "WarlockSpells",
                column: "WarlockId");

            migrationBuilder.CreateIndex(
                name: "IX_WarlockWeapons_WarlockId",
                table: "WarlockWeapons",
                column: "WarlockId");

            migrationBuilder.CreateIndex(
                name: "IX_WarlockWeapons_WeaponId",
                table: "WarlockWeapons",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarcasterAbilities");

            migrationBuilder.DropTable(
                name: "WarcasterSpells");

            migrationBuilder.DropTable(
                name: "WarcasterWeapons");

            migrationBuilder.DropTable(
                name: "WarlockAbillities");

            migrationBuilder.DropTable(
                name: "WarlockSpells");

            migrationBuilder.DropTable(
                name: "WarlockWeapons");
        }
    }
}
