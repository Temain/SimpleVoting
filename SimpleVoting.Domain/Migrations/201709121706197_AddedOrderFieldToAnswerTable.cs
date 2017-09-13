namespace SimpleVoting.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderFieldToAnswerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answer", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answer", "Order");
        }
    }
}
