using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class deletetabellangues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_languesData_languesDataID",
                table: "books");

            migrationBuilder.DropTable(
                name: "languesData");

            migrationBuilder.DropIndex(
                name: "IX_books_languesDataID",
                table: "books");

            migrationBuilder.DropColumn(
                name: "languesDataID",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "languageId",
                table: "books",
                newName: "language");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "language",
                table: "books",
                newName: "languageId");

            migrationBuilder.AddColumn<int>(
                name: "languesDataID",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "languesData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languesData", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_languesDataID",
                table: "books",
                column: "languesDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_books_languesData_languesDataID",
                table: "books",
                column: "languesDataID",
                principalTable: "languesData",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
