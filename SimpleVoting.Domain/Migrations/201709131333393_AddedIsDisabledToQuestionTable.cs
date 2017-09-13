namespace SimpleVoting.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDisabledToQuestionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "IsDisabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "IsDisabled");
        }
    }
}
