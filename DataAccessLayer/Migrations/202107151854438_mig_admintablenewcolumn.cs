namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admintablenewcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "ResetPasswordCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "ResetPasswordCode");
        }
    }
}
