namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Fourteen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductPictures", "Title", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductPictures", "Title");
        }
    }
}
