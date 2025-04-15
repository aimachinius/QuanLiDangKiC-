namespace QuanLiDangKiC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuaNgaySinhThanhDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HocViens", "NgaySinh", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HocViens", "NgaySinh", c => c.DateTime(nullable: false));
        }
    }
}
