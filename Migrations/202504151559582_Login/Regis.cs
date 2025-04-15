namespace QuanLiDangKiC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginRegis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false),
                        VaiTro = c.Boolean(nullable: false),
                        MaHocVien = c.Int(),
                    })
                .PrimaryKey(t => t.TenDangNhap)
                .ForeignKey("dbo.HocViens", t => t.MaHocVien)
                .Index(t => t.MaHocVien);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "MaHocVien", "dbo.HocViens");
            DropIndex("dbo.Users", new[] { "MaHocVien" });
            DropTable("dbo.Users");
        }
    }
}
