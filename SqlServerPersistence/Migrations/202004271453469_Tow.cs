namespace SqlServerPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 200),
                        Description = c.String(),
                        Phone1 = c.String(maxLength: 20),
                        Phone2 = c.String(maxLength: 20),
                        Address = c.String(),
                        PostalCode = c.String(maxLength: 20),
                        NationalCode = c.String(maxLength: 20),
                        NahveAshnaei = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
