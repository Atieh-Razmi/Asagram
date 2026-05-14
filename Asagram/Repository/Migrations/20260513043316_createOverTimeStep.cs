using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class createOverTimeStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OverTimeSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OverTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OverTimeStepNumber = table.Column<int>(type: "int", nullable: false),
                    OverTimeStepStatus = table.Column<int>(type: "int", nullable: false),
                    ApproverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverTimeSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverTimeSteps_OverTimes_OverTimeId",
                        column: x => x.OverTimeId,
                        principalTable: "OverTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OverTimeSteps_Users_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OverTimeSteps_ApproverId",
                table: "OverTimeSteps",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_OverTimeSteps_OverTimeId",
                table: "OverTimeSteps",
                column: "OverTimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OverTimeSteps");
        }
    }
}
