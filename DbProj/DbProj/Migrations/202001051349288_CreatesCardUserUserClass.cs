namespace DbProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatesCardUserUserClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        ShopName = c.String(),
                        Percent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CardId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        BirthDate = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserCards",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        CardId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CardId })
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCards", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserCards", "CardId", "dbo.Cards");
            DropIndex("dbo.UserCards", new[] { "CardId" });
            DropIndex("dbo.UserCards", new[] { "UserId" });
            DropTable("dbo.UserCards");
            DropTable("dbo.Users");
            DropTable("dbo.Cards");
        }
    }
}
