using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace svc.system.center.migration.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "States");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Cities",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Cities",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "States",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
