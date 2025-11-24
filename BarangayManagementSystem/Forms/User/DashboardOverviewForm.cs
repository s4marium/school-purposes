using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.User
{
    public partial class DashboardOverviewForm : Form
    {
        private Models.User currentUser;
        public event EventHandler<string> NavigationRequested;

        public DashboardOverviewForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void DashboardOverviewForm_Load(object sender, EventArgs e)
        {
            LoadGreeting();
            LoadStatistics();
            LoadRecentActivity();
        }

        private void LoadGreeting()
        {
            string timeOfDay = GetTimeOfDay();
            lblGreeting.Text = $"Good {timeOfDay}, {currentUser.FullName}! 👋";
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy - dddd");
        }

        private void LoadStatistics()
        {
            try
            {
                int pendingRequests = DatabaseHelper.GetUserRequests(currentUser.Id)
                    .Count(r => r.Status == "Pending");
                int approvedRequests = DatabaseHelper.GetUserRequests(currentUser.Id)
                    .Count(r => r.Status == "Approved");
                int activeReports = DatabaseHelper.GetUserReports(currentUser.Id)
                    .Count(r => r.Status == "Open");
                int notifications = EnhancedDatabaseHelper.GetUnreadNotificationCount(currentUser.Id);

                lblStat1Value.Text = pendingRequests.ToString();
                lblStat2Value.Text = approvedRequests.ToString();
                lblStat3Value.Text = activeReports.ToString();
                lblStat4Value.Text = notifications.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentActivity()
        {
            lstActivity.Items.Clear();
            
            try
            {
                var requests = DatabaseHelper.GetUserRequests(currentUser.Id)
                    .OrderByDescending(r => r.CreatedDate)
                    .Take(5);

                foreach (var req in requests)
                {
                    lstActivity.Items.Add($"📋 {req.RequestType} - {req.Status} ({req.CreatedDate:MMM dd})");
                }

                var reports = DatabaseHelper.GetUserReports(currentUser.Id)
                    .OrderByDescending(r => r.CreatedDate)
                    .Take(3);

                foreach (var rep in reports)
                {
                    lstActivity.Items.Add($"📊 {rep.ReportType} - {rep.Status} ({rep.CreatedDate:MMM dd})");
                }

                if (lstActivity.Items.Count == 0)
                {
                    lstActivity.Items.Add("No recent activity");
                }
            }
            catch (Exception ex)
            {
                lstActivity.Items.Add($"Error: {ex.Message}");
            }
        }

        private string GetTimeOfDay()
        {
            int hour = DateTime.Now.Hour;
            if (hour < 12) return "Morning";
            if (hour < 17) return "Afternoon";
            return "Evening";
        }

        private void LstActivity_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(lstActivity.Items[e.Index].ToString(),
                    e.Font, brush, e.Bounds.Left + 5, e.Bounds.Top + 8);
            }
        }

        private void BtnQuickRequest_Click(object sender, EventArgs e)
        {
            NavigationRequested?.Invoke(this, "SubmitRequest");
        }

        private void BtnQuickReport_Click(object sender, EventArgs e)
        {
            NavigationRequested?.Invoke(this, "FileReport");
        }

        private void BtnQuickMyRequests_Click(object sender, EventArgs e)
        {
            NavigationRequested?.Invoke(this, "MyRequests");
        }

        private void BtnQuickNews_Click(object sender, EventArgs e)
        {
            NavigationRequested?.Invoke(this, "News");
        }
    }
}