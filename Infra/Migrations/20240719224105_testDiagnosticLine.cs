using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class testDiagnosticLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Diagnosticos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Diagnosticos");

            migrationBuilder.CreateTable(
                name: "DiagnosticoLineas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DiagnosticoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticoLineas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagnosticoLineas_Diagnosticos_DiagnosticoId",
                        column: x => x.DiagnosticoId,
                        principalTable: "Diagnosticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticoLineas_DiagnosticoId",
                table: "DiagnosticoLineas",
                column: "DiagnosticoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosticoLineas");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Diagnosticos",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Diagnosticos",
                type: "TEXT",
                maxLength: 180,
                nullable: false,
                defaultValue: "");
        }
    }
}
