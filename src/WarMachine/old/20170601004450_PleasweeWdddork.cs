using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WarMachine.Migrations
{
    public partial class PleasweeWdddork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warcasters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ARM = table.Column<int>(nullable: false),
                    CMD = table.Column<int>(nullable: false),
                    DEF = table.Column<int>(nullable: false),
                    FactionID = table.Column<int>(nullable: true),
                    Feat = table.Column<string>(nullable: true),
                    Focus = table.Column<int>(nullable: false),
                    MAT = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PointCost = table.Column<int>(nullable: false),
                    RAT = table.Column<int>(nullable: false),
                    SPD = table.Column<int>(nullable: false),
                    STR = table.Column<int>(nullable: false),
                    WarjackPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warcasters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Warcasters_Factions_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Factions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warlocks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ARM = table.Column<int>(nullable: false),
                    CMD = table.Column<int>(nullable: false),
                    DEF = table.Column<int>(nullable: false),
                    FactionID = table.Column<int>(nullable: true),
                    Feat = table.Column<string>(nullable: true),
                    Fury = table.Column<int>(nullable: false),
                    MAT = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PointCost = table.Column<int>(nullable: false),
                    RAT = table.Column<int>(nullable: false),
                    SPD = table.Column<int>(nullable: false),
                    STR = table.Column<int>(nullable: false),
                    WarbeastPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warlocks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Warlocks_Factions_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Factions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "WarcasterID",
                table: "Weapons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarlockID",
                table: "Weapons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarcasterID",
                table: "Spells",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarlockID",
                table: "Spells",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarcasterID",
                table: "Abilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarlockID",
                table: "Abilities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WarcasterID",
                table: "Weapons",
                column: "WarcasterID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WarlockID",
                table: "Weapons",
                column: "WarlockID");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_WarcasterID",
                table: "Spells",
                column: "WarcasterID");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_WarlockID",
                table: "Spells",
                column: "WarlockID");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_WarcasterID",
                table: "Abilities",
                column: "WarcasterID");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_WarlockID",
                table: "Abilities",
                column: "WarlockID");

            migrationBuilder.CreateIndex(
                name: "IX_Warcasters_FactionID",
                table: "Warcasters",
                column: "FactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Warlocks_FactionID",
                table: "Warlocks",
                column: "FactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Warcasters_WarcasterID",
                table: "Abilities",
                column: "WarcasterID",
                principalTable: "Warcasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Warlocks_WarlockID",
                table: "Abilities",
                column: "WarlockID",
                principalTable: "Warlocks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_Warcasters_WarcasterID",
                table: "Spells",
                column: "WarcasterID",
                principalTable: "Warcasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_Warlocks_WarlockID",
                table: "Spells",
                column: "WarlockID",
                principalTable: "Warlocks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Warcasters_WarcasterID",
                table: "Weapons",
                column: "WarcasterID",
                principalTable: "Warcasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Warlocks_WarlockID",
                table: "Weapons",
                column: "WarlockID",
                principalTable: "Warlocks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Warcasters_WarcasterID",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Warlocks_WarlockID",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_Warcasters_WarcasterID",
                table: "Spells");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_Warlocks_WarlockID",
                table: "Spells");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Warcasters_WarcasterID",
                table: "Weapons");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Warlocks_WarlockID",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_WarcasterID",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_WarlockID",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Spells_WarcasterID",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Spells_WarlockID",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_WarcasterID",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_WarlockID",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "WarcasterID",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "WarlockID",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "WarcasterID",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "WarlockID",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "WarcasterID",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "WarlockID",
                table: "Abilities");

            migrationBuilder.DropTable(
                name: "Warcasters");

            migrationBuilder.DropTable(
                name: "Warlocks");
        }
    }
}
