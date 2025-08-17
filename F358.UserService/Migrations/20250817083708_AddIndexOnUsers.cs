using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F358.UserService.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexOnUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login")
                .Annotation("Npgsql:IndexInclude", new[] { "Id", "PasswordEncrypted", "EncryptionVersion" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");
        }
    }
}
