using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarMachine.Migrations
{
    public partial class cool2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoloAbilities",
                columns: table => new
                {
                    AbilityID = table.Column<int>(nullable: false),
                    SoloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoloAbilities", x => new { x.AbilityID, x.SoloID });
                    table.ForeignKey(
                        name: "FK_SoloAbilities_Abilities_AbilityID",
                        column: x => x.AbilityID,
                        principalTable: "Abilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoloAbilities_Solos_SoloID",
                        column: x => x.SoloID,
                        principalTable: "Solos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoloAbilities_AbilityID",
                table: "SoloAbilities",
                column: "AbilityID");

            migrationBuilder.CreateIndex(
                name: "IX_SoloAbilities_SoloID",
                table: "SoloAbilities",
                column: "SoloID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoloAbilities");
        }
    }
}
