using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;
using BarangayManagementSystem.Controls;

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
            
            // Set initial active button
            activeButton = btnDashboard;
            
            // Load dashboard by default
            LoadChildForm(new AdminDashboardOverviewForm(currentUser));
            
            // Start notification timer
            notificationRefreshTimer = new Timer();
            notificationRefreshTimer.Interval = 30000; // 30 seconds
            notificationRefreshTimer.Tick += (s, ev) => UpdateNotificationCount();
            notificationRefreshTimer.Start();
            
            UpdateNotificationCount();
            
            EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Login", "Admin Dashboard", "Admin logged in");
        }

        private void LoadChildForm(Form childForm)
        {
            if (activeChildForm != null)
                activeChildForm.Close();
                
            activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(childForm);
            contentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ActivateButton(Button button)
        {
            // Reset previous button
            if (activeButton != null)
            {
                activeButton.BackColor = Color.Transparent;
                activeButton.ForeColor = Color.FromArgb(222, 226, 230);
            }
            
            // Set new active button
            activeButton = button;
            button.BackColor = Color.FromArgb(220, 53, 69);
            button.ForeColor = Color.White;
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

        // Event Handlers
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard);
            LoadChildForm(new AdminDashboardOverviewForm(currentUser));
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            ActivateButton(btnUsers);
            LoadChildForm(new UserManagementForm(currentUser));
        }

        private void BtnRequests_Click(object sender, EventArgs e)
        {
            ActivateButton(btnRequests);
            LoadChildForm(new RequestManagementForm(currentUser));
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            ActivateButton(btnReports);
            LoadChildForm(new ReportManagementForm(currentUser));
        }

        private void BtnOfficials_Click(object sender, EventArgs e)
        {
            ActivateButton(btnOfficials);
            LoadChildForm(new OfficialManagementForm(currentUser));
        }

        private void BtnNews_Click(object sender, EventArgs e)
        {
            ActivateButton(btnNews);
            LoadChildForm(new NewsManagementForm(currentUser));
        }

        private void BtnAnnouncements_Click(object sender, EventArgs e)
        {
            ActivateButton(btnAnnouncements);
            LoadChildForm(new AnnouncementManagementForm(currentUser));
        }

        private void BtnAnalytics_Click(object sender, EventArgs e)
        {
            ActivateButton(btnAnalytics);
            LoadChildForm(new AnalyticsForm(currentUser));
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSettings);
            LoadChildForm(new SettingsForm(currentUser));
        }

        private void BtnNotification_Click(object sender, EventArgs e)
        {
            // Show notification panel
            NotificationPanel notifPanel = new NotificationPanel(currentUser);
            notifPanel.ShowNotifications();
            UpdateNotificationCount();
        }

        private void BtnAvatar_Click(object sender, EventArgs e)
        {
            AdminProfileForm profileForm = new AdminProfileForm(currentUser);
            profileForm.ShowDialog();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Logout", "Admin Dashboard", "Admin logged out");
                
                if (notificationRefreshTimer != null)
                {
                    notificationRefreshTimer.Stop();
                    notificationRefreshTimer.Dispose();
                }
                
                // Just close - the FormClosed event in LoginForm will show the original login form
                this.Close();
            }
        }

        private void SidebarButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != activeButton)
                btn.BackColor = Color.FromArgb(52, 58, 64);
        }

        private void SidebarButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != activeButton)
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
            if (notificationRefreshTimer != null)
            {
                notificationRefreshTimer.Stop();
                notificationRefreshTimer.Dispose();
            }
        }
    }
}