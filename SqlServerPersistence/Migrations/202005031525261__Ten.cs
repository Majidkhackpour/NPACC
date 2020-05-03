namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Ten : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "HalfCode", c => c.String(maxLength: 3));
            DropColumn("dbo.ProductGroups", "HalfCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductGroups", "HalfCode", c => c.String(maxLength: 3));
            DropColumn("dbo.Products", "HalfCode");
        }
    }
}
