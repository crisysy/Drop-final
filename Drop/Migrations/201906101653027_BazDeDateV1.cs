namespace Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BazDeDateV1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Alimentes", newName: "Alimente");
            CreateTable(
                "dbo.AportAlimentar",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdUtilizator = c.String(maxLength: 128),
                        Data = c.DateTime(nullable: false),
                        IdAliment = c.Guid(nullable: false),
                        Cantitate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alimente", t => t.IdAliment, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUtilizator)
                .Index(t => t.IdUtilizator)
                .Index(t => t.IdAliment);
            
            CreateTable(
                "dbo.Donatii",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdUtilizator = c.String(maxLength: 128),
                        Data = c.DateTime(nullable: false),
                        Centru = c.String(),
                        Oras = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUtilizator)
                .Index(t => t.IdUtilizator);
            
            AddColumn("dbo.AspNetUsers", "Nume", c => c.String());
            AddColumn("dbo.AspNetUsers", "Prenume", c => c.String());
            AddColumn("dbo.AspNetUsers", "Oras", c => c.String());
            AddColumn("dbo.AspNetUsers", "Sex", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DataNasterii", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Greutate", c => c.String());
            AddColumn("dbo.AspNetUsers", "GrupaSanguina", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Rh", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donatii", "IdUtilizator", "dbo.AspNetUsers");
            DropForeignKey("dbo.AportAlimentar", "IdUtilizator", "dbo.AspNetUsers");
            DropForeignKey("dbo.AportAlimentar", "IdAliment", "dbo.Alimente");
            DropIndex("dbo.Donatii", new[] { "IdUtilizator" });
            DropIndex("dbo.AportAlimentar", new[] { "IdAliment" });
            DropIndex("dbo.AportAlimentar", new[] { "IdUtilizator" });
            DropColumn("dbo.AspNetUsers", "Rh");
            DropColumn("dbo.AspNetUsers", "GrupaSanguina");
            DropColumn("dbo.AspNetUsers", "Greutate");
            DropColumn("dbo.AspNetUsers", "DataNasterii");
            DropColumn("dbo.AspNetUsers", "Sex");
            DropColumn("dbo.AspNetUsers", "Oras");
            DropColumn("dbo.AspNetUsers", "Prenume");
            DropColumn("dbo.AspNetUsers", "Nume");
            DropTable("dbo.Donatii");
            DropTable("dbo.AportAlimentar");
            RenameTable(name: "dbo.Alimente", newName: "Alimentes");
        }
    }
}
