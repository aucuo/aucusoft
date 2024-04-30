using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ProjectFixes_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_employees_EmployeeID",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_projects_EmployeeID",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_projects_EmployeeID",
                table: "projects",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_employees_EmployeeID",
                table: "projects",
                column: "EmployeeID",
                principalTable: "employees",
                principalColumn: "EmployeeID");
        }
    }
}
