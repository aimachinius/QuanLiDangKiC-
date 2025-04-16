namespace QuanLiDangKiC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chang : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "MaHocVien", "dbo.HocViens");
            DropIndex("dbo.Users", new[] { "MaHocVien" });
            DropTable("dbo.Users");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.TenDangNhap);
            
            CreateIndex("dbo.Users", "MaHocVien");
            AddForeignKey("dbo.Users", "MaHocVien", "dbo.HocViens", "MaHocVien");
        }
    }
}
