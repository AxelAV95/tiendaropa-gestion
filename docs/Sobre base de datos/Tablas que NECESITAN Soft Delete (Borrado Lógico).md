### Tablas que **NECESITAN** Soft Delete (Borrado Lógico)



Para estas tablas, eliminar un registro físicamente sería perjudicial para el historial, los reportes y la integridad de los datos. La buena noticia es que ya has incluido los campos perfectos para implementar esto.

1. **`Users`**
   - **Recomendación:** **Soft Delete**.
   - **Campo a Utilizar:** `IsActive` (BOOLEAN).
   - **Justificación:** Un usuario (empleado) puede ser desactivado si deja de trabajar en la tienda, pero sus registros históricos son vitales. Necesitas saber qué usuario procesó una venta (`Sales.ManagerUserId`) o realizó un movimiento de inventario (`InventoryMovements.UserId`) en el pasado. Borrarlo físicamente dejaría esos registros "huérfanos" y sin auditoría.
2. **`Products`**
   - **Recomendación:** **Soft Delete**.
   - **Campo a Utilizar:** `Status` (NVARCHAR(50)).
   - **Justificación:** Un producto puede ser descontinuado, pero nunca debe ser eliminado si ya ha sido parte de ventas pasadas. Si borras un producto, no podrías generar reportes de ventas históricos que incluyan el nombre o la categoría de ese producto. Cambiar el `Status` a `'Discontinued'` es la práctica correcta.
3. **`ProductVariants`**
   - **Recomendación:** **Soft Delete**.
   - **Campo a Utilizar:** `IsActive` (BIT).
   - **Justificación:** Al igual que con los productos, las variantes (talla/color) están directamente ligadas a los ítems de una venta (`SaleItems`) y a los movimientos de inventario. Son cruciales para el historial. Desactivar una variante significa que ya no está a la venta, pero todos sus registros pasados se mantienen intactos.
4. **`Customers`**
   - **Recomendación:** **Soft Delete**.
   - **Campo a Utilizar:** `IsActive` (BIT).
   - **Justificación:** El historial de compras de un cliente es uno de los activos más importantes. Si un cliente solicita ser eliminado, lo correcto es desactivar su cuenta para mantener la integridad de las ventas (`Sales`) que realizó. Esto preserva los datos para análisis y contabilidad.
5. **`Sales`**
   - **Recomendación:** **Soft Delete**.
   - **Campo a Utilizar:** `Status` (NVARCHAR(50)).
   - **Justificación:** Las ventas son registros transaccionales que nunca deben ser eliminados. Una venta no se "borra", se "cancela" o se "devuelve" (`Cancelled`, `Refunded`). El campo `Status` maneja perfectamente el ciclo de vida de una venta sin perder jamás el registro de que la transacción existió.



### Tablas donde **Hard Delete** es Aceptable



Estas tablas contienen datos cuyo ciclo de vida está completamente atado a su "padre". Si el padre es modificado de cierta manera, el borrado físico de estos registros es a menudo la opción más limpia.

1. **`SaleItems`**
   - **Recomendación:** **Hard Delete**.
   - **Justificación:** Un `SaleItem` es un detalle de una `Sale`. No tiene sentido "desactivar" un solo ítem de una venta ya completada. Si un cliente devuelve un producto, la acción correcta no es borrar el `SaleItem`, sino crear un movimiento de inventario de tipo `Return` y posiblemente actualizar el estado de la `Sale` a `Refunded`. El `SaleItem` se queda como evidencia de la venta original. El borrado físico solo aplicaría si se está modificando una venta *antes* de ser completada (como quitar un producto del carrito).



### Tablas que Deberían ser **Inmutables** (Ni Hard ni Soft Delete)



Estas tablas actúan como un libro contable (`ledger`). Su propósito es registrar eventos que ocurrieron. No se borran, y rara vez se actualizan.

1. **`InventoryMovements`**
   - **Recomendación:** **Tratar como Inmutable**.
   - **Justificación:** Esta tabla es tu libro de auditoría de inventario. Cada registro es un hecho: una venta ocurrió, se recibió una compra, se hizo un ajuste. Si se comete un error, la práctica contable correcta no es borrar el registro erróneo, sino **crear un nuevo movimiento que lo revierta o corrija**. Por ejemplo, un ajuste negativo para compensar una entrada incorrecta. Eliminar un movimiento de inventario sería como arrancar una página del libro contable.



### Resumen



| Tabla                 | Estrategia de Borrado Recomendada | Campo a Utilizar para Soft Delete |
| --------------------- | --------------------------------- | --------------------------------- |
| **`Users`**           | **Soft Delete**                   | `IsActive`                        |
| **`Products`**        | **Soft Delete**                   | `Status`                          |
| **`ProductVariants`** | **Soft Delete**                   | `IsActive`                        |
| **`Customers`**       | **Soft Delete**                   | `IsActive`                        |
| **`Sales`**           | **Soft Delete**                   | `Status`                          |
| `SaleItems`           | Hard Delete                       | N/A                               |
| `InventoryMovements`  | Inmutable (No se borra)           | N/A                               |

Para implementar esto eficazmente en tu aplicación ASP.NET Core, te recomiendo usar los **Global Query Filters** de Entity Framework Core, como discutimos anteriormente. De esta forma, puedes configurar tu `DbContext` para que automáticamente excluya los registros con `IsActive = false` o `Status = 'Discontinued'` de todas tus consultas.

