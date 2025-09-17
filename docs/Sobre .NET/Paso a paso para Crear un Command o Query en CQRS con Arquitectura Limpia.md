### Paso a paso para Crear un `Command` o `Query` en CQRS con Arquitectura Limpia



Este proceso se divide en 4 fases principales que corresponden a las capas de tu arquitectura.



#### Fase 1: La Capa `Application` - Definir la Solicitud y la Respuesta (El "QUÉ")



Aquí defines qué datos entran y qué datos salen.

- **✅ Paso 1: Crear la Carpeta de la Funcionalidad**
  - Dentro de `Application/Features`, crea una estructura clara.
  - **Ejemplo:** Para crear un producto, crea la carpeta `Application/Features/Products/Commands/CreateProduct`.
- **✅ Paso 2: Crear la Clase del `Command` o `Query`**
  - Dentro de la carpeta, crea el archivo (ej: `CreateProductCommand.cs`).
  - **Checklist:**
    - ¿Hereda de `IRequest<T>` de MediatR?
    - `T` debe ser el tipo de dato que devolverás (ej: `BaseResponse<int>` para el ID del nuevo producto, o `BaseResponse<MiDto>` para una consulta).
    - ¿Tiene las propiedades necesarias para los datos de entrada? (ej: `string Name`, `decimal Price`).
- **✅ Paso 3: Crear (o Reutilizar) el DTO de Respuesta**
  - Define el objeto de datos que devolverá tu API para no exponer tus entidades de dominio.
  - **Ubicación:** `Application/DTOs/`.
  - **Ejemplo:** `ProductDetailDto.cs`. Si ya existe uno que te sirve, ¡reutilízalo!

------



#### Fase 2: La Capa `Application` - Implementar la Lógica (El "CÓMO")



Aquí es donde ocurre la "magia".

- **✅ Paso 4: Implementar el `Handler`**
  - En la misma carpeta, crea el archivo del manejador (ej: `CreateProductCommandHandler.cs`).
  - **Checklist:**
    - ¿Hereda de `IRequestHandler<TRequest, TResponse>`? (donde `TRequest` es tu Command/Query y `TResponse` es la respuesta definida en el paso 2).
    - **Inyecta sus dependencias en el constructor.** Lo más común es: `IUnitOfWork` y `IMapper`.
    - **Implementa el método `Handle`:**
      - **Para Commands:** Valida reglas de negocio, crea la entidad de dominio, usa el repositorio (`_unitOfWork.Products.AddAsync(...)`) y guarda los cambios (`await _unitOfWork.SaveChangesAsync()`).
      - **Para Queries:** Usa el repositorio (`_unitOfWork.Products.Get...()`), comprueba si el resultado es nulo, y mapea la entidad a tu DTO.
    - Envuelve siempre el resultado en tu clase `BaseResponse<T>`.
- **✅ Paso 5: Crear el `Validator` (¡Casi siempre necesario!)**
  - En la misma carpeta, crea el archivo del validador (ej: `CreateProductCommandValidator.cs`).
  - **Checklist:**
    - ¿Hereda de `AbstractValidator<T>` de FluentValidation? (`T` es tu Command/Query).
    - Define las reglas de validación para las propiedades de entrada usando `RuleFor()`.
  - *Recordatorio: Este validador se ejecutará automáticamente antes que el Handler gracias al `ValidationBehavior` que ya configuraste.*
- **✅ Paso 6: Crear el Perfil de `Mapping` (Si es necesario)**
  - Si creaste un DTO nuevo, necesitas decirle a AutoMapper cómo hacer la conversión.
  - **Ubicación:** `Application/Mappings/`.
  - **Crea el archivo:** (ej: `ProductDetailMapping.cs`).
  - **Checklist:**
    - ¿Hereda de `Profile` de AutoMapper?
    - Define el `CreateMap<Entidad, MiNuevoDto>()` en el constructor, configurando las propiedades especiales con `.ForMember()`.
  - *Recordatorio: AutoMapper lo encontrará y registrará solo.*

------



#### Fase 3: La Capa `Infrastructure` - Acceso a Datos (El "DÓNDE")



**Nota:** Solo necesitas hacer esto si el Handler requiere una consulta a la base de datos que no existe en tu repositorio.

- **✅ Paso 7 (Opcional): Actualizar la Interfaz del Repositorio**
  - Si necesitas un método como `GetProductWithVariantsAsync`, primero defínelo en su interfaz.
  - **Ubicación:** `Application/Interfaces/Persistence/IProductRepository.cs`.
- **✅ Paso 8 (Opcional): Implementar el Método en el Repositorio**
  - Implementa la lógica de Entity Framework Core.
  - **Ubicación:** `Infrastructure/Repositories/ProductRepository.cs`.
  - Usa `_context`, `.Include()`, `.FirstOrDefaultAsync()`, etc.

------



#### Fase 4: La Capa `WebAPI` - Exponer la Funcionalidad (El "DISPARADOR")



El último paso es hacer que tu Command/Query sea accesible desde el exterior.

- **✅ Paso 9: Crear el Endpoint en el Controlador**
  - Abre el controlador apropiado (ej: `ProductsController.cs`).
  - **Checklist:**
    - ¿El controlador tiene `IMediator` inyectado?
    - Crea el método de acción con su verbo HTTP (`[HttpPost]`, `[HttpGet("{id}")]`, `[HttpPut]`).
    - Crea una instancia de tu Command/Query a partir de los datos de la petición (`[FromBody]`, `[FromRoute]`, etc.).
    - Envía la solicitud a MediatR: `var response = await _mediator.Send(miComandoOQuery);`.
    - Devuelve el `IActionResult` apropiado basado en la respuesta (`Ok(response)`, `NotFound(response)`, `BadRequest(response)`).

------



### Lista de Verificación Final (Antes de Terminar)



- [ ] **Application:** ¿Tengo la carpeta, el `Command/Query`, el `DTO`, el `Handler`, el `Validator` y el `Mapping`?
- [ ] **Infrastructure:** ¿Necesité un nuevo método de repositorio? Si es así, ¿está en la interfaz y en la clase?
- [ ] **WebAPI:** ¿Tengo el endpoint en el controlador que crea y envía la solicitud a MediatR?
- [ ] **Inyección de Dependencias:** Si creé una nueva interfaz/clase (como un nuevo repositorio), ¿la registré en `Program.cs`? (No es necesario para Handlers, Validators y Mappings, ya que se registran automáticamente por ensamblado).

¡Y eso es todo! Al principio puede parecer mucho, pero después de hacerlo dos o tres veces, este flujo se volverá mecánico y te permitirá construir funcionalidades de forma rápida, ordenada y robusta.