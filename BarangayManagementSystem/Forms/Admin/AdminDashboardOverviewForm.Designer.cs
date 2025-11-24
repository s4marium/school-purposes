using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.Admin
{
    partial class AdminDashboardOverviewForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel statsPanel;
        private Panel statCard1;
        private Panel statCard2;
        private Panel statCard3;
        private Panel statCard4;
        private Panel statCard5;
        private Panel statCard6;
        private Label lblStat1Icon;
        private Label lblStat1Value;
        private Label lblStat1Label;
        private Label lblStat2Icon;
        private Label lblStat2Value;
        private Label lblStat2Label;
        private Label lblStat3Icon;
        private Label lblStat3Value;
        private Label lblStat3Label;
        private Label lblStat4Icon;
        private Label lblStat4Value;
        private Label lblStat4Label;
        private Label lblStat5Icon;
        private Label lblStat5Value;
        private Label lblStat5Label;
        private Label lblStat6Icon;
        private Label lblStat6Value;
        private Label lblStat6Label;
        private Panel recentActivityPanel;
        private Label lblActivityTitle;
        private DataGridView dgvRecentActivity;
        private Panel quickActionsPanel;
        private Label lblQuickActionsTitle;
        private Button btnQuickApprove;
        private Button btnQuickUsers;
        private Button btnQuickReports;
        private Button btnQuickNews;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.statCard1 = new System.Windows.Forms.Panel();
            this.lblStat1Icon = new System.Windows.Forms.Label();
            this.lblStat1Value = new System.Windows.Forms.Label();
            this.lblStat1Label = new System.Windows.Forms.Label();
            this.statCard2 = new System.Windows.Forms.Panel();
            this.lblStat2Icon = new System.Windows.Forms.Label();
            this.lblStat2Value = new System.Windows.Forms.Label();
            this.lblStat2Label = new System.Windows.Forms.Label();
            this.statCard3 = new System.Windows.Forms.Panel();
            this.lblStat3Icon = new System.Windows.Forms.Label();
            this.lblStat3Value = new System.Windows.Forms.Label();
            this.lblStat3Label = new System.Windows.Forms.Label();
            this.statCard4 = new System.Windows.Forms.Panel();
            this.lblStat4Icon = new System.Windows.Forms.Label();
            this.lblStat4Value = new System.Windows.Forms.Label();
            this.lblStat4Label = new System.Windows.Forms.Label();
            this.statCard5 = new System.Windows.Forms.Panel();
            this.lblStat5Icon = new System.Windows.Forms.Label();
            this.lblStat5Value = new System.Windows.Forms.Label();
            this.lblStat5Label = new System.Windows.Forms.Label();
            this.statCard6 = new System.Windows.Forms.Panel();
            this.lblStat6Icon = new System.Windows.Forms.Label();
            this.lblStat6Value = new System.Windows.Forms.Label();
            this.lblStat6Label = new System.Windows.Forms.Label();
            this.recentActivityPanel = new System.Windows.Forms.Panel();
            this.lblActivityTitle = new System.Windows.Forms.Label();
            this.dgvRecentActivity = new System.Windows.Forms.DataGridView();
            this.quickActionsPanel = new System.Windows.Forms.Panel();
            this.lblQuickActionsTitle = new System.Windows.Forms.Label();
            this.btnQuickApprove = new System.Windows.Forms.Button();
            this.btnQuickUsers = new System.Windows.Forms.Button();
            this.btnQuickReports = new System.Windows.Forms.Button();
            this.btnQuickNews = new System.Windows.Forms.Button();
            this.statsPanel.SuspendLayout();
            this.statCard1.SuspendLayout();
            this.statCard2.SuspendLayout();
            this.statCard3.SuspendLayout();
            this.statCard4.SuspendLayout();
            this.statCard5.SuspendLayout();
            this.statCard6.SuspendLayout();
            this.recentActivityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).BeginInit();
            this.quickActionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(302, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Admin Dashboard";
            // 
            // statsPanel
            // 
            this.statsPanel.BackColor = System.Drawing.Color.Transparent;
            this.statsPanel.Controls.Add(this.statCard6);
            this.statsPanel.Controls.Add(this.statCard5);
            this.statsPanel.Controls.Add(this.statCard4);
            this.statsPanel.Controls.Add(this.statCard3);
            this.statsPanel.Controls.Add(this.statCard2);
            this.statsPanel.Controls.Add(this.statCard1);
            this.statsPanel.Location = new System.Drawing.Point(20, 70);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(880, 360);
            this.statsPanel.TabIndex = 1;
            // 
            // statCard1
            // 
            this.statCard1.BackColor = System.Drawing.Color.White;
            this.statCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard1.Controls.Add(this.lblStat1Label);
            this.statCard1.Controls.Add(this.lblStat1Value);
            this.statCard1.Controls.Add(this.lblStat1Icon);
            this.statCard1.Location = new System.Drawing.Point(0, 0);
            this.statCard1.Name = "statCard1";
            this.statCard1.Size = new System.Drawing.Size(280, 170);
            this.statCard1.TabIndex = 0;
            // 
            // lblStat1Icon
            // 
            this.lblStat1Icon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblStat1Icon.Location = new System.Drawing.Point(20, 20);
            this.lblStat1Icon.Name = "lblStat1Icon";
            this.lblStat1Icon.Size = new System.Drawing.Size(60, 60);
            this.lblStat1Icon.TabIndex = 0;
            this.lblStat1Icon.Text = "👥";
            // 
            // lblStat1Value
            // 
            this.lblStat1Value.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblStat1Value.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.lblStat1Value.Location = new System.Drawing.Point(15, 75);
            this.lblStat1Value.Name = "lblStat1Value";
            this.lblStat1Value.Size = new System.Drawing.Size(250, 50);
            this.lblStat1Value.TabIndex = 1;
            this.lblStat1Value.Text = "0";
            this.lblStat1Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat1Label
            // 
            this.lblStat1Label.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStat1Label.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStat1Label.Location = new System.Drawing.Point(20, 130);
            this.lblStat1Label.Name = "lblStat1Label";
            this.lblStat1Label.Size = new System.Drawing.Size(240, 25);
            this.lblStat1Label.TabIndex = 2;
            this.lblStat1Label.Text = "Total Users";
            this.lblStat1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statCard2
            // 
            this.statCard2.BackColor = System.Drawing.Color.White;
            this.statCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard2.Controls.Add(this.lblStat2Label);
            this.statCard2.Controls.Add(this.lblStat2Value);
            this.statCard2.Controls.Add(this.lblStat2Icon);
            this.statCard2.Location = new System.Drawing.Point(300, 0);
            this.statCard2.Name = "statCard2";
            this.statCard2.Size = new System.Drawing.Size(280, 170);
            this.statCard2.TabIndex = 1;
            // 
            // lblStat2Icon
            // 
            this.lblStat2Icon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblStat2Icon.Location = new System.Drawing.Point(20, 20);
            this.lblStat2Icon.Name = "lblStat2Icon";
            this.lblStat2Icon.Size = new System.Drawing.Size(60, 60);
            this.lblStat2Icon.TabIndex = 0;
            this.lblStat2Icon.Text = "📝";
            // 
            // lblStat2Value
            // 
            this.lblStat2Value.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblStat2Value.ForeColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.lblStat2Value.Location = new System.Drawing.Point(15, 75);
            this.lblStat2Value.Name = "lblStat2Value";
            this.lblStat2Value.Size = new System.Drawing.Size(250, 50);
            this.lblStat2Value.TabIndex = 1;
            this.lblStat2Value.Text = "0";
            this.lblStat2Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat2Label
            // 
            this.lblStat2Label.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStat2Label.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStat2Label.Location = new System.Drawing.Point(20, 130);
            this.lblStat2Label.Name = "lblStat2Label";
            this.lblStat2Label.Size = new System.Drawing.Size(240, 25);
            this.lblStat2Label.TabIndex = 2;
            this.lblStat2Label.Text = "Pending Requests";
            this.lblStat2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statCard3
            // 
            this.statCard3.BackColor = System.Drawing.Color.White;
            this.statCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard3.Controls.Add(this.lblStat3Label);
            this.statCard3.Controls.Add(this.lblStat3Value);
            this.statCard3.Controls.Add(this.lblStat3Icon);
            this.statCard3.Location = new System.Drawing.Point(600, 0);
            this.statCard3.Name = "statCard3";
            this.statCard3.Size = new System.Drawing.Size(280, 170);
            this.statCard3.TabIndex = 2;
            // 
            // lblStat3Icon
            // 
            this.lblStat3Icon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblStat3Icon.Location = new System.Drawing.Point(20, 20);
            this.lblStat3Icon.Name = "lblStat3Icon";
            this.lblStat3Icon.Size = new System.Drawing.Size(60, 60);
            this.lblStat3Icon.TabIndex = 0;
            this.lblStat3Icon.Text = "📊";
            // 
            // lblStat3Value
            // 
            this.lblStat3Value.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblStat3Value.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.lblStat3Value.Location = new System.Drawing.Point(15, 75);
            this.lblStat3Value.Name = "lblStat3Value";
            this.lblStat3Value.Size = new System.Drawing.Size(250, 50);
            this.lblStat3Value.TabIndex = 1;
            this.lblStat3Value.Text = "0";
            this.lblStat3Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat3Label
            // 
            this.lblStat3Label.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStat3Label.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStat3Label.Location = new System.Drawing.Point(20, 130);
            this.lblStat3Label.Name = "lblStat3Label";
            this.lblStat3Label.Size = new System.Drawing.Size(240, 25);
            this.lblStat3Label.TabIndex = 2;
            this.lblStat3Label.Text = "Open Reports";
            this.lblStat3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statCard4
            // 
            this.statCard4.BackColor = System.Drawing.Color.White;
            this.statCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard4.Controls.Add(this.lblStat4Label);
            this.statCard4.Controls.Add(this.lblStat4Value);
            this.statCard4.Controls.Add(this.lblStat4Icon);
            this.statCard4.Location = new System.Drawing.Point(0, 190);
            this.statCard4.Name = "statCard4";
            this.statCard4.Size = new System.Drawing.Size(280, 170);
            this.statCard4.TabIndex = 3;
            // 
            // lblStat4Icon
            // 
            this.lblStat4Icon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblStat4Icon.Location = new System.Drawing.Point(20, 20);
            this.lblStat4Icon.Name = "lblStat4Icon";
            this.lblStat4Icon.Size = new System.Drawing.Size(60, 60);
            this.lblStat4Icon.TabIndex = 0;
            this.lblStat4Icon.Text = "✅";
            // 
            // lblStat4Value
            // 
            this.lblStat4Value.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblStat4Value.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblStat4Value.Location = new System.Drawing.Point(15, 75);
            this.lblStat4Value.Name = "lblStat4Value";
            this.lblStat4Value.Size = new System.Drawing.Size(250, 50);
            this.lblStat4Value.TabIndex = 1;
            this.lblStat4Value.Text = "0";
            this.lblStat4Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat4Label
            // 
            this.lblStat4Label.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStat4Label.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStat4Label.Location = new System.Drawing.Point(20, 130);
            this.lblStat4Label.Name = "lblStat4Label";
            this.lblStat4Label.Size = new System.Drawing.Size(240, 25);
            this.lblStat4Label.TabIndex = 2;
            this.lblStat4Label.Text = "Approved Today";
            this.lblStat4Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statCard5
            // 
            this.statCard5.BackColor = System.Drawing.Color.White;
            this.statCard5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard5.Controls.Add(this.lblStat5Label);
            this.statCard5.Controls.Add(this.lblStat5Value);
            this.statCard5.Controls.Add(this.lblStat5Icon);
            this.statCard5.Location = new System.Drawing.Point(300, 190);
            this.statCard5.Name = "statCard5";
            this.statCard5.Size = new System.Drawing.Size(280, 170);
            this.statCard5.TabIndex = 4;
            // 
            // lblStat5Icon
            // 
            this.lblStat5Icon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblStat5Icon.Location = new System.Drawing.Point(20, 20);
            this.lblStat5Icon.Name = "lblStat5Icon";
            this.lblStat5Icon.Size = new System.Drawing.Size(60, 60);
            this.lblStat5Icon.TabIndex = 0;
            this.lblStat5Icon.Text = "🏛️";
            // 
            // lblStat5Value
            // 
            this.lblStat5Value.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblStat5Value.ForeColor = System.Drawing.Color.FromArgb(111, 66, 193);
            this.lblStat5Value.Location = new System.Drawing.Point(15, 75);
            this.lblStat5Value.Name = "lblStat5Value";
            this.lblStat5Value.Size = new System.Drawing.Size(250, 50);
            this.lblStat5Value.TabIndex = 1;
            this.lblStat5Value.Text = "0";
            this.lblStat5Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat5Label
            // 
            this.lblStat5Label.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStat5Label.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStat5Label.Location = new System.Drawing.Point(20, 130);
            this.lblStat5Label.Name = "lblStat5Label";
            this.lblStat5Label.Size = new System.Drawing.Size(240, 25);
            this.lblStat5Label.TabIndex = 2;
            this.lblStat5Label.Text = "Active Officials";
            this.lblStat5Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statCard6
            // 
            this.statCard6.BackColor = System.Drawing.Color.White;
            this.statCard6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard6.Controls.Add(this.lblStat6Label);
            this.statCard6.Controls.Add(this.lblStat6Value);
            this.statCard6.Controls.Add(this.lblStat6Icon);
            this.statCard6.Location = new System.Drawing.Point(600, 190);
            this.statCard6.Name = "statCard6";
            this.statCard6.Size = new System.Drawing.Size(280, 170);
            this.statCard6.TabIndex = 5;
            // 
            // lblStat6Icon
            // 
            this.lblStat6Icon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblStat6Icon.Location = new System.Drawing.Point(20, 20);
            this.lblStat6Icon.Name = "lblStat6Icon";
            this.lblStat6Icon.Size = new System.Drawing.Size(60, 60);
            this.lblStat6Icon.TabIndex = 0;
            this.lblStat6Icon.Text = "📰";
            // 
            // lblStat6Value
            // 
            this.lblStat6Value.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblStat6Value.ForeColor = System.Drawing.Color.FromArgb(23, 162, 184);
            this.lblStat6Value.Location = new System.Drawing.Point(15, 75);
            this.lblStat6Value.Name = "lblStat6Value";
            this.lblStat6Value.Size = new System.Drawing.Size(250, 50);
            this.lblStat6Value.TabIndex = 1;
            this.lblStat6Value.Text = "0";
            this.lblStat6Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat6Label
            // 
            this.lblStat6Label.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStat6Label.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStat6Label.Location = new System.Drawing.Point(20, 130);
            this.lblStat6Label.Name = "lblStat6Label";
            this.lblStat6Label.Size = new System.Drawing.Size(240, 25);
            this.lblStat6Label.TabIndex = 2;
            this.lblStat6Label.Text = "Published News";
            this.lblStat6Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // recentActivityPanel
            // 
            this.recentActivityPanel.BackColor = System.Drawing.Color.White;
            this.recentActivityPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recentActivityPanel.Controls.Add(this.dgvRecentActivity);
            this.recentActivityPanel.Controls.Add(this.lblActivityTitle);
            this.recentActivityPanel.Location = new System.Drawing.Point(20, 450);
            this.recentActivityPanel.Name = "recentActivityPanel";
            this.recentActivityPanel.Size = new System.Drawing.Size(550, 230);
            this.recentActivityPanel.TabIndex = 2;
            // 
            // lblActivityTitle
            // 
            this.lblActivityTitle.AutoSize = true;
            this.lblActivityTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblActivityTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblActivityTitle.Location = new System.Drawing.Point(15, 15);
            this.lblActivityTitle.Name = "lblActivityTitle";
            this.lblActivityTitle.Size = new System.Drawing.Size(182, 25);
            this.lblActivityTitle.TabIndex = 0;
            this.lblActivityTitle.Text = "📊 Recent Activity";
            // 
            // dgvRecentActivity
            // 
            this.dgvRecentActivity.AllowUserToAddRows = false;
            this.dgvRecentActivity.AllowUserToDeleteRows = false;
            this.dgvRecentActivity.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentActivity.Location = new System.Drawing.Point(15, 50);
            this.dgvRecentActivity.Name = "dgvRecentActivity";
            this.dgvRecentActivity.ReadOnly = true;
            this.dgvRecentActivity.RowHeadersVisible = false;
            this.dgvRecentActivity.Size = new System.Drawing.Size(520, 165);
            this.dgvRecentActivity.TabIndex = 1;
            // 
            // quickActionsPanel
            // 
            this.quickActionsPanel.BackColor = System.Drawing.Color.White;
            this.quickActionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickActionsPanel.Controls.Add(this.btnQuickNews);
            this.quickActionsPanel.Controls.Add(this.btnQuickReports);
            this.quickActionsPanel.Controls.Add(this.btnQuickUsers);
            this.quickActionsPanel.Controls.Add(this.btnQuickApprove);
            this.quickActionsPanel.Controls.Add(this.lblQuickActionsTitle);
            this.quickActionsPanel.Location = new System.Drawing.Point(590, 450);
            this.quickActionsPanel.Name = "quickActionsPanel";
            this.quickActionsPanel.Size = new System.Drawing.Size(310, 230);
            this.quickActionsPanel.TabIndex = 3;
            // 
            // lblQuickActionsTitle
            // 
            this.lblQuickActionsTitle.AutoSize = true;
            this.lblQuickActionsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuickActionsTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblQuickActionsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblQuickActionsTitle.Name = "lblQuickActionsTitle";
            this.lblQuickActionsTitle.Size = new System.Drawing.Size(163, 25);
            this.lblQuickActionsTitle.TabIndex = 0;
            this.lblQuickActionsTitle.Text = "⚡ Quick Actions";
            // 
            // btnQuickApprove
            // 
            this.btnQuickApprove.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnQuickApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickApprove.FlatAppearance.BorderSize = 0;
            this.btnQuickApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickApprove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickApprove.ForeColor = System.Drawing.Color.White;
            this.btnQuickApprove.Location = new System.Drawing.Point(15, 55);
            this.btnQuickApprove.Name = "btnQuickApprove";
            this.btnQuickApprove.Size = new System.Drawing.Size(280, 35);
            this.btnQuickApprove.TabIndex = 1;
            this.btnQuickApprove.Text = "✅ Approve Requests";
            this.btnQuickApprove.UseVisualStyleBackColor = false;
            // 
            // btnQuickUsers
            // 
            this.btnQuickUsers.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnQuickUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickUsers.FlatAppearance.BorderSize = 0;
            this.btnQuickUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickUsers.ForeColor = System.Drawing.Color.White;
            this.btnQuickUsers.Location = new System.Drawing.Point(15, 100);
            this.btnQuickUsers.Name = "btnQuickUsers";
            this.btnQuickUsers.Size = new System.Drawing.Size(280, 35);
            this.btnQuickUsers.TabIndex = 2;
            this.btnQuickUsers.Text = "👥 Manage Users";
            this.btnQuickUsers.UseVisualStyleBackColor = false;
            // 
            // btnQuickReports
            // 
            this.btnQuickReports.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnQuickReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickReports.FlatAppearance.BorderSize = 0;
            this.btnQuickReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickReports.ForeColor = System.Drawing.Color.White;
            this.btnQuickReports.Location = new System.Drawing.Point(15, 145);
            this.btnQuickReports.Name = "btnQuickReports";
            this.btnQuickReports.Size = new System.Drawing.Size(280, 35);
            this.btnQuickReports.TabIndex = 3;
            this.btnQuickReports.Text = "📊 Review Reports";
            this.btnQuickReports.UseVisualStyleBackColor = false;
            // 
            // btnQuickNews
            // 
            this.btnQuickNews.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnQuickNews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickNews.FlatAppearance.BorderSize = 0;
            this.btnQuickNews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickNews.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickNews.ForeColor = System.Drawing.Color.White;
            this.btnQuickNews.Location = new System.Drawing.Point(15, 190);
            this.btnQuickNews.Name = "btnQuickNews";
            this.btnQuickNews.Size = new System.Drawing.Size(280, 35);
            this.btnQuickNews.TabIndex = 4;
            this.btnQuickNews.Text = "📰 Publish News";
            this.btnQuickNews.UseVisualStyleBackColor = false;
            // 
            // AdminDashboardOverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.quickActionsPanel);
            this.Controls.Add(this.recentActivityPanel);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminDashboardOverviewForm";
            this.Load += new System.EventHandler(this.AdminDashboardOverviewForm_Load);
            this.statsPanel.ResumeLayout(false);
            this.statCard1.ResumeLayout(false);
            this.statCard2.ResumeLayout(false);
            this.statCard3.ResumeLayout(false);
            this.statCard4.ResumeLayout(false);
            this.statCard5.ResumeLayout(false);
            this.statCard6.ResumeLayout(false);
            this.recentActivityPanel.ResumeLayout(false);
            this.recentActivityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).EndInit();
            this.quickActionsPanel.ResumeLayout(false);
            this.quickActionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}