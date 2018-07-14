namespace WorldCup.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'801a3c31-dd9b-45d4-9761-1c0e63b34e9c', N'adminemail@worldcup.com', 0, N'APySU1RCqR4PvKvfEMVXFDjaIWj+QnBlX5EqFp4gnlfeMzVKev3nwNbW32scUde2qA==', N'cb4fd650-e223-4a3a-92bc-148622569ab4', NULL, 0, 0, NULL, 1, 0, N'adminemail@worldcup.com');
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Administrator');
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'User');
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'801a3c31-dd9b-45d4-9761-1c0e63b34e9c', N'1');
");

        }

        public override void Down()
        {
        }
    }
}
