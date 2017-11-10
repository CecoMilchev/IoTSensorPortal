namespace IoTSensorPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SensorFixed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.History", newName: "Histories");
            RenameTable(name: "dbo.ApplicationUserSensors", newName: "RegisteredUserSensors");
            RenameColumn(table: "dbo.RegisteredUserSensors", name: "ApplicationUser_Id", newName: "RegisteredUser_Id");
            RenameIndex(table: "dbo.RegisteredUserSensors", name: "IX_ApplicationUser_Id", newName: "IX_RegisteredUser_Id");
            AddColumn("dbo.Sensors", "RefreshRate", c => c.Int(nullable: false));
            AddColumn("dbo.Sensors", "MinValue", c => c.Int(nullable: false));
            AddColumn("dbo.Sensors", "MaxValue", c => c.Int(nullable: false));
            DropColumn("dbo.Sensors", "Description");
            DropColumn("dbo.Sensors", "Tag");
            DropColumn("dbo.Sensors", "MeasureType");
            DropColumn("dbo.Sensors", "MinPollingIntervalInSeconds");
            DropColumn("dbo.Sensors", "CurrentValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sensors", "CurrentValue", c => c.String());
            AddColumn("dbo.Sensors", "MinPollingIntervalInSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Sensors", "MeasureType", c => c.String());
            AddColumn("dbo.Sensors", "Tag", c => c.String());
            AddColumn("dbo.Sensors", "Description", c => c.String());
            DropColumn("dbo.Sensors", "MaxValue");
            DropColumn("dbo.Sensors", "MinValue");
            DropColumn("dbo.Sensors", "RefreshRate");
            RenameIndex(table: "dbo.RegisteredUserSensors", name: "IX_RegisteredUser_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.RegisteredUserSensors", name: "RegisteredUser_Id", newName: "ApplicationUser_Id");
            RenameTable(name: "dbo.RegisteredUserSensors", newName: "ApplicationUserSensors");
            RenameTable(name: "dbo.Histories", newName: "History");
        }
    }
}
