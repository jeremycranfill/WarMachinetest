using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarMachine.Migrations
{
    public partial class Cosdfdsfsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Weapons",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FA",
                table: "Units",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Spells",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FA",
                table: "Solos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Weapons",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FA",
                table: "Units",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Spells",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FA",
                table: "Solos",
                nullable: false);
        }
    }
}
