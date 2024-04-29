using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ProjectFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectManagerID",
                table: "projects",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "ProjectManagerID",
                table: "projects",
                newName: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "projects",
                newName: "ProjectManagerID");

            migrationBuilder.RenameIndex(
                name: "ManagerId",
                table: "projects",
                newName: "ProjectManagerID");
        }
    }
}
