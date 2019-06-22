namespace Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_dataLimita : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cereri", "DataLimita", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cereri", "DataLimita");
        }
    }
}
