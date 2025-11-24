using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.Admin
{
    partial class OfficialManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel searchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvOfficials;
        private Panel actionsPanel;
        private Button btnAddOfficial;
        private Button btnEditOfficial;
        private Button btnDeleteOfficial;
        private Button btnToggleStatus;

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
            this.searchPanel = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvOfficials = new System.Windows.Forms.DataGridView();
            this.actionsPanel = new System.Windows.Forms.Panel();
            this.btnToggleStatus = new System.Windows.Forms.Button();
            this.btnDeleteOfficial = new System.Windows.Forms.Button();
            this.btnEditOfficial = new System.Windows.Forms.Button();
            this.btnAddOfficial = new System.Windows.Forms.Button();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficials)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(354, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏛️ Official Management";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.btnRefresh);
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Location = new System.Drawing.Point(20, 70);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(880, 60);
            this.searchPanel.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(15, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(335, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(455, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvOfficials
            // 
            this.dgvOfficials.AllowUserToAddRows = false;
            this.dgvOfficials.AllowUserToDeleteRows = false;
            this.dgvOfficials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOfficials.BackgroundColor = System.Drawing.Color.White;
            this.dgvOfficials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvOfficials.ColumnHeadersHeight = 40;
            this.dgvOfficials.Location = new System.Drawing.Point(20, 145);
            this.dgvOfficials.Name = "dgvOfficials";
            this.dgvOfficials.ReadOnly = true;
            this.dgvOfficials.RowHeadersVisible = false;
            this.dgvOfficials.RowTemplate.Height = 35;
            this.dgvOfficials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOfficials.Size = new System.Drawing.Size(880, 445);
            this.dgvOfficials.TabIndex = 2;
            // 
            // actionsPanel
            // 
            this.actionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.actionsPanel.Controls.Add(this.btnToggleStatus);
            this.actionsPanel.Controls.Add(this.btnDeleteOfficial);
            this.actionsPanel.Controls.Add(this.btnEditOfficial);
            this.actionsPanel.Controls.Add(this.btnAddOfficial);
            this.actionsPanel.Location = new System.Drawing.Point(20, 605);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Size = new System.Drawing.Size(880, 50);
            this.actionsPanel.TabIndex = 3;
            // 
            // btnAddOfficial
            // 
            this.btnAddOfficial.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAddOfficial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddOfficial.FlatAppearance.BorderSize = 0;
            this.btnAddOfficial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOfficial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddOfficial.ForeColor = System.Drawing.Color.White;
            this.btnAddOfficial.Location = new System.Drawing.Point(0, 5);
            this.btnAddOfficial.Name = "btnAddOfficial";
            this.btnAddOfficial.Size = new System.Drawing.Size(180, 40);
            this.btnAddOfficial.TabIndex = 0;
            this.btnAddOfficial.Text = "➕ Add Official";
            this.btnAddOfficial.UseVisualStyleBackColor = false;
            this.btnAddOfficial.Click += new System.EventHandler(this.BtnAddOfficial_Click);
            // 
            // btnEditOfficial
            // 
            this.btnEditOfficial.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnEditOfficial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditOfficial.FlatAppearance.BorderSize = 0;
            this.btnEditOfficial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOfficial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditOfficial.ForeColor = System.Drawing.Color.White;
            this.btnEditOfficial.Location = new System.Drawing.Point(200, 5);
            this.btnEditOfficial.Name = "btnEditOfficial";
            this.btnEditOfficial.Size = new System.Drawing.Size(180, 40);
            this.btnEditOfficial.TabIndex = 1;
            this.btnEditOfficial.Text = "✏️ Edit Official";
            this.btnEditOfficial.UseVisualStyleBackColor = false;
            this.btnEditOfficial.Click += new System.EventHandler(this.BtnEditOfficial_Click);
            // 
            // btnDeleteOfficial
            // 
            this.btnDeleteOfficial.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDeleteOfficial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteOfficial.FlatAppearance.BorderSize = 0;
            this.btnDeleteOfficial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOfficial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteOfficial.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOfficial.Location = new System.Drawing.Point(400, 5);
            this.btnDeleteOfficial.Name = "btnDeleteOfficial";
            this.btnDeleteOfficial.Size = new System.Drawing.Size(180, 40);
            this.btnDeleteOfficial.TabIndex = 2;
            this.btnDeleteOfficial.Text = "🗑️ Delete";
            this.btnDeleteOfficial.UseVisualStyleBackColor = false;
            this.btnDeleteOfficial.Click += new System.EventHandler(this.BtnDeleteOfficial_Click);
            // 
            // btnToggleStatus
            // 
            this.btnToggleStatus.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleStatus.FlatAppearance.BorderSize = 0;
            this.btnToggleStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnToggleStatus.ForeColor = System.Drawing.Color.White;
            this.btnToggleStatus.Location = new System.Drawing.Point(600, 5);
            this.btnToggleStatus.Name = "btnToggleStatus";
            this.btnToggleStatus.Size = new System.Drawing.Size(180, 40);
            this.btnToggleStatus.TabIndex = 3;
            this.btnToggleStatus.Text = "🔄 Toggle Status";
            this.btnToggleStatus.UseVisualStyleBackColor = false;
            this.btnToggleStatus.Click += new System.EventHandler(this.BtnToggleStatus_Click);
            // 
            // OfficialManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.actionsPanel);
            this.Controls.Add(this.dgvOfficials);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OfficialManagementForm";
            this.Load += new System.EventHandler(this.OfficialManagementForm_Load);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficials)).EndInit();
            this.actionsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}