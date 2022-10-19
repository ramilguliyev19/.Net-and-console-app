using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pustokbackend.Migrations
{
    public partial class pustokbackend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedData = table.Column<DateTime>(nullable: false),
                    UpdatedData = table.Column<DateTime>(nullable: true),
                    Fullname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedData = table.Column<DateTime>(nullable: false),
                    UpdatedData = table.Column<DateTime>(nullable: true),
                    IconUrl = table.Column<string>(nullable: true),
                    Title1 = table.Column<string>(nullable: true),
                    Title2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedData = table.Column<DateTime>(nullable: false),
                    UpdatedData = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedData = table.Column<DateTime>(nullable: false),
                    UpdatedData = table.Column<DateTime>(nullable: true),
                    RedirectText = table.Column<string>(nullable: true),
                    RedirectUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondPromotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedData = table.Column<DateTime>(nullable: false),
                    UpdatedData = table.Column<DateTime>(nullable: true),
                    RedirectUrl = table.Column<string>(nullable: true),
                    RedirectText = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    ButtonText = table.Column<string>(nullable: true),
                    ButtonUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondPromotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedData = table.Column<DateTime>(nullable: false),
                    UpdatedData = table.Column<DateTime>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Title1 = table.Column<string>(nullable: true),
                    Title2 = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedData = table.Column<DateTime>(nullable: false),
                    UpdatedData = table.Column<DateTime>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SalePrice = table.Column<decimal>(nullable: false),
                    CostPrice = table.Column<decimal>(nullable: false),
                    DiscountPrice = table.Column<decimal>(nullable: false),
                    Desciption = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    IsNew = table.Column<bool>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Autors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Autors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AuthorId",
                table: "Products",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GenreId",
                table: "Products",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "SecondPromotions");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Autors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
