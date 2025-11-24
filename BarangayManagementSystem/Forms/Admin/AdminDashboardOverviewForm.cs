using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class AdminDashboardOverviewForm : Form
    {
        private Models.User currentUser;

        public AdminDashboardOverviewForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void AdminDashboardOverviewForm_Load(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadRecentActivity();
            ConfigureDataGridView();
        }

        private void LoadStatistics()
        {
            try
            {
                int totalUsers = DatabaseHelper.GetAllUsers().Count();
                int pendingRequests = DatabaseHelper.GetAllRequests().Count(r => r.Status == "Pending");
                int openReports = DatabaseHelper.GetAllReports().Count(r => r.Status == "Open");
                int approvedToday = DatabaseHelper.GetAllRequests().Count(r => r.Status == "Approved" && r.ProcessedDate.HasValue && r.ProcessedDate.Value.Date == DateTime.Now.Date);
                int activeOfficials = EnhancedDatabaseHelper.GetAllOfficials(true).Count();
                int publishedNews = EnhancedDatabaseHelper.GetAllNews().Count();

                lblStat1Value.Text = totalUsers.ToString();
                lblStat2Value.Text = pendingRequests.ToString();
                lblStat3Value.Text = openReports.ToString();
                lblStat4Value.Text = approvedToday.ToString();
                lblStat5Value.Text = activeOfficials.ToString();
                lblStat6Value.Text = publishedNews.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvRecentActivity.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 53, 69);
            dgvRecentActivity.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRecentActivity.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvRecentActivity.EnableHeadersVisualStyles = false;
            dgvRecentActivity.Font = new Font("Segoe UI", 9F);
            dgvRecentActivity.RowTemplate.Height = 30;
        }

        private void LoadRecentActivity()
        {
            try
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Activity", typeof(string));
                dataTable.Columns.Add("Time", typeof(string));

                var recentLogs = EnhancedDatabaseHelper.GetRecentActivityLogs(10);
                foreach (var log in recentLogs)
                {
                    dataTable.Rows.Add(
                        $"{log.Action} - {log.Description}",
                        log.CreatedDate.ToString("MMM dd, HH:mm")
                    );
                }

                dgvRecentActivity.DataSource = dataTable;
                dgvRecentActivity.Columns["Activity"].Width = 350;
                dgvRecentActivity.Columns["Time"].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading activity: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}