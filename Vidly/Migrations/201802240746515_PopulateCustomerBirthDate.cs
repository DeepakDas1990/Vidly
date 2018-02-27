namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCustomerBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '1955-08-21' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
