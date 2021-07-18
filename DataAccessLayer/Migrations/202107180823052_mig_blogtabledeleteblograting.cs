namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_blogtabledeleteblograting : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "BlogRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogRating", c => c.String());
        }
    }
}
