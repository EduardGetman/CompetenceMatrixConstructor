namespace CompetenceMatrix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requirements", "Position_Id", "dbo.Positions");
            DropIndex("dbo.Knowledges", new[] { "Employee_Id" });
            DropIndex("dbo.Requirements", new[] { "Position_Id" });
            DropColumn("dbo.Knowledges", "Id");
            RenameColumn(table: "dbo.Knowledges", name: "Employee_Id", newName: "Id");
            DropPrimaryKey("dbo.Knowledges");
            AddColumn("dbo.Knowledges", "Competence_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Requirements", "Competence_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Knowledges", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Positions", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Requirements", "Position_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Knowledges", "Id");
            CreateIndex("dbo.Knowledges", "Id");
            CreateIndex("dbo.Knowledges", "Competence_Id");
            CreateIndex("dbo.Requirements", "Competence_Id");
            CreateIndex("dbo.Requirements", "Position_Id");
            AddForeignKey("dbo.Knowledges", "Competence_Id", "dbo.Competences", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requirements", "Competence_Id", "dbo.Competences", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requirements", "Position_Id", "dbo.Positions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requirements", "Position_Id", "dbo.Positions");
            DropForeignKey("dbo.Requirements", "Competence_Id", "dbo.Competences");
            DropForeignKey("dbo.Knowledges", "Competence_Id", "dbo.Competences");
            DropIndex("dbo.Requirements", new[] { "Position_Id" });
            DropIndex("dbo.Requirements", new[] { "Competence_Id" });
            DropIndex("dbo.Knowledges", new[] { "Competence_Id" });
            DropIndex("dbo.Knowledges", new[] { "Id" });
            DropPrimaryKey("dbo.Knowledges");
            AlterColumn("dbo.Requirements", "Position_Id", c => c.Int());
            AlterColumn("dbo.Positions", "Name", c => c.String());
            AlterColumn("dbo.Knowledges", "Id", c => c.Int());
            AlterColumn("dbo.Employees", "FullName", c => c.String());
            DropColumn("dbo.Requirements", "Competence_Id");
            DropColumn("dbo.Knowledges", "Competence_Id");
            AddPrimaryKey("dbo.Knowledges", "Id");
            RenameColumn(table: "dbo.Knowledges", name: "Id", newName: "Employee_Id");
            AddColumn("dbo.Knowledges", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Requirements", "Position_Id");
            CreateIndex("dbo.Knowledges", "Employee_Id");
            AddForeignKey("dbo.Requirements", "Position_Id", "dbo.Positions", "Id");
        }
    }
}
