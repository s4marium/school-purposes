using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;
using BarangayManagementSystem.Controls;

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
            
            // Set initial active button
            activeButton = btnDashboard;
            
            // Load dashboard by default
            LoadChildForm(new DashboardOverviewForm(currentUser));
            
            // Start notification timer
            notificationRefreshTimer = new Timer();
            notificationRefreshTimer.Interval = 30000; // 30 seconds
            notificationRefreshTimer.Tick += (s, ev) => UpdateNotificationCount();
            notificationRefreshTimer.Start();
            
            UpdateNotificationCount();
            
            EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Login", "Dashboard", "User logged in");
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

            // Subscribe to navigation events if it's DashboardOverviewForm
            if (childForm is DashboardOverviewForm dashboardForm)
            {
                dashboardForm.NavigationRequested += DashboardForm_NavigationRequested;
            }
        }

        private void DashboardForm_NavigationRequested(object sender, string section)
        {
            switch (section)
            {
                case "SubmitRequest":
                    BtnSubmitRequest_Click(null, null);
                    break;
                case "FileReport":
                    BtnFileReport_Click(null, null);
                    break;
                case "MyRequests":
                    BtnMyRequests_Click(null, null);
                    break;
                case "News":
                    BtnNews_Click(null, null);
                    break;
            }
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

        // Event Handlers
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard);
            LoadChildForm(new DashboardOverviewForm(currentUser));
        }

        private void BtnNews_Click(object sender, EventArgs e)
        {
            ActivateButton(btnNews);
            LoadChildForm(new NewsViewForm(currentUser));
        }

        private void BtnOfficials_Click(object sender, EventArgs e)
        {
            ActivateButton(btnOfficials);
            LoadChildForm(new OfficialsViewForm(currentUser));
        }

        private void BtnSubmitRequest_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSubmitRequest);
            LoadChildForm(new SubmitRequestForm(currentUser));
        }

        private void BtnMyRequests_Click(object sender, EventArgs e)
        {
            ActivateButton(btnMyRequests);
            LoadChildForm(new MyRequestsForm(currentUser));
        }

        private void BtnFileReport_Click(object sender, EventArgs e)
        {
            ActivateButton(btnFileReport);
            LoadChildForm(new FileReportForm(currentUser));
        }

        private void BtnMyReports_Click(object sender, EventArgs e)
        {
            ActivateButton(btnMyReports);
            LoadChildForm(new MyReportsForm(currentUser));
        }

        private void BtnPrinting_Click(object sender, EventArgs e)
        {
            ActivateButton(btnPrinting);
            // Load printing center control
            contentPanel.Controls.Clear();
            PrintingCenter printingCenter = new PrintingCenter(currentUser, contentPanel);
            printingCenter.ShowPrintingCenter();
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
            UserProfileForm profileForm = new UserProfileForm(currentUser);
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
                EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Logout", "Dashboard", "User logged out");
                
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