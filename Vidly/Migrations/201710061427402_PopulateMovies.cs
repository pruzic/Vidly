namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MOVIES(Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) Values('Hangover', '01/10/1966', '09/10/2017', 10, 2)");
            Sql("INSERT INTO MOVIES(Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) Values('Die Hard', '01/10/1995', '08/05/2017', 15, 3)");
            Sql("INSERT INTO MOVIES(Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) Values('The Terminator', '01/10/2001', '07/25/2016', 22, 3)");
            Sql("INSERT INTO MOVIES(Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) Values('Toy Story', '01/10/2010', '05/25/2017', 10, 4)");
            Sql("INSERT INTO MOVIES(Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) Values('Titanic', '01/10/2013', '9/25/2017', 25, 5)");
        }
        
        public override void Down()
        {
        }
    }
}
