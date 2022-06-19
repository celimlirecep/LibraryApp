using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.DAL.Migrations
{
    public partial class addingStatusinBookReserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "BookReserves",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 7, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Uygarlıkların Batışı", 5, 7 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 8, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Uygarlıkların Batışı", 5, 7 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 9, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Uygarlıkların Batışı", 5, 7 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 10, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Uygarlıkların Batışı", 5, 7 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImage", "BookName", "BookStock", "CurrentStock" },
                values: new object[] { 11, "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", "Uygarlıkların Batışı", 5, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BookReserves");
        }
    }
}
