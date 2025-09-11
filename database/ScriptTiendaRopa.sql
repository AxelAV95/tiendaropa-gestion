CREATE DATABASE tiendadb

CREATE TABLE Users (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Email VARCHAR(255) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    Phone VARCHAR(20) NULL,
    Role VARCHAR(50) NOT NULL DEFAULT 'Manager', -- Sintaxis corregida
    IsActive BIT NOT NULL DEFAULT 1,             -- 'BIT' para SQL Server, 1 es TRUE
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Valor por defecto automático
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()  -- Valor por defecto automático
);

-- Primero, creas las tablas para categorías y marcas
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Brands (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Code NVARCHAR(50) NOT NULL UNIQUE,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    
    -- Usamos llaves foráneas en lugar de texto
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
    BrandId INT NULL FOREIGN KEY REFERENCES Brands(Id),
    
    BasePrice DECIMAL(18,2) NOT NULL,
    MinStock INT NOT NULL DEFAULT 5,
    
    -- Usamos una restricción CHECK para el estado
    Status NVARCHAR(50) NOT NULL DEFAULT 'Active' 
        CHECK (Status IN ('Active', 'Inactive', 'Discontinued')),
    
    ImageUrl NVARCHAR(500) NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE INDEX IX_Products_Name ON Products(Name);
CREATE INDEX IX_Products_CategoryId ON Products(CategoryId);

-- Tablas para los atributos
CREATE TABLE Sizes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE Colors (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE,
    HexCode CHAR(7) NULL -- Podrías incluso guardar el código de color
);
CREATE TABLE ProductVariants(
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    SizeId INT NULL,
    ColorId INT NULL,
    SKU NVARCHAR(100) NOT NULL UNIQUE,
    StockQuantity INT NOT NULL DEFAULT 0,
    PriceModifier DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),

    -- Nombres de restricción siguiendo la convención
	-- FK_TablaActual_TablaReferenciada.
    CONSTRAINT FK_ProductVariants_Products FOREIGN KEY (ProductId) REFERENCES Products(Id),
    CONSTRAINT FK_ProductVariants_Colors FOREIGN KEY (ColorId) REFERENCES Colors(Id),
    CONSTRAINT FK_ProductVariants_Sizes FOREIGN KEY (SizeId) REFERENCES Sizes(Id)
);

CREATE INDEX IX_ProductVariants_ProductId ON ProductVariants(ProductId);


CREATE TABLE Customers(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL UNIQUE, 
    Email NVARCHAR(255) NULL UNIQUE, 
    BirthDate DATE NULL,
    LoyaltyPoints INT NOT NULL DEFAULT 0,
    TotalPurchases DECIMAL(12,2) NOT NULL DEFAULT 0.00,
    
    PreferredSizeId INT NULL,

    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),

    -- Definimos la relación con la tabla de Tamaños
    CONSTRAINT FK_Customers_Sizes FOREIGN KEY (PreferredSizeId) REFERENCES Sizes(Id)
);

-- Tablas de búsqueda (lookup tables) primero
CREATE TABLE PaymentMethods (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE
);
CREATE TABLE SaleStatuses (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Sales(
    Id BIGINT PRIMARY KEY IDENTITY(1,1), -- Usar BIGINT es más seguro para tablas de alto volumen
    CustomerId INT NULL,
    ManagerUserId BIGINT NOT NULL,
    SaleDate DATETIME NOT NULL,
    SubtotalAmount DECIMAL (12,2) NOT NULL,
    DiscountAmount DECIMAL (12,2) NOT NULL DEFAULT 0.00,
    TaxAmount DECIMAL(12,2) NOT NULL DEFAULT 0.00,
    
    -- Columna calculada para asegurar que el total siempre sea correcto
    TotalAmount AS (SubtotalAmount - DiscountAmount + TaxAmount), -- COMPUTED COLUMN
    
    PaymentMethodId INT NOT NULL, -- Columna normalizada
    PaymentReference NVARCHAR(100) NULL,
    StatusId INT NOT NULL, -- Columna normalizada
    Notes NVARCHAR(MAX) NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),

    -- Restricciones de llaves foráneas
    CONSTRAINT FK_Sales_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id),    
    CONSTRAINT FK_Sales_PaymentMethods FOREIGN KEY (PaymentMethodId) REFERENCES PaymentMethods(Id),
    CONSTRAINT FK_Sales_SaleStatuses FOREIGN KEY (StatusId) REFERENCES SaleStatuses(Id)
);

