namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Thirteen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrdSelectedGroups",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        PrdGuid = c.Guid(nullable: false),
                        GroupGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.PrdTags",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        PrdGuid = c.Guid(nullable: false),
                        Tag = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Guid);
            
            AddColumn("dbo.Products", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "ImageName", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "ShortDesc", c => c.String(maxLength: 350));
            AddColumn("dbo.ProductPictures", "ImageName", c => c.String(maxLength: 50));
            DropColumn("dbo.Products", "HalfCode");
            DropColumn("dbo.Products", "GroupGuid");
            DropColumn("dbo.ProductPictures", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductPictures", "Path", c => c.String(maxLength: 400));
            AddColumn("dbo.Products", "GroupGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "HalfCode", c => c.String(maxLength: 3));
            DropColumn("dbo.ProductPictures", "ImageName");
            DropColumn("dbo.Products", "ShortDesc");
            DropColumn("dbo.Products", "ImageName");
            DropColumn("dbo.Products", "CreateDate");
            DropTable("dbo.PrdTags");
            DropTable("dbo.PrdSelectedGroups");
        }
    }
}
