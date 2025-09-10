# Guía Completa de Arquitectura Limpia - TIENDAROPA

## 📁 **TIENDAROPA.Domain** (Capa de Dominio - Núcleo)

**Propósito**: Contiene la lógica de negocio pura, independiente de tecnologías externas.

**Carpetas típicas:**

- Entities

   \- Entidades de dominio

  ```csharp
  public class Product { public string Name { get; set; } }public class Customer { public string Email { get; set; } }
  ```

- ValueObjects

   \- Objetos de valor inmutables

  ```csharp
  public record Money(decimal Amount, string Currency);
  ```

- **DomainServices** - Servicios de dominio

- **Repositories** (Interfaces) - Contratos para persistencia

- **DomainEvents** - Eventos de dominio

- **Exceptions** - Excepciones específicas del dominio

## 📁 **TIENDAROPA.Application** (Capa de Aplicación)

**Propósito**: Orquesta la lógica de negocio y coordina el flujo de datos.

**Carpetas típicas:**

- Commons

   \- Elementos base y compartidos

  - **Base** - Clases base reutilizables
  - **Enums** - Enumeraciones del sistema
  - **Constants** - Constantes y mensajes
  - **Extensions** - Métodos de extensión

- **Services** - Servicios de aplicación

- DTOs

   \- Objetos de transferencia de datos

  ```csharp
  public class ProductDto { public string Name { get; set; } }
  ```

- **Interfaces** - Contratos para servicios externos

- **UseCases** o **Commands/Queries** - Casos de uso específicos

- **Mappers** - Conversión entre DTOs y entidades

- **Validators** - Validaciones de entrada

## 📁 **TIENDAROPA.Infrastructure** (Capa de Infraestructura)

**Propósito**: Implementa detalles técnicos y acceso a recursos externos.

**Carpetas típicas:**

- Data

   \- Contexto de base de datos, configuraciones EF

  ```csharp
  public class AppDbContext : DbContext
  ```

- **Repositories** - Implementaciones concretas de repositorios

- **Services** - Implementaciones de servicios externos

- **ExternalServices** - APIs externas, email, SMS

- **Configuration** - Configuraciones de infraestructura

- **Migrations** - Migraciones de base de datos

## 📁 **TIENDAROPA.Api** (Capa de Presentación)

**Propósito**: Punto de entrada, maneja HTTP requests y responses.

**Carpetas típicas:**

- Controllers

   \- Controladores API

  ```csharp
  [ApiController]public class ProductsController : ControllerBase
  ```

- **Middleware** - Middleware personalizado

- **Filters** - Filtros de acción/autorización

- **Models** - ViewModels, RequestModels, ResponseModels

- **Extensions** - Métodos de extensión

- **Configuration** - Startup, Program.cs

## 🔄 **Relaciones de Dependencia**

```
Api → Application → Domain
     ↘ Infrastructure ↗
```

- **Application → Domain**: Usa entidades y servicios de dominio
- **Infrastructure → Application**: Implementa interfaces definidas en Application
- **Api → Application**: Llama a servicios de aplicación
- **Api → Infrastructure**: Para inyección de dependencias y configuración

## 📁 **Commons/Base en Application**

**Commons** es una carpeta que contiene elementos base y compartidos:

```
TIENDAROPA.Application/
├── Commons/
│   ├── Base/
│   │   ├── BaseEntity.cs
│   │   ├── BaseService.cs
│   │   ├── BaseResponse.cs
│   │   ├── BaseRequest.cs
│   │   └── BaseValidator.cs
│   ├── Enums/
│   │   ├── StatusEnum.cs
│   │   └── UserRoleEnum.cs
│   ├── Constants/
│   │   ├── ErrorMessages.cs
│   │   └── SystemConstants.cs
│   └── Extensions/
│       ├── StringExtensions.cs
│       └── DateTimeExtensions.cs
```

### **Ejemplos de Base Classes:**

```csharp
// Commons/Base/BaseResponse.cs
public class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; } = new();
}

// Commons/Base/BaseRequest.cs
public abstract class BaseRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

// Commons/Base/BaseService.cs
public abstract class BaseService
{
    protected readonly IUnitOfWork _unitOfWork;
    
    protected BaseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
```

## 📄 **DependencyInjection.cs por Capa**

Cada capa tiene su propio archivo para registrar sus dependencias:

### **Domain/DependencyInjection.cs**

```csharp
using Microsoft.Extensions.DependencyInjection;

namespace TIENDAROPA.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            // Domain Services
            services.AddScoped<IProductDomainService, ProductDomainService>();
            services.AddScoped<IOrderDomainService, OrderDomainService>();
            
            return services;
        }
    }
}
```

### **Application/DependencyInjection.cs**

