namespace Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_PerioadeAsteptare : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PerioadeAsteptare",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdUtilizator = c.String(maxLength: 128),
                        TipDonatie = c.Int(nullable: false),
                        Interval = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUtilizator)
                .Index(t => t.IdUtilizator);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PerioadeAsteptare", "IdUtilizator", "dbo.AspNetUsers");
            DropIndex("dbo.PerioadeAsteptare", new[] { "IdUtilizator" });
            DropTable("dbo.PerioadeAsteptare");
        }
    }
}
