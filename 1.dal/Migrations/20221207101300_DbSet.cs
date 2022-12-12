using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.dal.Migrations
{
    public partial class DbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    idCv = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tenDem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngSinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gioiTinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    sdt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    diaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    thanhPho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    quocGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    trangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.id);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_idCv",
                        column: x => x.idCv,
                        principalTable: "ChucVu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idLsp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    giaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.id);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSanPham_idLsp",
                        column: x => x.idLsp,
                        principalTable: "LoaiSanPham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idNv = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tinhTrang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.id);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_idNv",
                        column: x => x.idNv,
                        principalTable: "NhanVien",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idHd = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    thanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiet", x => x.id);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_HoaDon_idHd",
                        column: x => x.idHd,
                        principalTable: "HoaDon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_SanPham_idSp",
                        column: x => x.idSp,
                        principalTable: "SanPham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_idNv",
                table: "HoaDon",
                column: "idNv");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_idHd",
                table: "HoaDonChiTiet",
                column: "idHd");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_idSp",
                table: "HoaDonChiTiet",
                column: "idSp");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_idCv",
                table: "NhanVien",
                column: "idCv");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_idLsp",
                table: "SanPham",
                column: "idLsp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");

            migrationBuilder.DropTable(
                name: "ChucVu");
        }
    }
}
