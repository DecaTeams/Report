namespace Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Managers", "TotalSalary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Managers", "TotalSalary", c => c.Decimal(precision: 18, scale: 2, storeType: "numeric"));
        }
    }
}
