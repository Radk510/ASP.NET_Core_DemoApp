using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Side.Migrations
{
    public partial class Addbookandauthormodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 500, nullable: false),
                    LastName = table.Column<string>(maxLength: 500, nullable: false),
                    PlaceOfBirth = table.Column<string>(maxLength: 500, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateOfDath = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 3000, nullable: false),
                    AuthorImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    Genre = table.Column<string>(maxLength: 500, nullable: false),
                    DateOfRelize = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    BookImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
