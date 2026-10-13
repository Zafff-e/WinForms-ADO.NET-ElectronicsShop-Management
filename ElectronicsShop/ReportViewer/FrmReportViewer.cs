using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace ElectronicsShop.ReportViewer
{
    /// <summary>
    /// FrmReportViewer - Loads and displays the Crystal Report.
    /// Passes the disconnected DataTable from the Repository to the Crystal Report engine.
    /// </summary>
    public partial class FrmReportViewer : Form
    {
        private readonly System.Collections.Generic.List<ViewModels.PurchaseReportViewModel> _reportData;

        public FrmReportViewer(System.Collections.Generic.List<ViewModels.PurchaseReportViewModel> reportData)
        {
            InitializeComponent();
            _reportData = reportData;
        }

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                // We load the embedded resource PurchaseReport.rpt automatically.
                // You can update this report with the Database Expert to use the new PurchaseReportViewModel!
                Reports.PurchaseReport rpt = new Reports.PurchaseReport();
                
                // Set the main dataset datasource
                rpt.SetDataSource(_reportData);

                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to bind data to Crystal Report: {ex.Message}\n\nMake sure the SAP Crystal Reports runtime is correctly installed.", 
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
