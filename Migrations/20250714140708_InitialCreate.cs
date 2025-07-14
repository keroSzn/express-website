using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace express_website.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hakkimizda",
                columns: table => new
                {
                    HakkimizdaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HakkimizdaMetin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hakkimizda", x => x.HakkimizdaId);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriMetin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Baslik",
                columns: table => new
                {
                    BaslikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaslikAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    KategoriClassKategoriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baslik", x => x.BaslikId);
                    table.ForeignKey(
                        name: "FK_Baslik_Kategori_KategoriClassKategoriId",
                        column: x => x.KategoriClassKategoriId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId");
                });

            migrationBuilder.CreateTable(
                name: "AltBaslik",
                columns: table => new
                {
                    AltBaslikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltBaslikAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaslikId = table.Column<int>(type: "int", nullable: false),
                    AitOlduguBaslikBaslikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltBaslik", x => x.AltBaslikId);
                    table.ForeignKey(
                        name: "FK_AltBaslik_Baslik_AitOlduguBaslikBaslikId",
                        column: x => x.AitOlduguBaslikBaslikId,
                        principalTable: "Baslik",
                        principalColumn: "BaslikId");
                });

            migrationBuilder.CreateTable(
                name: "Eleman",
                columns: table => new
                {
                    ElemanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElemanAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElemanMetin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltBaslikId = table.Column<int>(type: "int", nullable: false),
                    AitOlduguAltBaslikAltBaslikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleman", x => x.ElemanId);
                    table.ForeignKey(
                        name: "FK_Eleman_AltBaslik_AitOlduguAltBaslikAltBaslikId",
                        column: x => x.AitOlduguAltBaslikAltBaslikId,
                        principalTable: "AltBaslik",
                        principalColumn: "AltBaslikId");
                });

            migrationBuilder.CreateTable(
                name: "ElemanModeli",
                columns: table => new
                {
                    ElemanModeliId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElemanModeliAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiyatBilgisi1 = table.Column<int>(type: "int", nullable: true),
                    FiyatBilgisi2 = table.Column<int>(type: "int", nullable: true),
                    ElemanId = table.Column<int>(type: "int", nullable: false),
                    AitOlduguElemanElemanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElemanModeli", x => x.ElemanModeliId);
                    table.ForeignKey(
                        name: "FK_ElemanModeli_Eleman_AitOlduguElemanElemanId",
                        column: x => x.AitOlduguElemanElemanId,
                        principalTable: "Eleman",
                        principalColumn: "ElemanId");
                });

            migrationBuilder.CreateTable(
                name: "Alan",
                columns: table => new
                {
                    AlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlanAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    AitOlduguElemanModeliElemanModeliId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alan", x => x.AlanId);
                    table.ForeignKey(
                        name: "FK_Alan_ElemanModeli_AitOlduguElemanModeliElemanModeliId",
                        column: x => x.AitOlduguElemanModeliElemanModeliId,
                        principalTable: "ElemanModeli",
                        principalColumn: "ElemanModeliId");
                });

            migrationBuilder.CreateTable(
                name: "Hucre",
                columns: table => new
                {
                    HucreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HucreMetin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlanId = table.Column<int>(type: "int", nullable: false),
                    AitOlduguAlanAlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hucre", x => x.HucreId);
                    table.ForeignKey(
                        name: "FK_Hucre_Alan_AitOlduguAlanAlanId",
                        column: x => x.AitOlduguAlanAlanId,
                        principalTable: "Alan",
                        principalColumn: "AlanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alan_AitOlduguElemanModeliElemanModeliId",
                table: "Alan",
                column: "AitOlduguElemanModeliElemanModeliId");

            migrationBuilder.CreateIndex(
                name: "IX_AltBaslik_AitOlduguBaslikBaslikId",
                table: "AltBaslik",
                column: "AitOlduguBaslikBaslikId");

            migrationBuilder.CreateIndex(
                name: "IX_Baslik_KategoriClassKategoriId",
                table: "Baslik",
                column: "KategoriClassKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Eleman_AitOlduguAltBaslikAltBaslikId",
                table: "Eleman",
                column: "AitOlduguAltBaslikAltBaslikId");

            migrationBuilder.CreateIndex(
                name: "IX_ElemanModeli_AitOlduguElemanElemanId",
                table: "ElemanModeli",
                column: "AitOlduguElemanElemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Hucre_AitOlduguAlanAlanId",
                table: "Hucre",
                column: "AitOlduguAlanAlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hakkimizda");

            migrationBuilder.DropTable(
                name: "Hucre");

            migrationBuilder.DropTable(
                name: "Alan");

            migrationBuilder.DropTable(
                name: "ElemanModeli");

            migrationBuilder.DropTable(
                name: "Eleman");

            migrationBuilder.DropTable(
                name: "AltBaslik");

            migrationBuilder.DropTable(
                name: "Baslik");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}
