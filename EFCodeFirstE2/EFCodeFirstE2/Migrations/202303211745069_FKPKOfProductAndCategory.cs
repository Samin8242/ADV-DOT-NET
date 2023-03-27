namespace EFCodeFirstE2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKPKOfProductAndCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Cid", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Cid");
            AddForeignKey("dbo.Products", "Cid", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cid", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Cid" });
            DropColumn("dbo.Products", "Cid");
        }
    }
}
