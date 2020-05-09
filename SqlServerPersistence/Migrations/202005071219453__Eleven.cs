namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Eleven : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rolles",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        RolleTitle = c.String(maxLength: 150),
                        RolleName = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        RealName = c.String(nullable: false, maxLength: 250),
                        RolleGuid = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 250),
                        ActiveCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Rolles");
        }
    }
}
