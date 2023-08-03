using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6.Additional.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SellerId",
                table: "Cars",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Sellers_SellerId",
                table: "Cars",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Sellers_SellerId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_SellerId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Cars");
        }
    }
}
