namespace GreyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Passes", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.Passes", "BlankId", "dbo.Blanks");
            DropForeignKey("dbo.Answers", new[] { "Pass_AuthorID", "Pass_BlankId" }, "dbo.Passes");
            DropIndex("dbo.Answers", new[] { "Pass_AuthorID", "Pass_BlankId" });
            DropIndex("dbo.Passes", new[] { "AuthorID" });
            DropIndex("dbo.Passes", new[] { "BlankId" });
            DropColumn("dbo.Answers", "PassId");
            DropColumn("dbo.Answers", "Pass_AuthorID");
            DropColumn("dbo.Answers", "Pass_BlankId");
            AddColumn("dbo.Answers", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "BlankId", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "AuthorId");
            CreateIndex("dbo.Answers", "BlankId");
            //AddForeignKey("dbo.Answers", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Answers", "BlankId", "dbo.Blanks", "Id", cascadeDelete: true);
            DropTable("dbo.Passes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Passes",
                c => new
                    {
                        AuthorID = c.Int(nullable: false),
                        BlankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorID, t.BlankId });
            
            AddColumn("dbo.Answers", "Pass_BlankId", c => c.Int());
            AddColumn("dbo.Answers", "Pass_AuthorID", c => c.Int());
            AddColumn("dbo.Answers", "PassId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Answers", "BlankId", "dbo.Blanks");
            DropForeignKey("dbo.Answers", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Answers", new[] { "BlankId" });
            DropIndex("dbo.Answers", new[] { "AuthorId" });
            DropColumn("dbo.Answers", "BlankId");
            DropColumn("dbo.Answers", "AuthorId");
            CreateIndex("dbo.Passes", "BlankId");
            CreateIndex("dbo.Passes", "AuthorID");
            CreateIndex("dbo.Answers", new[] { "Pass_AuthorID", "Pass_BlankId" });
            AddForeignKey("dbo.Answers", new[] { "Pass_AuthorID", "Pass_BlankId" }, "dbo.Passes", new[] { "AuthorID", "BlankId" });
            AddForeignKey("dbo.Passes", "BlankId", "dbo.Blanks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Passes", "AuthorID", "dbo.Authors", "Id", cascadeDelete: true);
        }
    }
}
