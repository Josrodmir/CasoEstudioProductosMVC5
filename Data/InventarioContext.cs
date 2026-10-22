using System;
using System.Data.Entity;
using CasoEstudioProductosMVC5.Models;
namespace CasoEstudioProductosMVC5.Data { public class InventarioContext : DbContext { public InventarioContext() : base(ObtenerConexion()) { } public DbSet<Producto> Productos { get; set; } protected override void OnModelCreating(DbModelBuilder modelBuilder) { modelBuilder.Entity<Producto>().ToTable("Productos"); modelBuilder.Entity<Producto>().HasIndex(p => p.Codigo).IsUnique(); modelBuilder.Entity<Producto>().Property(p => p.Precio).HasPrecision(12, 2); base.OnModelCreating(modelBuilder); } private static string ObtenerConexion() { var azure = Environment.GetEnvironmentVariable("INVENTARIO_AZURE_CONNECTION"); return string.IsNullOrWhiteSpace(azure) ? "InventarioDb" : azure; } } }
