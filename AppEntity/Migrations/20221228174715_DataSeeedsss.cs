using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppEntity.Migrations
{
    public partial class DataSeeedsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "CategoriaName" },
                values: new object[] { 1, "Tareas Personales" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "CategoriaName" },
                values: new object[] { 2, "Tareas que voy a patear" });

            migrationBuilder.InsertData(
                table: "TareasNovedosasSuperExclusivas",
                columns: new[] { "TareaId", "IdCategoria", "TareaName" },
                values: new object[] { 1, 1, "Lavar los platos" });

            migrationBuilder.InsertData(
                table: "TareasNovedosasSuperExclusivas",
                columns: new[] { "TareaId", "IdCategoria", "TareaName" },
                values: new object[] { 2, 1, "Ordenar los juguetes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TareasNovedosasSuperExclusivas",
                keyColumn: "TareaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TareasNovedosasSuperExclusivas",
                keyColumn: "TareaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 1);
        }
    }
}
