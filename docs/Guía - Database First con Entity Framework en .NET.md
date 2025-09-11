### Guía Completa para Principiantes: Database First con Entity Framework en .NET



Esta guía te llevará paso a paso a través del proceso de "Database First" con Entity Framework (EF) Core, utilizando la estructura de proyecto que has proporcionado. El objetivo es generar las entidades de tu base de datos en el proyecto `TIENDAROPA.Domain` y el `DbContext` en `TIENDAROPA.Infrastructure`, manteniendo tu arquitectura limpia y organizada.

------



### **Paso 1: Requisitos Previos**



Antes de comenzar, asegúrate de tener instaladas las siguientes herramientas:

1. **.NET SDK:** La interfaz de línea de comandos (CLI) de .NET es fundamental para ejecutar los comandos de EF Core.
2. **Visual Studio o tu editor de código preferido:** Para gestionar los proyectos.
3. **Acceso a tu base de datos:** Necesitarás la cadena de conexión a tu base de datos existente (SQL Server, PostgreSQL, MySQL, etc.).

------



### **Paso 2: Instalación de Paquetes NuGet de Entity Framework Core**



Necesitarás instalar algunos paquetes NuGet en los proyectos correspondientes. Puedes hacerlo a través de la Consola del Administrador de Paquetes (PMC) en Visual Studio o utilizando la CLI de .NET.



#### **Usando la CLI de .NET:**



Abre una terminal o símbolo del sistema en la raíz de tu solución.

1. **En el proyecto `TIENDAROPA.Infrastructure` (donde vivirá el DbContext):**

   - **Herramientas de Diseño (Design):** Necesario para que las herramientas de EF Core puedan interactuar con tu proyecto.

     Shell

     ```
     dotnet add TIENDAROPA.Infrastructure package Microsoft.EntityFrameworkCore.Design
     ```

   - **Proveedor de Base de Datos:** Instala el proveedor correspondiente a tu base de datos. Aquí un ejemplo para SQL Server.

     Shell

     ```
     dotnet add TIENDAROPA.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
     ```

     *(Si usas otra base de datos, reemplaza `SqlServer` por `Npgsql` para PostgreSQL, `MySql.EntityFrameworkCore` para MySQL, etc.)*

2. **En el proyecto `TIENDAROPA.Domain` (donde irán las entidades):**

   - **Abstracciones de EF Core:** Solo necesitas las abstracciones principales, ya que las entidades no deberían depender de la implementación de la base de datos.

     Shell

     ```
     dotnet add TIENDAROPA.Domain package Microsoft.EntityFrameworkCore
     ```

3. Instalación de la herramienta Global dotnet-ef:

   Asegúrate de tener instalada la herramienta de línea de comandos de EF. Si no la tienes, instálala con el siguiente comando:

   Shell

   ```
   dotnet tool install --global dotnet-ef
   ```

   Si ya la tienes, es una buena práctica actualizarla a la última versión:

   Shell

   ```
   dotnet tool update --global dotnet-ef
   ```

------



### **Paso 3: El Comando Mágico `dotnet ef dbcontext scaffold`**



Este es el comando principal que realizará la "ingeniería inversa" de tu base de datos para generar los archivos de C#. La clave para que todo quede en su lugar correcto es ejecutar el comando desde la carpeta del proyecto que contendrá el `DbContext` (`TIENDAROPA.Infrastructure`) y usar los parámetros para redirigir la salida de las entidades.



#### **Construcción del Comando:**



Abre tu terminal y **navega hasta la carpeta del proyecto de Infraestructura**:

Shell

```
cd path/to/your/solution/TIENDAROPA.Infrastructure
```

Ahora, ejecuta el siguiente comando, ajustando los marcadores de posición:

Shell

```
dotnet ef dbcontext scaffold "Server=AxelAV\SQLEXPRESS;Database=tiendadb;User Id=axelav;Password=admin1234;TrustServerCertificate=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir ../TIENDAROPA.Domain/Entities --namespace TIENDAROPA.Domain.Entities --context-namespace TIENDAROPA.Infrastructure.Data
```



#### **Desglose del Comando:**



