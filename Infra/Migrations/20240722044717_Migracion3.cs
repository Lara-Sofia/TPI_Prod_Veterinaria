using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Migracion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosticos_Users_VeterinarioId",
                table: "Diagnosticos");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Mascotas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Animal",
                table: "Mascotas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarioId",
                table: "Diagnosticos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosticos_Users_VeterinarioId",
                table: "Diagnosticos",
                column: "VeterinarioId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosticos_Users_VeterinarioId",
                table: "Diagnosticos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Animal",
                table: "Mascotas");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarioId",
                table: "Diagnosticos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosticos_Users_VeterinarioId",
                table: "Diagnosticos",
                column: "VeterinarioId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
