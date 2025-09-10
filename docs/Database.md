## Esquema Lógico de Base de Datos para Tienda de Ropa Boutique

El sistema principal se basa en una arquitectura de microservicios. El **Microservicio de Autenticación** (construido con Spring Boot) gestionará la tabla `Users` en su propia base de datos, mientras que el **Microservicio de Lógica de Negocio** (ASP.NET Core) manejará las tablas `Products`, `ProductVariants`, `Sales`, `SaleItems`, `Customers` e `InventoryMovements` en una base de datos separada.

------

## 1. Microservicio de Autenticación (Spring Boot)

Este microservicio gestionará únicamente la información de los usuarios que acceden al sistema. Tendrá su propia base de datos.

### Tabla: `Users`

| Columna        | Tipo de Dato   | Restricciones                   | Descripción                                        |
| -------------- | -------------- | ------------------------------- | -------------------------------------------------- |
| `Id`           | `BIGINT`       | `PRIMARY KEY`, `AUTO_INCREMENT` | Identificador único del usuario.                   |
| `Email`        | `VARCHAR(255)` | `UNIQUE`, `NOT NULL`            | Correo electrónico del usuario (para login).       |
| `PasswordHash` | `VARCHAR(255)` | `NOT NULL`                      | Hash seguro de la contraseña.                      |
| `FirstName`    | `VARCHAR(100)` | `NOT NULL`                      | Nombre del usuario.                                |
| `LastName`     | `VARCHAR(100)` | `NOT NULL`                      | Apellido del usuario.                              |
| `Phone`        | `VARCHAR(20)`  | `NULLABLE`                      | Número de teléfono de contacto.                    |
| `Role`         | `VARCHAR(50)`  | `NOT NULL`, `DEFAULT 'Manager'` | Rol del usuario en el sistema.                     |
| `IsActive`     | `BOOLEAN`      | `NOT NULL`, `DEFAULT TRUE`      | Indica si la cuenta del usuario está activa.       |
| `CreatedAt`    | `DATETIME`     | `NOT NULL`                      | Fecha y hora de creación del registro.             |
| `UpdatedAt`    | `DATETIME`     | `NOT NULL`                      | Última fecha y hora de actualización del registro. |

------

## 2. Microservicio de Lógica de Negocio (ASP.NET Core)

Este microservicio gestionará la información central de la tienda: productos, inventario, ventas y clientes. Las referencias al `UserId` se harán utilizando el ID proporcionado por el Microservicio de Autenticación, pero no se mantendrá una clave foránea física directamente, sino una referencia lógica.

### Tabla: `Products`

| Columna       | Tipo de Dato    | Restricciones                   | Descripción                                         |
| ------------- | --------------- | ------------------------------- | --------------------------------------------------- |
| `Id`          | `INT`           | `PRIMARY KEY`, `IDENTITY(1,1)`  | Identificador único del producto.                   |
| `Code`        | `NVARCHAR(50)`  | `NOT NULL`, `UNIQUE`, `INDEXED` | Código único del producto (SKU base).               |
| `Name`        | `NVARCHAR(200)` | `NOT NULL`, `INDEXED`           | Nombre del producto.                                |
| `Description` | `NVARCHAR(MAX)` | `NULLABLE`                      | Descripción detallada del producto.                 |
| `Category`    | `NVARCHAR(100)` | `NOT NULL`, `INDEXED`           | Categoría del producto (ej. Camisetas, Pantalones). |
| `Brand`       | `NVARCHAR(100)` | `NULLABLE`                      | Marca del producto.                                 |
| `BasePrice`   | `DECIMAL(10,2)` | `NOT NULL`                      | Precio base del producto.                           |
| `MinStock`    | `INT`           | `NOT NULL`, `DEFAULT 5`         | Stock mínimo para generar alertas.                  |
| `Status`      | `NVARCHAR(50)`  | `NOT NULL`, `DEFAULT 'Active'`  | Estado del producto (Active, Discontinued).         |
| `ImageUrl`    | `NVARCHAR(500)` | `NULLABLE`                      | URL de la imagen principal del producto.            |
| `CreatedAt`   | `DATETIME`      | `NOT NULL`                      | Fecha y hora de creación del registro.              |
| `UpdatedAt`   | `DATETIME`      | `NOT NULL`                      | Última fecha y hora de actualización del registro.  |

