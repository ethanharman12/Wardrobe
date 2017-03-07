namespace Wardrobe.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        BrandId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        ArticleTypeId = c.Int(nullable: false),
                        Size = c.String(),
                        PrimaryColor = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleType", t => t.ArticleTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUser", t => t.UserId)
                .Index(t => t.BrandId)
                .Index(t => t.UserId)
                .Index(t => t.ArticleTypeId);
            
            CreateTable(
                "dbo.ArticleType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WashEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Article", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.WearEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Article", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WearEvent", "ArticleId", "dbo.Article");
            DropForeignKey("dbo.WashEvent", "ArticleId", "dbo.Article");
            DropForeignKey("dbo.Article", "UserId", "dbo.AspNetUser");
            DropForeignKey("dbo.Article", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.Article", "ArticleTypeId", "dbo.ArticleType");
            DropIndex("dbo.WearEvent", new[] { "ArticleId" });
            DropIndex("dbo.WashEvent", new[] { "ArticleId" });
            DropIndex("dbo.Article", new[] { "ArticleTypeId" });
            DropIndex("dbo.Article", new[] { "UserId" });
            DropIndex("dbo.Article", new[] { "BrandId" });
            DropTable("dbo.WearEvent");
            DropTable("dbo.WashEvent");
            DropTable("dbo.AspNetUser");
            DropTable("dbo.Brand");
            DropTable("dbo.ArticleType");
            DropTable("dbo.Article");
        }
    }
}
