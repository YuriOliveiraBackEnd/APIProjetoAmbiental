using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAmbiental.Migrations
{
    /// <inheritdoc />
    public partial class AddCondicoesAmbientais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CondicoesAmbientais",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    qualidadeAr = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    umidade = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    temperatura = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    contatoEmergencia = table.Column<string>(type: "NVARCHAR2(15)", nullable: false),
                    desastreNatural = table.Column<string>(type: "NVARCHAR2(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicoesAmbientais", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondicoesAmbientais");
        }
    }
}
