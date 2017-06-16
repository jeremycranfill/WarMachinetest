using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarMachine.Migrations
{
    public partial class Tessssssjjst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FA",
                table: "Warlocks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FA",
                table: "Warcasters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FA",
                table: "Warlocks");

            migrationBuilder.DropColumn(
                name: "FA",
                table: "Warcasters");
        }
    }
}
