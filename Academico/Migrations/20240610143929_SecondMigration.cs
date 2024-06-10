using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academico.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursosDisciplinas_Cursos_CursoId",
                table: "CursosDisciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_CursosDisciplinas_Disciplinas_DisciplinaId",
                table: "CursosDisciplinas");

            migrationBuilder.AddForeignKey(
                name: "FK_CursosDisciplinas_Cursos_CursoId",
                table: "CursosDisciplinas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursosDisciplinas_Disciplinas_DisciplinaId",
                table: "CursosDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "DisciplinaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursosDisciplinas_Cursos_CursoId",
                table: "CursosDisciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_CursosDisciplinas_Disciplinas_DisciplinaId",
                table: "CursosDisciplinas");

            migrationBuilder.AddForeignKey(
                name: "FK_CursosDisciplinas_Cursos_CursoId",
                table: "CursosDisciplinas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CursosDisciplinas_Disciplinas_DisciplinaId",
                table: "CursosDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "DisciplinaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
