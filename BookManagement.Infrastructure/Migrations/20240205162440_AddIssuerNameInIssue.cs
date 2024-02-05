using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIssuerNameInIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Staffs",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Staffs",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "IssuerName",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssuerName",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Staffs",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Staffs",
                newName: "password");
        }
    }
}
