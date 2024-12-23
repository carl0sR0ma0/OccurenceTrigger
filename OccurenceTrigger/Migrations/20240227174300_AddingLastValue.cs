﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OccurenceTrigger.Migrations
{
    /// <inheritdoc />
    public partial class AddingLastValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LastValue",
                table: "TriggerConfigurations",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastValue",
                table: "TriggerConfigurations");
        }
    }
}
