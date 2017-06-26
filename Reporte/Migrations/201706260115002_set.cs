namespace Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class set : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Employees", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DepartmentId");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "Id", "dbo.Employees");
            DropForeignKey("dbo.Departments", "Id", "dbo.Managers");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Managers", new[] { "Id" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "Id" });
            DropColumn("dbo.Employees", "DepartmentId");
            DropTable("dbo.Managers");
            DropTable("dbo.Departments");
        }
    }
}
