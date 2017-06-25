namespace Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreinKey_gender : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.People", name: "Gender_Id", newName: "GenderId");
            RenameIndex(table: "dbo.People", name: "IX_Gender_Id", newName: "IX_GenderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.People", name: "IX_GenderId", newName: "IX_Gender_Id");
            RenameColumn(table: "dbo.People", name: "GenderId", newName: "Gender_Id");
        }
    }
}
