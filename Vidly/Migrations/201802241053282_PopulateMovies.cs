namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('John Wick', 6, '2017-02-17', '2017-03-01', 15)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('Hostiles', 1, '2018-01-19', '2018-02-01', 10)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('Atomic Blonde', 2, '2017-07-28', '2018-08-01', 22)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('Beauty and The Beast', 3, '2017-02-23', '2018-03-01', 8)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('The Lord of The Rings(Part 1)', 9, '2001-12-01', '2003-01-01', 12)");
        }
        
        public override void Down()
        {
        }
    }
}
