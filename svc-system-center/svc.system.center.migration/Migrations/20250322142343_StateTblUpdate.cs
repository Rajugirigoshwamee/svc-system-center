using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace svc.system.center.migration.Migrations
{
    /// <inheritdoc />
    public partial class StateTblUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "States",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "States");
        }
    }
}
