namespace FilmCatalog.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class NewInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ParentCategoryId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.FilmCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FilmId, t.CategoryId }, unique: true, name: "IX_FilmCategory");
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Director = c.String(nullable: false, maxLength: 200),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropIndex("dbo.FilmCategories", "IX_FilmCategory");
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            DropTable("dbo.Films");
            DropTable("dbo.FilmCategories");
            DropTable("dbo.Categories");
        }
    }
}
