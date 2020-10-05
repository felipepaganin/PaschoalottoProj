using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paschoalotto.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "paschoalotto");

            migrationBuilder.CreateTable(
                name: "Debt",
                schema: "paschoalotto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(unicode: false, maxLength: 200, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    CPF = table.Column<string>(maxLength: 17, nullable: false),
                    Interest = table.Column<float>(unicode: false, nullable: false),
                    FineFee = table.Column<float>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebtInstallments",
                schema: "paschoalotto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(unicode: false, maxLength: 150, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Price = table.Column<float>(unicode: false, maxLength: 50, nullable: false),
                    DebtId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtInstallments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtInstallments_Debt_DebtId",
                        column: x => x.DebtId,
                        principalSchema: "paschoalotto",
                        principalTable: "Debt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtInstallments_DebtId",
                schema: "paschoalotto",
                table: "DebtInstallments",
                column: "DebtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtInstallments",
                schema: "paschoalotto");

            migrationBuilder.DropTable(
                name: "Debt",
                schema: "paschoalotto");
        }
    }
}
