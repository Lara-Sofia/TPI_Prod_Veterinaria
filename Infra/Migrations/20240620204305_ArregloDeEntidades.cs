﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class ArregloDeEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Users_ClienteId",
                table: "Mascotas");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Mascotas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Users_ClienteId",
                table: "Mascotas",
                column: "ClienteId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Users_ClienteId",
                table: "Mascotas");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Mascotas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Users_ClienteId",
                table: "Mascotas",
                column: "ClienteId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
