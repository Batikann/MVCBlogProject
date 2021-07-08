namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_categoryExplanationColumnAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryExplanation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryExplanation");
        }
    }
}
