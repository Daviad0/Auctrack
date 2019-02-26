namespace DemoAuctrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemGroup",
                c => new
                    {
                        GroupID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        MainDonator = c.String(),
                        ForAllOfThose = c.String(),
                        Items_ItemID = c.Int(),
                    })
                .PrimaryKey(t => t.GroupID)
                .ForeignKey("dbo.Item", t => t.Items_ItemID)
                .Index(t => t.Items_ItemID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        ItemName = c.String(),
                        Description = c.String(),
                        Value = c.String(),
                        Current = c.String(),
                        Winner = c.String(),
                        Donator = c.String(),
                        TimeFrame = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemGroup", "Items_ItemID", "dbo.Item");
            DropIndex("dbo.ItemGroup", new[] { "Items_ItemID" });
            DropTable("dbo.Item");
            DropTable("dbo.ItemGroup");
        }
    }
}
