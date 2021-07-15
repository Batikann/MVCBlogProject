namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admintableaddcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Admins", "IsEmailVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "ActivationCode", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "ActivationCode");
            DropColumn("dbo.Admins", "IsEmailVerified");
            DropColumn("dbo.Admins", "DateOfBirth");
        }
    }
}
