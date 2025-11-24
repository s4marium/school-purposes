using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.User
{
    public partial class MyReportsForm : Form
    {
        private Models.User currentUser;

        public MyReportsForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void MyReportsForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            cmbFilter.SelectedIndex = 0; // Select "All"
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

        private void LoadReports(string filter = "All")
        {
            try
            {
                var reports = DatabaseHelper.GetUserReports(currentUser.Id);

                if (filter != "All")
                    reports = reports.Where(r => r.Status == filter).ToList();

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Type", typeof(string));
                dataTable.Columns.Add("Subject", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Date Filed", typeof(DateTime));
                dataTable.Columns.Add("Date Resolved", typeof(string));

                foreach (var report in reports.OrderByDescending(r => r.CreatedDate))
                {
                    dataTable.Rows.Add(
                        report.Id,
                        report.ReportType,
                        report.Subject,
                        report.Status,
                        report.CreatedDate,
                        report.ResolvedDate.HasValue ? 
                            report.ResolvedDate.Value.ToString("MMM dd, yyyy") : "Pending"
                    );
                }

                dgvReports.DataSource = dataTable;

                if (dgvReports.Columns["Id"] != null)
                    dgvReports.Columns["Id"].Visible = false;

                // Apply row colors based on status
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReports(cmbFilter.Text);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports(cmbFilter.Text);
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
            var reports = DatabaseHelper.GetUserReports(currentUser.Id);
            var report = reports.FirstOrDefault(r => r.Id == reportId);

            if (report != null)
            {
                ShowReportDetails(report);
            }
        }

        private void ShowReportDetails(Report report)
        {
            Form detailsForm = new Form
            {
                Text = "Report Details",
                Size = new Size(650, 500),
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
Type: {report.ReportType}
Status: {statusEmoji} {report.Status}

Subject: {report.Subject}

Date Filed: {report.CreatedDate:MMMM dd, yyyy HH:mm}
{(report.ResolvedDate.HasValue ? $"Date Resolved: {report.ResolvedDate:MMMM dd, yyyy HH:mm}" : "")}

Description:
{report.Description}

{(report.Status == "Resolved" ? "✅ Your report has been resolved." : "")}
{(report.Status == "Open" ? "📋 Your report is awaiting review." : "")}
{(report.Status == "Under Review" ? "🔍 Your report is currently being reviewed." : "")}
{(report.Status == "Closed" ? "🔒 Your report has been closed." : "")}
            ";

            TextBox txtDetails = new TextBox
            {
                Text = details,
                Font = new Font("Consolas", 10F),
                Location = new Point(30, 30),
                Size = new Size(590, 370),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button closeBtn = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(520, 415),
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