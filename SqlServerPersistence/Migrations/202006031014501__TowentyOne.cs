namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _TowentyOne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visits", "Date", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visits", "Date", c => c.DateTime(nullable: false));
        }
    }
}
