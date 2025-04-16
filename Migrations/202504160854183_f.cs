namespace QuanLiDangKiC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        TK = c.String(nullable: false, maxLength: 128),
                        MK = c.String(nullable: false),
                        Role = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TK);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
