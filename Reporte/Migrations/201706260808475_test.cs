namespace Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "Id", "dbo.Managers");
            DropIndex("dbo.Managers", new[] { "Id" });
            DropPrimaryKey("dbo.Managers");
            AlterColumn("dbo.Managers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Managers", "Id");
            CreateIndex("dbo.Managers", "Id");
            AddForeignKey("dbo.Departments", "Id", "dbo.Managers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "Id", "dbo.Managers");
            DropIndex("dbo.Managers", new[] { "Id" });
            DropPrimaryKey("dbo.Managers");
            AlterColumn("dbo.Managers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Managers", "Id");
            CreateIndex("dbo.Managers", "Id");
            AddForeignKey("dbo.Departments", "Id", "dbo.Managers", "Id");
        }
    }
}
