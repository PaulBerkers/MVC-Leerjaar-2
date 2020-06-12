namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniDBSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Onderdeels",
                c => new
                    {
                        OnderdeelId = c.Int(nullable: false, identity: true),
                        OnderdeelName = c.String(),
                        OnderdeelQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OnderdeelId);
            
            CreateTable(
                "dbo.Skateboards",
                c => new
                    {
                        SkateboardId = c.Int(nullable: false, identity: true),
                        SkateboardBrand = c.String(),
                        SkateboardWidth = c.String(),
                        SkateboardCurve = c.String(),
                    })
                .PrimaryKey(t => t.SkateboardId);
            
            CreateTable(
                "dbo.SkateboardOnderdeels",
                c => new
                    {
                        Skateboard_SkateboardId = c.Int(nullable: false),
                        Onderdeel_OnderdeelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skateboard_SkateboardId, t.Onderdeel_OnderdeelId })
                .ForeignKey("dbo.Skateboards", t => t.Skateboard_SkateboardId, cascadeDelete: true)
                .ForeignKey("dbo.Onderdeels", t => t.Onderdeel_OnderdeelId, cascadeDelete: true)
                .Index(t => t.Skateboard_SkateboardId)
                .Index(t => t.Onderdeel_OnderdeelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkateboardOnderdeels", "Onderdeel_OnderdeelId", "dbo.Onderdeels");
            DropForeignKey("dbo.SkateboardOnderdeels", "Skateboard_SkateboardId", "dbo.Skateboards");
            DropIndex("dbo.SkateboardOnderdeels", new[] { "Onderdeel_OnderdeelId" });
            DropIndex("dbo.SkateboardOnderdeels", new[] { "Skateboard_SkateboardId" });
            DropTable("dbo.SkateboardOnderdeels");
            DropTable("dbo.Skateboards");
            DropTable("dbo.Onderdeels");
        }
    }
}
