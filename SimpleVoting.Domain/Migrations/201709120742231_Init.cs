namespace SimpleVoting.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(nullable: false, maxLength: 200),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        GenderName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.UserAnswer",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.AnswerId })
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Answer", t => t.AnswerId)
                .Index(t => t.UserId)
                .Index(t => t.AnswerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.UserAnswer", "AnswerId", "dbo.Answer");
            DropForeignKey("dbo.UserAnswer", "UserId", "dbo.User");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropIndex("dbo.UserAnswer", new[] { "AnswerId" });
            DropIndex("dbo.UserAnswer", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "GenderId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropTable("dbo.UserAnswer");
            DropTable("dbo.Gender");
            DropTable("dbo.User");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
