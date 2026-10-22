using System.Data.Entity.Migrations;
using CasoEstudioProductosMVC5.Data;
using CasoEstudioProductosMVC5.Models;

namespace CasoEstudioProductosMVC5.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<InventarioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(InventarioContext context)
        {
            context.Productos.AddOrUpdate(p => p.Codigo,
                new Producto { Codigo = "UNI-001", Nombre = "Arroz premium", Categoria = "Granos", TipoProducto = TipoProducto.PorPeso, Precio = 2.85m, Existencia = 160, Activo = true },
                new Producto { Codigo = "UNI-002", Nombre = "Leche deslactosada", Categoria = "Lácteos", TipoProducto = TipoProducto.PorUnidad, Precio = 1.90m, Existencia = 48, Activo = true },
                new Producto { Codigo = "PES-001", Nombre = "Manzana roja", Categoria = "Frutas", TipoProducto = TipoProducto.PorPeso, Precio = 3.40m, Existencia = 95, Activo = true },
                new Producto { Codigo = "UNI-003", Nombre = "Pasta spaghetti", Categoria = "Abarrotes", TipoProducto = TipoProducto.PorUnidad, Precio = 1.35m, Existencia = 72, Activo = true },
                new Producto { Codigo = "PES-002", Nombre = "Queso fresco", Categoria = "Lácteos", TipoProducto = TipoProducto.PorPeso, Precio = 8.75m, Existencia = 22, Activo = true },
                new Producto { Codigo = "UNI-004", Nombre = "Jugo de naranja", Categoria = "Bebidas", TipoProducto = TipoProducto.PorUnidad, Precio = 2.15m, Existencia = 36, Activo = true });
        }
    }
}
