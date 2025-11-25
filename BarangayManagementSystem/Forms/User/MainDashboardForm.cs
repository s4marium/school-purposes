using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;
using BarangayManagementSystem.Controls;
using BarangayManagementSystem.Forms; // for PrintingCenterControl

namespace BarangayManagementSystem.Forms.User
{
    public partial class MainDashboardForm : Form
    {
        private Models.User currentUser;
        private Button activeButton;
        private Form activeChildForm;
        private Timer notificationRefreshTimer;

        public MainDashboardForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void MainDashboardForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = currentUser.FullName;
            btnAvatar.Text = currentUser.FullName.Substring(0, 1).ToUpper();

            activeButton = btnDashboard;
            LoadChildForm(new DashboardOverviewForm(currentUser));
            StartNotificationTimer();
            UpdateNotificationCount();

            EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Login", "Dashboard", "User logged in");
        }

        private void StartNotificationTimer()
        {
            notificationRefreshTimer = new Timer { Interval = 30000 };
            notificationRefreshTimer.Tick += (s, ev) => UpdateNotificationCount();
            notificationRefreshTimer.Start();
        }

        private void LoadChildForm(Form childForm)
        {
            // Unhook old dashboard event before disposing
            if (activeChildForm is DashboardOverviewForm oldDash)
                oldDash.NavigationRequested -= DashboardForm_NavigationRequested;

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
            contentPanel.Tag = childForm;
            childForm.Show();

            if (childForm is DashboardOverviewForm newDash)
                newDash.NavigationRequested += DashboardForm_NavigationRequested;
        }

        private void DashboardForm_NavigationRequested(object sender, string section)
        {
            Navigate(section);
        }

        private void Navigate(string section)
        {
            switch (section)
            {
                case "Dashboard":
                    ActivateButton(btnDashboard);
                    LoadChildForm(new DashboardOverviewForm(currentUser));
                    break;
                case "News":
                    ActivateButton(btnNews);
                    LoadChildForm(new NewsViewForm(currentUser));
                    break;
                case "Officials":
                    ActivateButton(btnOfficials);
                    LoadChildForm(new OfficialsViewForm(currentUser));
                    break;
                case "SubmitRequest":
                    ActivateButton(btnSubmitRequest);
                    LoadChildForm(new SubmitRequestForm(currentUser));
                    break;
                case "MyRequests":
                    ActivateButton(btnMyRequests);
                    LoadChildForm(new MyRequestsForm(currentUser));
                    break;
                case "FileReport":
                    ActivateButton(btnFileReport);
                    LoadChildForm(new FileReportForm(currentUser));
                    break;
                case "MyReports":
                    ActivateButton(btnMyReports);
                    LoadChildForm(new MyReportsForm(currentUser));
                    break;
                case "Printing":
                    ActivateButton(btnPrinting);
                    LoadChildForm(new PrintingCenterForm(currentUser)); // fixed: use child form loading
                    break;
            }
        }

        private void ActivateButton(Button button)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.Transparent;
                activeButton.ForeColor = Color.FromArgb(222, 226, 230);
            }

            activeButton = button;
            button.BackColor = Color.FromArgb(0, 123, 255);
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

        // Sidebar button handlers now delegate to Navigate for consistency
        private void BtnDashboard_Click(object sender, EventArgs e) => Navigate("Dashboard");
        private void BtnNews_Click(object sender, EventArgs e) => Navigate("News");
        private void BtnOfficials_Click(object sender, EventArgs e) => Navigate("Officials");
        private void BtnSubmitRequest_Click(object sender, EventArgs e) => Navigate("SubmitRequest");
        private void BtnMyRequests_Click(object sender, EventArgs e) => Navigate("MyRequests");
        private void BtnFileReport_Click(object sender, EventArgs e) => Navigate("FileReport");
        private void BtnMyReports_Click(object sender, EventArgs e) => Navigate("MyReports");
        private void BtnPrinting_Click(object sender, EventArgs e) => Navigate("Printing");

        private void BtnNotification_Click(object sender, EventArgs e)
        {
            NotificationPanel notifPanel = new NotificationPanel(currentUser);
            notifPanel.ShowNotifications();
            UpdateNotificationCount();
        }

        private void BtnAvatar_Click(object sender, EventArgs e)
        {
            using (UserProfileForm profileForm = new UserProfileForm(currentUser))
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
                EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Logout", "Dashboard", "User logged out");
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

            if (activeChildForm is DashboardOverviewForm dash)
                dash.NavigationRequested -= DashboardForm_NavigationRequested;
        }
    }
}