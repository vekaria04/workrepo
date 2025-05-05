using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NIA.OnlineApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixValueColumnLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Entity",
                type: "varchar(5000)",
                unicode: false,
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Entity",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldUnicode: false,
                oldMaxLength: 5000);
        }
    }
}
