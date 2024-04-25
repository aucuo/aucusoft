using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "clientfeedback_ibfk_1",
                table: "clientfeedback");

            migrationBuilder.DropForeignKey(
                name: "clientfeedback_ibfk_2",
                table: "clientfeedback");

            migrationBuilder.DropForeignKey(
                name: "employees_ibfk_1",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "employees_ibfk_2",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "employeetasks_ibfk_1",
                table: "employeetasks");

            migrationBuilder.DropForeignKey(
                name: "meetings_ibfk_1",
                table: "meetings");

            migrationBuilder.DropForeignKey(
                name: "projectdocuments_ibfk_1",
                table: "projectdocuments");

            migrationBuilder.DropForeignKey(
                name: "projects_ibfk_1",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "projects_ibfk_2",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "projecttechnologies_ibfk_1",
                table: "projecttechnologies");

            migrationBuilder.DropForeignKey(
                name: "projecttechnologies_ibfk_2",
                table: "projecttechnologies");

            migrationBuilder.DropForeignKey(
                name: "tasks_ibfk_1",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "tasks_ibfk_2",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "tasks_ibfk_3",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "worklogs_ibfk_1",
                table: "worklogs");

            migrationBuilder.DropForeignKey(
                name: "worklogs_ibfk_2",
                table: "worklogs");

            migrationBuilder.AddForeignKey(
                name: "clientfeedback_ibfk_1",
                table: "clientfeedback",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "clientfeedback_ibfk_2",
                table: "clientfeedback",
                column: "ClientID",
                principalTable: "clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "employees_ibfk_1",
                table: "employees",
                column: "PositionID",
                principalTable: "positions",
                principalColumn: "PositionID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "employees_ibfk_2",
                table: "employees",
                column: "DepartmentID",
                principalTable: "departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "employeetasks_ibfk_1",
                table: "employeetasks",
                column: "TaskID",
                principalTable: "tasks",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "meetings_ibfk_1",
                table: "meetings",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "projectdocuments_ibfk_1",
                table: "projectdocuments",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "projects_ibfk_1",
                table: "projects",
                column: "ClientID",
                principalTable: "clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "projects_ibfk_2",
                table: "projects",
                column: "ProjectManagerID",
                principalTable: "employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "projecttechnologies_ibfk_1",
                table: "projecttechnologies",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "projecttechnologies_ibfk_2",
                table: "projecttechnologies",
                column: "TechnologyID",
                principalTable: "technologies",
                principalColumn: "TechnologyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "tasks_ibfk_1",
                table: "tasks",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "tasks_ibfk_2",
                table: "tasks",
                column: "AssignedTo",
                principalTable: "employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "tasks_ibfk_3",
                table: "tasks",
                column: "StatusID",
                principalTable: "taskstatuses",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "worklogs_ibfk_1",
                table: "worklogs",
                column: "EmployeeID",
                principalTable: "employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "worklogs_ibfk_2",
                table: "worklogs",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "clientfeedback_ibfk_1",
                table: "clientfeedback");

            migrationBuilder.DropForeignKey(
                name: "clientfeedback_ibfk_2",
                table: "clientfeedback");

            migrationBuilder.DropForeignKey(
                name: "employees_ibfk_1",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "employees_ibfk_2",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "employeetasks_ibfk_1",
                table: "employeetasks");

            migrationBuilder.DropForeignKey(
                name: "meetings_ibfk_1",
                table: "meetings");

            migrationBuilder.DropForeignKey(
                name: "projectdocuments_ibfk_1",
                table: "projectdocuments");

            migrationBuilder.DropForeignKey(
                name: "projects_ibfk_1",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "projects_ibfk_2",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "projecttechnologies_ibfk_1",
                table: "projecttechnologies");

            migrationBuilder.DropForeignKey(
                name: "projecttechnologies_ibfk_2",
                table: "projecttechnologies");

            migrationBuilder.DropForeignKey(
                name: "tasks_ibfk_1",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "tasks_ibfk_2",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "tasks_ibfk_3",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "worklogs_ibfk_1",
                table: "worklogs");

            migrationBuilder.DropForeignKey(
                name: "worklogs_ibfk_2",
                table: "worklogs");

            migrationBuilder.AddForeignKey(
                name: "clientfeedback_ibfk_1",
                table: "clientfeedback",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "clientfeedback_ibfk_2",
                table: "clientfeedback",
                column: "ClientID",
                principalTable: "clients",
                principalColumn: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "employees_ibfk_1",
                table: "employees",
                column: "PositionID",
                principalTable: "positions",
                principalColumn: "PositionID");

            migrationBuilder.AddForeignKey(
                name: "employees_ibfk_2",
                table: "employees",
                column: "DepartmentID",
                principalTable: "departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "employeetasks_ibfk_1",
                table: "employeetasks",
                column: "TaskID",
                principalTable: "tasks",
                principalColumn: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "meetings_ibfk_1",
                table: "meetings",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "projectdocuments_ibfk_1",
                table: "projectdocuments",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "projects_ibfk_1",
                table: "projects",
                column: "ClientID",
                principalTable: "clients",
                principalColumn: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "projects_ibfk_2",
                table: "projects",
                column: "ProjectManagerID",
                principalTable: "employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "projecttechnologies_ibfk_1",
                table: "projecttechnologies",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "projecttechnologies_ibfk_2",
                table: "projecttechnologies",
                column: "TechnologyID",
                principalTable: "technologies",
                principalColumn: "TechnologyID");

            migrationBuilder.AddForeignKey(
                name: "tasks_ibfk_1",
                table: "tasks",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "tasks_ibfk_2",
                table: "tasks",
                column: "AssignedTo",
                principalTable: "employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "tasks_ibfk_3",
                table: "tasks",
                column: "StatusID",
                principalTable: "taskstatuses",
                principalColumn: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "worklogs_ibfk_1",
                table: "worklogs",
                column: "EmployeeID",
                principalTable: "employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "worklogs_ibfk_2",
                table: "worklogs",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");
        }
    }
}
