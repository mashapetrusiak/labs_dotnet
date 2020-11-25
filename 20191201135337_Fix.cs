using Microsoft.EntityFrameworkCore.Migrations;

namespace lab4.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_ProjectInfo_ProjectId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProjectInfoId",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_ProjectInfo_ProjectId",
                table: "Employee",
                column: "ProjectId",
                principalTable: "ProjectInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_ProjectInfo_ProjectId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ProjectInfoId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_ProjectInfo_ProjectId",
                table: "Employee",
                column: "ProjectId",
                principalTable: "ProjectInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