### Tabla: `ProductVariants`

| Columna         | Tipo de Dato    | Restricciones                           | Descripción                                        |
| --------------- | --------------- | --------------------------------------- | -------------------------------------------------- |
| `Id`            | `INT`           | `PRIMARY KEY`, `IDENTITY(1,1)`          | Identificador único de la variante.                |
| `ProductId`     | `INT`           | `NOT NULL`, `FOREIGN KEY (Products.Id)` | Identificador del producto padre.                  |
| `Size`          | `NVARCHAR(20)`  | `NULLABLE`                              | Talla del producto (S, M, L, XL, etc.).            |
| `Color`         | `NVARCHAR(50)`  | `NULLABLE`                              | Color de la variante.                              |
| `SKU`           | `NVARCHAR(100)` | `NOT NULL`, `UNIQUE`, `INDEXED`         | Código único de la variante (SKU completo).        |
| `StockQuantity` | `INT`           | `NOT NULL`, `DEFAULT 0`                 | Cantidad actual en stock de esta variante.         |
| `PriceModifier` | `DECIMAL(10,2)` | `DEFAULT 0.00`                          | Modificador de precio respecto al precio base.     |
| `IsActive`      | `BIT`           | `NOT NULL`, `DEFAULT 1`                 | Indica si la variante está activa para venta.      |
| `CreatedAt`     | `DATETIME`      | `NOT NULL`                              | Fecha y hora de creación del registro.             |
| `UpdatedAt`     | `DATETIME`      | `NOT NULL`                              | Última fecha y hora de actualización del registro. |

### Tabla: `Customers`

| Columna          | Tipo de Dato    | Restricciones                  | Descripción                                        |
| ---------------- | --------------- | ------------------------------ | -------------------------------------------------- |
| `Id`             | `INT`           | `PRIMARY KEY`, `IDENTITY(1,1)` | Identificador único del cliente.                   |
| `FirstName`      | `NVARCHAR(100)` | `NOT NULL`                     | Nombre del cliente.                                |
| `LastName`       | `NVARCHAR(100)` | `NOT NULL`                     | Apellido del cliente.                              |
| `Phone`          | `NVARCHAR(20)`  | `NOT NULL`, `INDEXED`          | Número de teléfono principal del cliente.          |
| `Email`          | `NVARCHAR(255)` | `NULLABLE`, `INDEXED`          | Correo electrónico del cliente.                    |
| `BirthDate`      | `DATE`          | `NULLABLE`                     | Fecha de nacimiento del cliente.                   |
| `LoyaltyPoints`  | `INT`           | `NOT NULL`, `DEFAULT 0`        | Puntos de fidelidad acumulados.                    |
| `TotalPurchases` | `DECIMAL(12,2)` | `NOT NULL`, `DEFAULT 0.00`     | Total acumulado de compras del cliente.            |
| `PreferredSize`  | `NVARCHAR(20)`  | `NULLABLE`                     | Talla preferida del cliente.                       |
| `IsActive`       | `BIT`           | `NOT NULL`, `DEFAULT 1`        | Indica si el cliente está activo.                  |
| `CreatedAt`      | `DATETIME`      | `NOT NULL`                     | Fecha y hora de registro del cliente.              |
| `UpdatedAt`      | `DATETIME`      | `NOT NULL`                     | Última fecha y hora de actualización del registro. |

### Tabla: `Sales`

