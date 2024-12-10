using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DividendDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Dividend = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DividendCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DividendTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gross = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Net = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Profit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Opening = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpeningCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpeningTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Closing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClosingCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClosingTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holdings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holdings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holdings_Summaries_SummaryId",
                        column: x => x.SummaryId,
                        principalTable: "Summaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Holdings_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_SummaryId",
                table: "Holdings",
                column: "SummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_TransactionId",
                table: "Holdings",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holdings");

            migrationBuilder.DropTable(
                name: "Summaries");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
