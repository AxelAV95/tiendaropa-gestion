# Casos de Uso CQRS para Sistema de Tienda

## 📦 **PRODUCTOS Y VARIANTES**

### Commands

- **CreateProductCommand** - Crear producto base
- **UpdateProductCommand** - Actualizar información del producto
- **DeleteProductCommand** - Eliminar/desactivar producto
- **CreateProductVariantCommand** - Crear variante (talla/color)
- **UpdateProductVariantCommand** - Actualizar variante
- **DeleteProductVariantCommand** - Eliminar variante
- **UpdateProductStockCommand** - Actualizar stock directo
- **BulkUpdateProductPricesCommand** - Actualización masiva de precios

### Queries

- **GetProductByIdQuery** - Obtener producto específico
- **GetProductsQuery** - Listado con filtros (categoría, marca, estado)
- **GetProductVariantsQuery** - Variantes de un producto
- **GetProductsByCategoryQuery** - Productos por categoría
- **GetProductsByBrandQuery** - Productos por marca
- **GetLowStockProductsQuery** - Productos con stock bajo
- **SearchProductsQuery** - Búsqueda por nombre/código
- **GetProductVariantBySkuQuery** - Buscar por SKU
- **GetProductSalesHistoryQuery** - Historial de ventas del producto

## 🏷️ **CATEGORÍAS Y MARCAS**

### Commands

- **CreateCategoryCommand** - Crear categoría
- **UpdateCategoryCommand** - Actualizar categoría
- **DeleteCategoryCommand** - Eliminar categoría
- **CreateBrandCommand** - Crear marca
- **UpdateBrandCommand** - Actualizar marca
- **DeleteBrandCommand** - Eliminar marca

### Queries

- **GetAllCategoriesQuery** - Todas las categorías
- **GetAllBrandsQuery** - Todas las marcas
- **GetCategoryWithProductsQuery** - Categoría con sus productos
- **GetBrandWithProductsQuery** - Marca con sus productos

## 👥 **CLIENTES**

### Commands

- **CreateCustomerCommand** - Registrar cliente
- **UpdateCustomerCommand** - Actualizar información
- **DeleteCustomerCommand** - Eliminar/desactivar cliente
- **AddLoyaltyPointsCommand** - Añadir puntos de lealtad
- **RedeemLoyaltyPointsCommand** - Canjear puntos
- **UpdateCustomerTotalPurchasesCommand** - Actualizar total compras

### Queries

- **GetCustomerByIdQuery** - Cliente específico
- **GetCustomersQuery** - Listado con filtros
- **SearchCustomersByPhoneQuery** - Buscar por teléfono
- **SearchCustomersByEmailQuery** - Buscar por email
- **GetCustomerPurchaseHistoryQuery** - Historial de compras
- **GetTopCustomersQuery** - Mejores clientes por compras
- **GetCustomerLoyaltyPointsQuery** - Puntos disponibles
- **GetCustomersByBirthdayQuery** - Clientes por cumpleaños (marketing)

## 💰 **VENTAS**

### Commands

- **CreateSaleCommand** - Procesar venta completa
- **UpdateSaleStatusCommand** - Cambiar estado de venta
- **CancelSaleCommand** - Cancelar venta
- **AddSaleItemCommand** - Añadir item a venta
- **RemoveSaleItemCommand** - Remover item de venta
- **ApplySaleDiscountCommand** - Aplicar descuento
- **ProcessRefundCommand** - Procesar devolución

### Queries

- **GetSaleByIdQuery** - Venta específica con detalles
- **GetSalesQuery** - Listado con filtros (fecha, cliente, estado)
- **GetSalesByCustomerQuery** - Ventas de un cliente
- **GetSalesByDateRangeQuery** - Ventas por período
- **GetSalesByPaymentMethodQuery** - Ventas por método de pago
- **GetDailySalesReportQuery** - Reporte diario
- **GetMonthlySalesReportQuery** - Reporte mensual
- **GetSalesAnalyticsQuery** - Analytics de ventas
- **GetTopSellingProductsQuery** - Productos más vendidos
- **GetSaleReceiptQuery** - Recibo de venta para impresión

## 📊 **INVENTARIO**

### Commands

- **CreateInventoryMovementCommand** - Registrar movimiento
- **ProcessInventoryAdjustmentCommand** - Ajuste de inventario
- **ProcessStockEntryCommand** - Entrada de mercancía
- **ProcessStockExitCommand** - Salida de mercancía
- **BulkInventoryUpdateCommand** - Actualización masiva

### Queries

