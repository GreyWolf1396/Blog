namespace GreyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passes",
                c => new
                    {
                        AuthorID = c.Int(nullable: false),
                        BlankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorID, t.BlankId })
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Blanks", t => t.BlankId, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.BlankId);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            AddColumn("dbo.Answers", "PassId", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "Pass_AuthorID", c => c.Int());
            AddColumn("dbo.Answers", "Pass_BlankId", c => c.Int());
            AddColumn("dbo.Questions", "BlankId", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", new[] { "Pass_AuthorID", "Pass_BlankId" });
            CreateIndex("dbo.Questions", "BlankId");
            AddForeignKey("dbo.Answers", new[] { "Pass_AuthorID", "Pass_BlankId" }, "dbo.Passes", new[] { "AuthorID", "BlankId" });
            AddForeignKey("dbo.Questions", "BlankId", "dbo.Blanks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Variants", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "BlankId", "dbo.Blanks");
            DropForeignKey("dbo.Answers", new[] { "Pass_AuthorID", "Pass_BlankId" }, "dbo.Passes");
            DropForeignKey("dbo.Passes", "BlankId", "dbo.Blanks");
            DropForeignKey("dbo.Passes", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Variants", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "BlankId" });
            DropIndex("dbo.Passes", new[] { "BlankId" });
            DropIndex("dbo.Passes", new[] { "AuthorID" });
            DropIndex("dbo.Answers", new[] { "Pass_AuthorID", "Pass_BlankId" });
            DropColumn("dbo.Questions", "BlankId");
            DropColumn("dbo.Answers", "Pass_BlankId");
            DropColumn("dbo.Answers", "Pass_AuthorID");
            DropColumn("dbo.Answers", "PassId");
            DropTable("dbo.Variants");
            DropTable("dbo.Passes");
        }
    }
}
