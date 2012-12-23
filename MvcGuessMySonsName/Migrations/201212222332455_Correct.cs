namespace MvcGuessMySonsName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guesses", "Correct", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guesses", "Correct");
        }
    }
}
