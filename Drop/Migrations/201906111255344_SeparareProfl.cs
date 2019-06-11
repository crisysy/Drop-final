namespace Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeparareProfl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiluri",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdUtilizator = c.String(maxLength: 128),
                        Nume = c.String(),
                        Prenume = c.String(),
                        Oras = c.String(),
                        Sex = c.Int(),
                        Greutate = c.Int(),
                        Inaltime = c.Int(),
                        GrupaSanguina = c.Int(),
                        Rh = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUtilizator)
                .Index(t => t.IdUtilizator);
            
            DropColumn("dbo.AspNetUsers", "Nume");
            DropColumn("dbo.AspNetUsers", "Prenume");
            DropColumn("dbo.AspNetUsers", "Oras");
            DropColumn("dbo.AspNetUsers", "Sex");
            DropColumn("dbo.AspNetUsers", "Greutate");
            DropColumn("dbo.AspNetUsers", "Inaltime");
            DropColumn("dbo.AspNetUsers", "GrupaSanguina");
            DropColumn("dbo.AspNetUsers", "Rh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Rh", c => c.Int());
            AddColumn("dbo.AspNetUsers", "GrupaSanguina", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Inaltime", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Greutate", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Sex", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Oras", c => c.String());
            AddColumn("dbo.AspNetUsers", "Prenume", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nume", c => c.String());
            DropForeignKey("dbo.Profiluri", "IdUtilizator", "dbo.AspNetUsers");
            DropIndex("dbo.Profiluri", new[] { "IdUtilizator" });
            DropTable("dbo.Profiluri");
        }
    }
}