| Columna            | Tipo de Dato    | Restricciones                            | Descripción                                                  |
| ------------------ | --------------- | ---------------------------------------- | ------------------------------------------------------------ |
| `Id`               | `INT`           | `PRIMARY KEY`, `IDENTITY(1,1)`           | Identificador único de la venta.                             |
| `CustomerId`       | `INT`           | `NULLABLE`, `FOREIGN KEY (Customers.Id)` | Identificador del cliente (opcional para ventas anónimas).   |
| `ManagerUserId`    | `BIGINT`        | `NOT NULL`                               | **Referencia lógica al `Id` del `Users` del Microservicio de Autenticación**. Usuario que procesó la venta. |
| `SaleDate`         | `DATETIME`      | `NOT NULL`                               | Fecha y hora de la venta.                                    |
| `SubtotalAmount`   | `DECIMAL(12,2)` | `NOT NULL`                               | Subtotal de la venta (sin impuestos ni descuentos).          |
| `DiscountAmount`   | `DECIMAL(12,2)` | `NOT NULL`, `DEFAULT 0.00`               | Monto total de descuentos aplicados.                         |
| `TaxAmount`        | `DECIMAL(12,2)` | `NOT NULL`, `DEFAULT 0.00`               | Monto de impuestos aplicados.                                |
| `TotalAmount`      | `DECIMAL(12,2)` | `NOT NULL`                               | Total final de la venta.                                     |
| `PaymentMethod`    | `NVARCHAR(50)`  | `NOT NULL`                               | Método de pago (Cash, Card, Transfer, etc.).                 |
| `PaymentReference` | `NVARCHAR(100)` | `NULLABLE`                               | Referencia del pago (número de transacción, etc.).           |
| `Status`           | `NVARCHAR(50)`  | `NOT NULL`, `DEFAULT 'Completed'`        | Estado de la venta (Completed, Refunded, Cancelled).         |
| `Notes`            | `NVARCHAR(MAX)` | `NULLABLE`                               | Notas adicionales sobre la venta.                            |
| `CreatedAt`        | `DATETIME`      | `NOT NULL`                               | Fecha y hora de creación del registro.                       |
| `UpdatedAt`        | `DATETIME`      | `NOT NULL`                               | Última fecha y hora de actualización del registro.           |

### Tabla: `SaleItems`

| Columna            | Tipo de Dato    | Restricciones                                  | Descripción                                        |
| ------------------ | --------------- | ---------------------------------------------- | -------------------------------------------------- |
| `Id`               | `INT`           | `PRIMARY KEY`, `IDENTITY(1,1)`                 | Identificador único del ítem de venta.             |
| `SaleId`           | `INT`           | `NOT NULL`, `FOREIGN KEY (Sales.Id)`           | Identificador de la venta a la que pertenece.      |
| `ProductVariantId` | `INT`           | `NOT NULL`, `FOREIGN KEY (ProductVariants.Id)` | Identificador de la variante del producto vendida. |
| `Quantity`         | `INT`           | `NOT NULL`                                     | Cantidad vendida de esta variante.                 |
| `UnitPrice`        | `DECIMAL(10,2)` | `NOT NULL`                                     | Precio unitario al momento de la venta.            |
| `DiscountPercent`  | `DECIMAL(5,2)`  | `DEFAULT 0.00`                                 | Porcentaje de descuento aplicado al ítem.          |
| `Subtotal`         | `DECIMAL(10,2)` | `NOT NULL`                                     | Subtotal del ítem (cantidad × precio × descuento). |
| `CreatedAt`        | `DATETIME`      | `NOT NULL`                                     | Fecha y hora de creación del registro.             |

### Tabla: `InventoryMovements`

| Columna            | Tipo de Dato    | Restricciones                                  | Descripción                                                 |
| ------------------ | --------------- | ---------------------------------------------- | ----------------------------------------------------------- |
| `Id`               | `INT`           | `PRIMARY KEY`, `IDENTITY(1,1)`                 | Identificador único del movimiento.                         |
| `ProductVariantId` | `INT`           | `NOT NULL`, `FOREIGN KEY (ProductVariants.Id)` | Identificador de la variante afectada.                      |
| `MovementType`     | `NVARCHAR(50)`  | `NOT NULL`                                     | Tipo de movimiento (Purchase, Sale, Adjustment, Return).    |
| `Quantity`         | `INT`           | `NOT NULL`                                     | Cantidad del movimiento (positiva o negativa).              |
| `ReferenceType`    | `NVARCHAR(50)`  | `NULLABLE`                                     | Tipo de referencia (Sale, Purchase, Manual).                |
| `ReferenceId`      | `INT`           | `NULLABLE`                                     | ID de referencia (SaleId, PurchaseId, etc.).                |
| `Reason`           | `NVARCHAR(200)` | `NULLABLE`                                     | Razón del movimiento.                                       |
| `Notes`            | `NVARCHAR(MAX)` | `NULLABLE`                                     | Notas adicionales sobre el movimiento.                      |
| `UserId`           | `BIGINT`        | `NOT NULL`                                     | **Referencia lógica al usuario que realizó el movimiento**. |
| `MovementDate`     | `DATETIME`      | `NOT NULL`                                     | Fecha y hora del movimiento.                                |
| `CreatedAt`        | `DATETIME`      | `NOT NULL`                                     | Fecha y hora de creación del registro.                      |

