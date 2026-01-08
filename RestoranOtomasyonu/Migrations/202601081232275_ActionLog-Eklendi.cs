namespace RestoranOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActionLogEklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionLogs",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        PersonelName = c.String(),
                        ActionType = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ActionLogs");
        }
    }
}
