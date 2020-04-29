namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Five : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Code = c.String(maxLength: 10),
                        Name = c.String(maxLength: 200),
                        GroupGuid = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Description = c.String(),
                        Abad = c.String(maxLength: 30),
                        Kind = c.String(maxLength: 100),
                        Color = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.ProductPictures",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Path = c.String(maxLength: 400),
                        PrdGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductPictures");
            DropTable("dbo.Products");
        }
    }
}
