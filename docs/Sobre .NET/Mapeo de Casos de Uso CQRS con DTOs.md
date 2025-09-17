# Mapeo de Casos de Uso CQRS con DTOs

## 📦 **PRODUCTOS Y VARIANTES**

### Commands

| Command                            | Input DTO                           | Output DTO                |
| ---------------------------------- | ----------------------------------- | ------------------------- |
| **CreateProductCommand**           | `CreateProductRequestDto`           | `ProductDto`              |
| **UpdateProductCommand**           | `UpdateProductRequestDto`           | `ProductDto`              |
| **DeleteProductCommand**           | `int productId`                     | `bool` o `ApiResponseDto` |
| **CreateProductVariantCommand**    | `CreateProductVariantRequestDto`    | `ProductVariantDto`       |
| **UpdateProductVariantCommand**    | `UpdateProductVariantRequestDto`    | `ProductVariantDto`       |
| **DeleteProductVariantCommand**    | `int variantId`                     | `bool` o `ApiResponseDto` |
| **UpdateProductStockCommand**      | `UpdateProductStockRequestDto`      | `ProductStockDto`         |
| **BulkUpdateProductPricesCommand** | `BulkUpdateProductPricesRequestDto` | `List<ProductDto>`        |

### Queries

| Query                           | Input DTO                       | Output DTO                              |
| ------------------------------- | ------------------------------- | --------------------------------------- |
| **GetProductByIdQuery**         | `int productId`                 | `ProductDetailDto`                      |
| **GetProductsQuery**            | `ProductFilterDto`              | `PaginatedResultDto<ProductSummaryDto>` |
| **GetProductVariantsQuery**     | `int productId`                 | `List<ProductVariantDto>`               |
| **GetProductsByCategoryQuery**  | `int categoryId, PaginationDto` | `PaginatedResultDto<ProductSummaryDto>` |
| **GetProductsByBrandQuery**     | `int brandId, PaginationDto`    | `PaginatedResultDto<ProductSummaryDto>` |
| **GetLowStockProductsQuery**    | `int minStock?`                 | `List<LowStockProductDto>`              |
| **SearchProductsQuery**         | `ProductSearchDto`              | `PaginatedResultDto<ProductSummaryDto>` |
| **GetProductVariantBySkuQuery** | `string sku`                    | `ProductVariantDto`                     |
| **GetProductSalesHistoryQuery** | `int productId, DateRangeDto`   | `ProductSalesHistoryDto`                |

------

## 🏷️ **CATEGORÍAS Y MARCAS**

### Commands

| Command                   | Input DTO                  | Output DTO    |
| ------------------------- | -------------------------- | ------------- |
| **CreateCategoryCommand** | `CreateCategoryRequestDto` | `CategoryDto` |
| **UpdateCategoryCommand** | `UpdateCategoryRequestDto` | `CategoryDto` |
| **DeleteCategoryCommand** | `int categoryId`           | `bool`        |
| **CreateBrandCommand**    | `CreateBrandRequestDto`    | `BrandDto`    |
| **UpdateBrandCommand**    | `UpdateBrandRequestDto`    | `BrandDto`    |
| **DeleteBrandCommand**    | `int brandId`              | `bool`        |

### Queries

| Query                            | Input DTO        | Output DTO                |
| -------------------------------- | ---------------- | ------------------------- |
| **GetAllCategoriesQuery**        | -                | `List<CategoryDto>`       |
| **GetAllBrandsQuery**            | -                | `List<BrandDto>`          |
| **GetCategoryWithProductsQuery** | `int categoryId` | `CategoryWithProductsDto` |
| **GetBrandWithProductsQuery**    | `int brandId`    | `BrandWithProductsDto`    |

------

## 👥 **CLIENTES**

### Commands

| Command                                 | Input DTO                        | Output DTO           |
| --------------------------------------- | -------------------------------- | -------------------- |
| **CreateCustomerCommand**               | `CreateCustomerRequestDto`       | `CustomerDto`        |
| **UpdateCustomerCommand**               | `UpdateCustomerRequestDto`       | `CustomerDto`        |
| **DeleteCustomerCommand**               | `int customerId`                 | `bool`               |
| **AddLoyaltyPointsCommand**             | `AddLoyaltyPointsRequestDto`     | `CustomerLoyaltyDto` |
| **RedeemLoyaltyPointsCommand**          | `RedeemLoyaltyPointsRequestDto`  | `CustomerLoyaltyDto` |
| **UpdateCustomerTotalPurchasesCommand** | `int customerId, decimal amount` | `CustomerDto`        |

### Queries

