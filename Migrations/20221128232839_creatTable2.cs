using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace car_rentals_project.Migrations
{
    public partial class creatTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobile",
                columns: table => new
                {
                    AutomobileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    models = table.Column<string>(type: "TEXT", nullable: true),
                    brand = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    placa = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobile", x => x.AutomobileId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Cellphone = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    AutomobileId = table.Column<int>(type: "INTEGER", nullable: false),
                    Total_Price = table.Column<double>(type: "REAL", nullable: false),
                    Total_Days = table.Column<double>(type: "REAL", nullable: false),
                    Total_Days_Price = table.Column<double>(type: "REAL", nullable: false),
                    Start_Date = table.Column<string>(type: "TEXT", nullable: true),
                    End_Date = table.Column<string>(type: "TEXT", nullable: true),
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

            migrationBuilder.DropTable(
                name: "Automobile");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
