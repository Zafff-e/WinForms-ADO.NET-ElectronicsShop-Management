using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ElectronicsShop.Models;
using ElectronicsShop.Repository;
using ElectronicsShop.ReportViewer;

namespace ElectronicsShop
{
    public partial class FrmMain : Form
    {
        private PurchaseRepo _repo = new PurchaseRepo();
        private PurchaseTransaction _transaction = new PurchaseTransaction();
        private int _intPurchaseId = 0;
        private bool _isDefaultImage = true;
        private byte[] _previousImageBytes = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoaddgvPurchases();
            ClearAll();
        }

        private void LoaddgvPurchases()
        {
            DataTable dt = _repo.GetAll();
            
          
            if (!dt.Columns.Contains("Image"))
                dt.Columns.Add("Image", typeof(byte[]));

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["InvoiceImage"] != DBNull.Value)
                {
                    dr["Image"] = (byte[])dr["InvoiceImage"];
                }
                else
                {
                    string defaultPath = Path.Combine(Application.StartupPath, "images", "noimage.jpg");
                    if (File.Exists(defaultPath))
                        dr["Image"] = File.ReadAllBytes(defaultPath);
                }
            }

            dgvPurchases.DataSource = null;
            dgvPurchases.Columns.Clear();
            dgvPurchases.DataSource = dt;

            AddGridButton(dgvPurchases, "Detail", "Detail");
            dgvPurchases.Columns["Detail"].DisplayIndex = 0;
            AddGridButton(dgvPurchases, "Edit", "Edit");
            dgvPurchases.Columns["Edit"].DisplayIndex = 1;
            AddGridButton(dgvPurchases, "Delete", "Delete");
            dgvPurchases.Columns["Delete"].DisplayIndex = 2;

            dgvPurchases.RowTemplate.Height = 100;
            foreach (DataGridViewRow row in dgvPurchases.Rows)
            {
                row.Height = 50;
            }

            if (dgvPurchases.Columns["Image"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 50;
                imgCol.DisplayIndex = 3;
            }

            if (dgvPurchases.Columns.Contains("PurchaseID"))
                dgvPurchases.Columns["PurchaseID"].Visible = false;
            if (dgvPurchases.Columns.Contains("InvoiceImage"))
                dgvPurchases.Columns["InvoiceImage"].Visible = false;
        }

        private void AddGridButton(DataGridView grid, string name, string text)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = name,
                Text = text,
                HeaderText = text,
                Width = 60,
                UseColumnTextForButtonValue = true
            };
            grid.Columns.Add(btn);
        }

        private void ClearAll()
        {
            string noImagePath = Path.Combine(Application.StartupPath, "images", "noimage.jpg");
            if (File.Exists(noImagePath))
            {
                using (var stream = new FileStream(noImagePath, FileMode.Open, FileAccess.Read))
                {
                    using (var img = Image.FromStream(stream))
                    {
                        picInvoice.Image = new Bitmap(img);
                    }
                }
            }
            else
            {
                picInvoice.Image = null;
            }

            _isDefaultImage = true;
            _previousImageBytes = null;
            _intPurchaseId = 0;
            _transaction = new PurchaseTransaction();
            
            btnSave.Text = "Save";

            txtPurchaseID.Text = "";
            dtpDate.Value = DateTime.Now;
            txtBuyer.Text = "";
            txtSupplier.Text = "";
            txtDelivery.Text = "0";
            txtTax.Text = "0";
            txtDiscount.Text = "0";
            chkIsPaid.Checked = false;

            txtProduct.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
            txtWarranty.Text = "0";

            dgvNewItems.DataSource = null;
            dgvExistingItems.DataSource = null;
            
            LoaddgvNewItems(_transaction.Items);
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var img = Image.FromStream(stream))
                    {
                        picInvoice.Image = new Bitmap(img);
                    }
                    _isDefaultImage = false;
                }
            }
        }

        private void btnCancelImage_Click(object sender, EventArgs e)
        {
            string defaultPath = Path.Combine(Application.StartupPath, "images", "noimage.jpg");
            if (File.Exists(defaultPath))
            {
                using (var stream = new FileStream(defaultPath, FileMode.Open, FileAccess.Read))
                {
                    using (var img = Image.FromStream(stream))
                    {
                        picInvoice.Image = new Bitmap(img);
                    }
                }
            }
            _isDefaultImage = true;
            _previousImageBytes = null;
        }

        private void dgvPurchases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                int pId = Convert.ToInt32(dgvPurchases.Rows[e.RowIndex].Cells["PurchaseID"].Value);
                string command = dgvPurchases.Columns[e.ColumnIndex].Name;

                switch (command)
                {
                    case "Detail":
                        var ptDetail = _repo.GetByID(pId);
                        if (ptDetail != null) {
                            dgvExistingItems.DataSource = ConvertToDataTable(ptDetail.Items);
                            if (dgvExistingItems.Columns.Contains("PurchaseID"))
                                dgvExistingItems.Columns["PurchaseID"].Visible = false;
                            if (dgvExistingItems.Columns.Contains("ItemID"))
                                dgvExistingItems.Columns["ItemID"].Visible = false;
                        }
                        break;
                    case "Delete":
                        if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            DeletePurchaseInfo(pId);
                        }
                        break;
                    case "Edit":
                        EditPurchaseInfo(pId);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletePurchaseInfo(int pId)
        {
            _repo.Delete(pId);
            LoaddgvPurchases();
        }

        private void EditPurchaseInfo(int pId)
        {
            var pt = _repo.GetByID(pId);
            if (pt == null) return;

            btnSave.Text = "Update";
            _intPurchaseId = pId;
            _transaction = pt;

            txtPurchaseID.Text = pt.PurchaseID.ToString();
            dtpDate.Value = pt.PurchaseDate;
            txtBuyer.Text = pt.BuyerName;
            txtSupplier.Text = pt.SupplierName;
            txtDelivery.Text = pt.DeliveryCharge.ToString();
            txtTax.Text = pt.TaxAmount.ToString();
            txtDiscount.Text = pt.Discount.ToString();
            chkIsPaid.Checked = pt.IsPaid;

            _previousImageBytes = pt.InvoiceImage;
            if (_previousImageBytes != null && _previousImageBytes.Length > 0)
            {
                using (var ms = new MemoryStream(_previousImageBytes))
                {
                    using (var img = Image.FromStream(ms))
                    {
                        picInvoice.Image = new Bitmap(img);
                    }
                    _isDefaultImage = false;
                }
            }
            else
            {
                _isDefaultImage = true;
                string defaultPath = Path.Combine(Application.StartupPath, "images", "noimage.jpg");
                if (File.Exists(defaultPath))
                {
                    using (var stream = new FileStream(defaultPath, FileMode.Open, FileAccess.Read))
                    {
                        using (var img = Image.FromStream(stream))
                        {
                            picInvoice.Image = new Bitmap(img);
                        }
                    }
                }
            }

            LoaddgvNewItems(_transaction.Items);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseItem item = new PurchaseItem
                {
                    ProductName = txtProduct.Text,
                    Quantity = Convert.ToInt32(txtQty.Text),
                    UnitPrice = Convert.ToDecimal(txtPrice.Text),
                    WarrantyMonths = string.IsNullOrWhiteSpace(txtWarranty.Text) ? 0 : Convert.ToInt32(txtWarranty.Text),
                };

                _transaction.Items.Add(item);
                LoaddgvNewItems(_transaction.Items);
                ClearItemInputField();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid item details. " + ex.Message);
            }
        }

        private void ClearItemInputField()
        {
            txtProduct.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
            txtWarranty.Text = "0";
        }

        private void LoaddgvNewItems(List<PurchaseItem> items)
        {
            dgvNewItems.DataSource = null;
            dgvNewItems.Columns.Clear();
            
            dgvNewItems.DataSource = ConvertToDataTable(items);

            AddGridButton(dgvNewItems, "Delete", "Delete");
            dgvNewItems.Columns["Delete"].DisplayIndex = 0;

            if (dgvNewItems.Columns.Contains("PurchaseID"))
                dgvNewItems.Columns["PurchaseID"].Visible = false;
            if (dgvNewItems.Columns.Contains("ItemID"))
                dgvNewItems.Columns["ItemID"].Visible = false;
        }

        private DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props) dataTable.Columns.Add(prop.Name);
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++) values[i] = Props[i].GetValue(item, null);
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private void dgvNewItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvNewItems.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_transaction.Items.Count > e.RowIndex) 
                        _transaction.Items.RemoveAt(e.RowIndex);
                        
                    LoaddgvNewItems(_transaction.Items);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValidated())
            {
                MessageBox.Show("Provide correct Information", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _transaction.PurchaseID = _intPurchaseId;
                _transaction.PurchaseDate = dtpDate.Value;
                _transaction.BuyerName = txtBuyer.Text;
                _transaction.SupplierName = txtSupplier.Text;
                _transaction.DeliveryCharge = Convert.ToDecimal(txtDelivery.Text);
                _transaction.TaxAmount = Convert.ToDecimal(txtTax.Text);
                _transaction.Discount = Convert.ToDecimal(txtDiscount.Text);
                _transaction.IsPaid = chkIsPaid.Checked;
                
                decimal itemsTotal = 0;
                foreach (var item in _transaction.Items)
                {
                    itemsTotal += item.SubTotal;
                }
                _transaction.GrandTotal = itemsTotal + _transaction.DeliveryCharge + _transaction.TaxAmount - _transaction.Discount;

                if (_isDefaultImage)
                {
                    _transaction.InvoiceImage = null; 
                }
                else
                {
                    if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(openFileDialog1.FileName))
                    {
                        _transaction.InvoiceImage = File.ReadAllBytes(openFileDialog1.FileName);
                    }
                    else
                    {
                        _transaction.InvoiceImage = _previousImageBytes;
                    }
                }

                (bool success, string msg, int newId) result;
                if (_intPurchaseId > 0)
                {
                    var uResult = _repo.Update(_transaction);
                    result = (uResult.Success, uResult.Message, _intPurchaseId);
                }
                else
                {
                    result = _repo.Save(_transaction);
                }

                if (result.success)
                {
                    MessageBox.Show(result.msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoaddgvPurchases();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(result.msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidated()
        {
            if (string.IsNullOrWhiteSpace(txtBuyer.Text) || string.IsNullOrWhiteSpace(txtSupplier.Text))
                return false;
            if (_transaction.Items == null || _transaction.Items.Count == 0)
                return false;
            return true;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var reportData = _repo.GetComprehensiveReportData();
            FrmReportViewer frm = new FrmReportViewer(reportData);
            frm.ShowDialog();
        }
    }
}
