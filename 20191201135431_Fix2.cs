using Microsoft.EntityFrameworkCore.Migrations;

namespace lab4.Migrations
{
    public partial class Fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_ProjectInfo_ProjectId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ProjectId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ProjectInfoId",
                table: "Employee",
                column: "ProjectInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_ProjectInfo_ProjectInfoId",
                table: "Employee",
                column: "ProjectInfoId",
                principalTable: "ProjectInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_ProjectInfo_ProjectInfoId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ProjectInfoId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ProjectId",
                table: "Employee",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_ProjectInfo_ProjectId",
                table: "Employee",
                column: "ProjectId",
                principalTable: "ProjectInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
