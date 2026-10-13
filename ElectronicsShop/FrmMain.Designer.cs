namespace ElectronicsShop
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkIsPaid = new System.Windows.Forms.CheckBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.txtDelivery = new System.Windows.Forms.TextBox();
            this.lblBuyer = new System.Windows.Forms.Label();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            this.lblPurchaseID = new System.Windows.Forms.Label();
            this.txtPurchaseID = new System.Windows.Forms.TextBox();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.btnCancelImage = new System.Windows.Forms.Button();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.picInvoice = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxItems = new System.Windows.Forms.GroupBox();
            this.dgvNewItems = new System.Windows.Forms.DataGridView();
            this.txtWarranty = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lblWarranty = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.dgvPurchases = new System.Windows.Forms.DataGridView();
            this.dgvExistingItems = new System.Windows.Forms.DataGridView();
            this.groupBoxDetails.SuspendLayout();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInvoice)).BeginInit();
            this.groupBoxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistingItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Electronics Purchase";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(808, 13);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(85, 23);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Crystal Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.btnSave);
            this.groupBoxDetails.Controls.Add(this.chkIsPaid);
            this.groupBoxDetails.Controls.Add(this.dtpDate);
            this.groupBoxDetails.Controls.Add(this.lblDate);
            this.groupBoxDetails.Controls.Add(this.lblTax);
            this.groupBoxDetails.Controls.Add(this.txtTax);
            this.groupBoxDetails.Controls.Add(this.lblSupplier);
            this.groupBoxDetails.Controls.Add(this.txtSupplier);
            this.groupBoxDetails.Controls.Add(this.lblDiscount);
            this.groupBoxDetails.Controls.Add(this.txtDiscount);
            this.groupBoxDetails.Controls.Add(this.lblDelivery);
            this.groupBoxDetails.Controls.Add(this.txtDelivery);
            this.groupBoxDetails.Controls.Add(this.lblBuyer);
            this.groupBoxDetails.Controls.Add(this.txtBuyer);
            this.groupBoxDetails.Controls.Add(this.lblPurchaseID);
            this.groupBoxDetails.Controls.Add(this.txtPurchaseID);
            this.groupBoxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDetails.Location = new System.Drawing.Point(26, 49);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(431, 195);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Purchase Details";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSave.Location = new System.Drawing.Point(286, 152);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 37);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsPaid
            // 
            this.chkIsPaid.AutoSize = true;
            this.chkIsPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsPaid.Location = new System.Drawing.Point(325, 78);
            this.chkIsPaid.Name = "chkIsPaid";
            this.chkIsPaid.Size = new System.Drawing.Size(61, 20);
            this.chkIsPaid.TabIndex = 4;
            this.chkIsPaid.Text = "Paid?";
            this.chkIsPaid.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(110, 68);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(90, 22);
            this.dtpDate.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(15, 68);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 16);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date:";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(235, 115);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(33, 16);
            this.lblTax.TabIndex = 0;
            this.lblTax.Text = "Tax:";
            // 
            // txtTax
            // 
            this.txtTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTax.Location = new System.Drawing.Point(325, 115);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(100, 22);
            this.txtTax.TabIndex = 4;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(15, 100);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(60, 16);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Supplier:";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(110, 100);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(117, 22);
            this.txtSupplier.TabIndex = 5;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(235, 36);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(62, 16);
            this.lblDiscount.TabIndex = 0;
            this.lblDiscount.Text = "Discount:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(325, 36);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(100, 22);
            this.txtDiscount.TabIndex = 2;
            // 
            // lblDelivery
            // 
            this.lblDelivery.AutoSize = true;
            this.lblDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelivery.Location = new System.Drawing.Point(15, 132);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(60, 16);
            this.lblDelivery.TabIndex = 0;
            this.lblDelivery.Text = "Delivery:";
            // 
            // txtDelivery
            // 
            this.txtDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelivery.Location = new System.Drawing.Point(110, 132);
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.Size = new System.Drawing.Size(90, 22);
            this.txtDelivery.TabIndex = 7;
            // 
            // lblBuyer
            // 
            this.lblBuyer.AutoSize = true;
            this.lblBuyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyer.Location = new System.Drawing.Point(15, 164);
            this.lblBuyer.Name = "lblBuyer";
            this.lblBuyer.Size = new System.Drawing.Size(45, 16);
            this.lblBuyer.TabIndex = 0;
            this.lblBuyer.Text = "Buyer:";
            // 
            // txtBuyer
            // 
            this.txtBuyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyer.Location = new System.Drawing.Point(110, 164);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(117, 22);
            this.txtBuyer.TabIndex = 8;
            // 
            // lblPurchaseID
            // 
            this.lblPurchaseID.AutoSize = true;
            this.lblPurchaseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseID.Location = new System.Drawing.Point(15, 36);
            this.lblPurchaseID.Name = "lblPurchaseID";
            this.lblPurchaseID.Size = new System.Drawing.Size(83, 16);
            this.lblPurchaseID.TabIndex = 0;
            this.lblPurchaseID.Text = "Purchase ID:";
            // 
            // txtPurchaseID
            // 
            this.txtPurchaseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseID.Location = new System.Drawing.Point(110, 36);
            this.txtPurchaseID.Name = "txtPurchaseID";
            this.txtPurchaseID.ReadOnly = true;
            this.txtPurchaseID.Size = new System.Drawing.Size(90, 22);
            this.txtPurchaseID.TabIndex = 1;
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Controls.Add(this.btnCancelImage);
            this.groupBoxImage.Controls.Add(this.btnUploadImage);
            this.groupBoxImage.Controls.Add(this.picInvoice);
            this.groupBoxImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxImage.Location = new System.Drawing.Point(463, 49);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(133, 195);
            this.groupBoxImage.TabIndex = 2;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Upload Image";
            // 
            // btnCancelImage
            // 
            this.btnCancelImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelImage.Location = new System.Drawing.Point(67, 152);
            this.btnCancelImage.Name = "btnCancelImage";
            this.btnCancelImage.Size = new System.Drawing.Size(60, 23);
            this.btnCancelImage.TabIndex = 1;
            this.btnCancelImage.Text = "Cancel";
            this.btnCancelImage.UseVisualStyleBackColor = true;
            this.btnCancelImage.Click += new System.EventHandler(this.btnCancelImage_Click);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.Location = new System.Drawing.Point(0, 152);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(65, 23);
            this.btnUploadImage.TabIndex = 1;
            this.btnUploadImage.Text = "Upload";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // picInvoice
            // 
            this.picInvoice.Location = new System.Drawing.Point(16, 31);
            this.picInvoice.Name = "picInvoice";
            this.picInvoice.Size = new System.Drawing.Size(100, 108);
            this.picInvoice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInvoice.TabIndex = 0;
            this.picInvoice.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBoxItems
            // 
            this.groupBoxItems.Controls.Add(this.dgvNewItems);
            this.groupBoxItems.Controls.Add(this.txtWarranty);
            this.groupBoxItems.Controls.Add(this.btnAddItem);
            this.groupBoxItems.Controls.Add(this.lblWarranty);
            this.groupBoxItems.Controls.Add(this.txtProduct);
            this.groupBoxItems.Controls.Add(this.lblProduct);
            this.groupBoxItems.Controls.Add(this.txtQty);
            this.groupBoxItems.Controls.Add(this.lblQty);
            this.groupBoxItems.Controls.Add(this.txtPrice);
            this.groupBoxItems.Controls.Add(this.lblPrice);
            this.groupBoxItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxItems.Location = new System.Drawing.Point(602, 49);
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.Size = new System.Drawing.Size(310, 195);
            this.groupBoxItems.TabIndex = 3;
            this.groupBoxItems.TabStop = false;
            this.groupBoxItems.Text = "Items";
            // 
            // dgvNewItems
            // 
            this.dgvNewItems.AllowUserToAddRows = false;
            this.dgvNewItems.AllowUserToDeleteRows = false;
            this.dgvNewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewItems.Location = new System.Drawing.Point(16, 85);
            this.dgvNewItems.Name = "dgvNewItems";
            this.dgvNewItems.ReadOnly = true;
            this.dgvNewItems.RowHeadersVisible = false;
            this.dgvNewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNewItems.Size = new System.Drawing.Size(288, 100);
            this.dgvNewItems.TabIndex = 2;
            this.dgvNewItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNewItems_CellContentClick);
            // 
            // txtWarranty
            // 
            this.txtWarranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarranty.Location = new System.Drawing.Point(230, 27);
            this.txtWarranty.Name = "txtWarranty";
            this.txtWarranty.Size = new System.Drawing.Size(30, 22);
            this.txtWarranty.TabIndex = 1;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(220, 55);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(70, 24);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblWarranty
            // 
            this.lblWarranty.AutoSize = true;
            this.lblWarranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarranty.Location = new System.Drawing.Point(190, 30);
            this.lblWarranty.Name = "lblWarranty";
            this.lblWarranty.Size = new System.Drawing.Size(35, 16);
            this.lblWarranty.TabIndex = 0;
            this.lblWarranty.Text = "War:";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(65, 27);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(120, 22);
            this.txtProduct.TabIndex = 1;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(5, 30);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(56, 16);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "Product:";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(40, 55);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(40, 22);
            this.txtQty.TabIndex = 1;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(5, 58);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(30, 16);
            this.lblQty.TabIndex = 0;
            this.lblQty.Text = "Qty:";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(135, 55);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(70, 22);
            this.txtPrice.TabIndex = 1;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(90, 58);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 16);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "Price:";
            // 
            // dgvPurchases
            // 
            this.dgvPurchases.AllowUserToAddRows = false;
            this.dgvPurchases.AllowUserToDeleteRows = false;
            this.dgvPurchases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchases.Location = new System.Drawing.Point(12, 251);
            this.dgvPurchases.Name = "dgvPurchases";
            this.dgvPurchases.ReadOnly = true;
            this.dgvPurchases.RowHeadersVisible = false;
            this.dgvPurchases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchases.Size = new System.Drawing.Size(609, 254);
            this.dgvPurchases.TabIndex = 4;
            this.dgvPurchases.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchases_CellContentClick);
            // 
            // dgvExistingItems
            // 
            this.dgvExistingItems.AllowUserToAddRows = false;
            this.dgvExistingItems.AllowUserToDeleteRows = false;
            this.dgvExistingItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExistingItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExistingItems.Location = new System.Drawing.Point(627, 251);
            this.dgvExistingItems.Name = "dgvExistingItems";
            this.dgvExistingItems.ReadOnly = true;
            this.dgvExistingItems.RowHeadersVisible = false;
            this.dgvExistingItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExistingItems.Size = new System.Drawing.Size(279, 254);
            this.dgvExistingItems.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(918, 517);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.dgvExistingItems);
            this.Controls.Add(this.dgvPurchases);
            this.Controls.Add(this.groupBoxItems);
            this.Controls.Add(this.groupBoxImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxDetails);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Electronics Purchase & Inventory Manager";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.groupBoxImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picInvoice)).EndInit();
            this.groupBoxItems.ResumeLayout(false);
            this.groupBoxItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistingItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReport;
        
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label lblPurchaseID;
        private System.Windows.Forms.TextBox txtPurchaseID;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblBuyer;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.TextBox txtDelivery;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.CheckBox chkIsPaid;
        private System.Windows.Forms.Button btnSave;
        
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.PictureBox picInvoice;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnCancelImage;
        
        private System.Windows.Forms.GroupBox groupBoxItems;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblWarranty;
        private System.Windows.Forms.TextBox txtWarranty;
        private System.Windows.Forms.Button btnAddItem;
        
        private System.Windows.Forms.DataGridView dgvNewItems;
        private System.Windows.Forms.DataGridView dgvPurchases;
        private System.Windows.Forms.DataGridView dgvExistingItems;
        
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
