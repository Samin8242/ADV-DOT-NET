namespace EFCodeFirstE2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKPKODPORDER : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "PId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "OId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "PId");
            CreateIndex("dbo.OrderDetails", "OId");
            AddForeignKey("dbo.OrderDetails", "OId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "PId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "PId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OId" });
            DropIndex("dbo.OrderDetails", new[] { "PId" });
            DropColumn("dbo.OrderDetails", "OId");
            DropColumn("dbo.OrderDetails", "PId");
        }
    }
}
