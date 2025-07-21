using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace express_website.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alan_ElemanModeli_AitOlduguElemanModeliElemanModeliId",
                table: "Alan");

            migrationBuilder.DropForeignKey(
                name: "FK_AltBaslik_Baslik_AitOlduguBaslikBaslikId",
                table: "AltBaslik");

            migrationBuilder.DropForeignKey(
                name: "FK_Baslik_Kategori_KategoriClassKategoriId",
                table: "Baslik");

            migrationBuilder.DropForeignKey(
                name: "FK_Eleman_AltBaslik_AitOlduguAltBaslikAltBaslikId",
                table: "Eleman");

            migrationBuilder.DropForeignKey(
                name: "FK_ElemanModeli_Eleman_AitOlduguElemanElemanId",
                table: "ElemanModeli");

            migrationBuilder.DropForeignKey(
                name: "FK_Hucre_Alan_AitOlduguAlanAlanId",
                table: "Hucre");

            migrationBuilder.DropIndex(
                name: "IX_Hucre_AitOlduguAlanAlanId",
                table: "Hucre");

            migrationBuilder.DropIndex(
                name: "IX_ElemanModeli_AitOlduguElemanElemanId",
                table: "ElemanModeli");

            migrationBuilder.DropIndex(
                name: "IX_Eleman_AitOlduguAltBaslikAltBaslikId",
                table: "Eleman");

            migrationBuilder.DropIndex(
                name: "IX_Baslik_KategoriClassKategoriId",
                table: "Baslik");

            migrationBuilder.DropIndex(
                name: "IX_AltBaslik_AitOlduguBaslikBaslikId",
                table: "AltBaslik");

            migrationBuilder.DropColumn(
                name: "AitOlduguAlanAlanId",
                table: "Hucre");

            migrationBuilder.DropColumn(
                name: "AitOlduguElemanElemanId",
                table: "ElemanModeli");

            migrationBuilder.DropColumn(
                name: "AitOlduguAltBaslikAltBaslikId",
                table: "Eleman");

            migrationBuilder.DropColumn(
                name: "KategoriClassKategoriId",
                table: "Baslik");

            migrationBuilder.DropColumn(
                name: "AitOlduguBaslikBaslikId",
                table: "AltBaslik");

            migrationBuilder.RenameColumn(
                name: "AitOlduguElemanModeliElemanModeliId",
                table: "Alan",
                newName: "ElemanModeliId");

            migrationBuilder.RenameIndex(
                name: "IX_Alan_AitOlduguElemanModeliElemanModeliId",
                table: "Alan",
                newName: "IX_Alan_ElemanModeliId");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    IletisimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IletisimAdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IletisimMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IletisimKonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IletisimMesaj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.IletisimId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hucre_AlanId",
                table: "Hucre",
                column: "AlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ElemanModeli_ElemanId",
                table: "ElemanModeli",
                column: "ElemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Eleman_AltBaslikId",
                table: "Eleman",
                column: "AltBaslikId");

            migrationBuilder.CreateIndex(
                name: "IX_Baslik_KategoriId",
                table: "Baslik",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_AltBaslik_BaslikId",
                table: "AltBaslik",
                column: "BaslikId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Alan_ElemanModeli_ElemanModeliId",
                table: "Alan",
                column: "ElemanModeliId",
                principalTable: "ElemanModeli",
                principalColumn: "ElemanModeliId");

            migrationBuilder.AddForeignKey(
                name: "FK_AltBaslik_Baslik_BaslikId",
                table: "AltBaslik",
                column: "BaslikId",
                principalTable: "Baslik",
                principalColumn: "BaslikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baslik_Kategori_KategoriId",
                table: "Baslik",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eleman_AltBaslik_AltBaslikId",
                table: "Eleman",
                column: "AltBaslikId",
                principalTable: "AltBaslik",
                principalColumn: "AltBaslikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElemanModeli_Eleman_ElemanId",
                table: "ElemanModeli",
                column: "ElemanId",
                principalTable: "Eleman",
                principalColumn: "ElemanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hucre_Alan_AlanId",
                table: "Hucre",
                column: "AlanId",
                principalTable: "Alan",
                principalColumn: "AlanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alan_ElemanModeli_ElemanModeliId",
                table: "Alan");

            migrationBuilder.DropForeignKey(
                name: "FK_AltBaslik_Baslik_BaslikId",
                table: "AltBaslik");

            migrationBuilder.DropForeignKey(
                name: "FK_Baslik_Kategori_KategoriId",
                table: "Baslik");

            migrationBuilder.DropForeignKey(
                name: "FK_Eleman_AltBaslik_AltBaslikId",
                table: "Eleman");

            migrationBuilder.DropForeignKey(
                name: "FK_ElemanModeli_Eleman_ElemanId",
                table: "ElemanModeli");

            migrationBuilder.DropForeignKey(
                name: "FK_Hucre_Alan_AlanId",
                table: "Hucre");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Iletisim");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Hucre_AlanId",
                table: "Hucre");

            migrationBuilder.DropIndex(
                name: "IX_ElemanModeli_ElemanId",
                table: "ElemanModeli");

            migrationBuilder.DropIndex(
                name: "IX_Eleman_AltBaslikId",
                table: "Eleman");

            migrationBuilder.DropIndex(
                name: "IX_Baslik_KategoriId",
                table: "Baslik");

            migrationBuilder.DropIndex(
                name: "IX_AltBaslik_BaslikId",
                table: "AltBaslik");

            migrationBuilder.RenameColumn(
                name: "ElemanModeliId",
                table: "Alan",
                newName: "AitOlduguElemanModeliElemanModeliId");

            migrationBuilder.RenameIndex(
                name: "IX_Alan_ElemanModeliId",
                table: "Alan",
                newName: "IX_Alan_AitOlduguElemanModeliElemanModeliId");

            migrationBuilder.AddColumn<int>(
                name: "AitOlduguAlanAlanId",
                table: "Hucre",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AitOlduguElemanElemanId",
                table: "ElemanModeli",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AitOlduguAltBaslikAltBaslikId",
                table: "Eleman",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KategoriClassKategoriId",
                table: "Baslik",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AitOlduguBaslikBaslikId",
                table: "AltBaslik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hucre_AitOlduguAlanAlanId",
                table: "Hucre",
                column: "AitOlduguAlanAlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ElemanModeli_AitOlduguElemanElemanId",
                table: "ElemanModeli",
                column: "AitOlduguElemanElemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Eleman_AitOlduguAltBaslikAltBaslikId",
                table: "Eleman",
                column: "AitOlduguAltBaslikAltBaslikId");

            migrationBuilder.CreateIndex(
                name: "IX_Baslik_KategoriClassKategoriId",
                table: "Baslik",
                column: "KategoriClassKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_AltBaslik_AitOlduguBaslikBaslikId",
                table: "AltBaslik",
                column: "AitOlduguBaslikBaslikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alan_ElemanModeli_AitOlduguElemanModeliElemanModeliId",
                table: "Alan",
                column: "AitOlduguElemanModeliElemanModeliId",
                principalTable: "ElemanModeli",
                principalColumn: "ElemanModeliId");

            migrationBuilder.AddForeignKey(
                name: "FK_AltBaslik_Baslik_AitOlduguBaslikBaslikId",
                table: "AltBaslik",
                column: "AitOlduguBaslikBaslikId",
                principalTable: "Baslik",
                principalColumn: "BaslikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baslik_Kategori_KategoriClassKategoriId",
                table: "Baslik",
                column: "KategoriClassKategoriId",
                principalTable: "Kategori",
                principalColumn: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eleman_AltBaslik_AitOlduguAltBaslikAltBaslikId",
                table: "Eleman",
                column: "AitOlduguAltBaslikAltBaslikId",
                principalTable: "AltBaslik",
                principalColumn: "AltBaslikId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElemanModeli_Eleman_AitOlduguElemanElemanId",
                table: "ElemanModeli",
                column: "AitOlduguElemanElemanId",
                principalTable: "Eleman",
                principalColumn: "ElemanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hucre_Alan_AitOlduguAlanAlanId",
                table: "Hucre",
                column: "AitOlduguAlanAlanId",
                principalTable: "Alan",
                principalColumn: "AlanId");
        }
    }
}
