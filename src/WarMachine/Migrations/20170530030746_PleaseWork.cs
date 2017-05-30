using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WarMachine.Migrations
{
    public partial class PleaseWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faction",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Faction",
                table: "Solos");

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WarBeasts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ARM = table.Column<int>(nullable: false),
                    CMD = table.Column<int>(nullable: false),
                    DEF = table.Column<int>(nullable: false),
                    FA = table.Column<string>(nullable: true),
                    FactionID = table.Column<int>(nullable: true),
                    Fury = table.Column<int>(nullable: false),
                    MAT = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PointCost = table.Column<int>(nullable: false),
                    RAT = table.Column<int>(nullable: false),
                    SPD = table.Column<int>(nullable: false),
                    STR = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Threshhold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarBeasts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WarBeasts_Factions_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Factions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warjacks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ARM = table.Column<int>(nullable: false),
                    CMD = table.Column<int>(nullable: false),
                    DEF = table.Column<int>(nullable: false),
                    FA = table.Column<string>(nullable: true),
                    FactionID = table.Column<int>(nullable: true),
                    MAT = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PointCost = table.Column<int>(nullable: false),
                    RAT = table.Column<int>(nullable: false),
                    SPD = table.Column<int>(nullable: false),
                    STR = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warjacks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Warjacks_Factions_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Factions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "SoloModelID",
                table: "Weapons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitModelID",
                table: "Weapons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarBeastID",
                table: "Weapons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarjackID",
                table: "Weapons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactionID",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoloModelID",
                table: "Spells",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitModelID",
                table: "Spells",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarBeastID",
                table: "Spells",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarjackID",
                table: "Spells",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isAnimi",
                table: "Spells",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FactionID",
                table: "Solos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarBeastID",
                table: "Abilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarjackID",
                table: "Abilities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_SoloModelID",
                table: "Weapons",
                column: "SoloModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_UnitModelID",
                table: "Weapons",
                column: "UnitModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WarBeastID",
                table: "Weapons",
                column: "WarBeastID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WarjackID",
                table: "Weapons",
                column: "WarjackID");

            migrationBuilder.CreateIndex(
                name: "IX_Units_FactionID",
                table: "Units",
                column: "FactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_SoloModelID",
                table: "Spells",
                column: "SoloModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_UnitModelID",
                table: "Spells",
                column: "UnitModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_WarBeastID",
                table: "Spells",
                column: "WarBeastID");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_WarjackID",
                table: "Spells",
                column: "WarjackID");

            migrationBuilder.CreateIndex(
                name: "IX_Solos_FactionID",
                table: "Solos",
                column: "FactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_WarBeastID",
                table: "Abilities",
                column: "WarBeastID");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_WarjackID",
                table: "Abilities",
                column: "WarjackID");

            migrationBuilder.CreateIndex(
                name: "IX_WarBeasts_FactionID",
                table: "WarBeasts",
                column: "FactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Warjacks_FactionID",
                table: "Warjacks",
                column: "FactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_WarBeasts_WarBeastID",
                table: "Abilities",
                column: "WarBeastID",
                principalTable: "WarBeasts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Warjacks_WarjackID",
                table: "Abilities",
                column: "WarjackID",
                principalTable: "Warjacks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solos_Factions_FactionID",
                table: "Solos",
                column: "FactionID",
                principalTable: "Factions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_Solos_SoloModelID",
                table: "Spells",
                column: "SoloModelID",
                principalTable: "Solos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_Units_UnitModelID",
                table: "Spells",
                column: "UnitModelID",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_WarBeasts_WarBeastID",
                table: "Spells",
                column: "WarBeastID",
                principalTable: "WarBeasts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_Warjacks_WarjackID",
                table: "Spells",
                column: "WarjackID",
                principalTable: "Warjacks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionID",
                table: "Units",
                column: "FactionID",
                principalTable: "Factions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Solos_SoloModelID",
                table: "Weapons",
                column: "SoloModelID",
                principalTable: "Solos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Units_UnitModelID",
                table: "Weapons",
                column: "UnitModelID",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_WarBeasts_WarBeastID",
                table: "Weapons",
                column: "WarBeastID",
                principalTable: "WarBeasts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Warjacks_WarjackID",
                table: "Weapons",
                column: "WarjackID",
                principalTable: "Warjacks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_WarBeasts_WarBeastID",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Warjacks_WarjackID",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Solos_Factions_FactionID",
                table: "Solos");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_Solos_SoloModelID",
                table: "Spells");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_Units_UnitModelID",
                table: "Spells");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_WarBeasts_WarBeastID",
                table: "Spells");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_Warjacks_WarjackID",
                table: "Spells");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_FactionID",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Solos_SoloModelID",
                table: "Weapons");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Units_UnitModelID",
                table: "Weapons");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_WarBeasts_WarBeastID",
                table: "Weapons");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Warjacks_WarjackID",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_SoloModelID",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_UnitModelID",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_WarBeastID",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_WarjackID",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Units_FactionID",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Spells_SoloModelID",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Spells_UnitModelID",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Spells_WarBeastID",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Spells_WarjackID",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Solos_FactionID",
                table: "Solos");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_WarBeastID",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_WarjackID",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "SoloModelID",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "UnitModelID",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "WarBeastID",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "WarjackID",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "FactionID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "SoloModelID",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "UnitModelID",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "WarBeastID",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "WarjackID",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "isAnimi",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "FactionID",
                table: "Solos");

            migrationBuilder.DropColumn(
                name: "WarBeastID",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "WarjackID",
                table: "Abilities");

            migrationBuilder.DropTable(
                name: "WarBeasts");

            migrationBuilder.DropTable(
                name: "Warjacks");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.AddColumn<string>(
                name: "Faction",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faction",
                table: "Solos",
                nullable: true);
        }
    }
}
