using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace pgEfCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditiveList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CHOofkcal = table.Column<int>(name: "CHO % of kcal", nullable: true),
                    Kcalunit = table.Column<decimal>(name: "Kcal/unit", type: "decimal", nullable: true),
                    Lipidofkcal = table.Column<int>(name: "Lipid % of kcal", nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Proteinofkcal = table.Column<int>(name: "Protein % of kcal", nullable: true),
                    Unit = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DextroseConcentration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Concentration = table.Column<string>(maxLength: 10, nullable: false),
                    KcalMl = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DextroseConcentration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormulaList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CHO = table.Column<int>(nullable: false),
                    Kcal_mL = table.Column<decimal>(type: "decimal", nullable: false),
                    Kcal_oz = table.Column<decimal>(type: "decimal", nullable: true),
                    Lipid = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Protein = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LongName = table.Column<string>(maxLength: 200, nullable: false),
                    ShortName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SiteId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    SubjectId = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Sites",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal", nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalEntries_Subjects",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Additive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AdditiveListId = table.Column<int>(nullable: false),
                    CalEntryId = table.Column<int>(nullable: false),
                    Volume = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Additive_AdditiveList",
                        column: x => x.AdditiveListId,
                        principalTable: "AdditiveList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Additive_Entry",
                        column: x => x.CalEntryId,
                        principalTable: "CalEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enteral",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CalEntryId = table.Column<int>(nullable: false),
                    FormulaListId = table.Column<int>(nullable: false),
                    Volume = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enteral", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enteral_CalEntry",
                        column: x => x.CalEntryId,
                        principalTable: "CalEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enteral_FormulaList",
                        column: x => x.FormulaListId,
                        principalTable: "FormulaList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FluidInfusion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CalEntryId = table.Column<int>(nullable: false),
                    DextroseConcentrationId = table.Column<int>(nullable: false),
                    Volume = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluidInfusion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FluidInfusions_CalEntries",
                        column: x => x.CalEntryId,
                        principalTable: "CalEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FluidInfusions_DextroseConcentrations",
                        column: x => x.DextroseConcentrationId,
                        principalTable: "DextroseConcentration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parenteral",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Amino = table.Column<decimal>(type: "decimal", nullable: true),
                    CalEntryId = table.Column<int>(nullable: false),
                    Dextrose = table.Column<decimal>(type: "decimal", nullable: true),
                    Lipid = table.Column<decimal>(type: "decimal", nullable: true),
                    Volume = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parenteral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parenteral_CalEntry",
                        column: x => x.CalEntryId,
                        principalTable: "CalEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Additive_AdditiveListId",
                table: "Additive",
                column: "AdditiveListId");

            migrationBuilder.CreateIndex(
                name: "IX_Additive_CalEntryId",
                table: "Additive",
                column: "CalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_CalEntry_SubjectId",
                table: "CalEntry",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Enteral_CalEntryId",
                table: "Enteral",
                column: "CalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Enteral_FormulaListId",
                table: "Enteral",
                column: "FormulaListId");

            migrationBuilder.CreateIndex(
                name: "IX_FluidInfusion_CalEntryId",
                table: "FluidInfusion",
                column: "CalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_FluidInfusion_DextroseConcentrationId",
                table: "FluidInfusion",
                column: "DextroseConcentrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parenteral_CalEntryId",
                table: "Parenteral",
                column: "CalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SiteId",
                table: "Subject",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Additive");

            migrationBuilder.DropTable(
                name: "Enteral");

            migrationBuilder.DropTable(
                name: "FluidInfusion");

            migrationBuilder.DropTable(
                name: "Parenteral");

            migrationBuilder.DropTable(
                name: "AdditiveList");

            migrationBuilder.DropTable(
                name: "FormulaList");

            migrationBuilder.DropTable(
                name: "DextroseConcentration");

            migrationBuilder.DropTable(
                name: "CalEntry");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}
