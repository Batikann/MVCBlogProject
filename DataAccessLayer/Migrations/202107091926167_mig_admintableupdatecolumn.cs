namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admintableupdatecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminTitle", c => c.String());
            AddColumn("dbo.Admins", "AdminPhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminPhoneNumber");
            DropColumn("dbo.Admins", "AdminTitle");
        }
    }
}
