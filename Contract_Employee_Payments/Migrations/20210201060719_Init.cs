using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contract_Employee_Payments.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractEmployee",
                columns: table => new
                {
                    ContractEmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    HourlyRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEmployee", x => x.ContractEmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    EstimatedHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TimeRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    ContractEmployeeId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeRecord_ContractEmployee_ContractEmployeeId",
                        column: x => x.ContractEmployeeId,
                        principalTable: "ContractEmployee",
                        principalColumn: "ContractEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeRecord_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecord_ContractEmployeeId",
                table: "TimeRecord",
                column: "ContractEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecord_ProjectId",
                table: "TimeRecord",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeRecord");

            migrationBuilder.DropTable(
                name: "ContractEmployee");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
