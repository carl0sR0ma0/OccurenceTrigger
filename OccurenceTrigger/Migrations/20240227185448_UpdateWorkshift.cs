using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OccurenceTrigger.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkshift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Workshift",
                table: "IndicatorHistorics",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Workshift",
                table: "IndicatorHistorics",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
