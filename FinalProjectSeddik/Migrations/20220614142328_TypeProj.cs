using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectSeddik.Migrations
{
    public partial class TypeProj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "project_type",
                table: "compRegs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "project_type",
                table: "compRegs");
        }
    }
}
