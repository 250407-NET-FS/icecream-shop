using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IcecreamShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class IcecreamShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.PhoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Icecreams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scoops = table.Column<int>(type: "int", nullable: false),
                    Flavors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnCone = table.Column<bool>(type: "bit", nullable: false),
                    Toppings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icecreams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashierPhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Cashiers_CashierPhoneNumber",
                        column: x => x.CashierPhoneNumber,
                        principalTable: "Cashiers",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerEmail",
                        column: x => x.CustomerEmail,
                        principalTable: "Customers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerIcecream",
                columns: table => new
                {
                    CustomersEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IcecreamHistoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerIcecream", x => new { x.CustomersEmail, x.IcecreamHistoryId });
                    table.ForeignKey(
                        name: "FK_CustomerIcecream_Customers_CustomersEmail",
                        column: x => x.CustomersEmail,
                        principalTable: "Customers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerIcecream_Icecreams_IcecreamHistoryId",
                        column: x => x.IcecreamHistoryId,
                        principalTable: "Icecreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IcecreamTransaction",
                columns: table => new
                {
                    IcecreamsId = table.Column<int>(type: "int", nullable: false),
                    TransactionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecreamTransaction", x => new { x.IcecreamsId, x.TransactionsId });
                    table.ForeignKey(
                        name: "FK_IcecreamTransaction_Icecreams_IcecreamsId",
                        column: x => x.IcecreamsId,
                        principalTable: "Icecreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IcecreamTransaction_Transactions_TransactionsId",
                        column: x => x.TransactionsId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cashiers",
                columns: new[] { "PhoneNumber", "Name" },
                values: new object[,]
                {
                    { "305-123-4567", "John Pickleberry" },
                    { "305-533-6103", "Jessica Largecake" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Email", "Name" },
                values: new object[,]
                {
                    { "coldcoder9225@proton.me", "Lucas Rodriguez" },
                    { "mail@potatoes.vore", "M Andy" }
                });

            migrationBuilder.InsertData(
                table: "Icecreams",
                columns: new[] { "Id", "Flavors", "OnCone", "Scoops", "Size", "Toppings" },
                values: new object[,]
                {
                    { 1, "[\"Blueberry\",\"Strawberry\"]", true, 2, 2, "[\"Cherry\"]" },
                    { 2, "[\"Mint Chocolate\"]", false, 1, 3, "[\"Sprinkles\",\"Chocolate Chips\"]" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerIcecream_IcecreamHistoryId",
                table: "CustomerIcecream",
                column: "IcecreamHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IcecreamTransaction_TransactionsId",
                table: "IcecreamTransaction",
                column: "TransactionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CashierPhoneNumber",
                table: "Transactions",
                column: "CashierPhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerEmail",
                table: "Transactions",
                column: "CustomerEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerIcecream");

            migrationBuilder.DropTable(
                name: "IcecreamTransaction");

            migrationBuilder.DropTable(
                name: "Icecreams");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
