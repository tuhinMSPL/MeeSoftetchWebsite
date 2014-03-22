namespace MeeSoftetchWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CareersRegistrations",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        SelectedHighestQualification = c.String(nullable: false),
                        ExperienceYear = c.Int(nullable: false),
                        ExperienceMonth = c.Int(nullable: false),
                        KeySkills = c.String(nullable: false),
                        ResumePlainText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CareersRegistrations");
        }
    }
}
