namespace Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tesst : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Managers", "Id", "dbo.Departments");
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Departments", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Departments", "Id");
            CreateIndex("dbo.Departments", "Id");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Departments", new[] { "Id" });
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Departments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Departments", "Id");
            AddForeignKey("dbo.Managers", "Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id");
        }
    }
}
