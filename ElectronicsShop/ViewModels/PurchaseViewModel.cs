using ElectronicsShop.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ElectronicsShop.ViewModels
{
    
    public class PurchaseViewModel
    {
        
        public PurchaseTransaction ReadFromForm(
            TextBox txtPurchaseID,
            DateTimePicker dtpDate,
            TextBox txtBuyer,
            TextBox txtSupplier,
            TextBox txtDelivery,
            TextBox txtTax,
            TextBox txtDiscount,
            Label   lblGrandTotal,
            CheckBox chkIsPaid,
            byte[] invoiceImageBytes,
            List<PurchaseItem> currentItems)
        {
            var pt = new PurchaseTransaction();

            // PurchaseID: 0 on new record, >0 on edit
            if (int.TryParse(txtPurchaseID.Text.Trim(), out int pid))
                pt.PurchaseID = pid;

            pt.PurchaseDate = dtpDate.Value;
            pt.BuyerName    = txtBuyer.Text.Trim();
            pt.SupplierName = txtSupplier.Text.Trim();

            // Safe decimal parsing — default to 0 if blank or invalid
            pt.DeliveryCharge = TryDecimal(txtDelivery.Text);
            pt.TaxAmount      = TryDecimal(txtTax.Text);
            pt.Discount       = TryDecimal(txtDiscount.Text);

            // Strip the currency symbol from the label if present
            string totalText = lblGrandTotal.Text
                .Replace("৳", "").Replace(",", "").Trim();
            pt.GrandTotal     = TryDecimal(totalText);

            pt.IsPaid         = chkIsPaid.Checked;
            pt.InvoiceImage   = invoiceImageBytes;

            // Copy in-memory item list into the model
            pt.Items = new List<PurchaseItem>(currentItems);

            return pt;
        }

        
        public void WriteToForm(
            PurchaseTransaction pt,
            TextBox txtPurchaseID,
            DateTimePicker dtpDate,
            TextBox txtBuyer,
            TextBox txtSupplier,
            TextBox txtDelivery,
            TextBox txtTax,
            TextBox txtDiscount,
            Label   lblGrandTotal,
            CheckBox chkIsPaid,
            System.Windows.Forms.PictureBox picInvoice)
        {
            if (pt == null) return;

            txtPurchaseID.Text    = pt.PurchaseID.ToString();
            dtpDate.Value         = pt.PurchaseDate;
            txtBuyer.Text         = pt.BuyerName;
            txtSupplier.Text      = pt.SupplierName;
            txtDelivery.Text      = pt.DeliveryCharge.ToString("0.00");
            txtTax.Text           = pt.TaxAmount.ToString("0.00");
            txtDiscount.Text      = pt.Discount.ToString("0.00");
            lblGrandTotal.Text    = "৳ " + pt.GrandTotal.ToString("N2");
            chkIsPaid.Checked     = pt.IsPaid;

            // Restore invoice image if available
            if (pt.InvoiceImage != null && pt.InvoiceImage.Length > 0)
                picInvoice.Image = DAL.PurchaseGateway.BytesToImage(pt.InvoiceImage);
            else
                picInvoice.Image = null;
        }

        // ── Helper ──────────────────────────────────────────────────
        private static decimal TryDecimal(string text)
        {
            return decimal.TryParse(text, out decimal d) ? d : 0m;
        }
    }
}
