using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace p1.Migrations
{
    /// <inheritdoc />
    public partial class adddebtrelationsmanytomanywithuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DebtRegUser",
                columns: table => new
                {
                    DebtUsersId = table.Column<long>(type: "bigint", nullable: false),
                    DebtsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtRegUser", x => new { x.DebtUsersId, x.DebtsId });
                    table.ForeignKey(
                        name: "FK_DebtRegUser_Debts_DebtsId",
                        column: x => x.DebtsId,
                        principalTable: "Debts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebtRegUser_Users_DebtUsersId",
                        column: x => x.DebtUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtRegUser_DebtsId",
                table: "DebtRegUser",
                column: "DebtsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtRegUser");
        }
    }
}
