using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Migrations
{
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombreCompleto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    passport = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    needAssistance = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    nit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracionFactura",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    nitProveedor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    razonSocialProveedor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    nroAutorizacion = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionFactura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reservationNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    reservationStatus = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    monto = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    deuda = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    tipoReserva = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VueloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    source_airport_code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    destiny_airport_code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flight_program_id = table.Column<int>(type: "int", nullable: false),
                    information = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    importe = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    nroFactura = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    lugar = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    nitBeneficiario = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    razonSocialBeneficiario = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    nroAutorizacion = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    tipoNit = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VueloId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConfiguracionFacturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_ConfiguracionFactura_ConfiguracionFacturaId",
                        column: x => x.ConfiguracionFacturaId,
                        principalTable: "ConfiguracionFactura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Vuelo_VueloId",
                        column: x => x.VueloId,
                        principalTable: "Vuelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ConfiguracionFacturaId",
                table: "Factura",
                column: "ConfiguracionFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ReservaId",
                table: "Factura",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_VueloId",
                table: "Factura",
                column: "VueloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ConfiguracionFactura");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Vuelo");
        }
    }
}
