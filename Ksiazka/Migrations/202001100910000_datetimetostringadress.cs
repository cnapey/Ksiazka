namespace Ksiazka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimetostringadress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonalDatas", "DateOfBirth", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalDatas", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
