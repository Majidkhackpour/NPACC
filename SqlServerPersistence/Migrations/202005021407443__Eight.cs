namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Eight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Simcards", "AdvCat1", c => c.Guid());
            AddColumn("dbo.Simcards", "AdvCat2", c => c.Guid());
            AddColumn("dbo.Simcards", "AdvCat3", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Simcards", "AdvCat3");
            DropColumn("dbo.Simcards", "AdvCat2");
            DropColumn("dbo.Simcards", "AdvCat1");
        }
    }
}
