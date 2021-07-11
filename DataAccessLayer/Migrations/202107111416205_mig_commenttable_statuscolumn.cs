﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_commenttable_statuscolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentStatus");
        }
    }
}
