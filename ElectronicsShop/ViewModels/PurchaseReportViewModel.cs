using System;

namespace ElectronicsShop.ViewModels
{
    public class PurchaseReportViewModel
    {
        // Transaction (Master)
        public int PurchaseID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string BuyerName { get; set; }
        public string SupplierName { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public bool IsPaid { get; set; }
        public byte[] InvoiceImage { get; set; }

        // Item (Detail)

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int WarrantyMonths { get; set; }
        public decimal SubTotal { get; set; }
    }
}
