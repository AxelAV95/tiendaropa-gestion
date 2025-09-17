# Lista Completa de DTOs para Sistema de Tienda

## 📦 **PRODUCTOS**

### Request DTOs (Commands/Queries)

```csharp
// Commands
CreateProductRequestDto
UpdateProductRequestDto
CreateProductVariantRequestDto
UpdateProductVariantRequestDto
UpdateProductStockRequestDto
BulkUpdateProductPricesRequestDto

// Query Filters
ProductFilterDto
ProductSearchDto
```

### Response DTOs

```csharp
ProductDto                    // Producto básico
ProductDetailDto             // Producto con todas las relaciones
ProductVariantDto           // Variante individual
ProductWithVariantsDto     // Producto con sus variantes
ProductSummaryDto         // Resumen para listados
ProductStockDto          // Info específica de stock
ProductSalesHistoryDto   // Historial de ventas
LowStockProductDto      // Para alertas de stock bajo
```

## 🏷️ **CATEGORÍAS Y MARCAS**

### Request DTOs

```csharp
CreateCategoryRequestDto
UpdateCategoryRequestDto
CreateBrandRequestDto
UpdateBrandRequestDto
```

### Response DTOs

```csharp
CategoryDto                  // Categoría básica
CategoryWithProductsDto     // Categoría con productos
BrandDto                   // Marca básica
BrandWithProductsDto      // Marca con productos
CategorySummaryDto       // Para dropdowns
BrandSummaryDto         // Para dropdowns
```

## 🎨 **ATRIBUTOS (TALLAS Y COLORES)**

### Request DTOs

```csharp
CreateSizeRequestDto
UpdateSizeRequestDto
CreateColorRequestDto
UpdateColorRequestDto
```

### Response DTOs

```csharp
SizeDto
ColorDto
SizeWithProductsDto        // Talla con productos que la usan
ColorWithProductsDto       // Color con productos que lo usan
```

## 👥 **CLIENTES**

### Request DTOs

```csharp
CreateCustomerRequestDto
UpdateCustomerRequestDto
CustomerSearchDto
AddLoyaltyPointsRequestDto
RedeemLoyaltyPointsRequestDto
```

### Response DTOs

```csharp
CustomerDto                    // Cliente básico
CustomerDetailDto             // Cliente con info completa
CustomerSummaryDto           // Para listados y búsquedas
CustomerPurchaseHistoryDto   // Historial de compras
CustomerLoyaltyDto          // Info de programa de lealtad
TopCustomerDto             // Para rankings
CustomerAnalyticsDto       // Analytics del cliente
BirthdayCustomerDto       // Para campañas de cumpleaños
```

## 💰 **VENTAS**

### Request DTOs

```csharp
CreateSaleRequestDto
UpdateSaleStatusRequestDto
AddSaleItemRequestDto
RemoveSaleItemRequestDto
ApplySaleDiscountRequestDto
ProcessRefundRequestDto
SaleFilterDto
SalesReportFilterDto
```

### Response DTOs

```csharp
SaleDto                      // Venta básica
SaleDetailDto               // Venta con items completos
SaleItemDto                // Item individual de venta
SaleSummaryDto            // Para listados
SaleReceiptDto           // Para impresión de recibos
DailySalesReportDto     // Reporte diario
MonthlySalesReportDto   // Reporte mensual
SalesAnalyticsDto      // Analytics de ventas
TopSellingProductDto   // Productos más vendidos
PaymentMethodSalesDto  // Ventas por método de pago
```

## 📊 **INVENTARIO**

### Request DTOs

```csharp
CreateInventoryMovementRequestDto
ProcessInventoryAdjustmentRequestDto
ProcessStockEntryRequestDto
ProcessStockExitRequestDto
BulkInventoryUpdateRequestDto
InventoryMovementFilterDto
```

### Response DTOs

```csharp
InventoryMovementDto           // Movimiento individual
InventoryMovementDetailDto     // Movimiento con referencias
ProductStockDto               // Stock actual de producto
InventoryReportDto           // Reporte de inventario
StockValuationDto           // Valoración de stock
InventoryTurnoverDto        // Rotación de inventario
LowStockReportDto          // Reporte stock bajo
MovementTypeDto           // Tipo de movimiento
```

## 💳 **CONFIGURACIÓN**

### Request DTOs

```csharp
CreatePaymentMethodRequestDto
UpdatePaymentMethodRequestDto
CreateSaleStatusRequestDto
CreateMovementTypeRequestDto
```

### Response DTOs

```csharp
PaymentMethodDto
SaleStatusDto
MovementTypeDto
ConfigurationDto             // Configuraciones generales
```