- `"TU_CADENA_DE_CONEXION"`: Reemplaza esto con la cadena de conexión a tu base de datos. **Ejemplo:** `"Server=my_server;Database=TiendaRopaDB;User Id=my_user;Password=my_password;"`
- `Microsoft.EntityFrameworkCore.SqlServer`: Este es el proveedor de la base de datos. Cámbialo si usas otra.
- `--context-dir Data`:
  - Le dice a EF Core que coloque el archivo `DbContext` generado dentro de la carpeta `Data` del proyecto actual (`TIENDAROPA.Infrastructure`).
- `--output-dir ../TIENDAROPA.Domain/Entities`:
  - Este es el truco principal. Le indica a EF Core que genere todas las clases de las entidades en una carpeta diferente.
  - `../` sube un nivel en el árbol de directorios (desde `Infrastructure` a la raíz de la solución).
  - `TIENDAROPA.Domain/Entities` especifica la ruta de destino final para tus entidades.
- `--namespace TIENDAROPA.Domain.Entities`:
  - Establece el `namespace` para todas las clases de entidad generadas, asegurando que coincida con la estructura de tu proyecto.
- `--context-namespace TIENDAROPA.Infrastructure.Data`:
  - Establece el `namespace` específico para tu clase `DbContext`.

Al ejecutarlo, verás que las entidades se crean en `TIENDAROPA.Domain/Entities` y tu `DbContext` aparece en `TIENDAROPA.Infrastructure/Data`, exactamente como lo necesitas.

------



### **Paso 4: Configuración del DbContext en el Proyecto API**



Ahora que tienes tus entidades y tu contexto, necesitas registrarlo en el contenedor de dependencias de tu aplicación para poder usarlo en tus servicios.

1. **Añade Referencias de Proyecto:**

   - El proyecto `TIENDAROPA.Api` necesita una referencia a `TIENDAROPA.Infrastructure` y a `TIENDAROPA.Application`.
   - El proyecto `TIENDAROPA.Application` necesita una referencia a `TIENDAROPA.Domain` y `TIENDAROPA.Infrastructure`.
   - El proyecto `TIENDAROPA.Infrastructure` necesita una referencia a `TIENDAROPA.Domain`.

2. Configura la Cadena de Conexión en appsettings.json:

   En tu proyecto TIENDAROPA.Api, abre el archivo appsettings.json y añade tu cadena de conexión:

   JSON

   ```
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=my_server;Database=TiendaRopaDB;User Id=my_user;Password=my_password;"
     },
     "Logging": { ... },
     "AllowedHosts": "*"
   }
   ```

3. Registra el DbContext en Program.cs:

   En el archivo Program.cs de TIENDAROPA.Api, añade el servicio del DbContext:

   C#

   ```
   using Microsoft.EntityFrameworkCore;
   using TIENDAROPA.Infrastructure.Data; // Asegúrate de importar el namespace correcto
   
   var builder = WebApplication.CreateBuilder(args);
   
   // ... otros servicios
   
   // Añadir el DbContext al contenedor de DI
   var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
   builder.Services.AddDbContext<TuDbContext>(options =>
       options.UseSqlServer(connectionString));
   
   // ... resto de la configuración
   
   var app = builder.Build();
   
   // ...
   
   app.Run();
   ```

   **Nota:** Reemplaza `TuDbContext` con el nombre real que EF Core le dio a tu clase de contexto (generalmente es el nombre de la base de datos seguido de "Context").



### **Resumen y Próximos Pasos**



¡Felicidades! Has realizado exitosamente el proceso de Database First, alineándolo con una arquitectura limpia.

- **Entidades:** Viven en `TIENDAROPA.Domain/Entities`, libres de dependencias de infraestructura.
- **DbContext:** Reside en `TIENDAROPA.Infrastructure/Data`, manejando la lógica de acceso a datos.
- **API:** Configurada para inyectar y utilizar el `DbContext` donde sea necesario.

Si necesitas actualizar tus entidades porque la base de datos cambió, simplemente **vuelve a ejecutar el mismo comando `dotnet ef dbcontext scaffold` del Paso 3**. Puedes añadir el flag `--force` para sobrescribir los archivos existentes.