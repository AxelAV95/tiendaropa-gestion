/*
 =================================================================================
 SEED DATA SCRIPT PARA TIENDA DE ROPA (tiendadb)
 =================================================================================
 Este script puebla las tablas con datos iniciales de ejemplo.
 Ejecutar después de haber creado la estructura completa de la base de datos.
*/

-- Usar la base de datos correcta
USE tiendadb;
GO

-- 1. Poblar tablas de Catálogo (Lookup Tables)
-- =================================================================================

PRINT 'Poblando tablas de catálogo...';

INSERT INTO Categories (Name) VALUES
('Camisetas'), ('Pantalones'), ('Zapatos'), ('Accesorios'), ('Ropa de Mujer'), ('Ropa de Hombre');

INSERT INTO Brands (Name) VALUES
('K-Dnal'), ('Aca Joe CR'), ('Imperio Urbano'), ('Costanera Fit'), ('Volcán Activewear'), ('Generica');

INSERT INTO Sizes (Name) VALUES
('XS'), ('S'), ('M'), ('L'), ('XL'), ('XXL');

INSERT INTO Colors (Name, HexCode) VALUES
('Rojo', '#FF0000'), ('Azul', '#0000FF'), ('Negro', '#000000'), ('Blanco', '#FFFFFF'), ('Verde', '#008000'), ('Gris', '#808080');

INSERT INTO PaymentMethods (Name) VALUES
('Tarjeta de Crédito/Débito'), ('SINPE Móvil'), ('Efectivo'), ('Transferencia Bancaria');

INSERT INTO SaleStatuses (Name) VALUES
('Completada'), ('Pendiente de Pago'), ('Cancelada'), ('En Proceso'), ('Devuelta');

INSERT INTO MovementTypes (Name, Description) VALUES
('Compra a Proveedor', 'Entrada de inventario por compra.'),
('Venta a Cliente', 'Salida de inventario por una venta.'),
('Devolución de Cliente', 'Entrada de inventario por devolución de una venta.'),
('Ajuste Manual - Positivo', 'Entrada de inventario por conteo o corrección.'),
('Ajuste Manual - Negativo', 'Salida de inventario por merma, daño o corrección.');
GO

-- 2. Poblar tablas de Entidades Principales
-- =================================================================================

PRINT 'Poblando tablas de entidades principales (Users, Customers, Products)...';

-- Crear un usuario Manager de ejemplo
INSERT INTO Users (Email, PasswordHash, FirstName, LastName, Phone, Role) VALUES
('manager@tienda.com', 'HASH_DE_PRUEBA_SUPER_SEGURO_ABC123', 'Ana', 'Rojas', '8888-8888', 'Manager');

-- Crear un cliente de ejemplo
INSERT INTO Customers (FirstName, LastName, Phone, Email, PreferredSizeId) VALUES
('Carlos', 'Solis', '7777-7777', 'carlos.solis@email.com', (SELECT Id FROM Sizes WHERE Name = 'L'));

-- Crear un producto de ejemplo
INSERT INTO Products (Code, Name, Description, CategoryId, BrandId, BasePrice, MinStock, Status) VALUES
('CAM-IMP-001', 'Camiseta Gráfica Volcán', 'Camiseta de algodón con diseño del Volcán Arenal.', 
(SELECT Id FROM Categories WHERE Name = 'Camisetas'), 
(SELECT Id FROM Brands WHERE Name = 'Volcán Activewear'), 
15000.00, 10, 'Active');

-- Crear variantes para el producto anterior
INSERT INTO ProductVariants (ProductId, SizeId, ColorId, SKU, StockQuantity, PriceModifier) VALUES
((SELECT Id FROM Products WHERE Code = 'CAM-IMP-001'), (SELECT Id FROM Sizes WHERE Name = 'M'), (SELECT Id FROM Colors WHERE Name = 'Negro'), 'CAM-IMP-001-M-NEG', 25, 0.00),
((SELECT Id FROM Products WHERE Code = 'CAM-IMP-001'), (SELECT Id FROM Sizes WHERE Name = 'L'), (SELECT Id FROM Colors WHERE Name = 'Negro'), 'CAM-IMP-001-L-NEG', 30, 0.00),
((SELECT Id FROM Products WHERE Code = 'CAM-IMP-001'), (SELECT Id FROM Sizes WHERE Name = 'M'), (SELECT Id FROM Colors WHERE Name = 'Blanco'), 'CAM-IMP-001-M-BLA', 15, 500.00);
GO

-- 3. Crear una Transacción de Ejemplo Completa (Inventario -> Venta)
-- =================================================================================
PRINT 'Creando una transacción de ejemplo completa...';

BEGIN TRANSACTION;

DECLARE @ManagerId BIGINT = (SELECT Id FROM Users WHERE Email = 'manager@tienda.com');
DECLARE @CustomerId INT = (SELECT Id FROM Customers WHERE Phone = '7777-7777');
DECLARE @VariantId1 INT = (SELECT Id FROM ProductVariants WHERE SKU = 'CAM-IMP-001-M-NEG');
DECLARE @VariantId2 INT = (SELECT Id FROM ProductVariants WHERE SKU = 'CAM-IMP-001-L-NEG');
DECLARE @NewSaleId BIGINT;

-- a. Movimiento de inventario inicial para las variantes (simulando una compra)
INSERT INTO InventoryMovements (ProductVariantId, MovementTypeId, Quantity, Reason, UserId, MovementDate) VALUES
(@VariantId1, (SELECT Id FROM MovementTypes WHERE Name = 'Compra a Proveedor'), 50, 'Stock inicial', @ManagerId, GETDATE()),
(@VariantId2, (SELECT Id FROM MovementTypes WHERE Name = 'Compra a Proveedor'), 50, 'Stock inicial', @ManagerId, GETDATE());

-- b. Crear la Venta (Sale)
INSERT INTO Sales (CustomerId, ManagerUserId, SaleDate, SubtotalAmount, DiscountAmount, TaxAmount, PaymentMethodId, StatusId) VALUES
(@CustomerId, @ManagerId, GETDATE(), 30000.00, 1500.00, 3705.00, (SELECT Id FROM PaymentMethods WHERE Name = 'SINPE Móvil'), (SELECT Id FROM SaleStatuses WHERE Name = 'Completada'));

-- Capturar el ID de la venta recién creada
SET @NewSaleId = SCOPE_IDENTITY();

-- c. Añadir los artículos a la venta (SaleItems)
-- Item 1: 1 unidad de la variante 1
INSERT INTO SaleItems (SaleId, ProductVariantId, Quantity, UnitPrice, DiscountPercent) VALUES
(@NewSaleId, @VariantId1, 1, 15000.00, 5.00);

-- Item 2: 1 unidad de la variante 2
INSERT INTO SaleItems (SaleId, ProductVariantId, Quantity, UnitPrice, DiscountPercent) VALUES
(@NewSaleId, @VariantId2, 1, 15000.00, 5.00);

-- d. Crear los movimientos de inventario correspondientes a la venta
INSERT INTO InventoryMovements (ProductVariantId, MovementTypeId, Quantity, ReferenceType, ReferenceId, UserId, MovementDate) VALUES
(@VariantId1, (SELECT Id FROM MovementTypes WHERE Name = 'Venta a Cliente'), -1, 'Sale', @NewSaleId, @ManagerId, GETDATE()),
(@VariantId2, (SELECT Id FROM MovementTypes WHERE Name = 'Venta a Cliente'), -1, 'Sale', @NewSaleId, @ManagerId, GETDATE());

COMMIT TRANSACTION;
GO

PRINT 'Script de Seed finalizado correctamente.';
GO