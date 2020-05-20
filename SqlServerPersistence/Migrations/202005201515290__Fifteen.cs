namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Fifteen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Title = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.PrdFeatures",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        PrdGuid = c.Guid(nullable: false),
                        FeatureGuid = c.Guid(nullable: false),
                        Value = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Guid);
            
            DropColumn("dbo.Products", "Abad");
            DropColumn("dbo.Products", "Kind");
            DropColumn("dbo.Products", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Color", c => c.String(maxLength: 100));
            AddColumn("dbo.Products", "Kind", c => c.String(maxLength: 100));
            AddColumn("dbo.Products", "Abad", c => c.String(maxLength: 30));
            DropTable("dbo.PrdFeatures");
            DropTable("dbo.Features");
        }
    }
}
