namespace Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.People", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.People", "FName");
            DropColumn("dbo.People", "LName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "LName", c => c.String(nullable: false));
            AddColumn("dbo.People", "FName", c => c.String(nullable: false));
            DropColumn("dbo.People", "LastName");
            DropColumn("dbo.People", "FirstName");
        }
    }
}
