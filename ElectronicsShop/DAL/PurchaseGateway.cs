using ElectronicsShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ElectronicsShop.DAL
{
    
    public class PurchaseGateway
    {
        
        private readonly string _conStr =
            ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        
        public int SavePurchase(PurchaseTransaction pt)
        {
            int newPurchaseID = 0;

            using (SqlConnection con = new SqlConnection(_conStr))
            {
                con.Open(); // open connection ONCE for the whole transaction

                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        // ── Step 1: Insert master row ──────────────────────
                        string masterSql = @"
                            INSERT INTO PurchaseTransaction
                                (PurchaseDate, BuyerName, SupplierName,
                                 DeliveryCharge, TaxAmount, Discount,
                                 GrandTotal, IsPaid, InvoiceImage)
                            VALUES
                                (@PurchaseDate, @BuyerName, @SupplierName,
                                 @DeliveryCharge, @TaxAmount, @Discount,
                                 @GrandTotal, @IsPaid, @InvoiceImage);
                            SELECT SCOPE_IDENTITY();"; // returns the new PurchaseID

                        using (SqlCommand cmd = new SqlCommand(masterSql, con, tran))
                        {
                            
                            cmd.Parameters.Add("@PurchaseDate",   SqlDbType.DateTime).Value   = pt.PurchaseDate;
                            cmd.Parameters.Add("@BuyerName",      SqlDbType.VarChar, 100).Value = pt.BuyerName;
                            cmd.Parameters.Add("@SupplierName",   SqlDbType.VarChar, 100).Value = pt.SupplierName;
                            cmd.Parameters.Add("@DeliveryCharge", SqlDbType.Decimal).Value   = pt.DeliveryCharge;
                            cmd.Parameters.Add("@TaxAmount",      SqlDbType.Decimal).Value   = pt.TaxAmount;
                            cmd.Parameters.Add("@Discount",       SqlDbType.Decimal).Value   = pt.Discount;
                            cmd.Parameters.Add("@GrandTotal",     SqlDbType.Decimal).Value   = pt.GrandTotal;
                            cmd.Parameters.Add("@IsPaid",         SqlDbType.Bit).Value        = pt.IsPaid;

                            
                            if (pt.InvoiceImage != null && pt.InvoiceImage.Length > 0)
                                cmd.Parameters.Add("@InvoiceImage", SqlDbType.VarBinary).Value = pt.InvoiceImage;
                            else
                                cmd.Parameters.Add("@InvoiceImage", SqlDbType.VarBinary).Value = DBNull.Value;

                           
                            object result = cmd.ExecuteScalar();
                            newPurchaseID = Convert.ToInt32(result);
                        }

                        // ── Step 2: Insert each detail row ─────────────────
                        foreach (PurchaseItem item in pt.Items)
                        {
                            // Note: we do NOT insert SubTotal — it's a SQL COMPUTED column
                            string itemSql = @"
                                INSERT INTO PurchaseItems
                                    (PurchaseID, ProductName, Quantity, UnitPrice, WarrantyMonths)
                                VALUES
                                    (@PurchaseID, @ProductName, @Quantity, @UnitPrice, @WarrantyMonths)";

                            using (SqlCommand icmd = new SqlCommand(itemSql, con, tran))
                            {
                                icmd.Parameters.Add("@PurchaseID",     SqlDbType.Int).Value         = newPurchaseID;
                                icmd.Parameters.Add("@ProductName",    SqlDbType.VarChar, 150).Value = item.ProductName;
                                icmd.Parameters.Add("@Quantity",       SqlDbType.Int).Value          = item.Quantity;
                                icmd.Parameters.Add("@UnitPrice",      SqlDbType.Decimal).Value      = item.UnitPrice;
                                icmd.Parameters.Add("@WarrantyMonths", SqlDbType.Int).Value          = item.WarrantyMonths;
                                icmd.ExecuteNonQuery(); // returns rows affected (not needed here)
                            }
                        }

                        tran.Commit(); // ALL inserts succeeded — make permanent
                        return newPurchaseID;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback(); // something failed — undo everything
                        throw new Exception("SavePurchase failed: " + ex.Message, ex);
                    }
                } 
            } 
        }

        
        public int UpdatePurchase(PurchaseTransaction pt)
        {
            int rowsAffected = 0;

            
            PurchaseTransaction existing = GetPurchaseByID(pt.PurchaseID);
            if (existing == null) return 0;

            using (SqlConnection con = new SqlConnection(_conStr))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        List<string> updateFields = new List<string>();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.Transaction = tran;
                        cmd.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = pt.PurchaseID;

                       
                        if (pt.PurchaseDate != existing.PurchaseDate && pt.PurchaseDate != default(DateTime))
                        {
                            updateFields.Add("PurchaseDate = @PurchaseDate");
                            cmd.Parameters.Add("@PurchaseDate", SqlDbType.DateTime).Value = pt.PurchaseDate;
                        }
                        if (pt.BuyerName != existing.BuyerName && pt.BuyerName != null)
                        {
                            updateFields.Add("BuyerName = @BuyerName");
                            cmd.Parameters.Add("@BuyerName", SqlDbType.VarChar, 100).Value = pt.BuyerName;
                        }
                        if (pt.SupplierName != existing.SupplierName && pt.SupplierName != null)
                        {
                            updateFields.Add("SupplierName = @SupplierName");
                            cmd.Parameters.Add("@SupplierName", SqlDbType.VarChar, 100).Value = pt.SupplierName;
                        }
                        if (pt.DeliveryCharge != existing.DeliveryCharge)
                        {
                            updateFields.Add("DeliveryCharge = @DeliveryCharge");
                            cmd.Parameters.Add("@DeliveryCharge", SqlDbType.Decimal).Value = pt.DeliveryCharge;
                        }
                        if (pt.TaxAmount != existing.TaxAmount)
                        {
                            updateFields.Add("TaxAmount = @TaxAmount");
                            cmd.Parameters.Add("@TaxAmount", SqlDbType.Decimal).Value = pt.TaxAmount;
                        }
                        if (pt.Discount != existing.Discount)
                        {
                            updateFields.Add("Discount = @Discount");
                            cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = pt.Discount;
                        }
                        if (pt.GrandTotal != existing.GrandTotal)
                        {
                            updateFields.Add("GrandTotal = @GrandTotal");
                            cmd.Parameters.Add("@GrandTotal", SqlDbType.Decimal).Value = pt.GrandTotal;
                        }
                        if (pt.IsPaid != existing.IsPaid)
                        {
                            updateFields.Add("IsPaid = @IsPaid");
                            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = pt.IsPaid;
                        }
                        if (!CompareBytes(pt.InvoiceImage, existing.InvoiceImage))
                        {
                            updateFields.Add("InvoiceImage = @InvoiceImage");
                            if (pt.InvoiceImage != null && pt.InvoiceImage.Length > 0)
                                cmd.Parameters.Add("@InvoiceImage", SqlDbType.VarBinary).Value = pt.InvoiceImage;
                            else
                                cmd.Parameters.Add("@InvoiceImage", SqlDbType.VarBinary).Value = DBNull.Value;
                        }

                        if (updateFields.Count > 0)
                        {
                            cmd.CommandText = "UPDATE PurchaseTransaction SET " + string.Join(", ", updateFields) + " WHERE PurchaseID = @PurchaseID";
                            rowsAffected = cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            rowsAffected = 1; 
                        }

                        
                        using (SqlCommand dcmd = new SqlCommand(
                            "DELETE FROM PurchaseItems WHERE PurchaseID = @PurchaseID", con, tran))
                        {
                            dcmd.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = pt.PurchaseID;
                            dcmd.ExecuteNonQuery();
                        }

                        foreach (PurchaseItem item in pt.Items)
                        {
                            using (SqlCommand icmd = new SqlCommand(@"
                                INSERT INTO PurchaseItems
                                    (PurchaseID, ProductName, Quantity, UnitPrice, WarrantyMonths)
                                VALUES
                                    (@PurchaseID, @ProductName, @Quantity, @UnitPrice, @WarrantyMonths)",
                                con, tran))
                            {
                                icmd.Parameters.Add("@PurchaseID",     SqlDbType.Int).Value          = pt.PurchaseID;
                                icmd.Parameters.Add("@ProductName",    SqlDbType.VarChar, 150).Value = item.ProductName;
                                icmd.Parameters.Add("@Quantity",       SqlDbType.Int).Value          = item.Quantity;
                                icmd.Parameters.Add("@UnitPrice",      SqlDbType.Decimal).Value      = item.UnitPrice;
                                icmd.Parameters.Add("@WarrantyMonths", SqlDbType.Int).Value          = item.WarrantyMonths;
                                icmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return rowsAffected;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("UpdatePurchase failed: " + ex.Message, ex);
                    }
                }
            }
        }

        private bool CompareBytes(byte[] a, byte[] b)
        {
            if (a == b) return true;
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }

        // ─────────────────────────────────────────────────────────────────
        //  ① CONNECTED — DELETE
        // ─────────────────────────────────────────────────────────────────
        /// <summary>
        /// Deletes a purchase transaction.
        /// ON DELETE CASCADE in the FK means PurchaseItems are also deleted
        /// automatically by SQL Server — we only need to delete the master row.
        /// </summary>
        public int DeletePurchase(int purchaseID)
        {
            using (SqlConnection con = new SqlConnection(_conStr))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "DELETE FROM PurchaseTransaction WHERE PurchaseID = @PurchaseID",
                            con, tran))
                        {
                            cmd.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = purchaseID;
                            int rows = cmd.ExecuteNonQuery();
                            tran.Commit();
                            return rows;
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("DeletePurchase failed: " + ex.Message, ex);
                    }
                }
            }
        }

        
        public PurchaseTransaction GetPurchaseByID(int purchaseID)
        {
            PurchaseTransaction pt = null;

            using (SqlConnection con = new SqlConnection(_conStr))
            {
                // ── Read master row ────────────────────────────────────
                string masterSql = @"
                    SELECT PurchaseID, PurchaseDate, BuyerName, SupplierName,
                           DeliveryCharge, TaxAmount, Discount, GrandTotal,
                           IsPaid, InvoiceImage
                    FROM   PurchaseTransaction
                    WHERE  PurchaseID = @PurchaseID";

                SqlCommand cmd = new SqlCommand(masterSql, con);
                cmd.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = purchaseID;

                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read()) // true if a row was returned
                    {
                        pt = new PurchaseTransaction
                        {
                            PurchaseID     = Convert.ToInt32(rdr["PurchaseID"]),
                            PurchaseDate   = Convert.ToDateTime(rdr["PurchaseDate"]),
                            BuyerName      = rdr["BuyerName"].ToString(),
                            SupplierName   = rdr["SupplierName"].ToString(),
                            DeliveryCharge = Convert.ToDecimal(rdr["DeliveryCharge"]),
                            TaxAmount      = Convert.ToDecimal(rdr["TaxAmount"]),
                            Discount       = Convert.ToDecimal(rdr["Discount"]),
                            GrandTotal     = Convert.ToDecimal(rdr["GrandTotal"]),
                            IsPaid         = Convert.ToBoolean(rdr["IsPaid"]),
                            // Handle NULL image gracefully
                            InvoiceImage   = rdr["InvoiceImage"] == DBNull.Value
                                              ? null
                                              : (byte[])rdr["InvoiceImage"]
                        };
                    }
                }

                // ── Read detail rows for this purchase ─────────────────
                if (pt != null)
                {
                    string itemSql = @"
                        SELECT ItemID, PurchaseID, ProductName,
                               Quantity, UnitPrice, WarrantyMonths, SubTotal
                        FROM   PurchaseItems
                        WHERE  PurchaseID = @PurchaseID
                        ORDER  BY ItemID";

                    SqlCommand icmd = new SqlCommand(itemSql, con);
                    icmd.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = purchaseID;

                    using (SqlDataReader irdr = icmd.ExecuteReader())
                    {
                        while (irdr.Read()) // loop through all item rows
                        {
                            pt.Items.Add(new PurchaseItem
                            {
                                ItemID         = Convert.ToInt32(irdr["ItemID"]),
                                PurchaseID     = Convert.ToInt32(irdr["PurchaseID"]),
                                ProductName    = irdr["ProductName"].ToString(),
                                Quantity       = Convert.ToInt32(irdr["Quantity"]),
                                UnitPrice      = Convert.ToDecimal(irdr["UnitPrice"]),
                                WarrantyMonths = Convert.ToInt32(irdr["WarrantyMonths"])
                                // SubTotal is a computed column — derived in model
                            });
                        }
                    }
                }
            }

            return pt; // null if ID not found
        }

        
        public DataTable GetAllPurchases()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_conStr))
            {
                string sql = @"
                    SELECT
                        pt.PurchaseID,
                        FORMAT(pt.PurchaseDate, 'dd-MMM-yyyy') AS PurchaseDate,
                        pt.BuyerName,
                        pt.SupplierName,
                        pt.DeliveryCharge,
                        pt.TaxAmount,
                        pt.Discount,
                        pt.GrandTotal,
                        CASE WHEN pt.IsPaid = 1 THEN 'Yes' ELSE 'No' END AS PaymentStatus,
                        pt.InvoiceImage,
                        (SELECT COUNT(ItemID) FROM PurchaseItems WHERE PurchaseID = pt.PurchaseID) AS ItemCount
                    FROM  PurchaseTransaction pt
                    ORDER BY pt.PurchaseID DESC";

                SqlCommand    cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill(dt);
            }

            return dt;
        }

       
        public DataTable SearchPurchases(string keyword)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_conStr))
            {
                string sql = @"
                    SELECT
                        pt.PurchaseID,
                        FORMAT(pt.PurchaseDate, 'dd-MMM-yyyy') AS PurchaseDate,
                        pt.BuyerName,
                        pt.SupplierName,
                        pt.GrandTotal,
                        CASE WHEN pt.IsPaid = 1 THEN 'Yes' ELSE 'No' END AS PaymentStatus,
                        pt.InvoiceImage
                    FROM  PurchaseTransaction pt
                    WHERE  pt.SupplierName LIKE @Keyword
                        OR pt.BuyerName    LIKE @Keyword
                        OR CAST(pt.PurchaseID AS VARCHAR) LIKE @Keyword
                    ORDER BY pt.PurchaseID DESC";

                SqlCommand     cmd = new SqlCommand(sql, con);
                SqlDataAdapter da  = new SqlDataAdapter(cmd);
                // % wildcard on both sides = "contains" search
                cmd.Parameters.Add("@Keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable GetPurchaseReportData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_conStr))
            {
                string sql = @"
                    SELECT
                        pt.PurchaseID,
                        FORMAT(pt.PurchaseDate, 'dd-MMM-yyyy')  AS PurchaseDate,
                        pt.BuyerName,
                        pt.SupplierName,
                        pi.ProductName,
                        pi.Quantity,
                        pi.UnitPrice,
                        pi.SubTotal,
                        pi.WarrantyMonths,
                        pt.DeliveryCharge,
                        pt.TaxAmount,
                        pt.Discount,
                        pt.GrandTotal,
                        CASE WHEN pt.IsPaid = 1 THEN 'Paid' ELSE 'Unpaid' END AS PaymentStatus,
                        pt.InvoiceImage
                    FROM  PurchaseTransaction pt
                    JOIN  PurchaseItems pi ON pt.PurchaseID = pi.PurchaseID
                    ORDER BY pt.SupplierName, pt.PurchaseID, pi.ItemID";

                SqlDataAdapter da = new SqlDataAdapter(new SqlCommand(sql, con));
                da.Fill(dt);
            }

            return dt;
        }

      
        public List<ViewModels.PurchaseReportViewModel> GetComprehensivePurchaseReportData()
        {
            var list = new List<ViewModels.PurchaseReportViewModel>();

            using (SqlConnection con = new SqlConnection(_conStr))
            {
                string sql = @"
                    SELECT
                        pt.PurchaseID,
                        pt.PurchaseDate,
                        pt.BuyerName,
                        pt.SupplierName,
                        pt.DeliveryCharge,
                        pt.TaxAmount,
                        pt.Discount,
                        pt.GrandTotal,
                        pt.IsPaid,
                        pt.InvoiceImage,
                        pi.ProductName,
                        pi.Quantity,
                        pi.UnitPrice,
                        pi.WarrantyMonths,
                        pi.SubTotal
                    FROM  PurchaseTransaction pt
                    JOIN  PurchaseItems pi ON pt.PurchaseID = pi.PurchaseID
                    ORDER BY pt.SupplierName, pt.PurchaseID, pi.ItemID";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var vm = new ViewModels.PurchaseReportViewModel
                            {
                                PurchaseID = Convert.ToInt32(reader["PurchaseID"]),
                                PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"]),
                                BuyerName = reader["BuyerName"].ToString(),
                                SupplierName = reader["SupplierName"].ToString(),
                                DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"]),
                                TaxAmount = Convert.ToDecimal(reader["TaxAmount"]),
                                Discount = Convert.ToDecimal(reader["Discount"]),
                                GrandTotal = Convert.ToDecimal(reader["GrandTotal"]),
                                IsPaid = Convert.ToBoolean(reader["IsPaid"]),
                                InvoiceImage = reader["InvoiceImage"] as byte[],
                                
                                ProductName = reader["ProductName"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                                WarrantyMonths = Convert.ToInt32(reader["WarrantyMonths"]),
                                SubTotal = Convert.ToDecimal(reader["SubTotal"])
                            };
                            list.Add(vm);
                        }
                    }
                }
            }
            return list;
        }

        
        public static byte[] ImageToBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

       
        public static System.Drawing.Image BytesToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                
                return System.Drawing.Image.FromStream(new MemoryStream(imageBytes));
            }
        }
    }
}