- **GetInventoryMovementsQuery** - Movimientos con filtros
- **GetProductCurrentStockQuery** - Stock actual de producto
- **GetInventoryMovementsByProductQuery** - Movimientos por producto
- **GetInventoryReportQuery** - Reporte de inventario
- **GetStockValuationQuery** - Valoración del inventario
- **GetInventoryMovementsByDateQuery** - Movimientos por fecha
- **GetLowStockReportQuery** - Reporte de stock bajo
- **GetInventoryTurnoverQuery** - Rotación de inventario

## 📈 **REPORTES Y ANALYTICS**

### Queries Especializadas

- **GetDashboardSummaryQuery** - Resumen para dashboard
- **GetSalesReportByPeriodQuery** - Ventas por período
- **GetProfitabilityReportQuery** - Reporte de rentabilidad
- **GetCustomerAnalyticsQuery** - Analytics de clientes
- **GetProductPerformanceQuery** - Rendimiento por producto
- **GetSeasonalTrendsQuery** - Tendencias estacionales
- **GetInventoryTurnoverReportQuery** - Rotación de inventario
- **GetPaymentMethodsReportQuery** - Reporte métodos de pago
- **GetLoyaltyProgramReportQuery** - Reporte programa lealtad

## 🎨 **ATRIBUTOS (TALLAS Y COLORES)**

### Commands

- **CreateSizeCommand** - Crear talla
- **UpdateSizeCommand** - Actualizar talla
- **DeleteSizeCommand** - Eliminar talla
- **CreateColorCommand** - Crear color
- **UpdateColorCommand** - Actualizar color
- **DeleteColorCommand** - Eliminar color

### Queries

- **GetAllSizesQuery** - Todas las tallas
- **GetAllColorsQuery** - Todos los colores
- **GetSizesByProductQuery** - Tallas disponibles por producto
- **GetColorsByProductQuery** - Colores disponibles por producto

## 💳 **CONFIGURACIÓN**

### Commands

- **CreatePaymentMethodCommand** - Crear método de pago
- **UpdatePaymentMethodCommand** - Actualizar método
- **CreateSaleStatusCommand** - Crear estado de venta
- **CreateMovementTypeCommand** - Crear tipo movimiento

### Queries

- **GetAllPaymentMethodsQuery** - Métodos de pago
- **GetAllSaleStatusesQuery** - Estados de venta
- **GetAllMovementTypesQuery** - Tipos de movimiento

## 🔍 **CASOS DE USO AVANZADOS**

### Queries Complejas Adicionales

- **GetProductRecommendationsQuery** - Recomendaciones basadas en historial
- **GetCustomerSegmentationQuery** - Segmentación de clientes
- **GetABCInventoryAnalysisQuery** - Análisis ABC de inventario
- **GetSeasonalForecastQuery** - Pronóstico estacional
- **GetCrossSellOpportunitiesQuery** - Oportunidades de venta cruzada
- **GetPriceOptimizationQuery** - Optimización de precios
- **GetInventoryPlanningQuery** - Planificación de inventario

## 📱 **CASOS DE USO PARA DIFERENTES INTERFACES**

### Para POS (Punto de Venta)

- **ProcessQuickSaleCommand** - Venta rápida
- **GetProductQuickSearchQuery** - Búsqueda rápida productos
- **GetCustomerQuickSearchQuery** - Búsqueda rápida clientes

### Para Gestión

- **GetManagerDashboardQuery** - Dashboard gerencial
- **GetOperationalMetricsQuery** - Métricas operacionales
- **GetComplianceReportQuery** - Reportes de cumplimiento

### Para Marketing

- **GetMarketingCampaignDataQuery** - Datos para campañas
- **GetCustomerLifetimeValueQuery** - Valor de vida del cliente
- **GetChurnAnalysisQuery** - Análisis de abandono

------

## 🎯 **PRIORIZACIÓN SUGERIDA**

### **Fase 1 - MVP:**

1. Productos (CRUD básico + búsquedas)
2. Clientes (CRUD básico + búsquedas)
3. Ventas (proceso completo)
4. Inventario básico (movimientos + stock actual)

### **Fase 2 - Operacional:**

1. Reportes básicos (ventas diarias/mensuales)
2. Gestión de stock bajo
3. Analytics básicos
4. Configuraciones

### **Fase 3 - Avanzado:**

1. Reportes avanzados
2. Analytics predictivos
3. Optimizaciones
4. Integraciones

Esta estructura te dará una aplicación robusta y escalable que aprovecha al máximo las relaciones de tu base de datos.