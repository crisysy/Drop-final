namespace Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tipDontie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donatii", "TipDonatie", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donatii", "TipDonatie");
        }
    }
}
