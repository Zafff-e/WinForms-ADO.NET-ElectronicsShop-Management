using ElectronicsShop.DAL;
using ElectronicsShop.Models;
using System;
using System.Data;

namespace ElectronicsShop.Repository
{
    
    public class PurchaseRepo
    {
        private readonly PurchaseGateway _gateway = new PurchaseGateway();

        // ── Save ────────────────────────────────────────────────────
        public (bool Success, string Message, int PurchaseID) Save(PurchaseTransaction pt)
        {
            if (string.IsNullOrWhiteSpace(pt.BuyerName))
                return (false, "Buyer name is required.", 0);

            if (string.IsNullOrWhiteSpace(pt.SupplierName))
                return (false, "Supplier name is required.", 0);

            if (pt.Items == null || pt.Items.Count == 0)
                return (false, "At least one item must be added before saving.", 0);

            if (pt.GrandTotal <= 0)
                return (false, "Grand Total must be greater than zero.", 0);

            try
            {
                int id = _gateway.SavePurchase(pt);
                return (true, $"Purchase #{id} saved successfully!", id);
            }
            catch (Exception ex)
            {
                return (false, "Error: " + ex.Message, 0);
            }
        }

        // ── Update ───────────────────────────────────────────────────
        public (bool Success, string Message) Update(PurchaseTransaction pt)
        {
            if (pt.PurchaseID <= 0)
                return (false, "Select a purchase to update.");

            if (string.IsNullOrWhiteSpace(pt.BuyerName))
                return (false, "Buyer name is required.");

            if (pt.Items == null || pt.Items.Count == 0)
                return (false, "Cannot save a purchase with no items.");

            try
            {
                int rows = _gateway.UpdatePurchase(pt);
                return rows > 0
                    ? (true,  $"Purchase #{pt.PurchaseID} updated successfully!")
                    : (false, $"Purchase #{pt.PurchaseID} not found.");
            }
            catch (Exception ex)
            {
                return (false, "Error: " + ex.Message);
            }
        }

        // ── Delete ───────────────────────────────────────────────────
        public (bool Success, string Message) Delete(int purchaseID)
        {
            if (purchaseID <= 0)
                return (false, "Select a purchase to delete.");

            try
            {
                int rows = _gateway.DeletePurchase(purchaseID);
                return rows > 0
                    ? (true,  $"Purchase #{purchaseID} deleted (including all items).")
                    : (false, $"Purchase #{purchaseID} not found.");
            }
            catch (Exception ex)
            {
                return (false, "Error: " + ex.Message);
            }
        }

        // ── Get single (connected) ───────────────────────────────────
        public PurchaseTransaction GetByID(int purchaseID)
        {
            if (purchaseID <= 0) return null;
            return _gateway.GetPurchaseByID(purchaseID);
        }

        // ── Get all (disconnected) ───────────────────────────────────
        public DataTable GetAll()      => _gateway.GetAllPurchases();

        // ── Search (disconnected) ────────────────────────────────────
        public DataTable Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _gateway.GetAllPurchases(); // empty search = show all
            return _gateway.SearchPurchases(keyword);
        }

        // ── Report data ──────────────────────────────────────────────
        public DataTable GetReportData() => _gateway.GetPurchaseReportData();
        
        public System.Collections.Generic.List<ViewModels.PurchaseReportViewModel> GetComprehensiveReportData() => _gateway.GetComprehensivePurchaseReportData();
    }
}
