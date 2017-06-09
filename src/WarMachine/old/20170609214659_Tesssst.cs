using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using WarMachine.ViewModels;

namespace WarMachine.Migrations
{
    public partial class Tesssst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "factionName",
                table: "Warlocks",
                nullable: false,
                defaultValue: BasedModelViewModel.FactionName.Cryx);

            migrationBuilder.AddColumn<int>(
                name: "factionName",
                table: "Warjacks",
                nullable: false,
                defaultValue: BasedModelViewModel.FactionName.Cryx);

            migrationBuilder.AddColumn<int>(
                name: "factionName",
                table: "Warcasters",
                nullable: false,
                defaultValue: BasedModelViewModel.FactionName.Cryx);

            migrationBuilder.AddColumn<int>(
                name: "factionName",
                table: "WarBeasts",
                nullable: false,
                defaultValue: BasedModelViewModel.FactionName.Cryx);

            migrationBuilder.AddColumn<int>(
                name: "factionName",
                table: "Units",
                nullable: false,
                defaultValue: BasedModelViewModel.FactionName.Cryx);

            migrationBuilder.AddColumn<int>(
                name: "factionName",
                table: "Solos",
                nullable: false,
                defaultValue: BasedModelViewModel.FactionName.Cryx);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "factionName",
                table: "Warlocks");

            migrationBuilder.DropColumn(
                name: "factionName",
                table: "Warjacks");

            migrationBuilder.DropColumn(
                name: "factionName",
                table: "Warcasters");

            migrationBuilder.DropColumn(
                name: "factionName",
                table: "WarBeasts");

            migrationBuilder.DropColumn(
                name: "factionName",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "factionName",
                table: "Solos");
        }
    }
}
