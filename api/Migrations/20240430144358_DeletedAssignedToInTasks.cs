using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DeletedAssignedToInTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "tasks_ibfk_2",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "AssignedTo",
                table: "tasks",
                newName: "AssignedToNavigationID");

            migrationBuilder.RenameIndex(
                name: "AssignedTo",
                table: "tasks",
                newName: "IX_tasks_AssignedToNavigationID");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_employees_AssignedToNavigationID",
                table: "tasks",
                column: "AssignedToNavigationID",
                principalTable: "employees",
                principalColumn: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_employees_AssignedToNavigationID",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "AssignedToNavigationID",
                table: "tasks",
                newName: "AssignedTo");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_AssignedToNavigationID",
                table: "tasks",
                newName: "AssignedTo");

            migrationBuilder.AddForeignKey(
                name: "tasks_ibfk_2",
                table: "tasks",
                column: "AssignedTo",
                principalTable: "employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
