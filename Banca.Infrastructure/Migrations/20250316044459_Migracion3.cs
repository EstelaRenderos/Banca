using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migracion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionTypeCode",
                table: "AccountTypes");

            migrationBuilder.AddColumn<string>(
                name: "TransactionTypeCode",
                table: "TransactionType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionTypeCode",
                table: "TransactionType");

            migrationBuilder.AddColumn<string>(
                name: "TransactionTypeCode",
                table: "AccountTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
