using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Issues_BookId",
                table: "Issues",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_StudentId",
                table: "Issues",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Books_BookId",
                table: "Issues",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Students_StudentId",
                table: "Issues",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Books_BookId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Students_StudentId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_BookId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_StudentId",
                table: "Issues");
        }
    }
}
