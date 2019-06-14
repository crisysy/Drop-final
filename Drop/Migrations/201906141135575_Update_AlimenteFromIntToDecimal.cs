namespace Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_AlimenteFromIntToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alimente", "ValoareEnergetica", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Alimente", "Proteine", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Alimente", "Carbohidrati", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Alimente", "Glucide", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Alimente", "Fier", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Alimente", "VitaminaC", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Alimente", "AcidFolic", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Alimente", "Riboflavina", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Alimente", "Piridoxina", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alimente", "Piridoxina", c => c.Int(nullable: false));
            AlterColumn("dbo.Alimente", "Riboflavina", c => c.Int(nullable: false));
            AlterColumn("dbo.Alimente", "AcidFolic", c => c.Int(nullable: false));
            AlterColumn("dbo.Alimente", "VitaminaC", c => c.Int(nullable: false));
            AlterColumn("dbo.Alimente", "Fier", c => c.Int(nullable: false));
            AlterColumn("dbo.Alimente", "Glucide", c => c.Int(nullable: false));
            AlterColumn("dbo.Alimente", "Carbohidrati", c => c.Int(nullable: false));
            AlterColumn("dbo.Alimente", "Proteine", c => c.Int(nullable: false));
            AlterColumn("dbo.Alimente", "ValoareEnergetica", c => c.Int(nullable: false));
        }
    }
}
