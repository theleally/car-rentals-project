using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace car_rentals_project.Migrations
{
    public partial class OrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    AutomobileId = table.Column<int>(type: "INTEGER", nullable: false),
                    Total_Price = table.Column<float>(type: "REAL", nullable: false),
                    Total_Days = table.Column<string>(type: "TEXT", nullable: true),
                    Start_Date = table.Column<string>(type: "TEXT", nullable: true),
                    End_Date = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrdersId);
                    table.ForeignKey(
                        name: "FK_Orders_Automobile_AutomobileId",
                        column: x => x.AutomobileId,
                        principalTable: "Automobile",
                        principalColumn: "AutomobileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AutomobileId",
                table: "Orders",
                column: "AutomobileId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AutomobileId = table.Column<int>(type: "INTEGER", nullable: true),
                    AutomobilelId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End_Date = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    Start_Date = table.Column<string>(type: "TEXT", nullable: true),
                    Total_Days = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Total_Price = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Automobile_AutomobileId",
                        column: x => x.AutomobileId,
                        principalTable: "Automobile",
                        principalColumn: "AutomobileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_AutomobileId",
                table: "Order",
                column: "AutomobileId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId");
        }
    }
}
