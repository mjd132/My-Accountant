using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace p1.Migrations
{
    /// <inheritdoc />
    public partial class addDebtrelationonetomanyuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MadarKharjId",
                table: "Debts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Debts_MadarKharjId",
                table: "Debts",
                column: "MadarKharjId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_Users_MadarKharjId",
                table: "Debts",
                column: "MadarKharjId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Users_MadarKharjId",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Debts_MadarKharjId",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "MadarKharjId",
                table: "Debts");
        }
    }
}