| Query                               | Input DTO                       | Output DTO                               |
| ----------------------------------- | ------------------------------- | ---------------------------------------- |
| **GetCustomerByIdQuery**            | `int customerId`                | `CustomerDetailDto`                      |
| **GetCustomersQuery**               | `CustomerFilterDto`             | `PaginatedResultDto<CustomerSummaryDto>` |
| **SearchCustomersByPhoneQuery**     | `string phone`                  | `List<CustomerSummaryDto>`               |
| **SearchCustomersByEmailQuery**     | `string email`                  | `List<CustomerSummaryDto>`               |
| **GetCustomerPurchaseHistoryQuery** | `int customerId, PaginationDto` | `CustomerPurchaseHistoryDto`             |
| **GetTopCustomersQuery**            | `int topCount, DateRangeDto?`   | `List<TopCustomerDto>`                   |
| **GetCustomerLoyaltyPointsQuery**   | `int customerId`                | `CustomerLoyaltyDto`                     |
| **GetCustomersByBirthdayQuery**     | `DateRangeDto`                  | `List<BirthdayCustomerDto>`              |

------

## 💰 **VENTAS**

### Commands

| Command                      | Input DTO                     | Output DTO      |
| ---------------------------- | ----------------------------- | --------------- |
| **CreateSaleCommand**        | `CreateSaleRequestDto`        | `SaleDetailDto` |
| **UpdateSaleStatusCommand**  | `UpdateSaleStatusRequestDto`  | `SaleDto`       |
| **CancelSaleCommand**        | `int saleId, string reason`   | `SaleDto`       |
| **AddSaleItemCommand**       | `AddSaleItemRequestDto`       | `SaleItemDto`   |
| **RemoveSaleItemCommand**    | `RemoveSaleItemRequestDto`    | `bool`          |
| **ApplySaleDiscountCommand** | `ApplySaleDiscountRequestDto` | `SaleDto`       |
| **ProcessRefundCommand**     | `ProcessRefundRequestDto`     | `SaleDto`       |

### Queries

| Query                            | Input DTO                           | Output DTO                           |
| -------------------------------- | ----------------------------------- | ------------------------------------ |
| **GetSaleByIdQuery**             | `int saleId`                        | `SaleDetailDto`                      |
| **GetSalesQuery**                | `SaleFilterDto`                     | `PaginatedResultDto<SaleSummaryDto>` |
| **GetSalesByCustomerQuery**      | `int customerId, PaginationDto`     | `PaginatedResultDto<SaleSummaryDto>` |
| **GetSalesByDateRangeQuery**     | `DateRangeDto`                      | `List<SaleSummaryDto>`               |
| **GetSalesByPaymentMethodQuery** | `int paymentMethodId, DateRangeDto` | `PaymentMethodSalesDto`              |
| **GetDailySalesReportQuery**     | `DateTime date`                     | `DailySalesReportDto`                |
| **GetMonthlySalesReportQuery**   | `int year, int month`               | `MonthlySalesReportDto`              |
| **GetSalesAnalyticsQuery**       | `SalesReportFilterDto`              | `SalesAnalyticsDto`                  |
| **GetTopSellingProductsQuery**   | `int topCount, DateRangeDto`        | `List<TopSellingProductDto>`         |
| **GetSaleReceiptQuery**          | `int saleId`                        | `SaleReceiptDto`                     |

------

## 📊 **INVENTARIO**

### Commands

| Command                               | Input DTO                              | Output DTO                   |
| ------------------------------------- | -------------------------------------- | ---------------------------- |
| **CreateInventoryMovementCommand**    | `CreateInventoryMovementRequestDto`    | `InventoryMovementDto`       |
| **ProcessInventoryAdjustmentCommand** | `ProcessInventoryAdjustmentRequestDto` | `List<InventoryMovementDto>` |
| **ProcessStockEntryCommand**          | `ProcessStockEntryRequestDto`          | `InventoryMovementDto`       |
| **ProcessStockExitCommand**           | `ProcessStockExitRequestDto`           | `InventoryMovementDto`       |
| **BulkInventoryUpdateCommand**        | `BulkInventoryUpdateRequestDto`        | `List<InventoryMovementDto>` |

### Queries

| Query                                   | Input DTO                             | Output DTO                                 |
| --------------------------------------- | ------------------------------------- | ------------------------------------------ |
| **GetInventoryMovementsQuery**          | `InventoryMovementFilterDto`          | `PaginatedResultDto<InventoryMovementDto>` |
| **GetProductCurrentStockQuery**         | `int productVariantId`                | `ProductStockDto`                          |
| **GetInventoryMovementsByProductQuery** | `int productVariantId, PaginationDto` | `List<InventoryMovementDetailD             |