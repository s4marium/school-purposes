using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.User
{
    partial class DashboardOverviewForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel welcomeCard;
        private Label lblGreeting;
        private Label lblSubtitle;
        private Label lblDate;
        private Panel statsPanel;
        private Panel statCard1;
        private Panel statCard2;
        private Panel statCard3;
        private Panel statCard4;
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
        private Panel activityPanel;
        private Label lblActivityTitle;
        private ListBox lstActivity;
        private Panel quickActionsPanel;
        private Label lblQuickActionsTitle;
        private Button btnQuickRequest;
        private Button btnQuickReport;
        private Button btnQuickMyRequests;
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
            this.welcomeCard = new System.Windows.Forms.Panel();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
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
            this.activityPanel = new System.Windows.Forms.Panel();
            this.lblActivityTitle = new System.Windows.Forms.Label();
            this.lstActivity = new System.Windows.Forms.ListBox();
            this.quickActionsPanel = new System.Windows.Forms.Panel();
            this.lblQuickActionsTitle = new System.Windows.Forms.Label();
            this.btnQuickRequest = new System.Windows.Forms.Button();
            this.btnQuickReport = new System.Windows.Forms.Button();
            this.btnQuickMyRequests = new System.Windows.Forms.Button();
            this.btnQuickNews = new System.Windows.Forms.Button();
            this.welcomeCard.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.statCard1.SuspendLayout();
            this.statCard2.SuspendLayout();
            this.statCard3.SuspendLayout();
            this.statCard4.SuspendLayout();
            this.activityPanel.SuspendLayout();
            this.quickActionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcomeCard
            // 
            this.welcomeCard.BackColor = System.Drawing.Color.White;
            this.welcomeCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.welcomeCard.Controls.Add(this.lblDate);
            this.welcomeCard.Controls.Add(this.lblSubtitle);
            this.welcomeCard.Controls.Add(this.lblGreeting);
            this.welcomeCard.Location = new System.Drawing.Point(20, 20);
            this.welcomeCard.Name = "welcomeCard";
            this.welcomeCard.Size = new System.Drawing.Size(880, 150);
            this.welcomeCard.TabIndex = 0;
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblGreeting.Location = new System.Drawing.Point(25, 25);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(345, 41);
            this.lblGreeting.TabIndex = 0;
            this.lblGreeting.Text = "Good Morning, User! 👋";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblSubtitle.Location = new System.Drawing.Point(28, 70);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(404, 21);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Welcome to your Barangay Management Dashboard";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblDate.Location = new System.Drawing.Point(29, 100);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(186, 19);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "November 25, 2025 - Monday";
            // 
            // statsPanel
            // 
            this.statsPanel.BackColor = System.Drawing.Color.Transparent;
            this.statsPanel.Controls.Add(this.statCard4);
            this.statsPanel.Controls.Add(this.statCard3);
            this.statsPanel.Controls.Add(this.statCard2);
            this.statsPanel.Controls.Add(this.statCard1);
            this.statsPanel.Location = new System.Drawing.Point(20, 190);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(880, 170);
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
            this.statCard1.Size = new System.Drawing.Size(210, 170);
            this.statCard1.TabIndex = 0;
            // 
            // lblStat1Icon
            // 
            this.lblStat1Icon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblStat1Icon.Location = new System.Drawing.Point(20, 20);
            this.lblStat1Icon.Name = "lblStat1Icon";
            this.lblStat1Icon.Size = new System.Drawing.Size(60, 60);
            this.lblStat1Icon.TabIndex = 0;
            this.lblStat1Icon.Text = "📋";
            // 
            // lblStat1Value
            // 
            this.lblStat1Value.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblStat1Value.ForeColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.lblStat1Value.Location = new System.Drawing.Point(15, 75);
            this.lblStat1Value.Name = "lblStat1Value";
            this.lblStat1Value.Size = new System.Drawing.Size(180, 50);
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
            this.lblStat1Label.Size = new System.Drawing.Size(170, 25);
            this.lblStat1Label.TabIndex = 2;
            this.lblStat1Label.Text = "Pending Requests";
            this.lblStat1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statCard2
            // 
            this.statCard2.BackColor = System.Drawing.Color.White;
            this.statCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard2.Controls.Add(this.lblStat2Label);
            this.statCard2.Controls.Add(this.lblStat2Value);
            this.statCard2.Controls.Add(this.lblStat2Icon);
            this.statCard2.Location = new System.Drawing.Point(223, 0);
            this.statCard2.Name = "statCard2";
            this.statCard2.Size = new System.Drawing.Size(210, 170);
            this.statCard2.TabIndex = 1;
            // 
            // lblStat2Icon
            // 
            this.lblStat2Icon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblStat2Icon.Location = new System.Drawing.Point(20, 20);
            this.lblStat2Icon.Name = "lblStat2Icon";
            this.lblStat2Icon.Size = new System.Drawing.Size(60, 60);
            this.lblStat2Icon.TabIndex = 0;
            this.lblStat2Icon.Text = "✅";
            // 
            // lblStat2Value
            // 
            this.lblStat2Value.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblStat2Value.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblStat2Value.Location = new System.Drawing.Point(15, 75);
            this.lblStat2Value.Name = "lblStat2Value";
            this.lblStat2Value.Size = new System.Drawing.Size(180, 50);
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
            this.lblStat2Label.Size = new System.Drawing.Size(170, 25);
            this.lblStat2Label.TabIndex = 2;
            this.lblStat2Label.Text = "Approved Requests";
            this.lblStat2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statCard3
            // 
            this.statCard3.BackColor = System.Drawing.Color.White;
            this.statCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard3.Controls.Add(this.lblStat3Label);
            this.statCard3.Controls.Add(this.lblStat3Value);
            this.statCard3.Controls.Add(this.lblStat3Icon);
            this.statCard3.Location = new System.Drawing.Point(446, 0);
            this.statCard3.Name = "statCard3";
            this.statCard3.Size = new System.Drawing.Size(210, 170);
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
            this.lblStat3Value.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.lblStat3Value.Location = new System.Drawing.Point(15, 75);
            this.lblStat3Value.Name = "lblStat3Value";
            this.lblStat3Value.Size = new System.Drawing.Size(180, 50);
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
            this.lblStat3Label.Size = new System.Drawing.Size(170, 25);
            this.lblStat3Label.TabIndex = 2;
            this.lblStat3Label.Text = "Active Reports";
            this.lblStat3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statCard4
            // 
            this.statCard4.BackColor = System.Drawing.Color.White;
            this.statCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard4.Controls.Add(this.lblStat4Label);
            this.statCard4.Controls.Add(this.lblStat4Value);
            this.statCard4.Controls.Add(this.lblStat4Icon);
            this.statCard4.Location = new System.Drawing.Point(669, 0);
            this.statCard4.Name = "statCard4";
            this.statCard4.Size = new System.Drawing.Size(210, 170);
            this.statCard4.TabIndex = 3;
            // 
            // lblStat4Icon
            // 
            this.lblStat4Icon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblStat4Icon.Location = new System.Drawing.Point(20, 20);
            this.lblStat4Icon.Name = "lblStat4Icon";
            this.lblStat4Icon.Size = new System.Drawing.Size(60, 60);
            this.lblStat4Icon.TabIndex = 0;
            this.lblStat4Icon.Text = "🔔";
            // 
            // lblStat4Value
            // 
            this.lblStat4Value.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblStat4Value.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.lblStat4Value.Location = new System.Drawing.Point(15, 75);
            this.lblStat4Value.Name = "lblStat4Value";
            this.lblStat4Value.Size = new System.Drawing.Size(180, 50);
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
            this.lblStat4Label.Size = new System.Drawing.Size(170, 25);
            this.lblStat4Label.TabIndex = 2;
            this.lblStat4Label.Text = "Notifications";
            this.lblStat4Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // activityPanel
            // 
            this.activityPanel.BackColor = System.Drawing.Color.White;
            this.activityPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activityPanel.Controls.Add(this.lstActivity);
            this.activityPanel.Controls.Add(this.lblActivityTitle);
            this.activityPanel.Location = new System.Drawing.Point(20, 380);
            this.activityPanel.Name = "activityPanel";
            this.activityPanel.Size = new System.Drawing.Size(430, 300);
            this.activityPanel.TabIndex = 2;
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
            // lstActivity
            // 
            this.lstActivity.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.lstActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstActivity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstActivity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstActivity.ItemHeight = 35;
            this.lstActivity.Location = new System.Drawing.Point(15, 50);
            this.lstActivity.Name = "lstActivity";
            this.lstActivity.Size = new System.Drawing.Size(395, 245);
            this.lstActivity.TabIndex = 1;
            this.lstActivity.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LstActivity_DrawItem);
            // 
            // quickActionsPanel
            // 
            this.quickActionsPanel.BackColor = System.Drawing.Color.White;
            this.quickActionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickActionsPanel.Controls.Add(this.btnQuickNews);
            this.quickActionsPanel.Controls.Add(this.btnQuickMyRequests);
            this.quickActionsPanel.Controls.Add(this.btnQuickReport);
            this.quickActionsPanel.Controls.Add(this.btnQuickRequest);
            this.quickActionsPanel.Controls.Add(this.lblQuickActionsTitle);
            this.quickActionsPanel.Location = new System.Drawing.Point(470, 380);
            this.quickActionsPanel.Name = "quickActionsPanel";
            this.quickActionsPanel.Size = new System.Drawing.Size(430, 300);
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
            // btnQuickRequest
            // 
            this.btnQuickRequest.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnQuickRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickRequest.FlatAppearance.BorderSize = 0;
            this.btnQuickRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickRequest.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuickRequest.ForeColor = System.Drawing.Color.White;
            this.btnQuickRequest.Location = new System.Drawing.Point(15, 55);
            this.btnQuickRequest.Name = "btnQuickRequest";
            this.btnQuickRequest.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQuickRequest.Size = new System.Drawing.Size(395, 50);
            this.btnQuickRequest.TabIndex = 1;
            this.btnQuickRequest.Text = "📝  Request Certificate";
            this.btnQuickRequest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuickRequest.UseVisualStyleBackColor = false;
            this.btnQuickRequest.Click += new System.EventHandler(this.BtnQuickRequest_Click);
            // 
            // btnQuickReport
            // 
            this.btnQuickReport.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnQuickReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickReport.FlatAppearance.BorderSize = 0;
            this.btnQuickReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuickReport.ForeColor = System.Drawing.Color.White;
            this.btnQuickReport.Location = new System.Drawing.Point(15, 115);
            this.btnQuickReport.Name = "btnQuickReport";
            this.btnQuickReport.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQuickReport.Size = new System.Drawing.Size(395, 50);
            this.btnQuickReport.TabIndex = 2;
            this.btnQuickReport.Text = "📊  File a Report";
            this.btnQuickReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuickReport.UseVisualStyleBackColor = false;
            this.btnQuickReport.Click += new System.EventHandler(this.BtnQuickReport_Click);
            // 
            // btnQuickMyRequests
            // 
            this.btnQuickMyRequests.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnQuickMyRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickMyRequests.FlatAppearance.BorderSize = 0;
            this.btnQuickMyRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickMyRequests.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuickMyRequests.ForeColor = System.Drawing.Color.White;
            this.btnQuickMyRequests.Location = new System.Drawing.Point(15, 175);
            this.btnQuickMyRequests.Name = "btnQuickMyRequests";
            this.btnQuickMyRequests.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQuickMyRequests.Size = new System.Drawing.Size(395, 50);
            this.btnQuickMyRequests.TabIndex = 3;
            this.btnQuickMyRequests.Text = "📋  View My Requests";
            this.btnQuickMyRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuickMyRequests.UseVisualStyleBackColor = false;
            this.btnQuickMyRequests.Click += new System.EventHandler(this.BtnQuickMyRequests_Click);
            // 
            // btnQuickNews
            // 
            this.btnQuickNews.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnQuickNews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickNews.FlatAppearance.BorderSize = 0;
            this.btnQuickNews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickNews.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuickNews.ForeColor = System.Drawing.Color.White;
            this.btnQuickNews.Location = new System.Drawing.Point(15, 235);
            this.btnQuickNews.Name = "btnQuickNews";
            this.btnQuickNews.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQuickNews.Size = new System.Drawing.Size(395, 50);
            this.btnQuickNews.TabIndex = 4;
            this.btnQuickNews.Text = "📰  Read News";
            this.btnQuickNews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuickNews.UseVisualStyleBackColor = false;
            this.btnQuickNews.Click += new System.EventHandler(this.BtnQuickNews_Click);
            // 
            // DashboardOverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.quickActionsPanel);
            this.Controls.Add(this.activityPanel);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.welcomeCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardOverviewForm";
            this.Load += new System.EventHandler(this.DashboardOverviewForm_Load);
            this.welcomeCard.ResumeLayout(false);
            this.welcomeCard.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.statCard1.ResumeLayout(false);
            this.statCard2.ResumeLayout(false);
            this.statCard3.ResumeLayout(false);
            this.statCard4.ResumeLayout(false);
            this.activityPanel.ResumeLayout(false);
            this.activityPanel.PerformLayout();
            this.quickActionsPanel.ResumeLayout(false);
            this.quickActionsPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}