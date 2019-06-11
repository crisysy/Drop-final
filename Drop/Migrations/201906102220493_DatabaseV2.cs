namespace Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Inaltime", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "Sex", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "Greutate", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Greutate", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Sex", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Inaltime");
        }
    }
}
