using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarMachine.Migrations
{
    public partial class cool1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoloModelID",
                table: "Abilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitModelID",
                table: "Abilities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_SoloModelID",
                table: "Abilities",
                column: "SoloModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_UnitModelID",
                table: "Abilities",
                column: "UnitModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Solos_SoloModelID",
                table: "Abilities",
                column: "SoloModelID",
                principalTable: "Solos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Units_UnitModelID",
                table: "Abilities",
                column: "UnitModelID",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Solos_SoloModelID",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Units_UnitModelID",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_SoloModelID",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_UnitModelID",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "SoloModelID",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "UnitModelID",
                table: "Abilities");
        }
    }
}
