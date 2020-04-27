namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Three : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "GroupGuid", c => c.Guid(nullable: false));
            AlterColumn("dbo.Customers", "NahveAshnaei", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "NahveAshnaei", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "GroupGuid");
        }
    }
}
