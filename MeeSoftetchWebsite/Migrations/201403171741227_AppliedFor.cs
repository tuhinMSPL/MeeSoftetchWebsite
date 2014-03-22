namespace MeeSoftetchWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppliedFor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CareersRegistrations", "AppliedFor", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CareersRegistrations", "AppliedFor");
        }
    }
}
