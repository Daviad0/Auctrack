namespace DemoAuctrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bidder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bidder",
                c => new
                    {
                        BidderNum = c.Int(nullable: false),
                        Name = c.String(),
                        ContactInfo = c.String(),
                    })
                .PrimaryKey(t => t.BidderNum);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bidder");
        }
    }
}
