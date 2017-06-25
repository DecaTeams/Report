namespace Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreinKey_Department : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Departments_Id", newName: "DepartmentId");
            RenameIndex(table: "dbo.Employees", name: "IX_Departments_Id", newName: "IX_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Employees", name: "IX_DepartmentId", newName: "IX_Departments_Id");
            RenameColumn(table: "dbo.Employees", name: "DepartmentId", newName: "Departments_Id");
        }
    }
}
