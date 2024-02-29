using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OccurenceTrigger.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "TriggerConfigurations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TriggerConfigurations");
        }
    }
}
