using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.Admin
{
    partial class AnalyticsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel statsPanel;
        private Panel statCard1;
        private Panel statCard2;
        private Panel statCard3;
        private Panel statCard4;
        private Label lblStat1Title;
        private Label lblStat1Value;
        private Label lblStat2Title;
        private Label lblStat2Value;
        private Label lblStat3Title;
        private Label lblStat3Value;
        private Label lblStat4Title;
        private Label lblStat4Value;
        private Panel chartPanel;
        private Label lblChartTitle;
        private DataGridView dgvActivityLog;
        private Label lblActivityTitle;
        private ComboBox cmbTimeRange;
        private Button btnRefresh;
        private Button btnExport;

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
            this.statCard4 = new System.Windows.Forms.Panel();
            this.lblStat4Value = new System.Windows.Forms.Label();
            this.lblStat4Title = new System.Windows.Forms.Label();
            this.statCard3 = new System.Windows.Forms.Panel();
            this.lblStat3Value = new System.Windows.Forms.Label();
            this.lblStat3Title = new System.Windows.Forms.Label();
            this.statCard2 = new System.Windows.Forms.Panel();
            this.lblStat2Value = new System.Windows.Forms.Label();
            this.lblStat2Title = new System.Windows.Forms.Label();
            this.statCard1 = new System.Windows.Forms.Panel();
            this.lblStat1Value = new System.Windows.Forms.Label();
            this.lblStat1Title = new System.Windows.Forms.Label();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.dgvActivityLog = new System.Windows.Forms.DataGridView();
            this.lblActivityTitle = new System.Windows.Forms.Label();
            this.cmbTimeRange = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.statsPanel.SuspendLayout();
            this.statCard4.SuspendLayout();
            this.statCard3.SuspendLayout();
            this.statCard2.SuspendLayout();
            this.statCard1.SuspendLayout();
            this.chartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLog)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(348, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📈 Analytics && Reporting";
            // 
            // statsPanel
            // 
            this.statsPanel.BackColor = System.Drawing.Color.Transparent;
            this.statsPanel.Controls.Add(this.statCard4);
            this.statsPanel.Controls.Add(this.statCard3);
            this.statsPanel.Controls.Add(this.statCard2);
            this.statsPanel.Controls.Add(this.statCard1);
            this.statsPanel.Location = new System.Drawing.Point(20, 70);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(880, 140);
            this.statsPanel.TabIndex = 1;
            // 
            // statCard1
            // 
            this.statCard1.BackColor = System.Drawing.Color.White;
            this.statCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard1.Controls.Add(this.lblStat1Value);
            this.statCard1.Controls.Add(this.lblStat1Title);
            this.statCard1.Location = new System.Drawing.Point(0, 0);
            this.statCard1.Name = "statCard1";
            this.statCard1.Size = new System.Drawing.Size(210, 130);
            this.statCard1.TabIndex = 0;
            // 
            // lblStat1Title
            // 
            this.lblStat1Title.AutoSize = true;
            this.lblStat1Title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStat1Title.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStat1Title.Location = new System.Drawing.Point(15, 15);
            this.lblStat1Title.Name = "lblStat1Title";
            this.lblStat1Title.Size = new System.Drawing.Size(90, 19);
            this.lblStat1Title.TabIndex = 0;
            this.lblStat1Title.Text = "Total Logins";
            // 
            // lblStat1Value
            // 
            this.lblStat1Value.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblStat1Value.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.lblStat1Value.Location = new System.Drawing.Point(10, 50);
            this.lblStat1Value.Name = "lblStat1Value";
            this.lblStat1Value.Size = new System.Drawing.Size(190, 60);
            this.lblStat1Value.TabIndex = 1;
            this.lblStat1Value.Text = "0";
            this.lblStat1Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statCard2
            // 
            this.statCard2.BackColor = System.Drawing.Color.White;
            this.statCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard2.Controls.Add(this.lblStat2Value);
            this.statCard2.Controls.Add(this.lblStat2Title);
            this.statCard2.Location = new System.Drawing.Point(223, 0);
            this.statCard2.Name = "statCard2";
            this.statCard2.Size = new System.Drawing.Size(210, 130);
            this.statCard2.TabIndex = 1;
            // 
            // lblStat2Title
            // 
            this.lblStat2Title.AutoSize = true;
            this.lblStat2Title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStat2Title.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStat2Title.Location = new System.Drawing.Point(15, 15);
            this.lblStat2Title.Name = "lblStat2Title";
            this.lblStat2Title.Size = new System.Drawing.Size(112, 19);
            this.lblStat2Title.TabIndex = 0;
            this.lblStat2Title.Text = "Requests Today";
            // 
            // lblStat2Value
            // 
            this.lblStat2Value.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblStat2Value.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblStat2Value.Location = new System.Drawing.Point(10, 50);
            this.lblStat2Value.Name = "lblStat2Value";
            this.lblStat2Value.Size = new System.Drawing.Size(190, 60);
            this.lblStat2Value.TabIndex = 1;
            this.lblStat2Value.Text = "0";
            this.lblStat2Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statCard3
            // 
            this.statCard3.BackColor = System.Drawing.Color.White;
            this.statCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard3.Controls.Add(this.lblStat3Value);
            this.statCard3.Controls.Add(this.lblStat3Title);
            this.statCard3.Location = new System.Drawing.Point(446, 0);
            this.statCard3.Name = "statCard3";
            this.statCard3.Size = new System.Drawing.Size(210, 130);
            this.statCard3.TabIndex = 2;
            // 
            // lblStat3Title
            // 
            this.lblStat3Title.AutoSize = true;
            this.lblStat3Title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStat3Title.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStat3Title.Location = new System.Drawing.Point(15, 15);
            this.lblStat3Title.Name = "lblStat3Title";
            this.lblStat3Title.Size = new System.Drawing.Size(101, 19);
            this.lblStat3Title.TabIndex = 0;
            this.lblStat3Title.Text = "Reports Today";
            // 
            // lblStat3Value
            // 
            this.lblStat3Value.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblStat3Value.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.lblStat3Value.Location = new System.Drawing.Point(10, 50);
            this.lblStat3Value.Name = "lblStat3Value";
            this.lblStat3Value.Size = new System.Drawing.Size(190, 60);
            this.lblStat3Value.TabIndex = 1;
            this.lblStat3Value.Text = "0";
            this.lblStat3Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statCard4
            // 
            this.statCard4.BackColor = System.Drawing.Color.White;
            this.statCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statCard4.Controls.Add(this.lblStat4Value);
            this.statCard4.Controls.Add(this.lblStat4Title);
            this.statCard4.Location = new System.Drawing.Point(669, 0);
            this.statCard4.Name = "statCard4";
            this.statCard4.Size = new System.Drawing.Size(210, 130);
            this.statCard4.TabIndex = 3;
            // 
            // lblStat4Title
            // 
            this.lblStat4Title.AutoSize = true;
            this.lblStat4Title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStat4Title.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStat4Title.Location = new System.Drawing.Point(15, 15);
            this.lblStat4Title.Name = "lblStat4Title";
            this.lblStat4Title.Size = new System.Drawing.Size(96, 19);
            this.lblStat4Title.TabIndex = 0;
            this.lblStat4Title.Text = "Active Users";
            // 
            // lblStat4Value
            // 
            this.lblStat4Value.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblStat4Value.ForeColor = System.Drawing.Color.FromArgb(111, 66, 193);
            this.lblStat4Value.Location = new System.Drawing.Point(10, 50);
            this.lblStat4Value.Name = "lblStat4Value";
            this.lblStat4Value.Size = new System.Drawing.Size(190, 60);
            this.lblStat4Value.TabIndex = 1;
            this.lblStat4Value.Text = "0";
            this.lblStat4Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartPanel
            // 
            this.chartPanel.BackColor = System.Drawing.Color.White;
            this.chartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartPanel.Controls.Add(this.lblChartTitle);
            this.chartPanel.Location = new System.Drawing.Point(20, 220);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(550, 250);
            this.chartPanel.TabIndex = 2;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblChartTitle.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(189, 21);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "Activity Trend (7 Days)";
            // 
            // dgvActivityLog
            // 
            this.dgvActivityLog.AllowUserToAddRows = false;
            this.dgvActivityLog.AllowUserToDeleteRows = false;
            this.dgvActivityLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvActivityLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvActivityLog.ColumnHeadersHeight = 35;
            this.dgvActivityLog.Location = new System.Drawing.Point(590, 220);
            this.dgvActivityLog.Name = "dgvActivityLog";
            this.dgvActivityLog.ReadOnly = true;
            this.dgvActivityLog.RowHeadersVisible = false;
            this.dgvActivityLog.Size = new System.Drawing.Size(310, 250);
            this.dgvActivityLog.TabIndex = 3;
            // 
            // lblActivityTitle
            // 
            this.lblActivityTitle.AutoSize = true;
            this.lblActivityTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblActivityTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblActivityTitle.Location = new System.Drawing.Point(20, 485);
            this.lblActivityTitle.Name = "lblActivityTitle";
            this.lblActivityTitle.Size = new System.Drawing.Size(177, 21);
            this.lblActivityTitle.TabIndex = 4;
            this.lblActivityTitle.Text = "Recent Activity Logs";
            // 
            // cmbTimeRange
            // 
            this.cmbTimeRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeRange.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTimeRange.FormattingEnabled = true;
            this.cmbTimeRange.Items.AddRange(new object[] {
            "Today",
            "Last 7 Days",
            "Last 30 Days",
            "This Month",
            "All Time"});
            this.cmbTimeRange.Location = new System.Drawing.Point(230, 483);
            this.cmbTimeRange.Name = "cmbTimeRange";
            this.cmbTimeRange.Size = new System.Drawing.Size(150, 25);
            this.cmbTimeRange.TabIndex = 5;
            this.cmbTimeRange.SelectedIndexChanged += new System.EventHandler(this.CmbTimeRange_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(400, 480);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "?? Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(520, 480);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 30);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "?? Export CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // AnalyticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbTimeRange);
            this.Controls.Add(this.lblActivityTitle);
            this.Controls.Add(this.dgvActivityLog);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnalyticsForm";
            this.Load += new System.EventHandler(this.AnalyticsForm_Load);
            this.statsPanel.ResumeLayout(false);
            this.statCard4.ResumeLayout(false);
            this.statCard4.PerformLayout();
            this.statCard3.ResumeLayout(false);
            this.statCard3.PerformLayout();
            this.statCard2.ResumeLayout(false);
            this.statCard2.PerformLayout();
            this.statCard1.ResumeLayout(false);
            this.statCard1.PerformLayout();
            this.chartPanel.ResumeLayout(false);
            this.chartPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}