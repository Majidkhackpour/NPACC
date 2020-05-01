namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Six : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductGroups", "Code", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductGroups", "Code");
        }
    }
}
