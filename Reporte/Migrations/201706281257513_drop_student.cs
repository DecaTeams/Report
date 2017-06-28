namespace Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop_student : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Id", "dbo.People");
            DropIndex("dbo.Students", new[] { "Id" });
            AlterColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"));
            AlterColumn("dbo.Managers", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"));
            DropTable("dbo.Students");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Managers", "Salary", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Salary", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Id");
            AddForeignKey("dbo.Students", "Id", "dbo.People", "Id");
        }
    }
}
