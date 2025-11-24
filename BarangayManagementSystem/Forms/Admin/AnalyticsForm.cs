using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class AnalyticsForm : Form
    {
        private Models.User currentUser;

        public AnalyticsForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            cmbTimeRange.SelectedIndex = 1; // Last 7 Days
            LoadAnalytics();
        }

        private void ConfigureDataGridView()
        {
            dgvActivityLog.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(111, 66, 193);
            dgvActivityLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvActivityLog.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvActivityLog.EnableHeadersVisualStyles = false;
            dgvActivityLog.Font = new Font("Segoe UI", 9F);
            dgvActivityLog.RowTemplate.Height = 30;
        }

        private void LoadAnalytics()
        {
            try
            {
                DateTime startDate = GetStartDate();

                // Load statistics
                var activities = EnhancedDatabaseHelper.GetActivityLogsByDateRange(startDate, DateTime.Now);
                var requests = DatabaseHelper.GetAllRequests().Where(r => r.CreatedDate >= startDate).ToList();
                var reports = DatabaseHelper.GetAllReports().Where(r => r.CreatedDate >= startDate).ToList();
                var activeUsers = DatabaseHelper.GetAllUsers().Count(u => u.IsActive);

                lblStat1Value.Text = activities.Count(a => a.Action == "Login").ToString();
                lblStat2Value.Text = requests.Count(r => r.CreatedDate.Date == DateTime.Now.Date).ToString();
                lblStat3Value.Text = reports.Count(r => r.CreatedDate.Date == DateTime.Now.Date).ToString();
                lblStat4Value.Text = activeUsers.ToString();

                // Load recent activity
                LoadRecentActivity();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading analytics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentActivity()
        {
            try
            {
                var activities = EnhancedDatabaseHelper.GetRecentActivityLogs(5);

                var dataTable = new DataTable();
                dataTable.Columns.Add("Action", typeof(string));
                dataTable.Columns.Add("Time", typeof(string));

                foreach (var activity in activities)
                {
                    dataTable.Rows.Add(
                        activity.Action,
                        activity.CreatedDate.ToString("MMM dd HH:mm")
                    );
                }

                dgvActivityLog.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading activity: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime GetStartDate()
        {
            switch (cmbTimeRange.SelectedIndex)
            {
                case 0: // Today
                    return DateTime.Now.Date;
                case 1: // Last 7 Days
                    return DateTime.Now.AddDays(-7);
                case 2: // Last 30 Days
                    return DateTime.Now.AddDays(-30);
                case 3: // This Month
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                case 4: // All Time
                    return DateTime.MinValue;
                default:
                    return DateTime.Now.AddDays(-7);
            }
        }

        private void CmbTimeRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAnalytics();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAnalytics();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export to CSV functionality will be implemented.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}