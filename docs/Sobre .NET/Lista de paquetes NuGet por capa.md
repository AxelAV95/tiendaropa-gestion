# Lista de las herramientas y paquetes NuGet esenciales y recomendados para cada capa.

------



### 1. `TIENDAROPA.Domain` (La Capa del Dominio)



Esta es la capa más importante y el corazón de tu aplicación. Contiene la lógica de negocio pura y no debe depender de ninguna tecnología externa (como bases de datos o APIs).

- **Regla Principal:** ¡Cero paquetes NuGet!
- **Contenido:**
  - **Entities:** Clases que representan los objetos de tu negocio (Producto, Cliente, Orden).
  - **ValueObjects:** Objetos inmutables que representan un valor (Dirección, Dinero).
  - **Enums:** Enumeraciones.
  - **Exceptions:** Excepciones personalizadas del dominio.
  - **Interfaces:** Abstracciones de los repositorios (`IProductRepository`, `IOrderRepository`). La implementación real estará en la capa de Infraestructura.

------



### 2. `TIENDAROPA.Application` (La Capa de Aplicación)



Esta capa orquesta los casos de uso de la aplicación. Contiene la lógica de la aplicación pero no la lógica de negocio (que está en el Dominio). Depende del Dominio, pero no de la Infraestructura.

- **Paquetes NuGet Recomendados:**
  - **`MediatR`**: Una librería muy popular para implementar los patrones CQRS (Command Query Responsibility Segregation) y Mediator. Ayuda a desacoplar la lógica, manteniendo los casos de uso limpios y enfocados. Por ejemplo, `CreateProductCommand`.
    - Necesitarás **`MediatR.Extensions.Microsoft.DependencyInjection`** para registrarlo fácilmente.
  - **`AutoMapper`**: Se usa para mapear (convertir) los objetos del Dominio (Entities) a DTOs (Data Transfer Objects) que se enviarán a la capa de presentación.
    - Necesitarás **`AutoMapper.Extensions.Microsoft.DependencyInjection`** para la inyección de dependencias.
  - **`FluentValidation`**: Para definir reglas de validación para los comandos y DTOs de entrada. Es mucho más potente y limpio que usar Data Annotations.
    - Necesitarás **`FluentValidation.DependencyInjectionExtensions`** para integrarlo.

------



### 3. `TIENDAROPA.Infrastructure` (La Capa de Infraestructura)



Esta capa contiene las implementaciones de las interfaces definidas en las capas de Aplicación y Dominio. Aquí es donde viven todos los detalles técnicos y las dependencias de librerías externas.

- **Paquetes NuGet Esenciales:**
  - **`Microsoft.EntityFrameworkCore`**: El paquete principal de EF Core.
  - **`Microsoft.EntityFrameworkCore.SqlServer`**: El proveedor de base de datos para SQL Server.
  - **`Microsoft.EntityFrameworkCore.Tools`**: Contiene las herramientas de línea de comandos (`dotnet ef`). Es fundamental para las migraciones y el scaffolding.
  - **`Microsoft.EntityFrameworkCore.Design`**: Requerido por las herramientas para poder funcionar en tiempo de diseño.
  - **`Microsoft.Extensions.Configuration.Abstractions`**: Para poder leer la configuración (como el connection string) de `appsettings.json`.
  - **`Microsoft.Extensions.DependencyInjection.Abstractions`**: Necesario para crear los métodos de extensión para la inyección de dependencias (`AddInfrastructure`).
- **Paquetes Opcionales (dependiendo de las necesidades):**
  - **`Microsoft.AspNetCore.Identity.EntityFrameworkCore`**: Si necesitas manejar usuarios, roles y autenticación.
  - **`SendGrid`** o **`MailKit`**: Si necesitas enviar correos electrónicos.
  - **`Azure.Storage.Blobs`**: Si necesitas interactuar con Azure Blob Storage para guardar archivos.

------



### 4. `TIENDAROPA.Api` (La Capa de Presentación)



Este es el punto de entrada a tu aplicación. En tu caso, una Web API. Es responsable de manejar las peticiones HTTP, la autenticación, el enrutamiento y la serialización.

- **Paquetes NuGet Recomendados:**
  - **`Swashbuckle.AspNetCore`**: Para generar automáticamente la documentación de tu API con Swagger/OpenAPI. Esencial para probar y documentar los endpoints.
  - **`Microsoft.AspNetCore.Authentication.JwtBearer`**: Si vas a proteger tu API con JSON Web Tokens (JWT), que es un estándar muy común.
  - **`FluentValidation.AspNetCore`**: Para integrar `FluentValidation` automáticamente en el pipeline de ASP.NET Core, de modo que los modelos de entrada se validen antes de llegar a tus controladores.
  - **`Serilog.AspNetCore`**: (Opcional pero muy recomendado) Una librería de logging mucho más potente y configurable que la que viene por defecto.
  - **Microsoft.EntityFrameworkCore.Tools**: Si instalas `Microsoft.EntityFrameworkCore.Tools` en el proyecto `TIENDAROPA.Api`, lo haces con el objetivo de designar a este proyecto como el **anfitrión de las herramientas de diseño**.



### Resumen de Referencias entre Proyectos



La regla más importante es la dirección de las dependencias:

- `Domain`: No referencia a ningún otro proyecto.
- `Application`: Referencia a `Domain`.
- `Infrastructure`: Referencia a `Application` (y por ende, a `Domain`).
- `Api`: Referencia a `Infrastructure` y `Application`.

Visualmente:

Api -> Infrastructure -> Application -> Domain

