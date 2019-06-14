namespace Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_StiDeViat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiluri", "StilDeViata", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiluri", "StilDeViata");
        }
    }
}
