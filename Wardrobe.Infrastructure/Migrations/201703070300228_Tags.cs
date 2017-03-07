namespace Wardrobe.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUser", newName: "AspNetUsers");
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        TagTypeId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Article", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.TagType", t => t.TagTypeId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.TagTypeId);
            
            CreateTable(
                "dbo.TagType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tag", "TagTypeId", "dbo.TagType");
            DropForeignKey("dbo.Tag", "ArticleId", "dbo.Article");
            DropIndex("dbo.Tag", new[] { "TagTypeId" });
            DropIndex("dbo.Tag", new[] { "ArticleId" });
            DropTable("dbo.TagType");
            DropTable("dbo.Tag");
            RenameTable(name: "dbo.AspNetUsers", newName: "AspNetUser");
        }
    }
}
