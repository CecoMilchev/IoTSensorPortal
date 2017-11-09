namespace IoTSensorPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSensorproperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SensorHistories", "SensorId", "dbo.Sensors");
            DropIndex("dbo.SensorHistories", new[] { "SensorId" });
            RenameColumn(table: "dbo.Sensors", name: "ApplicationUserId", newName: "OwnerId");
            RenameIndex(table: "dbo.Sensors", name: "IX_ApplicationUserId", newName: "IX_OwnerId");
            CreateTable(
                "dbo.History",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SensorId = c.Guid(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sensors", t => t.SensorId, cascadeDelete: true)
                .Index(t => t.SensorId);
            
            AddColumn("dbo.Sensors", "Url", c => c.String());
            AddColumn("dbo.Sensors", "Name", c => c.String());
            AddColumn("dbo.Sensors", "IsPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sensors", "LastUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sensors", "CurrentValue", c => c.String());
            DropTable("dbo.SensorHistories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SensorHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SensorId = c.Guid(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        Value = c.String(nullable: false),
                        ValueType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.History", "SensorId", "dbo.Sensors");
            DropIndex("dbo.History", new[] { "SensorId" });
            DropColumn("dbo.Sensors", "CurrentValue");
            DropColumn("dbo.Sensors", "LastUpdated");
            DropColumn("dbo.Sensors", "IsPublic");
            DropColumn("dbo.Sensors", "Name");
            DropColumn("dbo.Sensors", "Url");
            DropTable("dbo.History");
            RenameIndex(table: "dbo.Sensors", name: "IX_OwnerId", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.Sensors", name: "OwnerId", newName: "ApplicationUserId");
            CreateIndex("dbo.SensorHistories", "SensorId");
            AddForeignKey("dbo.SensorHistories", "SensorId", "dbo.Sensors", "Id", cascadeDelete: true);
        }
    }
}
