using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectSeddik.Migrations.ApplicationDb
{
    public partial class Relle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "AspNetUsers",
                newName: "IsJudge");
        }
    }
}
