-- =====================================================================
-- Database Schema & Sample Seed: ElectronicShopDB
-- Project: Electronics Shop Management ERP (WinForms + ADO.NET + Crystal Reports)
-- Author: A.H.M. Zafir Hasan (Trainee ID: 1294926, Round 70, IsDB-BISEW)
-- Compatibility: Microsoft SQL Server 2017+ / LocalDB / Azure SQL
-- =====================================================================

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'ElectronicShopDB')
BEGIN
    CREATE DATABASE [ElectronicShopDB];
END
GO

USE [ElectronicShopDB];
GO

-- ---------------------------------------------------------------------
-- Table 1: Master Order Header (PurchaseTransaction)
-- ---------------------------------------------------------------------
IF OBJECT_ID('dbo.PurchaseItems', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseItems];
GO

IF OBJECT_ID('dbo.PurchaseTransaction', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseTransaction];
GO

CREATE TABLE [dbo].[PurchaseTransaction]
(
    [PurchaseID]     INT            NOT NULL PRIMARY KEY IDENTITY(1001, 1),
    [PurchaseDate]   DATETIME       NOT NULL,
    [BuyerName]      VARCHAR(100)   NOT NULL,
    [SupplierName]   VARCHAR(100)   NOT NULL,
    [DeliveryCharge] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
    [TaxAmount]      DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
    [Discount]       DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
    [GrandTotal]     DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
    [IsPaid]         BIT            NOT NULL DEFAULT 0,
    [InvoiceImage]   VARBINARY(MAX) NULL -- Stores receipt / invoice scanned copy
);
GO

-- ---------------------------------------------------------------------
-- Table 2: Detail Purchase Line Items (PurchaseItems)
-- ---------------------------------------------------------------------
CREATE TABLE [dbo].[PurchaseItems]
(
    [ItemID]         INT            NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [PurchaseID]     INT            NOT NULL,
    [ProductName]    VARCHAR(150)   NOT NULL,
    [Quantity]       INT            NOT NULL,
    [UnitPrice]      DECIMAL(18, 2) NOT NULL,
    [WarrantyMonths] INT            NOT NULL DEFAULT 0,
    [SubTotal]       AS ([Quantity] * [UnitPrice]), -- Deterministic computed column

    CONSTRAINT [FK_PurchaseItems_PurchaseTransaction]
        FOREIGN KEY ([PurchaseID])
        REFERENCES [dbo].[PurchaseTransaction]([PurchaseID])
        ON DELETE CASCADE -- Cascades item removal when header is deleted
);
GO

-- ---------------------------------------------------------------------
-- Seed Data for Testing & Demonstration
-- ---------------------------------------------------------------------
INSERT INTO [dbo].[PurchaseTransaction]
    ([PurchaseDate], [BuyerName], [SupplierName], [DeliveryCharge], [TaxAmount], [Discount], [GrandTotal], [IsPaid])
VALUES
    (GETDATE(), 'Ahmed Khan',   'ABC Electronics',  500.00, 800.00, 200.00, 115600.00, 0),
    (GETDATE(), 'Sara Ahmed',   'TechWorld Ltd',    300.00, 500.00, 100.00,  13000.00, 1),
    (GETDATE(), 'Rahim Uddin',  'DigiMart BD',      200.00, 300.00,  50.00,  38200.00, 0);
GO

INSERT INTO [dbo].[PurchaseItems]
    ([PurchaseID], [ProductName], [Quantity], [UnitPrice], [WarrantyMonths])
VALUES
    -- Purchase 1001 (Total: 90000 + 17500 + 8000 = 115500 + 500 + 800 - 200 = 115600)
    (1001, 'Laptop ASUS VivoBook 15', 2, 45000.00, 24),
    (1001, 'SSD Samsung 512GB',       5,  3500.00, 36),
    (1001, 'Wireless Mouse Logitech',10,   800.00, 12),

    -- Purchase 1002 (Total: 7500 + 4800 = 12300 + 300 + 500 - 100 = 13000)
    (1002, 'Mechanical Keyboard',     3,  2500.00, 12),
    (1002, 'USB Hub 7-Port',          8,   600.00,  6),

    -- Purchase 1003 (Total: 36000 + 1750 = 37750 + 200 + 300 - 50 = 38200)
    (1003, 'Monitor 24" FHD',         2, 18000.00, 12),
    (1003, 'HDMI Cable 2m',           5,   350.00,  0);
GO

-- ---------------------------------------------------------------------
-- Verification Queries
-- ---------------------------------------------------------------------
SELECT pt.PurchaseID, pt.BuyerName, pt.SupplierName, pt.GrandTotal, COUNT(pi.ItemID) AS TotalItems
FROM [dbo].[PurchaseTransaction] pt
JOIN [dbo].[PurchaseItems] pi ON pt.PurchaseID = pi.PurchaseID
GROUP BY pt.PurchaseID, pt.BuyerName, pt.SupplierName, pt.GrandTotal;
GO
