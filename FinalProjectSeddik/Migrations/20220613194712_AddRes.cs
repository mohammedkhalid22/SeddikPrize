using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectSeddik.Migrations
{
    public partial class AddRes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UploadProject",
                table: "UploadProject");

            migrationBuilder.RenameTable(
                name: "UploadProject",
                newName: "Projects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");
        }
    }
}
