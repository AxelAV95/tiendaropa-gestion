# Observaciones de desarrollo

- **Recomendación:** Para la mayoría de los proyectos con Entity Framework, **la Opción A (sobrescribir `SaveChangesAsync`) es la más limpia y mantenible.** Mantiene la lógica centralizada en tu código C#, que es donde EF gestiona el resto de tus reglas de negocio.

- **`UnitPrice`:** Guardar el precio al momento de la venta es **crítico**. Si solo te basaras en el precio del producto, y este cambiara en el futuro, todos tus reportes de ventas históricos serían incorrectos. Has creado una "foto" del precio, lo cual es perfecto.

- Conexiones con contraseña: 

* String de conexión:  "ConnectionStrings": {
    "DefaultConnection": "Server=AxelAV\\SQLEXPRESS;Database=tiendadb;User Id=axelav;Password=admin1234;TrustServerCertificate=True;MultipleActiveResultSets=true"
  
  }
  
- Analizar si varias ramas están iguales con varios trucos:

  

  ### 🔹 Opción 1 – Ver diferencias en commits

  ```bash
  git log main..develop
  ```

  - Muestra los commits que **están en develop pero no en main**.

  ```bash
  git log develop..main
  ```

  - Muestra los commits que **están en main pero no en develop**.

  🔹 Si ambos comandos **no muestran nada**, están iguales en commits.

  ------

  ### 🔹 Opción 2 – Ver diferencias en archivos

  ```bash
  git diff main..develop
  ```

  - Muestra **diferencias en contenido** (archivos cambiados, líneas distintas).

  🔹 Si no sale nada, están iguales en contenido.

  ------

  ### 🔹 Opción 3 – Ver el último commit de cada rama

  ```bash
  git checkout main
  git log -1
  git checkout develop
  git log -1
  ```

  🔹 Si ambos **hashes** (los códigos largos) son iguales → mismo commit base.

  ------

  ### 🔹 Opción 4 – Ver comparación rápida con `git status`

  ```bash
  git fetch origin
  git status
  ```

  Esto te dice si tu rama local está adelantada o atrasada respecto a la remota, aunque no es tan detallado para comparar entre ramas.


### Database first - Configuración

dotnet add TIENDAROPA.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add TIENDAROPA.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer

dotnet add TIENDAROPA.Domain package Microsoft.EntityFrameworkCore

dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef



cd path/to/your/solution/TIENDAROPA.Infrastructure

dotnet ef dbcontext scaffold "TU_CADENA_DE_CONEXION" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir ../TIENDAROPA.Domain/Entities --namespace TIENDAROPA.Domain.Entities --context-namespace TIENDAROPA.Infrastructure.Data