```csharp
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace TIENDAROPA.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Application Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            
            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            // MediatR (si lo usas)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            
            return services;
        }
    }
}
```

### **Infrastructure/DependencyInjection.cs**

```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TIENDAROPA.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration)
        {
            // Database
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            // External Services
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPaymentService, PaymentService>();
            
            return services;
        }
    }
}
```

### **Api/DependencyInjection.cs** (o Program.cs)

```csharp
// En Program.cs o DependencyInjection.cs
using TIENDAROPA.Domain;
using TIENDAROPA.Application;
using TIENDAROPA.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Registro de todas las capas
builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Servicios específicos de API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
```

## 🏗️ **Estructura Completa del Proyecto**

```
TIENDAROPA.Domain/
├── Entities/
├── ValueObjects/
├── Repositories/ (interfaces)
├── Services/
├── Events/
├── Exceptions/
└── DependencyInjection.cs

TIENDAROPA.Application/
├── Commons/
│   ├── Base/
│   │   ├── BaseEntity.cs
│   │   ├── BaseService.cs
│   │   ├── BaseResponse.cs
│   │   ├── BaseRequest.cs
│   │   └── BaseValidator.cs
│   ├── Enums/
│   │   ├── StatusEnum.cs
│   │   └── UserRoleEnum.cs
│   ├── Constants/
│   │   ├── ErrorMessages.cs
│   │   └── SystemConstants.cs
│   └── Extensions/
│       ├── StringExtensions.cs
│       └── DateTimeExtensions.cs
├── Services/
├── DTOs/
├── Interfaces/
├── Validators/
├── Mappers/
├── UseCases/ (opcional)
└── DependencyInjection.cs

TIENDAROPA.Infrastructure/
├── Data/
│   ├── AppDbContext.cs
│   └── Configurations/
├── Repositories/
├── Services/
├── ExternalServices/
├── Migrations/
└── DependencyInjection.cs

TIENDAROPA.Api/
├── Controllers/
├── Middleware/
├── Filters/
├── Models/
│   ├── Requests/
│   ├── Responses/
│   └── ViewModels/
├── Extensions/
├── DependencyInjection.cs (opcional)
└── Program.cs
```

## 📝 **Ejemplo Práctico Completo**

### **Domain/Entities/Product.cs**

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Money Price { get; set; }
    public bool IsActive { get; set; }
}
```

### **Application/Commons/Base/BaseResponse.cs**

```csharp
public class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; } = new();
    
    public static BaseResponse<T> Success(T data, string message = "Success")
    {
        return new BaseResponse<T>
        {
            IsSuccess = true,
            Data = data,
            Message = message
        };
    }
    
    public static BaseResponse<T> Failure(string error)
    {
        return new BaseResponse<T>
        {
            IsSuccess = false,
            Errors = new List<string> { error }
        };
    }
}
```

### **Application/Services/ProductService.cs**

```csharp
public class ProductService : BaseService, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public ProductService(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<BaseResponse<ProductDto>> GetProductAsync(int id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return BaseResponse<ProductDto>.Failure("Product not found");
                
            var productDto = _mapper.Map<ProductDto>(product);
            return BaseResponse<ProductDto>.Success(productDto);
        }
        catch (Exception ex)
        {
            return BaseResponse<ProductDto>.Failure($"Error: {ex.Message}");
        }
    }
}
```

### **Infrastructure/Repositories/ProductRepository.cs**

```csharp
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }
    
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.Where(p => p.IsActive).ToListAsync();
    }
}
```

### **Api/Controllers/ProductsController.cs**

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<ProductDto>>> GetProduct(int id)
    {
        var response = await _productService.GetProductAsync(id);
        
        if (!response.IsSuccess)
            return BadRequest(response);
            
        return Ok(response);
    }
}
```

## 🎯 **Beneficios de esta Estructura**

1. **Separación Clara**: Cada capa maneja sus propias dependencias
2. **Fácil Testing**: Puedes testear cada capa independientemente
3. **Mantenibilidad**: Cambios en una capa no afectan otras
4. **Reutilización**: Commons/Base evita duplicación de código
5. **Principio de Responsabilidad Única**: Cada DependencyInjection tiene una responsabilidad específica
6. **Escalabilidad**: Fácil agregar nuevas funcionalidades
7. **Testabilidad**: Mockeo sencillo de dependencias
8. **Consistencia**: Respuestas uniformes a través de BaseResponse

## ✅ **Buenas Prácticas**

- Siempre usar interfaces para definir contratos
- Mantener el Domain libre de dependencias externas
- Usar DTO para transferencia de datos entre capas
- Implementar validaciones en Application
- Manejar excepciones de forma consistente
- Usar AutoMapper para mapeo automático
- Implementar Unit of Work para transacciones
- Seguir principios SOLID en todas las capas