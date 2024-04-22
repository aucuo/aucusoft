using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UniversityProjectInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Industry = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPerson = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ClientID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "managers",
                columns: table => new
                {
                    ManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ManagerID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    PositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SalaryGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PositionID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "taskstatuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.StatusID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "technologies",
                columns: table => new
                {
                    TechnologyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TechnologyID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManagerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "fk_departments_managers",
                        column: x => x.ManagerID,
                        principalTable: "managers",
                        principalColumn: "ManagerID",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PositionID = table.Column<int>(type: "int", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "employees_ibfk_1",
                        column: x => x.PositionID,
                        principalTable: "positions",
                        principalColumn: "PositionID");
                    table.ForeignKey(
                        name: "employees_ibfk_2",
                        column: x => x.DepartmentID,
                        principalTable: "departments",
                        principalColumn: "DepartmentID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    ProjectManagerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ProjectID);
                    table.ForeignKey(
                        name: "projects_ibfk_1",
                        column: x => x.ClientID,
                        principalTable: "clients",
                        principalColumn: "ClientID");
                    table.ForeignKey(
                        name: "projects_ibfk_2",
                        column: x => x.ProjectManagerID,
                        principalTable: "employees",
                        principalColumn: "EmployeeID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "clientfeedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "clientfeedback_ibfk_1",
                        column: x => x.ProjectID,
                        principalTable: "projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "clientfeedback_ibfk_2",
                        column: x => x.ClientID,
                        principalTable: "clients",
                        principalColumn: "ClientID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "meetings",
                columns: table => new
                {
                    MeetingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    MeetingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Agenda = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MeetingID);
                    table.ForeignKey(
                        name: "meetings_ibfk_1",
                        column: x => x.ProjectID,
                        principalTable: "projects",
                        principalColumn: "ProjectID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "projectdocuments",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentPath = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.DocumentID);
                    table.ForeignKey(
                        name: "projectdocuments_ibfk_1",
                        column: x => x.ProjectID,
                        principalTable: "projects",
                        principalColumn: "ProjectID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "projecttechnologies",
                columns: table => new
                {
                    ProjectTechnologyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    TechnologyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ProjectTechnologyID);
                    table.ForeignKey(
                        name: "projecttechnologies_ibfk_1",
                        column: x => x.ProjectID,
                        principalTable: "projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "projecttechnologies_ibfk_2",
                        column: x => x.TechnologyID,
                        principalTable: "technologies",
                        principalColumn: "TechnologyID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    AssignedTo = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TaskID);
                    table.ForeignKey(
                        name: "tasks_ibfk_1",
                        column: x => x.ProjectID,
                        principalTable: "projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "tasks_ibfk_2",
                        column: x => x.AssignedTo,
                        principalTable: "employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "tasks_ibfk_3",
                        column: x => x.StatusID,
                        principalTable: "taskstatuses",
                        principalColumn: "StatusID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "worklogs",
                columns: table => new
                {
                    WorkLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    HoursWorked = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.WorkLogID);
                    table.ForeignKey(
                        name: "worklogs_ibfk_1",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "worklogs_ibfk_2",
                        column: x => x.ProjectID,
                        principalTable: "projects",
                        principalColumn: "ProjectID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employeetasks",
                columns: table => new
                {
                    EmployeeTaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaskID = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    TimeSpent = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.EmployeeTaskID);
                    table.ForeignKey(
                        name: "employeetasks_ibfk_1",
                        column: x => x.TaskID,
                        principalTable: "tasks",
                        principalColumn: "TaskID");
                    table.ForeignKey(
                        name: "employeetasks_ibfk_2",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "ClientID",
                table: "clientfeedback",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "ProjectID",
                table: "clientfeedback",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "fk_departments_managers",
                table: "departments",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "DepartmentID",
                table: "employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "PositionID",
                table: "employees",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "employeetasks_ibfk_2",
                table: "employeetasks",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "TaskID",
                table: "employeetasks",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "ProjectID1",
                table: "meetings",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "ProjectID2",
                table: "projectdocuments",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "ClientID1",
                table: "projects",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "ProjectManagerID",
                table: "projects",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "ProjectID3",
                table: "projecttechnologies",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "TechnologyID",
                table: "projecttechnologies",
                column: "TechnologyID");

            migrationBuilder.CreateIndex(
                name: "AssignedTo",
                table: "tasks",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "ProjectID4",
                table: "tasks",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "StatusID",
                table: "tasks",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "EmployeeID",
                table: "worklogs",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "ProjectID5",
                table: "worklogs",
                column: "ProjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientfeedback");

            migrationBuilder.DropTable(
                name: "employeetasks");

            migrationBuilder.DropTable(
                name: "meetings");

            migrationBuilder.DropTable(
                name: "projectdocuments");

            migrationBuilder.DropTable(
                name: "projecttechnologies");

            migrationBuilder.DropTable(
                name: "worklogs");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "technologies");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "taskstatuses");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "managers");
        }
    }
}
