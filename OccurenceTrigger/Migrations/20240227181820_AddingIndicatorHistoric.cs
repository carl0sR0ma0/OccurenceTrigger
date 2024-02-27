using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OccurenceTrigger.Migrations
{
    /// <inheritdoc />
    public partial class AddingIndicatorHistoric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Indicators");

            migrationBuilder.RenameColumn(
                name: "AdherenceShift",
                table: "Indicators",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Indicators",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CalcType",
                table: "Indicators",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductionUnitId",
                table: "Indicators",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "System",
                table: "Indicators",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IndicatorHistorics",
                columns: table => new
                {
                    IndicatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Reability = table.Column<int>(type: "INTEGER", nullable: false),
                    Workshift = table.Column<string>(type: "TEXT", nullable: false),
                    AdherenceShift = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorHistorics", x => new { x.IndicatorId, x.Date });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicatorHistorics");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Indicators");

            migrationBuilder.DropColumn(
                name: "CalcType",
                table: "Indicators");

            migrationBuilder.DropColumn(
                name: "ProductionUnitId",
                table: "Indicators");

            migrationBuilder.DropColumn(
                name: "System",
                table: "Indicators");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Indicators",
                newName: "AdherenceShift");

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Indicators",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
