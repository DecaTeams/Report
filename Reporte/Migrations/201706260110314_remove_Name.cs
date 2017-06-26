namespace Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_Name : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "FullName", c => c.String());
        }
    }
}
