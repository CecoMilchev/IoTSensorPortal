namespace IoTSensorPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registerSensor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "CurrentValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sensors", "CurrentValue");
        }
    }
}
