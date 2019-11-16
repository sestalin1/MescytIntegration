namespace MescytIntegration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewStudentsFats", "period", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewStudentsFats", "period");
        }
    }
}
