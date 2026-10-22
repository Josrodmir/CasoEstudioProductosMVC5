# Caso de estudio — CRUD de productos

Aplicación web de inventario construida con **ASP.NET MVC 5 (.NET Framework 4.8)**, **Entity Framework 6 Code First** y **SQL Server LocalDB**. Permite administrar una única entidad, `Producto`, durante todo su ciclo CRUD.

## Objetivo resuelto

Una tienda pequeña necesita abandonar la hoja de cálculo y administrar sus productos desde una pantalla web. La aplicación permite consultar el inventario, registrar productos, revisar su detalle, modificarlos y eliminarlos mediante confirmación.

La tabla `Productos` maneja los dos tipos solicitados en el mismo registro:

- **Por unidad**: leche, pasta o jugo.
- **Por peso**: arroz, manzanas o queso. El precio se visualiza por kilogramo.

## Tecnologías

- ASP.NET MVC 5
- .NET Framework 4.8
- Entity Framework 6.5.1
- SQL Server LocalDB (`MSSQLLocalDB`)
- Code First con `MigrateDatabaseToLatestVersion`

## Modelo de datos

La única entidad es `Producto`, almacenada en `dbo.Productos`.

| Campo | Tipo | Regla |
|---|---|---|
| `Id` | `int` | Clave primaria e identidad. |
| `Codigo` | `string(12)` | Obligatorio, único y máximo 12 caracteres. |
| `Nombre` | `string(80)` | Obligatorio; mínimo 3 y máximo 80 caracteres. |
| `Categoria` | `string(40)` | Obligatoria y máximo 40 caracteres. |
| `TipoProducto` | `int` | `PorUnidad` o `PorPeso`, en la misma tabla. |
| `Precio` | `decimal(12,2)` | Obligatorio y mayor que cero. |
| `Existencia` | `int` | Entre 0 y 9999. |
| `Activo` | `bit` | Estado del producto. |

Las reglas se implementan en el servidor mediante **Data Annotations** y se comprueba la unicidad del código antes de guardar.

## Base de datos y datos de demostración

La conexión por defecto está en `Web.config`:

```text
Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CasoEstudioProductos;Integrated Security=True
```

Al iniciar la aplicación, Entity Framework crea o actualiza la base mediante Code First. La semilla de datos agrega, sin duplicar, seis productos de demostración:

| Código | Producto | Tipo | Categoría |
|---|---|---|---|
| `UNI-001` | Arroz premium | Por peso | Granos |
| `UNI-002` | Leche deslactosada | Por unidad | Lácteos |
| `PES-001` | Manzana roja | Por peso | Frutas |
| `UNI-003` | Pasta spaghetti | Por unidad | Abarrotes |
| `PES-002` | Queso fresco | Por peso | Lácteos |
| `UNI-004` | Jugo de naranja | Por unidad | Bebidas |

> La configuración opcional de Azure solo se usa si se define `INVENTARIO_AZURE_CONNECTION`. Para esta entrega no es necesaria: el proyecto funciona de forma aislada con LocalDB.

## Funcionalidades CRUD

| Operación | Ruta | Evidencia funcional |
|---|---|---|
| Listar y filtrar | `/Productos` | Lista productos desde la base de datos y filtra por código, nombre o categoría. |
| Crear | `/Productos/Create` | Formulario con validación de servidor, `AntiForgeryToken` y confirmación posterior. |
| Detalle | `/Productos/Details/{id}` | Presenta toda la información del producto seleccionado. |
| Editar | `/Productos/Edit/{id}` | Recupera el producto, valida y persiste el cambio con EF6. |
| Eliminar | `/Productos/Delete/{id}` | Muestra una pantalla de confirmación antes del `POST` que elimina. |

Todos los `POST` validan `ModelState` antes de usar `SaveChanges`. Las acciones reciben identificadores inválidos con respuesta HTTP 400 o 404 según corresponda.

## Ejecución

1. Abrir `CasoEstudioProductosMVC5.sln` con Visual Studio.
2. Ejecutar **Compilar → Recompilar solución**.
3. Presionar **F5** para iniciar IIS Express.
4. Abrir `Productos` y verificar los seis registros iniciales.
5. Para ver la base en SSMS, conectarse a `(localdb)\MSSQLLocalDB` y expandir **Databases → CasoEstudioProductos → Tables → dbo.Productos**.

## Script SQL para compartir

El proyecto incluye [Database/CrearCasoEstudioProductos.sql](Database/CrearCasoEstudioProductos.sql). Es autocontenido e idempotente: crea `CasoEstudioProductos` si no existe, crea `dbo.Productos`, agrega sus restricciones y carga los seis productos solo si aún no existen.

Un compañero puede abrirlo en SSMS, conectarse con **Windows Authentication** a su instancia SQL Server y presionar **Execute**. Después debe actualizar la cadena `InventarioDb` de `Web.config` si su instancia no es `(localdb)\MSSQLLocalDB`.

## Lista de verificación para la rúbrica

- [x] Proyecto MVC ejecutable con modelo, `DbContext`, controlador y vistas.
- [x] Persistencia con Entity Framework 6 y base SQL Server LocalDB.
- [x] Listado de productos guardados en base de datos.
- [x] Crear producto y mostrar sus datos después de guardar.
- [x] Consultar detalle de un producto.
- [x] Editar y persistir los cambios.
- [x] Eliminar solo después de una pantalla de confirmación.
- [x] Validación de servidor mediante Data Annotations y mensajes en vista.
- [x] Una tabla `Productos` con productos por peso y por unidad.
- [x] Filtro opcional por código, nombre o categoría.
- [x] Interfaz responsive, usable y con estados visuales de venta/estado.

## Capturas recomendadas para entregar

1. Listado con productos por unidad y por peso visibles.
2. Formulario **Nuevo producto** mostrando las validaciones.
3. Detalle de un producto recién creado o actualizado.
4. Pantalla **Confirmar eliminación** antes de borrar.
5. SSMS con `CasoEstudioProductos`, `dbo.Productos` y los registros precargados.
