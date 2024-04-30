using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DeletedAssignedToInTasks_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_employees_AssignedToNavigationID",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "AssignedToNavigationID",
                table: "tasks",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_AssignedToNavigationID",
                table: "tasks",
                newName: "IX_tasks_EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_employees_EmployeeID",
                table: "tasks",
                column: "EmployeeID",
                principalTable: "employees",
                principalColumn: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_employees_EmployeeID",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "tasks",
                newName: "AssignedToNavigationID");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_EmployeeID",
                table: "tasks",
                newName: "IX_tasks_AssignedToNavigationID");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_employees_AssignedToNavigationID",
                table: "tasks",
                column: "AssignedToNavigationID",
                principalTable: "employees",
                principalColumn: "EmployeeID");
        }
    }
}
