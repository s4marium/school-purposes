using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.Admin
{
    partial class AdminMainDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel topPanel;
        private Panel sidebarPanel;
        private Panel contentPanel;
        private Label lblLogo;
        private Label lblBrand;
        private Label lblSubtitle;
        private Label lblUserName;
        private Label lblRole;
        private Button btnNotification;
        private Button btnAvatar;
        private Button btnMinimize;
        private Button btnClose;
        private Button btnDashboard;
        private Button btnUsers;
        private Button btnRequests;
        private Button btnReports;
        private Button btnOfficials;
        private Button btnNews;
        private Button btnAnnouncements;
        private Button btnAnalytics;
        private Button btnSettings;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnNotification = new System.Windows.Forms.Button();
            this.btnAvatar = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnRequests = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnOfficials = new System.Windows.Forms.Button();
            this.btnNews = new System.Windows.Forms.Button();
            this.btnAnnouncements = new System.Windows.Forms.Button();
            this.btnAnalytics = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Controls.Add(this.btnMinimize);
            this.topPanel.Controls.Add(this.btnAvatar);
            this.topPanel.Controls.Add(this.btnNotification);
            this.topPanel.Controls.Add(this.lblRole);
            this.topPanel.Controls.Add(this.lblUserName);
            this.topPanel.Controls.Add(this.lblSubtitle);
            this.topPanel.Controls.Add(this.lblBrand);
            this.topPanel.Controls.Add(this.lblLogo);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1200, 70);
            this.topPanel.TabIndex = 0;
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TopPanel_Paint);
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Emoji", 24F);
            this.lblLogo.Location = new System.Drawing.Point(20, 20);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(40, 35);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "🏛️";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblBrand.Location = new System.Drawing.Point(65, 18);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(156, 20);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "BARANGAY PORTAL";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblSubtitle.Location = new System.Drawing.Point(65, 38);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(129, 13);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Administrator Dashboard";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblUserName.Location = new System.Drawing.Point(860, 15);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(77, 19);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "User Name";
            // 
            // lblRole
            // 
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.lblRole.Location = new System.Drawing.Point(860, 35);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(75, 13);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Administrator";
            // 
            // btnNotification
            // 
            this.btnNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotification.BackColor = System.Drawing.Color.Transparent;
            this.btnNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotification.FlatAppearance.BorderSize = 0;
            this.btnNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotification.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnNotification.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnNotification.Location = new System.Drawing.Point(1000, 15);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(40, 40);
            this.btnNotification.TabIndex = 5;
            this.btnNotification.Text = "🔔";
            this.btnNotification.UseVisualStyleBackColor = false;
            this.btnNotification.Click += new System.EventHandler(this.BtnNotification_Click);
            // 
            // btnAvatar
            // 
            this.btnAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvatar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAvatar.FlatAppearance.BorderSize = 0;
            this.btnAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvatar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAvatar.ForeColor = System.Drawing.Color.White;
            this.btnAvatar.Location = new System.Drawing.Point(1050, 15);
            this.btnAvatar.Name = "btnAvatar";
            this.btnAvatar.Size = new System.Drawing.Size(40, 40);
            this.btnAvatar.TabIndex = 6;
            this.btnAvatar.Text = "A";
            this.btnAvatar.UseVisualStyleBackColor = false;
            this.btnAvatar.Click += new System.EventHandler(this.BtnAvatar_Click);
            this.btnAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnAvatar_Paint);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnMinimize.Location = new System.Drawing.Point(1100, 17);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 7;
            this.btnMinimize.Text = "─";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnClose.Location = new System.Drawing.Point(1145, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.AutoScroll = true;
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.sidebarPanel.Controls.Add(this.btnLogout);
            this.sidebarPanel.Controls.Add(this.btnSettings);
            this.sidebarPanel.Controls.Add(this.btnAnalytics);
            this.sidebarPanel.Controls.Add(this.btnAnnouncements);
            this.sidebarPanel.Controls.Add(this.btnNews);
            this.sidebarPanel.Controls.Add(this.btnOfficials);
            this.sidebarPanel.Controls.Add(this.btnReports);
            this.sidebarPanel.Controls.Add(this.btnRequests);
            this.sidebarPanel.Controls.Add(this.btnUsers);
            this.sidebarPanel.Controls.Add(this.btnDashboard);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 70);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(260, 730);
            this.sidebarPanel.TabIndex = 1;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 40);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(260, 50);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "📊  Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.btnUsers.Location = new System.Drawing.Point(0, 95);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(260, 50);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "👥  User Management";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.BtnUsers_Click);
            this.btnUsers.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.btnUsers.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // btnRequests
            // 
            this.btnRequests.BackColor = System.Drawing.Color.Transparent;
            this.btnRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequests.FlatAppearance.BorderSize = 0;
            this.btnRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequests.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRequests.ForeColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.btnRequests.Location = new System.Drawing.Point(0, 150);
            this.btnRequests.Name = "btnRequests";
            this.btnRequests.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRequests.Size = new System.Drawing.Size(260, 50);
            this.btnRequests.TabIndex = 2;
            this.btnRequests.Text = "📝  Requests";
            this.btnRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRequests.UseVisualStyleBackColor = false;
            this.btnRequests.Click += new System.EventHandler(this.BtnRequests_Click);
            this.btnRequests.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.btnRequests.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.Transparent;
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.btnReports.Location = new System.Drawing.Point(0, 205);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(260, 50);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "📊  Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.BtnReports_Click);
            this.btnReports.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.btnReports.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // btnOfficials
            // 
            this.btnOfficials.BackColor = System.Drawing.Color.Transparent;
            this.btnOfficials.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOfficials.FlatAppearance.BorderSize = 0;
            this.btnOfficials.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOfficials.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnOfficials.ForeColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.btnOfficials.Location = new System.Drawing.Point(0, 260);
            this.btnOfficials.Name = "btnOfficials";
            this.btnOfficials.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnOfficials.Size = new System.Drawing.Size(260, 50);
            this.btnOfficials.TabIndex = 4;
            this.btnOfficials.Text = "🏛️  Officials";
            this.btnOfficials.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOfficials.UseVisualStyleBackColor = false;
            this.btnOfficials.Click += new System.EventHandler(this.BtnOfficials_Click);
            this.btnOfficials.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.btnOfficials.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // btnNews
            // 
            this.btnNews.BackColor = System.Drawing.Color.Transparent;
            this.btnNews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNews.FlatAppearance.BorderSize = 0;
            this.btnNews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNews.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNews.ForeColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.btnNews.Location = new System.Drawing.Point(0, 315);
            this.btnNews.Name = "btnNews";
            this.btnNews.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNews.Size = new System.Drawing.Size(260, 50);
            this.btnNews.TabIndex = 5;
            this.btnNews.Text = "📰  News";
            this.btnNews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNews.UseVisualStyleBackColor = false;
            this.btnNews.Click += new System.EventHandler(this.BtnNews_Click);
            this.btnNews.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.btnNews.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // btnAnnouncements
            // 
            this.btnAnnouncements.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnouncements.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnnouncements.FlatAppearance.BorderSize = 0;
            this.btnAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnouncements.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAnnouncements.ForeColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.btnAnnouncements.Location = new System.Drawing.Point(0, 370);
            this.btnAnnouncements.Name = "btnAnnouncements";
            this.btnAnnouncements.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAnnouncements.Size = new System.Drawing.Size(260, 50);
            this.btnAnnouncements.TabIndex = 6;
            this.btnAnnouncements.Text = "📢  Announcements";
            this.btnAnnouncements.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnnouncements.UseVisualStyleBackColor = false;
            this.btnAnnouncements.Click += new System.EventHandler(this.BtnAnnouncements_Click);
            this.btnAnnouncements.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.btnAnnouncements.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // btnAnalytics
            // 
            this.btnAnalytics.BackColor = System.Drawing.Color.Transparent;
            this.btnAnalytics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalytics.FlatAppearance.BorderSize = 0;
            this.btnAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalytics.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAnalytics.ForeColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.btnAnalytics.Location = new System.Drawing.Point(0, 425);
            this.btnAnalytics.Name = "btnAnalytics";
            this.btnAnalytics.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAnalytics.Size = new System.Drawing.Size(260, 50);
            this.btnAnalytics.TabIndex = 7;
            this.btnAnalytics.Text = "📈  Analytics";
            this.btnAnalytics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalytics.UseVisualStyleBackColor = false;
            this.btnAnalytics.Click += new System.EventHandler(this.BtnAnalytics_Click);
            this.btnAnalytics.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.btnAnalytics.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.btnSettings.Location = new System.Drawing.Point(0, 480);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(260, 50);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "⚙️  Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            this.btnSettings.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.btnSettings.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 675);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(260, 55);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "🚪  Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(260, 70);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(20);
            this.contentPanel.Size = new System.Drawing.Size(940, 730);
            this.contentPanel.TabIndex = 2;
            // 
            // AdminMainDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "AdminMainDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barangay Management System - Admin Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminMainDashboardForm_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.sidebarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}