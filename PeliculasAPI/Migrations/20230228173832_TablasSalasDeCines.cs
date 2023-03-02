using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasAPI.Migrations
{
    public partial class TablasSalasDeCines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeliculasSalasDeCinePeliculaId",
                table: "PeliculasGeneros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasGeneros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeliculasSalasDeCinePeliculaId",
                table: "PeliculasActores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasActores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalasDeCines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalasDeCines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasSalasDeCines",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaDeCineId = table.Column<int>(type: "int", nullable: false),
                    PeliculasSalasDeCinePeliculaId = table.Column<int>(type: "int", nullable: true),
                    PeliculasSalasDeCineSalaDeCineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasSalasDeCines", x => new { x.PeliculaId, x.SalaDeCineId });
                    table.ForeignKey(
                        name: "FK_PeliculasSalasDeCines_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasSalasDeCines_PeliculasSalasDeCines_PeliculasSalasDeCinePeliculaId_PeliculasSalasDeCineSalaDeCineId",
                        columns: x => new { x.PeliculasSalasDeCinePeliculaId, x.PeliculasSalasDeCineSalaDeCineId },
                        principalTable: "PeliculasSalasDeCines",
                        principalColumns: new[] { "PeliculaId", "SalaDeCineId" });
                    table.ForeignKey(
                        name: "FK_PeliculasSalasDeCines_SalasDeCines_SalaDeCineId",
                        column: x => x.SalaDeCineId,
                        principalTable: "SalasDeCines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasGeneros_PeliculasSalasDeCinePeliculaId_PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasGeneros",
                columns: new[] { "PeliculasSalasDeCinePeliculaId", "PeliculasSalasDeCineSalaDeCineId" });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_PeliculasSalasDeCinePeliculaId_PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasActores",
                columns: new[] { "PeliculasSalasDeCinePeliculaId", "PeliculasSalasDeCineSalaDeCineId" });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasSalasDeCines_PeliculasSalasDeCinePeliculaId_PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasSalasDeCines",
                columns: new[] { "PeliculasSalasDeCinePeliculaId", "PeliculasSalasDeCineSalaDeCineId" });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasSalasDeCines_SalaDeCineId",
                table: "PeliculasSalasDeCines",
                column: "SalaDeCineId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasActores_PeliculasSalasDeCines_PeliculasSalasDeCinePeliculaId_PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasActores",
                columns: new[] { "PeliculasSalasDeCinePeliculaId", "PeliculasSalasDeCineSalaDeCineId" },
                principalTable: "PeliculasSalasDeCines",
                principalColumns: new[] { "PeliculaId", "SalaDeCineId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasGeneros_PeliculasSalasDeCines_PeliculasSalasDeCinePeliculaId_PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasGeneros",
                columns: new[] { "PeliculasSalasDeCinePeliculaId", "PeliculasSalasDeCineSalaDeCineId" },
                principalTable: "PeliculasSalasDeCines",
                principalColumns: new[] { "PeliculaId", "SalaDeCineId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasActores_PeliculasSalasDeCines_PeliculasSalasDeCinePeliculaId_PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasActores");

            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasGeneros_PeliculasSalasDeCines_PeliculasSalasDeCinePeliculaId_PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasGeneros");

            migrationBuilder.DropTable(
                name: "PeliculasSalasDeCines");

            migrationBuilder.DropTable(
                name: "SalasDeCines");

            migrationBuilder.DropIndex(
                name: "IX_PeliculasGeneros_PeliculasSalasDeCinePeliculaId_PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasGeneros");

            migrationBuilder.DropIndex(
                name: "IX_PeliculasActores_PeliculasSalasDeCinePeliculaId_PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasActores");

            migrationBuilder.DropColumn(
                name: "PeliculasSalasDeCinePeliculaId",
                table: "PeliculasGeneros");

            migrationBuilder.DropColumn(
                name: "PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasGeneros");

            migrationBuilder.DropColumn(
                name: "PeliculasSalasDeCinePeliculaId",
                table: "PeliculasActores");

            migrationBuilder.DropColumn(
                name: "PeliculasSalasDeCineSalaDeCineId",
                table: "PeliculasActores");
        }
    }
}
