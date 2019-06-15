namespace Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corectatDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alimente", "Zaharuri", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alimente", "Zaharuri", c => c.Int(nullable: false));
        }
    }
}
