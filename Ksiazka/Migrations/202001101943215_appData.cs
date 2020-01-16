namespace Ksiazka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppConfigDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskSleepTime = c.Int(nullable: false),
                        EncryptionKey = c.String(),
                        AccessKey = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppConfigDatas");
        }
    }
}
