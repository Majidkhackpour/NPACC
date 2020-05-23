namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Sixteen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrdComments",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        PrdGuid = c.Guid(nullable: false),
                        Name = c.String(maxLength: 150),
                        Email = c.String(maxLength: 150),
                        WebSite = c.String(maxLength: 200),
                        ParentGuid = c.Guid(nullable: false),
                        Comment = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PrdComments");
        }
    }
}
