namespace MeeSoftetchWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppliedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CareersRegistrations", "AppliedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CareersRegistrations", "AppliedDate");
        }
    }
}
