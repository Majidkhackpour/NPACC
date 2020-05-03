namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Nine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductGroups", "HalfCode", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductGroups", "HalfCode");
        }
    }
}
