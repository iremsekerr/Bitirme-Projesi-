using Microsoft.EntityFrameworkCore.Migrations;

namespace bitirmeSonProje.Migrations
{
    public partial class ver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DersProgramis",
                columns: table => new
                {
                    Gun = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DersSaati = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DersKod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnKosul = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersProgramis", x => x.Gun);
                });

            migrationBuilder.CreateTable(
                name: "DuyuruTurus",
                columns: table => new
                {
                    DuyuruId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuyuruTurus", x => x.DuyuruId);
                });

            migrationBuilder.CreateTable(
                name: "Kisis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    SeciliKisiId = table.Column<int>(type: "int", nullable: false),
                    ResimYolu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TamAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    OnayliMi = table.Column<bool>(type: "bit", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    TipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfisSaatis",
                columns: table => new
                {
                    MusaitlikDurumu = table.Column<bool>(type: "bit", nullable: false),
                    OfisSaatiGun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfisSaatiBaslangic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfisSaatiBitis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfisSaatis", x => x.MusaitlikDurumu);
                });

            migrationBuilder.CreateTable(
                name: "SiteAyarlars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecilenKisiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteAyarlars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duyurus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuyuruAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuyuruTur = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duyurus_DuyuruTurus_DuyuruTur",
                        column: x => x.DuyuruTur,
                        principalTable: "DuyuruTurus",
                        principalColumn: "DuyuruId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duyurus_DuyuruTur",
                table: "Duyurus",
                column: "DuyuruTur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersProgramis");

            migrationBuilder.DropTable(
                name: "Duyurus");

            migrationBuilder.DropTable(
                name: "Kisis");

            migrationBuilder.DropTable(
                name: "Kullanicis");

            migrationBuilder.DropTable(
                name: "OfisSaatis");

            migrationBuilder.DropTable(
                name: "SiteAyarlars");

            migrationBuilder.DropTable(
                name: "DuyuruTurus");
        }
    }
}