-- Índices para el rendimiento
CREATE INDEX IX_Sales_CustomerId ON Sales(CustomerId);
CREATE INDEX IX_Sales_ManagerUserId ON Sales(ManagerUserId);
CREATE INDEX IX_Sales_SaleDate ON Sales(SaleDate);

CREATE TABLE SaleItems(
    -- Usar BIGINT para la PK es más seguro para el futuro
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    
    -- Llaves foráneas que deben coincidir con los tipos de las tablas referenciadas
    SaleId BIGINT NOT NULL,
    ProductVariantId INT NOT NULL,
    
    Quantity INT NOT NULL CHECK (Quantity > 0), -- MEJORA: Asegura que la cantidad sea positiva
    
    -- El precio en el momento de la venta (perfecto como está)
    UnitPrice DECIMAL(10,2) NOT NULL,
    
    DiscountPercent DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    
    -- MEJORA PRO: Columna calculada para garantizar la integridad del subtotal
    -- La fórmula es: (Cantidad * Precio) * (1 - (PorcentajeDescuento / 100))
    Subtotal AS (
        CAST(Quantity * UnitPrice * (1 - (DiscountPercent / 100.0)) AS DECIMAL(10,2)) --COMPUTED COLUMN
    ),
    
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),

    -- Restricciones de llaves foráneas
    CONSTRAINT FK_SaleItems_Sales FOREIGN KEY (SaleId) REFERENCES Sales(Id),
    CONSTRAINT FK_SaleItems_ProductVariants FOREIGN KEY (ProductVariantId) REFERENCES ProductVariants(Id)
);

-- ÍNDICES CRÍTICOS PARA EL RENDIMIENTO --
-- Para buscar rápidamente todos los items de una venta
CREATE INDEX IX_SaleItems_SaleId ON SaleItems(SaleId);

-- Opcional pero útil: para buscar todas las ventas de un producto específico
CREATE INDEX IX_SaleItems_ProductVariantId ON SaleItems(ProductVariantId);
GO

-- MEJORA: Crear una tabla para los tipos de movimiento
CREATE TABLE MovementTypes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE,
    -- Podríamos añadir una columna para saber si suma o resta inventario, 
    -- pero manejarlo con el signo de Quantity es más flexible.
    Description NVARCHAR(255) NULL
);
GO

-- Tabla principal de Movimientos de Inventario (versión Pro)
CREATE TABLE InventoryMovements(
    -- Usar BIGINT para la PK es más seguro para una tabla que crecerá mucho
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    
    ProductVariantId INT NOT NULL,
    MovementTypeId INT NOT NULL, -- MEJORA: Normalizado
    
    -- La cantidad del movimiento. Positivo para entradas, negativo para salidas.
    Quantity INT NOT NULL
        CHECK (Quantity <> 0), -- MEJORA: Evita movimientos inútiles de cantidad 0.
        
    -- Referencia a otro documento (ej. Venta, Orden de Compra). Esto es un "polymorphic relationship".
    ReferenceType NVARCHAR(50) NULL,
    ReferenceId BIGINT NULL, -- Usar BIGINT para ser compatible con IDs de otras tablas (ej. Sales.Id)
    
    Reason NVARCHAR(200) NULL,
    Notes NVARCHAR(MAX) NULL,
    UserId BIGINT NOT NULL,
    MovementDate DATETIME NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),

    -- Restricciones de llaves foráneas
    CONSTRAINT FK_InventoryMovements_ProductVariants FOREIGN KEY (ProductVariantId) REFERENCES ProductVariants(Id),
    CONSTRAINT FK_InventoryMovements_MovementTypes FOREIGN KEY (MovementTypeId) REFERENCES MovementTypes(Id)
);
GO

-- ÍNDICE ESENCIAL: Para calcular el stock de un producto de forma instantánea.
CREATE INDEX IX_InventoryMovements_ProductVariantId ON InventoryMovements(ProductVariantId);
GO

-- Índice útil para auditar o buscar movimientos por documento de referencia.
CREATE INDEX IX_InventoryMovements_Reference ON InventoryMovements(ReferenceType, ReferenceId);
GO

-- Índice útil para reportes de movimiento por fecha.
CREATE INDEX IX_InventoryMovements_MovementDate ON InventoryMovements(MovementDate);
GO