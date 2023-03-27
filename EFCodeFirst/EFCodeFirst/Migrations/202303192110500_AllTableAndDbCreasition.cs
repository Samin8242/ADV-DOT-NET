namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTableAndDbCreasition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qty = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        PId = c.Int(nullable: false),
                        OId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.PId, cascadeDelete: true)
                .Index(t => t.PId)
                .Index(t => t.OId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Username);
            
            AddColumn("dbo.Orders", "OrderByUserId", c => c.String(maxLength: 10));
            AddColumn("dbo.Products", "Cid", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Price", c => c.Int());
            CreateIndex("dbo.Products", "Cid");
            CreateIndex("dbo.Orders", "OrderByUserId");
            AddForeignKey("dbo.Products", "Cid", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "OrderByUserId", "dbo.Users", "Username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "PId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "OrderByUserId", "dbo.Users");
            DropForeignKey("dbo.Products", "Cid", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "OrderByUserId" });
            DropIndex("dbo.OrderDetails", new[] { "OId" });
            DropIndex("dbo.OrderDetails", new[] { "PId" });
            DropIndex("dbo.Products", new[] { "Cid" });
            AlterColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "Cid");
            DropColumn("dbo.Orders", "OrderByUserId");
            DropTable("dbo.Users");
            DropTable("dbo.OrderDetails");
        }
    }
}
