namespace IoTSensorPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Secondmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserSensors",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Sensor_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Sensor_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: false)
                .ForeignKey("dbo.Sensors", t => t.Sensor_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Sensor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserSensors", "Sensor_Id", "dbo.Sensors");
            DropForeignKey("dbo.ApplicationUserSensors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserSensors", new[] { "Sensor_Id" });
            DropIndex("dbo.ApplicationUserSensors", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserSensors");
        }
    }
}
