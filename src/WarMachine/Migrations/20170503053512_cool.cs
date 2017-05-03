using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WarMachine.Migrations
{
    public partial class cool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Solos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ARM = table.Column<int>(nullable: false),
                    CMD = table.Column<int>(nullable: false),
                    DEF = table.Column<int>(nullable: false),
                    FA = table.Column<int>(nullable: false),
                    Faction = table.Column<string>(nullable: true),
                    MAT = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PointCost = table.Column<int>(nullable: false),
                    RAT = table.Column<int>(nullable: false),
                    SPD = table.Column<int>(nullable: false),
                    STR = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AOE = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OFF = table.Column<bool>(nullable: false),
                    POW = table.Column<int>(nullable: false),
                    RNG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ARM = table.Column<int>(nullable: false),
                    CMD = table.Column<int>(nullable: false),
                    DEF = table.Column<int>(nullable: false),
                    FA = table.Column<int>(nullable: false),
                    Faction = table.Column<string>(nullable: true),
                    MAT = table.Column<int>(nullable: false),
                    MaxUnit = table.Column<int>(nullable: false),
                    MinUnit = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PointCost = table.Column<int>(nullable: false),
                    RAT = table.Column<int>(nullable: false),
                    SPD = table.Column<int>(nullable: false),
                    STR = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    POW = table.Column<int>(nullable: false),
                    RNG = table.Column<int>(nullable: false),
                    ROF = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Solos");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
