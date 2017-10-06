namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres(Name) Values('Comedy')");
            Sql("Insert Into Genres(Name) Values( 'Action')");
            Sql("Insert Into Genres(Name) Values('Family')");
            Sql("Insert Into Genres(Name) Values('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
