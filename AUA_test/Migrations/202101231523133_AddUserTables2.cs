namespace AUA_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTables2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginDetails");
        }
    }
}
