namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addblogpreread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogPreRead", c => c.String());
            DropColumn("dbo.Blogs", "BlogPreReading");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogPreReading", c => c.String());
            DropColumn("dbo.Blogs", "BlogPreRead");
        }
    }
}
