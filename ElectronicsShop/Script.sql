-- =============================================================
--  ElectronicsShop Database Script
--  Run this in VS2022 → Server Explorer → New Query
--  OR paste into SQL Server Management Studio
-- =============================================================

-- ── TABLE 1: Master (one purchase order header) ──────────────
CREATE TABLE [dbo].[PurchaseTransaction]
(
    [PurchaseID]     INT            NOT NULL PRIMARY KEY IDENTITY(1001, 1),
    [PurchaseDate]   DATETIME       NOT NULL,
    [BuyerName]      VARCHAR(100)   NOT NULL,
    [SupplierName]   VARCHAR(100)   NOT NULL,
    [DeliveryCharge] DECIMAL(18, 2) NOT NULL DEFAULT 0,
    [TaxAmount]      DECIMAL(18, 2) NOT NULL DEFAULT 0,
    [Discount]       DECIMAL(18, 2) NOT NULL DEFAULT 0,
    [GrandTotal]     DECIMAL(18, 2) NOT NULL DEFAULT 0,
    [IsPaid]         BIT            NOT NULL DEFAULT 0,
    [InvoiceImage]   VARBINARY(MAX) NULL        -- stores image as raw bytes
);

-- ── TABLE 2: Detail (many line items per purchase) ────────────
CREATE TABLE [dbo].[PurchaseItems]
(
    [ItemID]         INT            NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [PurchaseID]     INT            NOT NULL
                       REFERENCES [dbo].[PurchaseTransaction]([PurchaseID])
                       ON DELETE CASCADE,           -- auto-delete items when header deleted
    [ProductName]    VARCHAR(150)   NOT NULL,
    [Quantity]       INT            NOT NULL,
    [UnitPrice]      DECIMAL(18, 2) NOT NULL,
    [WarrantyMonths] INT            NOT NULL DEFAULT 0,
    [SubTotal]       AS ([Quantity] * [UnitPrice])  -- SQL computed column, always consistent
);

-- ── Verify tables created ─────────────────────────────────────
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';

-- ── Sample data for testing ───────────────────────────────────
INSERT INTO [dbo].[PurchaseTransaction]
    ([PurchaseDate], [BuyerName], [SupplierName], [DeliveryCharge], [TaxAmount], [Discount], [GrandTotal], [IsPaid])
VALUES
    (GETDATE(), 'Ahmed Khan',   'ABC Electronics',  500.00, 800.00, 200.00, 0, 0),
    (GETDATE(), 'Sara Ahmed',   'TechWorld Ltd',    300.00, 500.00, 100.00, 0, 1),
    (GETDATE(), 'Rahim Uddin',  'DigiMart BD',      200.00, 300.00,  50.00, 0, 0);

INSERT INTO [dbo].[PurchaseItems]
    ([PurchaseID], [ProductName], [Quantity], [UnitPrice], [WarrantyMonths])
VALUES
    -- Purchase 1001 items
    (1001, 'Laptop ASUS VivoBook 15', 2, 45000.00, 24),
    (1001, 'SSD Samsung 512GB',       5,  3500.00, 36),
    (1001, 'Wireless Mouse Logitech',10,   800.00, 12),
    -- Purchase 1002 items
    (1002, 'Mechanical Keyboard',     3,  2500.00, 12),
    (1002, 'USB Hub 7-Port',          8,   600.00,  6),
    -- Purchase 1003 items
    (1003, 'Monitor 24" FHD',         2, 18000.00, 12),
    (1003, 'HDMI Cable 2m',           5,   350.00,  0);
