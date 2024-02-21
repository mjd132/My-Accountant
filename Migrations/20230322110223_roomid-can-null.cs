using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace p1.Migrations
{
    /// <inheritdoc />
    public partial class roomidcannull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_roomId",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "roomId",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_roomId",
                table: "Users",
                column: "roomId",
                principalTable: "Rooms",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_roomId",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "roomId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_roomId",
                table: "Users",
                column: "roomId",
                principalTable: "Rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
