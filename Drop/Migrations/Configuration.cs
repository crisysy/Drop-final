namespace Drop.Migrations
{
    using Drop.SqlViews;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Drop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Drop.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Alimente.Any())
            {
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Piept de pui",
                    ValoareEnergetica = 173,
                    Proteine = 30.9m,
                    Carbohidrati = 0,
                    Glucide = 4.5m,
                    Fier = 1.1m,
                    VitaminaC = 0,
                    AcidFolic = 4,
                    Riboflavina = 0.1m,
                    Piridoxina = 0.6m,
                    Zaharuri = 0,
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Măr",
                    ValoareEnergetica = 52,
                    Proteine = 0.3m,
                    Carbohidrati = 13.8m,
                    Glucide = 0.2m,
                    Fier = 0.1m,
                    VitaminaC = 4.6m,
                    AcidFolic = 3,
                    Riboflavina = 0,
                    Piridoxina = 0,
                    Zaharuri = 10,
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Somon",
                    ValoareEnergetica = 206,
                    Proteine = 22.1m,
                    Carbohidrati = 0,
                    Glucide = 12.4m,
                    Fier = 0.3m,
                    VitaminaC = 3.7m,
                    AcidFolic = 34,
                    Riboflavina = 0.1m,
                    Piridoxina = 0.6m,
                    Zaharuri = 0
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Cartofi prăjiți",
                    ValoareEnergetica = 291.2m,
                    Proteine = 3m,
                    Carbohidrati = 38.4m,
                    Glucide = 16.2m,
                    Fier = 0.6m,
                    VitaminaC = 12.9m,
                    AcidFolic = 15.7m,
                    Riboflavina = 0m,
                    Piridoxina = 0.5m,
                    Zaharuri = 1.6m
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Ciocolată neagră",
                    ValoareEnergetica = 598,
                    Proteine = 7.8m,
                    Carbohidrati = 45.9m,
                    Glucide = 42.6m,
                    Fier = 11.9m,
                    VitaminaC = 0,
                    AcidFolic = 14,
                    Riboflavina = 0.1m,
                    Piridoxina = 0m,
                    Zaharuri = 24,
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Pâine integrală",
                    ValoareEnergetica = 252,
                    Proteine = 12.5m,
                    Carbohidrati = 42.7m,
                    Glucide = 3.5m,
                    Fier = 2.5m,
                    VitaminaC = 0,
                    AcidFolic = 42,
                    Riboflavina = 0.2m,
                    Piridoxina = 0.2m,
                    Zaharuri = 4.3m,
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Ou, fiert",
                    ValoareEnergetica = 155,
                    Proteine = 12.6m,
                    Carbohidrati = 1.1m,
                    Glucide = 10.6m,
                    Fier = 1.2m,
                    VitaminaC = 0,
                    AcidFolic = 44,
                    Riboflavina = 0.5m,
                    Piridoxina = 0.1m,
                    Zaharuri = 1.1m,
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Lasagna (vită)",
                    ValoareEnergetica = 160.9m,
                    Proteine = 10.6m,
                    Carbohidrati = 12.7m,
                    Glucide = 7.5m,
                    Fier = 1.2m,
                    VitaminaC = 4.1m,
                    AcidFolic = 44.6m,
                    Riboflavina = 0.2m,
                    Piridoxina = 0.1m,
                    Zaharuri = 1.9m,
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Pizza",
                    ValoareEnergetica = 281.4m,
                    Proteine = 12.8m,
                    Carbohidrati = 30.4m,
                    Glucide = 12m,
                    Fier = 2.1m,
                    VitaminaC = 2,
                    AcidFolic = 96.8m,
                    Riboflavina = 0.3m,
                    Piridoxina = 0.1m,
                    Zaharuri = 2.3m,
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Căpșuni",
                    ValoareEnergetica = 32,
                    Proteine = 0.7m,
                    Carbohidrati = 7.7m,
                    Glucide = 0.3m,
                    Fier = 0.4m,
                    VitaminaC = 58.8m,
                    AcidFolic = 24,
                    Riboflavina = 0m,
                    Piridoxina = 0m,
                    Zaharuri = 4.9m,
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Lapte",
                    ValoareEnergetica = 61,
                    Proteine = 3.2m,
                    Carbohidrati = 4.8m,
                    Glucide = 3.3m,
                    Fier = 0m,
                    VitaminaC = 0,
                    AcidFolic = 5,
                    Riboflavina = 0.2m,
                    Piridoxina = 0m,
                    Zaharuri = 5.1m,
                });
                context.Alimente.AddOrUpdate(new Aliment
                {
                    Id = Guid.NewGuid(),
                    Nume = "Fulgi de ovăz",
                    ValoareEnergetica = 379,
                    Proteine = 13.2m,
                    Carbohidrati = 67.7m,
                    Glucide = 6.5m,
                    Fier = 4.3m,
                    VitaminaC = 0,
                    AcidFolic = 32,
                    Riboflavina = 0.2m,
                    Piridoxina = 0.1m,
                    Zaharuri = 1,
                });
            }
            
        }
    }
}
