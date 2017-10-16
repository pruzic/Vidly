namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[Email]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEndDateUtc]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[UserName])
     VALUES
           (N'46962e15-908e-47b4-bcfa-e25065db80b3'
            ,N'guest@vidly.com'
            ,0
            ,N'AHGd2XpCp/hwhbxtbQ/sBjYGlEjJ42R5hC73qsAX2WMSjxPefeCdgwh7xGzd1gsuKg=='
		    ,N'f658e202-70ce-4756-be76-384c8544d3dc'
            ,NULL
			,0
			,0
			,NULL
			,1
			,0
			,N'guest@vidly.com')

            INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[Email]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEndDateUtc]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[UserName])
     VALUES
           (N'd53e20f6-a700-404c-b157-a7963501ff7f'
		   ,N'admin@vidly.com'
		   ,0
		   ,N'AKxlpWtI375JJl0aB96S0KPlFDITsNg/MaZVOhLICqYkoCEmHMcp6yX7Z26MY6bDdg=='
		   ,N'6133985d-d2c4-4d06-a992-f6ef549fc1f6'
		   ,NULL
		   ,0
		   ,0
		   ,NULL
		   ,1
		   ,0
		   ,N'admin@vidly.com')

        INSERT INTO [dbo].[AspNetRoles]([Id],[Name])
        VALUES (N'60e77d7b-9e9f-4e09-bc93-5cd2c1bbac96','CanManageMovies')

        INSERT INTO [dbo].[AspNetUserRoles] ([UserId],[RoleId])
        VALUES (N'd53e20f6-a700-404c-b157-a7963501ff7f','60e77d7b-9e9f-4e09-bc93-5cd2c1bbac96')");
        }
        
        public override void Down()
        {
        }
    }
}