------

## Relaciones Entre Tablas

Dada la arquitectura de microservicios, las relaciones se gestionan de la siguiente manera:

### Relaciones dentro del Microservicio de Lógica de Negocio:

- **`Products` (Uno) a `ProductVariants` (Muchos)**
  - Un producto puede tener múltiples variantes (tallas/colores).
  - `ProductVariants.ProductId` es una clave foránea que referencia a `Products.Id`.
- **`Customers` (Uno) a `Sales` (Muchos)**
  - Un cliente puede tener múltiples ventas.
  - `Sales.CustomerId` es una clave foránea que referencia a `Customers.Id`.
- **`Sales` (Uno) a `SaleItems` (Muchos)**
  - Una venta puede tener múltiples ítems.
  - `SaleItems.SaleId` es una clave foránea que referencia a `Sales.Id`.
- **`ProductVariants` (Uno) a `SaleItems` (Muchos)**
  - Una variante de producto puede aparecer en múltiples ítems de venta.
  - `SaleItems.ProductVariantId` es una clave foránea que referencia a `ProductVariants.Id`.
- **`ProductVariants` (Uno) a `InventoryMovements` (Muchos)**
  - Una variante de producto puede tener múltiples movimientos de inventario.
  - `InventoryMovements.ProductVariantId` es una clave foránea que referencia a `ProductVariants.Id`.

### Relación entre Microservicios:

- **`Users` (Microservicio de Autenticación) a `Sales` (Microservicio de Lógica de Negocio)**
  - Un usuario puede procesar muchas ventas.
  - La relación aquí es **lógica** a través del campo `Sales.ManagerUserId`.
- **`Users` (Microservicio de Autenticación) a `InventoryMovements` (Microservicio de Lógica de Negocio)**
  - Un usuario puede realizar muchos movimientos de inventario.
  - La relación aquí es **lógica** a través del campo `InventoryMovements.UserId`.

### Nota sobre Integridad Referencial entre Microservicios:

Las referencias a `UserId` en las tablas `Sales` e `InventoryMovements` no son claves foráneas físicas. La integridad referencial se gestiona a nivel de aplicación mediante llamadas a la API del Microservicio de Autenticación para validar IDs de usuario.

------

## Índices Recomendados

Para optimizar el rendimiento, se recomienda crear los siguientes índices adicionales:

### Microservicio de Autenticación:

- `IX_Users_Email` (ya incluido por UNIQUE)
- `IX_Users_Role_IsActive` (índice compuesto)

### Microservicio de Lógica de Negocio:

- `IX_Products_Category_Status` (índice compuesto)
- `IX_ProductVariants_ProductId_IsActive` (índice compuesto)
- `IX_ProductVariants_SKU` (ya incluido por UNIQUE)
- `IX_Sales_SaleDate` (para reportes por fecha)
- `IX_Sales_CustomerId_SaleDate` (índice compuesto)
- `IX_SaleItems_ProductVariantId` (para análisis de productos)
- `IX_InventoryMovements_ProductVariantId_MovementDate` (índice compuesto)
- `IX_Customers_Phone` (ya incluido por INDEXED)
- `IX_Customers_Email` (ya incluido por INDEXED)

------

## Consideraciones de Diseño

1. **Separación de Responsabilidades**: Cada microservicio tiene su propia base de datos con tablas específicas a su dominio.
2. **Escalabilidad**: Las tablas están diseñadas para manejar grandes volúmenes de transacciones y productos.
3. **Auditoría**: Todas las tablas incluyen `CreatedAt` y `UpdatedAt` para trazabilidad.
4. **Flexibilidad**: El diseño permite múltiples variantes por producto y diferentes tipos de movimientos de inventario.
5. **Integridad de Datos**: Se utilizan constraints apropiados y tipos de datos optimizados para cada campo.
6. **Performance**: Los índices están estratégicamente ubicados en campos de búsqueda y join frecuentes.
