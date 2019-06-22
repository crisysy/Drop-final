namespace Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_cereri : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cereri",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Centru = c.String(nullable: false),
                        DonatiiNecesare = c.Int(nullable: false),
                        Contributii = c.Int(nullable: false),
                        GrupaSanguinaNecesara = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cereri");
        }
    }
}
