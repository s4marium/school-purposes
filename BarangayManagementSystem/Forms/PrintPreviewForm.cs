using System;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;
using UserModel = BarangayManagementSystem.Models.User;

namespace BarangayManagementSystem.Forms
{
    public partial class PrintPreviewForm : Form
    {
        private readonly UserModel currentUser;
        private readonly string documentType;

        public PrintPreviewForm(UserModel user, string docType)
        {
            currentUser = user;
            documentType = docType;
            InitializeComponent();
            PreparePreview();
        }

        private void PreparePreview()
        {
            var barangay = EnhancedDatabaseHelper.GetSystemSettings()?.BarangayName ?? "YOUR BARANGAY";
            lblTitle.Text = $"Print Preview: {documentType}";
            lblPreviewText.Text =
$@"REPUBLIC OF THE PHILIPPINES
{barangay}

{documentType.ToUpper()}

This is to certify that...

[Document content will appear here]

Date Issued: {DateTime.Now:MMMM dd, yyyy}";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Printing {documentType}...\n\nThis feature will be integrated with the system printer.",
                "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);

            EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Print Document", "Printing",
                $"Printed {documentType}");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}