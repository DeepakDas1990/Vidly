namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id,Name) VALUES (1,'Western')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (2,'Thriller')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (3,'Romance')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (4,'Sci-Fi')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (5,'Comedy')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (6,'Action')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (7,'Animation')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (8,'Family')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (9,'Adventure')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (10,'Drama')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (11,'Horror')");

        }
        
        public override void Down()
        {
        }
    }
}
