using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectSeddik.Migrations.ApplicationDb
{
    public partial class Rellee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "AspNetUsers");
        }
    }
}
