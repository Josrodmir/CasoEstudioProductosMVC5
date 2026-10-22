/*
   Caso de estudio: CRUD de productos MVC5 + EF6
   Uso: ejecutar este archivo en SSMS con Windows Authentication.
   Crea una base independiente, su tabla Productos y datos de demostración.
*/

IF DB_ID(N'CasoEstudioProductos') IS NULL
BEGIN
    CREATE DATABASE CasoEstudioProductos;
END
GO

USE CasoEstudioProductos;
GO

IF OBJECT_ID(N'dbo.Productos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Productos
    (
        Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Productos PRIMARY KEY,
        Codigo NVARCHAR(12) NOT NULL,
        Nombre NVARCHAR(80) NOT NULL,
        Categoria NVARCHAR(40) NOT NULL,
        TipoProducto INT NOT NULL CONSTRAINT CK_Productos_TipoProducto CHECK (TipoProducto IN (1, 2)),
        Precio DECIMAL(12,2) NOT NULL CONSTRAINT CK_Productos_Precio CHECK (Precio > 0),
        Existencia INT NOT NULL CONSTRAINT CK_Productos_Existencia CHECK (Existencia BETWEEN 0 AND 9999),
        Activo BIT NOT NULL CONSTRAINT DF_Productos_Activo DEFAULT (1),
        CONSTRAINT UQ_Productos_Codigo UNIQUE (Codigo)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Productos WHERE Codigo = N'UNI-001')
    INSERT INTO dbo.Productos (Codigo, Nombre, Categoria, TipoProducto, Precio, Existencia, Activo)
    VALUES (N'UNI-001', N'Arroz premium', N'Granos', 2, 2.85, 160, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.Productos WHERE Codigo = N'UNI-002')
    INSERT INTO dbo.Productos (Codigo, Nombre, Categoria, TipoProducto, Precio, Existencia, Activo)
    VALUES (N'UNI-002', N'Leche deslactosada', N'Lácteos', 1, 1.90, 48, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.Productos WHERE Codigo = N'PES-001')
    INSERT INTO dbo.Productos (Codigo, Nombre, Categoria, TipoProducto, Precio, Existencia, Activo)
    VALUES (N'PES-001', N'Manzana roja', N'Frutas', 2, 3.40, 95, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.Productos WHERE Codigo = N'UNI-003')
    INSERT INTO dbo.Productos (Codigo, Nombre, Categoria, TipoProducto, Precio, Existencia, Activo)
    VALUES (N'UNI-003', N'Pasta spaghetti', N'Abarrotes', 1, 1.35, 72, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.Productos WHERE Codigo = N'PES-002')
    INSERT INTO dbo.Productos (Codigo, Nombre, Categoria, TipoProducto, Precio, Existencia, Activo)
    VALUES (N'PES-002', N'Queso fresco', N'Lácteos', 2, 8.75, 22, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.Productos WHERE Codigo = N'UNI-004')
    INSERT INTO dbo.Productos (Codigo, Nombre, Categoria, TipoProducto, Precio, Existencia, Activo)
    VALUES (N'UNI-004', N'Jugo de naranja', N'Bebidas', 1, 2.15, 36, 1);
GO

SELECT Id, Codigo, Nombre, Categoria,
       CASE TipoProducto WHEN 1 THEN N'Por unidad' WHEN 2 THEN N'Por peso' END AS TipoVenta,
       Precio, Existencia, Activo
FROM dbo.Productos
ORDER BY Codigo;
GO
