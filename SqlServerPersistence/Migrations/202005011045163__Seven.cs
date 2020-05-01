namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Seven : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatNumbers",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        FromNumber = c.Long(nullable: false),
                        Number = c.String(maxLength: 20),
                        City = c.String(maxLength: 50),
                        Category = c.String(maxLength: 100),
                        IsSendChat = c.Boolean(nullable: false),
                        IsSendSMS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.DivarCategories",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 150),
                        ParentGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Simcards",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Number = c.Long(nullable: false),
                        OwnerName = c.String(maxLength: 100),
                        DivarToken = c.String(),
                        ChatToken = c.String(),
                        ChatCat1 = c.Guid(),
                        ChatCat2 = c.Guid(),
                        ChatCat3 = c.Guid(),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Simcards");
            DropTable("dbo.DivarCategories");
            DropTable("dbo.ChatNumbers");
        }
    }
}
