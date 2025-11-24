using System;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.User
{
    public partial class FileReportForm : Form
    {
        private Models.User currentUser;

        public FileReportForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void FileReportForm_Load(object sender, EventArgs e)
        {
            // Form is ready
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedIndex == -1 || 
                string.IsNullOrWhiteSpace(txtSubject.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var report = new Report
            {
                UserId = currentUser.Id,
                ReportType = cmbReportType.Text,
                Subject = txtSubject.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            if (DatabaseHelper.CreateReport(report))
            {
                EnhancedDatabaseHelper.CreateNotification(new Notification
                {
                    UserId = currentUser.Id,
                    Title = "Report Submitted",
                    Message = $"Your report about '{report.Subject}' has been submitted.",
                    Type = "Info",
                    Category = "Report",
                    CreatedBy = currentUser.Id
                });

                EnhancedDatabaseHelper.LogActivity(currentUser.Id, "File Report", "Reports",
                    $"Filed {cmbReportType.Text} report");

                MessageBox.Show("Report submitted successfully! The barangay will review your concern.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to submit report. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cmbReportType.SelectedIndex = -1;
            txtSubject.Clear();
            txtDescription.Clear();
        }
    }
}