namespace Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Departments_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Departments_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Departments_Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        IsMarreid = c.Boolean(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id, cascadeDelete: true)
                .Index(t => t.Gender_Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Id", "dbo.People");
            DropForeignKey("dbo.People", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Employees", "Id", "dbo.People");
            DropForeignKey("dbo.Managers", "Id", "dbo.Employees");
            DropForeignKey("dbo.Departments", "Id", "dbo.Managers");
            DropForeignKey("dbo.Employees", "Departments_Id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.People", new[] { "Gender_Id" });
            DropIndex("dbo.Managers", new[] { "Id" });
            DropIndex("dbo.Employees", new[] { "Departments_Id" });
            DropIndex("dbo.Employees", new[] { "Id" });
            DropIndex("dbo.Departments", new[] { "Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Genders");
            DropTable("dbo.People");
            DropTable("dbo.Managers");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
