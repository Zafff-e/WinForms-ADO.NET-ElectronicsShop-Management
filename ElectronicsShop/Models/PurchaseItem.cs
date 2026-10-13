namespace ElectronicsShop.Models
{
    
    public class PurchaseItem
    {
        // PRIMARY KEY of this detail row
        public int ItemID { get; set; }

        // FOREIGN KEY — links back to parent PurchaseTransaction
        public int PurchaseID { get; set; }

        // Product description text
        public string ProductName { get; set; }

        // Integer quantities
        public int Quantity { get; set; }

        // Money — always decimal!
        public decimal UnitPrice { get; set; }

        // Months of warranty (0 = no warranty)
        public int WarrantyMonths { get; set; }

        // Read-only computed property — automatically derived in C#
        // The SQL column is also a computed column, so they always agree
        public decimal SubTotal => Quantity * UnitPrice;
    }
}
