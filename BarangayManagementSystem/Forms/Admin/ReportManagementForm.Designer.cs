using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.Admin
{
    partial class ReportManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel filterPanel;
        private Label lblFilter;
        private ComboBox cmbStatusFilter;
        private ComboBox cmbTypeFilter;
        private Button btnRefresh;
        private DataGridView dgvReports;
        private Panel actionsPanel;
        private Button btnResolve;
        private Button btnUnderReview;
        private Button btnClose;
        private Button btnViewDetails;
        private Label lblStats;

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
            this.filterPanel = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbTypeFilter = new System.Windows.Forms.ComboBox();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.actionsPanel = new System.Windows.Forms.Panel();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUnderReview = new System.Windows.Forms.Button();
            this.btnResolve = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.actionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(316, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Report Management";
            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.Color.White;
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Controls.Add(this.btnRefresh);
            this.filterPanel.Controls.Add(this.cmbTypeFilter);
            this.filterPanel.Controls.Add(this.cmbStatusFilter);
            this.filterPanel.Controls.Add(this.lblFilter);
            this.filterPanel.Location = new System.Drawing.Point(20, 70);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(880, 60);
            this.filterPanel.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblFilter.Location = new System.Drawing.Point(15, 20);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(48, 19);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter:";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "All Status",
            "Open",
            "Under Review",
            "Resolved",
            "Closed"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(80, 17);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 25);
            this.cmbStatusFilter.TabIndex = 1;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.CmbStatusFilter_SelectedIndexChanged);
            // 
            // cmbTypeFilter
            // 
            this.cmbTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTypeFilter.FormattingEnabled = true;
            this.cmbTypeFilter.Items.AddRange(new object[] {
            "All Types",
            "Noise Complaint",
            "Illegal Parking",
            "Garbage Issues",
            "Street Light Problem",
            "Road Damage",
            "Water/Drainage Issue",
            "Security Concern",
            "Other Issues"});
            this.cmbTypeFilter.Location = new System.Drawing.Point(250, 17);
            this.cmbTypeFilter.Name = "cmbTypeFilter";
            this.cmbTypeFilter.Size = new System.Drawing.Size(200, 25);
            this.cmbTypeFilter.TabIndex = 2;
            this.cmbTypeFilter.SelectedIndexChanged += new System.EventHandler(this.CmbTypeFilter_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(470, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvReports.ColumnHeadersHeight = 40;
            this.dgvReports.Location = new System.Drawing.Point(20, 170);
            this.dgvReports.MultiSelect = false;
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowHeadersVisible = false;
            this.dgvReports.RowTemplate.Height = 35;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new System.Drawing.Size(880, 420);
            this.dgvReports.TabIndex = 2;
            // 
            // actionsPanel
            // 
            this.actionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.actionsPanel.Controls.Add(this.btnViewDetails);
            this.actionsPanel.Controls.Add(this.btnClose);
            this.actionsPanel.Controls.Add(this.btnUnderReview);
            this.actionsPanel.Controls.Add(this.btnResolve);
            this.actionsPanel.Location = new System.Drawing.Point(20, 605);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Size = new System.Drawing.Size(880, 50);
            this.actionsPanel.TabIndex = 3;
            // 
            // btnResolve
            // 
            this.btnResolve.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnResolve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResolve.FlatAppearance.BorderSize = 0;
            this.btnResolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolve.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnResolve.ForeColor = System.Drawing.Color.White;
            this.btnResolve.Location = new System.Drawing.Point(0, 5);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(200, 40);
            this.btnResolve.TabIndex = 0;
            this.btnResolve.Text = "✅ Mark as Resolved";
            this.btnResolve.UseVisualStyleBackColor = false;
            this.btnResolve.Click += new System.EventHandler(this.BtnResolve_Click);
            // 
            // btnUnderReview
            // 
            this.btnUnderReview.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnUnderReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnderReview.FlatAppearance.BorderSize = 0;
            this.btnUnderReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnderReview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUnderReview.ForeColor = System.Drawing.Color.White;
            this.btnUnderReview.Location = new System.Drawing.Point(220, 5);
            this.btnUnderReview.Name = "btnUnderReview";
            this.btnUnderReview.Size = new System.Drawing.Size(200, 40);
            this.btnUnderReview.TabIndex = 1;
            this.btnUnderReview.Text = "🔍 Under Review";
            this.btnUnderReview.UseVisualStyleBackColor = false;
            this.btnUnderReview.Click += new System.EventHandler(this.BtnUnderReview_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(440, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "🔒 Close Report";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnViewDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(660, 5);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(200, 40);
            this.btnViewDetails.TabIndex = 3;
            this.btnViewDetails.Text = "👁️ View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.BtnViewDetails_Click);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStats.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblStats.Location = new System.Drawing.Point(20, 140);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(232, 19);
            this.lblStats.TabIndex = 4;
            this.lblStats.Text = "Total Reports: 0 | Open: 0 | Today: 0";
            // 
            // ReportManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.actionsPanel);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportManagementForm";
            this.Load += new System.EventHandler(this.ReportManagementForm_Load);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.actionsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}