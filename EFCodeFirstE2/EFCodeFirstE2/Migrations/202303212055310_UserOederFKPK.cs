namespace EFCodeFirstE2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserOederFKPK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderedById", c => c.String(maxLength: 10));
            CreateIndex("dbo.Orders", "OrderedById");
            AddForeignKey("dbo.Orders", "OrderedById", "dbo.Users", "Username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderedById", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "OrderedById" });
            DropColumn("dbo.Orders", "OrderedById");
        }
    }
}