## 📈 **REPORTES Y ANALYTICS**

### Request DTOs

```csharp
DashboardFilterDto
ReportPeriodFilterDto
ProfitabilityFilterDto
CustomerAnalyticsFilterDto
ProductPerformanceFilterDto
```

### Response DTOs

```csharp
DashboardSummaryDto          // Dashboard principal
SalesReportDto              // Reporte de ventas
ProfitabilityReportDto      // Reporte rentabilidad
CustomerAnalyticsReportDto   // Analytics clientes
ProductPerformanceReportDto  // Performance productos
SeasonalTrendsDto          // Tendencias estacionales
InventoryTurnoverReportDto  // Rotación inventario
LoyaltyProgramReportDto    // Reporte lealtad
```

## 🔍 **DTOs AVANZADOS**

### Analytics Predictivos

```csharp
ProductRecommendationDto     // Recomendaciones
CustomerSegmentDto          // Segmentación
ABCInventoryAnalysisDto     // Análisis ABC
SeasonalForecastDto        // Pronósticos
CrossSellOpportunityDto    // Venta cruzada
PriceOptimizationDto      // Optimización precios
InventoryPlanningDto      // Planificación inventario
```

### Para POS

```csharp
QuickSaleRequestDto         // Venta rápida
ProductQuickSearchDto       // Búsqueda rápida
CustomerQuickSearchDto      // Búsqueda cliente rápida
POSSessionDto              // Sesión de caja
```

## 📱 **DTOs ESPECÍFICOS POR INTERFAZ**

### Management Dashboard

```csharp
ManagerDashboardDto
OperationalMetricsDto
ComplianceReportDto
KPIDto                     // Key Performance Indicators
```

### Marketing

```csharp
MarketingCampaignDataDto
CustomerLifetimeValueDto
ChurnAnalysisDto
MarketingSegmentDto
```

## 🔄 **DTOs COMPARTIDOS/COMUNES**

### Base DTOs

```csharp
BaseEntityDto              // Id, CreatedAt, UpdatedAt
PaginatedResultDto<T>      // Para paginación
FilterBaseDto             // Filtros base
SortingDto               // Ordenamiento
```

### Validation DTOs

```csharp
ValidationErrorDto
ValidationResultDto
```

### Response Wrappers

```csharp
ApiResponseDto<T>         // Respuesta estándar API
ErrorResponseDto         // Respuestas de error
SuccessResponseDto      // Respuestas exitosas
```

## 🎯 **DTOs POR CASOS DE USO ESPECÍFICOS**

### E-commerce (si aplica)

```csharp
CartDto
CartItemDto
WishlistDto
ProductCatalogDto
```

### Auditoría

```csharp
AuditLogDto
UserActionDto
SystemEventDto
```

### Notificaciones

```csharp
NotificationDto
AlertDto
ReminderDto
```

## 📊 **DTOs DE MÉTRICAS**

```csharp
SalesMetricsDto
InventoryMetricsDto
CustomerMetricsDto
ProductMetricsDto
FinancialMetricsDto
OperationalMetricsDto
```

## 🔧 **DTOs DE UTILIDAD**

```csharp
DropdownItemDto           // Para listas desplegables
KeyValuePairDto          // Pares clave-valor genéricos
SelectListItemDto       // Items de selección
ChartDataDto           // Datos para gráficos
ExportDataDto         // Para exportaciones
ImportResultDto       // Resultado de importaciones
```

------

## 📋 **ORGANIZACIÓN SUGERIDA EN CARPETAS**

```
DTOs/
├── Common/              // DTOs compartidos
├── Products/           // Productos y variantes
├── Customers/         // Clientes
├── Sales/            // Ventas
├── Inventory/       // Inventario
├── Configuration/  // Configuraciones
├── Reports/       // Reportes
├── Analytics/    // Analytics
├── POS/         // Punto de venta
└── Validation/  // Validaciones
```

## 🎯 **PRIORIZACIÓN**

### **Fase 1 - Esenciales:**

- Todos los DTOs de Products, Customers, Sales básicos
- DTOs de configuración (PaymentMethod, SaleStatus)
- DTOs comunes (BaseEntity, PaginatedResult, ApiResponse)

### **Fase 2 - Operacionales:**

- DTOs de Inventory
- DTOs de Reports básicos
- DTOs de Analytics básicos

### **Fase 3 - Avanzados:**

- DTOs de Analytics predictivos
- DTOs de Marketing
- DTOs especializados por interfaz

Esta estructura te dará flexibilidad y mantenibilidad en tu aplicación, siguiendo las mejores prácticas de Clean Architecture.