# Caso de estudio: CRUD de productos

Proyecto ASP.NET MVC 5 (.NET Framework 4.8) con Entity Framework 6 Code First. `Producto` es la única entidad y `InventarioContext` la expone como `DbSet`; EF crea y actualiza la tabla mediante `MigrateDatabaseToLatestVersion`. `Index` consulta, `Create` agrega, `Details` lee, `Edit` modifica y `Delete` elimina tras confirmación. Todos los POST validan `ModelState` antes de `SaveChanges`.

Configure `InventarioDb` en `Web.config` para LocalDB. Para Azure SQL, defina la variable de entorno `INVENTARIO_AZURE_CONNECTION` con la cadena completa; tiene prioridad sobre la conexión local y evita almacenar credenciales en el repositorio. Al iniciar, EF6 aplica las migraciones automáticas y crea/actualiza `Productos`.
