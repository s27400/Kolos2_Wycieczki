using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolos2_1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdClient", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdCountry", x => x.IdCountry);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    IdTrip = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdTrip", x => x.IdTrip);
                });

            migrationBuilder.CreateTable(
                name: "Client_Trip",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdTrip = table.Column<int>(type: "int", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ClientTrip_pk", x => new { x.IdClient, x.IdTrip });
                    table.ForeignKey(
                        name: "FK_Client_Trip_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Trip_Trip_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Trip",
                        principalColumn: "IdTrip",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountryTrip",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    IdTrip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTrip", x => new { x.IdCountry, x.IdTrip });
                    table.ForeignKey(
                        name: "FK_CountryTrip_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTrip_Trip_IdTrip",
                        column: x => x.IdTrip,
                        principalTable: "Trip",
                        principalColumn: "IdTrip",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdClient", "Email", "FirstName", "LastName", "Pesel", "Telephone" },
                values: new object[,]
                {
                    { 1, "a@wp.pl", "Ada", "Nowak", "1", "123" },
                    { 2, "m@wp.pl", "Adam", "Malinowski", "2", "312" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "IdCountry", "Name" },
                values: new object[,]
                {
                    { 1, "Maroko_kraj" },
                    { 2, "USA_kraj" }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "IdTrip", "DateFrom", "DateTo", "Description", "MaxPeople", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 6, 21, 36, 33, 231, DateTimeKind.Local).AddTicks(6420), new DateTime(2024, 9, 6, 21, 36, 33, 231, DateTimeKind.Local).AddTicks(6440), "Desc1", 120, "Maroko" },
                    { 2, new DateTime(2024, 6, 6, 21, 38, 33, 231, DateTimeKind.Local).AddTicks(6440), new DateTime(2024, 6, 6, 21, 42, 33, 231, DateTimeKind.Local).AddTicks(6450), "Desc2", 90, "USA" }
                });

            migrationBuilder.InsertData(
                table: "Client_Trip",
                columns: new[] { "IdClient", "IdTrip", "PaymentDate", "RegisteredAt" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2024, 6, 6, 21, 36, 33, 229, DateTimeKind.Local).AddTicks(6540) },
                    { 2, 2, new DateTime(2024, 6, 6, 21, 37, 33, 229, DateTimeKind.Local).AddTicks(6600), new DateTime(2024, 6, 6, 21, 36, 33, 229, DateTimeKind.Local).AddTicks(6590) }
                });

            migrationBuilder.InsertData(
                table: "CountryTrip",
                columns: new[] { "IdCountry", "IdTrip" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryTrip_IdTrip",
                table: "CountryTrip",
                column: "IdTrip");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client_Trip");

            migrationBuilder.DropTable(
                name: "CountryTrip");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Trip");
        }
    }
}
