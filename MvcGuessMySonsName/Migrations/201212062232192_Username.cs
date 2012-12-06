namespace MvcGuessMySonsName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Username : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guesses", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guesses", "Username");
        }
    }
}
