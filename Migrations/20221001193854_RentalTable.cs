using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace car_rentals_project.Migrations
{
    public partial class RentalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    table.PrimaryKey("PK_Rental", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rental_Automobile_AutomobileId",
                        column: x => x.AutomobileId,
                        principalTable: "Automobile",
                        principalColumn: "AutomobileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_AutomobileId",
                table: "Rental",
                column: "AutomobileId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_ClientId",
                table: "Rental",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AutomobileId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End_Date = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    Start_Date = table.Column<string>(type: "TEXT", nullable: true),
                    Total_Days = table.Column<string>(type: "TEXT", nullable: true),
                    Total_Price = table.Column<float>(type: "REAL", nullable: false)
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
    }
}
