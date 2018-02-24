namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsLetter, MembershipTypeId) VALUES ('Bijaya Das',1,1)");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsLetter, MembershipTypeId) VALUES ('Pravakar Das',0,3)");
        }
        
        public override void Down()
        {
        }
    }
}
