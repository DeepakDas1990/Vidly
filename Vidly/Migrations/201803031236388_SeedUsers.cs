namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3e00bc2d-812d-4a81-a569-0a90ac2f8f90', N'deepak.b@vidly.in', 0, N'AKJz5ywy7HqP+4OPyFtpk3tzTMFr8bddaVQXj9C+vqUeZj5q51GjRfUn2dtdLHkkPQ==', N'c8cb922d-42d8-4d0f-9107-8c5a05cc5845', NULL, 0, 0, NULL, 1, 0, N'deepak.b@vidly.in')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c1591673-13ae-4248-bcf3-b8d3392ae02b', N'admin@vidly.in', 0, N'AJkgx0j/JHRaliDdJkOr3kXSeOMnIG9g8AvXj//YpqpAlH6bViMZF+55RTqLFFtqPQ==', N'ca305e81-0f2c-4d47-b49d-4737038d93d3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.in')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'57853199-da60-41dd-963d-384a888f91ae', N'CanManageMovies')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c1591673-13ae-4248-bcf3-b8d3392ae02b', N'57853199-da60-41dd-963d-384a888f91ae')
                "
                );
        }
        
        public override void Down()
        {
        }
    }
}
