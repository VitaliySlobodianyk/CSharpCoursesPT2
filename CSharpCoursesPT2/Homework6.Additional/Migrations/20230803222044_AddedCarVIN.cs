using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6.Additional.Migrations
{
    /// <inheritdoc />
    public partial class AddedCarVIN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VIN",
                table: "Cars");
        }
    }
}
