namespace FilmCatalog.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Def : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            AlterColumn("dbo.Categories", "ParentCategoryId", c => c.Int(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: "1", newValue: null)
                    },
                }));
            CreateIndex("dbo.Categories", "ParentCategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            AlterColumn("dbo.Categories", "ParentCategoryId", c => c.Int(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "1")
                    },
                }));
            CreateIndex("dbo.Categories", "ParentCategoryId");
        }
    }
}
