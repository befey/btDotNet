namespace btDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsItems",
                c => new
                    {
                        NewsItemId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.NewsItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsItems");
        }
    }
}
