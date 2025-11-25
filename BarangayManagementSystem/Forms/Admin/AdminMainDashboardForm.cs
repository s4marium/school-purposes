using BarangayManagementSystem.Data;
// Existing admin forms
using BarangayManagementSystem.Forms.Admin; // AdminDashboardOverviewForm, UserManagementForm, RequestManagementForm, ReportManagementForm, SettingsForm
using BarangayManagementSystem.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class AdminMainDashboardForm : Form
    {
        private Models.User currentUser;
        private Button activeButton;
        private Form activeChildForm;
        private Timer notificationRefreshTimer;

        public AdminMainDashboardForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void AdminMainDashboardForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = currentUser.FullName;
            btnAvatar.Text = currentUser.FullName.Substring(0, 1).ToUpper();

            activeButton = btnDashboard;
            LoadChildForm(new AdminDashboardOverviewForm(currentUser));
            StartNotificationTimer();
            UpdateNotificationCount();

            EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Login", "Admin Dashboard", "Admin logged in");
        }

        private void StartNotificationTimer()
        {
            notificationRefreshTimer = new Timer { Interval = 30000 };
            notificationRefreshTimer.Tick += (s, ev) => UpdateNotificationCount();
            notificationRefreshTimer.Start();
        }

        private void LoadChildForm(Form childForm)
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
                activeChildForm.Dispose();
            }

            activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(childForm);
            childForm.Show();
        }

        private void ActivateButton(Button button)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.Transparent;
                activeButton.ForeColor = Color.FromArgb(222, 226, 230);
            }
            activeButton = button;
            button.BackColor = Color.FromArgb(220, 53, 69);
            button.ForeColor = Color.White;
        }

        // Centralized navigation
        private void Navigate(string section)
        {
            switch (section)
            {
                case "Dashboard":
                    ActivateButton(btnDashboard);
                    LoadChildForm(new AdminDashboardOverviewForm(currentUser));
                    break;

                case "Users":
                    ActivateButton(btnUsers);
                    LoadChildForm(new UserManagementForm(currentUser));
                    break;

                case "Requests":
                    ActivateButton(btnRequests);
                    LoadChildForm(new RequestManagementForm(currentUser));
                    break;

                case "Reports":
                    ActivateButton(btnReports);
                    LoadChildForm(new ReportManagementForm(currentUser));
                    break;

                case "Officials":
                    ActivateButton(btnOfficials);
                    LoadChildForm(new OfficialManagementForm(currentUser));
                    break;

                case "News":
                    ActivateButton(btnNews);
                    LoadChildForm(new NewsManagementForm(currentUser));
                    break;

                case "Announcements":
                    ActivateButton(btnAnnouncements);
                    LoadChildForm(new AnnouncementManagementForm(currentUser));
                    break;

                case "Analytics":
                    ActivateButton(btnAnalytics);
                    LoadChildForm(new AnalyticsForm(currentUser));
                    break;

                case "Settings":
                    ActivateButton(btnSettings);
                    LoadChildForm(new SettingsForm(currentUser));
                    break;

                default:
                    MessageBox.Show($"Section '{section}' not found.", "Navigation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void UpdateNotificationCount()
        {
            try
            {
                int count = EnhancedDatabaseHelper.GetUnreadNotificationCount(currentUser.Id);
                btnNotification.Text = count > 0 ? $"🔔 {count}" : "🔔";
            }
            catch { }
        }

        // Sidebar button handlers now call Navigate
        private void BtnDashboard_Click(object sender, EventArgs e) => Navigate("Dashboard");
        private void BtnUsers_Click(object sender, EventArgs e) => Navigate("Users");
        private void BtnRequests_Click(object sender, EventArgs e) => Navigate("Requests");
        private void BtnReports_Click(object sender, EventArgs e) => Navigate("Reports");
        private void BtnAnnouncements_Click(object sender, EventArgs e) => Navigate("Announcements");
        private void BtnAnalytics_Click(object sender, EventArgs e) => Navigate("Analytics");
        private void BtnSettings_Click(object sender, EventArgs e) => Navigate("Settings");
        // Added missing handlers referenced by Designer
        private void BtnOfficials_Click(object sender, EventArgs e) => Navigate("Officials");
        private void BtnNews_Click(object sender, EventArgs e) => Navigate("News");

        private void BtnNotification_Click(object sender, EventArgs e)
        {
            Controls.NotificationPanel notifPanel = new Controls.NotificationPanel(currentUser);
            notifPanel.ShowNotifications();
            UpdateNotificationCount();
        }

        private void BtnAvatar_Click(object sender, EventArgs e)
        {
            using (User.UserProfileForm profileForm = new User.UserProfileForm(currentUser))
            {
                profileForm.ShowDialog(this);
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        private void BtnClose_Click(object sender, EventArgs e) => Application.Exit();

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Logout", "Admin Dashboard", "Admin logged out");
                notificationRefreshTimer?.Stop();
                notificationRefreshTimer?.Dispose();
                Close();
            }
        }

        private void SidebarButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn && btn != activeButton)
                btn.BackColor = Color.FromArgb(52, 58, 64);
        }

        private void SidebarButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn && btn != activeButton)
                btn.BackColor = Color.Transparent;
        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                e.Graphics.DrawLine(pen, 0, topPanel.Height - 1, topPanel.Width, topPanel.Height - 1);
            }
        }

        private void BtnAvatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, btnAvatar.Width - 1, btnAvatar.Height - 1);
                btnAvatar.Region = new Region(path);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            notificationRefreshTimer?.Stop();
            notificationRefreshTimer?.Dispose();
        }
    }
}