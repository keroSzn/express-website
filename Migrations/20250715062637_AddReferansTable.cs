using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace express_website.Migrations
{
    /// <inheritdoc />
    public partial class AddReferansTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proje",
                columns: table => new
                {
                    ProjeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeGorsel = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proje", x => x.ProjeId);
                });

            migrationBuilder.CreateTable(
                name: "Referans",
                columns: table => new
                {
                    ReferansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferansGorsel = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referans", x => x.ReferansId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proje");

            migrationBuilder.DropTable(
                name: "Referans");
        }
    }
}
