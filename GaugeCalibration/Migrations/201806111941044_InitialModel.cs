namespace GaugeCalibration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GaugeId = c.Int(nullable: false),
                        Date = c.DateTime(),
                        Name = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gauges", t => t.GaugeId, cascadeDelete: true)
                .Index(t => t.Id, unique: true)
                .Index(t => t.GaugeId);
            
            CreateTable(
                "dbo.Gauges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Serial = c.String(),
                        Plant = c.String(maxLength: 3),
                        Type = c.String(),
                        Manufacturer = c.String(),
                        Range = c.String(),
                        Frequency = c.String(),
                        LastCal = c.DateTime(),
                        NextCal = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "GaugeId", "dbo.Gauges");
            DropIndex("dbo.Gauges", new[] { "Id" });
            DropIndex("dbo.Comments", new[] { "GaugeId" });
            DropIndex("dbo.Comments", new[] { "Id" });
            DropTable("dbo.Gauges");
            DropTable("dbo.Comments");
        }
    }
}
