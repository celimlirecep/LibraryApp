using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.DAL.Migrations
{
    public partial class initializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    BookImage = table.Column<string>(type: "TEXT", nullable: true),
                    BookStock = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentStock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "UserCards",
                columns: table => new
                {
                    UserCardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCards", x => x.UserCardId);
                });

            migrationBuilder.CreateTable(
                name: "BookReserves",
                columns: table => new
                {
                    BookReserveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BarrowingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserCardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReserves", x => x.BookReserveId);
                    table.ForeignKey(
                        name: "FK_BookReserves_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReserves_UserCards_UserCardId",
                        column: x => x.UserCardId,
                        principalTable: "UserCards",
                        principalColumn: "UserCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 1, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Dinle Küçük Adam", 5, 5 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 2, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Nar Ağacı", 5, 8 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 3, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Savaşçı", 5, 5 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 4, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Doğmamış Çocuğa Mektup", 5, 3 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 5, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Küçük Kara Balık", 5, 10 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 6, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Uygarlıkların Batışı", 5, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_BookReserves_BookId",
                table: "BookReserves",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReserves_UserCardId",
                table: "BookReserves",
                column: "UserCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReserves");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "UserCards");
        }
    }
}
