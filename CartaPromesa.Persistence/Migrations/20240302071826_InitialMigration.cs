using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartaPromesa.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreOrdenante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoOrdenante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreBeneficiario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoBeneficiario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaSolicitud = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FechaVencimiento = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitudes");
        }
    }
}
