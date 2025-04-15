namespace QuanLiDangKiC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DangKyKhoaHocs",
                c => new
                    {
                        MaDangKy = c.Int(nullable: false, identity: true),
                        MaHocVien = c.Int(nullable: false),
                        MaKhoaHoc = c.Int(nullable: false),
                        NgayDangKy = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaDangKy)
                .ForeignKey("dbo.HocViens", t => t.MaHocVien, cascadeDelete: true)
                .ForeignKey("dbo.KhoaHocs", t => t.MaKhoaHoc, cascadeDelete: true)
                .Index(t => t.MaHocVien)
                .Index(t => t.MaKhoaHoc);
            
            CreateTable(
                "dbo.HocViens",
                c => new
                    {
                        MaHocVien = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 100),
                        NgaySinh = c.DateTime(nullable: false),
                        SoDienThoai = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        TaiKhoan = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MaHocVien);
            
            CreateTable(
                "dbo.KhoaHocs",
                c => new
                    {
                        MaKhoaHoc = c.Int(nullable: false, identity: true),
                        TenKhoaHoc = c.String(nullable: false, maxLength: 100),
                        GiangVien = c.String(nullable: false, maxLength: 100),
                        ThoiGianKhaiGiang = c.DateTime(nullable: false),
                        HocPhi = c.Double(nullable: false),
                        SoLuongHocVienToiDa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhoaHoc);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DangKyKhoaHocs", "MaKhoaHoc", "dbo.KhoaHocs");
            DropForeignKey("dbo.DangKyKhoaHocs", "MaHocVien", "dbo.HocViens");
            DropIndex("dbo.DangKyKhoaHocs", new[] { "MaKhoaHoc" });
            DropIndex("dbo.DangKyKhoaHocs", new[] { "MaHocVien" });
            DropTable("dbo.KhoaHocs");
            DropTable("dbo.HocViens");
            DropTable("dbo.DangKyKhoaHocs");
        }
    }
}
