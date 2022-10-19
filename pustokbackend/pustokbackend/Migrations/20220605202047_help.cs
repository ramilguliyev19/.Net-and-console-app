using Microsoft.EntityFrameworkCore.Migrations;

namespace pustokbackend.Migrations
{
    public partial class help : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Autors_AuthorId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autors",
                table: "Autors");

            migrationBuilder.RenameTable(
                name: "Autors",
                newName: "Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Authors_AuthorId",
                table: "Products",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Authors_AuthorId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Autors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autors",
                table: "Autors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Autors_AuthorId",
                table: "Products",
                column: "AuthorId",
                principalTable: "Autors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
