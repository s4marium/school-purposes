using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class ReportManagementForm : Form
    {
        private Models.User currentUser;

        public ReportManagementForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void ReportManagementForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            cmbStatusFilter.SelectedIndex = 0;
            cmbTypeFilter.SelectedIndex = 0;
            LoadReports();
        }

        private void ConfigureDataGridView()
        {
            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 53, 69);
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvReports.EnableHeadersVisualStyles = false;
            dgvReports.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvReports.Font = new Font("Segoe UI", 10F);
        }

        private void LoadReports(string statusFilter = "All Status", string typeFilter = "All Types")
        {
            try
            {
                var reports = DatabaseHelper.GetAllReports();

                // Apply filters
                if (statusFilter != "All Status")
                    reports = reports.Where(r => r.Status == statusFilter).ToList();

                if (typeFilter != "All Types")
                    reports = reports.Where(r => r.ReportType == typeFilter).ToList();

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("User", typeof(string));
                dataTable.Columns.Add("Report Type", typeof(string));
                dataTable.Columns.Add("Subject", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Date Filed", typeof(DateTime));
                dataTable.Columns.Add("Date Resolved", typeof(string));

                foreach (var report in reports.OrderByDescending(r => r.CreatedDate))
                {
                    var user = DatabaseHelper.GetUserById(report.UserId);
                    dataTable.Rows.Add(
                        report.Id,
                        user != null ? user.FullName : "Unknown",
                        report.ReportType,
                        report.Subject,
                        report.Status,
                        report.CreatedDate,
                        report.ResolvedDate.HasValue ? report.ResolvedDate.Value.ToString("MMM dd, yyyy") : "Pending"
                    );
                }

                dgvReports.DataSource = dataTable;

                if (dgvReports.Columns["Id"] != null)
                    dgvReports.Columns["Id"].Visible = false;

                // Color code status
                foreach (DataGridViewRow row in dgvReports.Rows)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    switch (status)
                    {
                        case "Open":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                            break;
                        case "Under Review":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(209, 236, 241);
                            break;
                        case "Resolved":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 218);
                            break;
                        case "Closed":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(233, 236, 239);
                            break;
                    }
                }

                UpdateStatistics(reports);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics(System.Collections.Generic.List<Report> reports)
        {
            int total = reports.Count;
            int open = reports.Count(r => r.Status == "Open");
            int today = reports.Count(r => r.CreatedDate.Date == DateTime.Now.Date);

            lblStats.Text = $"Total Reports: {total} | Open: {open} | Today: {today}";
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReports(cmbStatusFilter.Text, cmbTypeFilter.Text);
        }

        private void CmbTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReports(cmbStatusFilter.Text, cmbTypeFilter.Text);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            cmbStatusFilter.SelectedIndex = 0;
            cmbTypeFilter.SelectedIndex = 0;
            LoadReports();
        }

        private void BtnResolve_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a report to resolve.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reportId = Convert.ToInt32(dgvReports.SelectedRows[0].Cells["Id"].Value);
            string subject = dgvReports.SelectedRows[0].Cells["Subject"].Value.ToString();
            string userName = dgvReports.SelectedRows[0].Cells["User"].Value.ToString();

            DialogResult result = MessageBox.Show($"Mark report '{subject}' as Resolved?",
                "Confirm Resolution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (DatabaseHelper.UpdateReportStatus(reportId, "Resolved"))
                {
                    var report = DatabaseHelper.GetAllReports().FirstOrDefault(r => r.Id == reportId);
                    if (report != null)
                    {
                        EnhancedDatabaseHelper.CreateNotification(new Notification
                        {
                            UserId = report.UserId,
                            Title = "Report Resolved",
                            Message = $"Your report '{report.Subject}' has been resolved.",
                            Type = "Success",
                            Category = "Report",
                            CreatedBy = currentUser.Id
                        });
                    }

                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Resolve Report", "Reports",
                        $"Resolved report: {subject}");

                    MessageBox.Show("Report marked as resolved!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReports(cmbStatusFilter.Text, cmbTypeFilter.Text);
                }
            }
        }

        private void BtnUnderReview_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a report to review.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reportId = Convert.ToInt32(dgvReports.SelectedRows[0].Cells["Id"].Value);

            if (DatabaseHelper.UpdateReportStatus(reportId, "Under Review"))
            {
                MessageBox.Show("Report status updated to Under Review!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReports(cmbStatusFilter.Text, cmbTypeFilter.Text);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a report to close.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reportId = Convert.ToInt32(dgvReports.SelectedRows[0].Cells["Id"].Value);
            string subject = dgvReports.SelectedRows[0].Cells["Subject"].Value.ToString();

            DialogResult result = MessageBox.Show($"Close report '{subject}'?",
                "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (DatabaseHelper.UpdateReportStatus(reportId, "Closed"))
                {
                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Close Report", "Reports",
                        $"Closed report: {subject}");

                    MessageBox.Show("Report closed!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReports(cmbStatusFilter.Text, cmbTypeFilter.Text);
                }
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a report to view details.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reportId = Convert.ToInt32(dgvReports.SelectedRows[0].Cells["Id"].Value);
            var reports = DatabaseHelper.GetAllReports();
            var report = reports.FirstOrDefault(r => r.Id == reportId);

            if (report != null)
            {
                ShowReportDetails(report);
            }
        }

        private void ShowReportDetails(Report report)
        {
            var user = DatabaseHelper.GetUserById(report.UserId);

            Form detailsForm = new Form
            {
                Text = "Report Details",
                Size = new Size(650, 550),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            string statusEmoji = report.Status == "Resolved" ? "✅" :
                                report.Status == "Under Review" ? "🔍" :
                                report.Status == "Closed" ? "🔒" : "📋";

            string details = $@"
REPORT DETAILS

Report ID: #{report.Id}
Reported By: {user?.FullName ?? "Unknown"}
Contact: {user?.ContactNumber ?? "N/A"}

Report Type: {report.ReportType}
Subject: {report.Subject}
Status: {statusEmoji} {report.Status}

Date Filed: {report.CreatedDate:MMMM dd, yyyy HH:mm}
{(report.ResolvedDate.HasValue ? $"Date Resolved: {report.ResolvedDate:MMMM dd, yyyy HH:mm}" : "")}

Description:
{report.Description}
            ";

            TextBox txtDetails = new TextBox
            {
                Text = details,
                Font = new Font("Consolas", 10F),
                Location = new Point(30, 30),
                Size = new Size(590, 420),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button closeBtn = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(520, 465),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.Click += (s, args) => detailsForm.Close();

            detailsForm.Controls.AddRange(new Control[] { txtDetails, closeBtn });
            detailsForm.ShowDialog();
        }
    }
}