namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Towelve : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RememberMe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RememberMe");
        }
    }
}
