namespace MescytIntegration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _base : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.String(),
                        FirstName = c.String(),
                        FirstLastName = c.String(),
                        SecondLastName = c.String(),
                        Gender = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Genmunicipality = c.String(),
                        CountryOfBirth = c.String(),
                        CountryBeforeStartStudying = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NewStudentsFats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CarreerID = c.Int(nullable: false),
                        UniversityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Carreers", t => t.CarreerID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Universities", t => t.UniversityID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CarreerID)
                .Index(t => t.UniversityID);
            
            CreateTable(
                "dbo.Carreers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Modality = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        acronym = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewStudentsFats", "UniversityID", "dbo.Universities");
            DropForeignKey("dbo.NewStudentsFats", "StudentID", "dbo.Students");
            DropForeignKey("dbo.NewStudentsFats", "CarreerID", "dbo.Carreers");
            DropIndex("dbo.NewStudentsFats", new[] { "UniversityID" });
            DropIndex("dbo.NewStudentsFats", new[] { "CarreerID" });
            DropIndex("dbo.NewStudentsFats", new[] { "StudentID" });
            DropTable("dbo.Universities");
            DropTable("dbo.Carreers");
            DropTable("dbo.NewStudentsFats");
            DropTable("dbo.Students");
        }
    }
}
