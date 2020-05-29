namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _NineTeen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "URL", c => c.String(maxLength: 450));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "URL");
        }
    }
}
