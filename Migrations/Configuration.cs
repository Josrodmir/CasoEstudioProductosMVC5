using System.Data.Entity.Migrations;
using CasoEstudioProductosMVC5.Data;
namespace CasoEstudioProductosMVC5.Migrations { public sealed class Configuration : DbMigrationsConfiguration<InventarioContext> { public Configuration() { AutomaticMigrationsEnabled = true; AutomaticMigrationDataLossAllowed = false; } protected override void Seed(InventarioContext context) { } } }
