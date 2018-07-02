using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDatosAcceso.ModeloNegocio.Migrations
{
    public partial class MigracionParaDBEjercicioClaroV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetalleLista",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListaId = table.Column<long>(nullable: false),
                    TrackNumber = table.Column<long>(nullable: false),
                    InternalId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    DurationInSeconds = table.Column<long>(nullable: false),
                    AlbumId = table.Column<long>(nullable: false),
                    AlbumName = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    ArtistId = table.Column<string>(nullable: true),
                    Artists = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    SongSourceType = table.Column<long>(nullable: false),
                    ListSourceType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallesLista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listas",
                columns: table => new
                {
                    ListaId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    IsFollowing = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listas", x => x.ListaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallesLista");

            migrationBuilder.DropTable(
                name: "listas");
        }
    }
}
