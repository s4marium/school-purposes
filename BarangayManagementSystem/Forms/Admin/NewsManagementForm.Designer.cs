using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.Admin
{
    partial class NewsManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel searchPanel;
        private TextBox txtSearch;
        private ComboBox cmbCategoryFilter;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvNews;
        private Panel actionsPanel;
        private Button btnAddNews;
        private Button btnEditNews;
        private Button btnDeleteNews;
        private Button btnViewDetails;

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
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvNews = new System.Windows.Forms.DataGridView();
            this.actionsPanel = new System.Windows.Forms.Panel();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnDeleteNews = new System.Windows.Forms.Button();
            this.btnEditNews = new System.Windows.Forms.Button();
            this.btnAddNews = new System.Windows.Forms.Button();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(313, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📰 News Management";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.btnRefresh);
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.cmbCategoryFilter);
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
            this.txtSearch.Size = new System.Drawing.Size(250, 25);
            this.txtSearch.TabIndex = 0;
            // 
            // cmbCategoryFilter
            // 
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategoryFilter.FormattingEnabled = true;
            this.cmbCategoryFilter.Items.AddRange(new object[] {
            "All Categories",
            "Announcement",
            "Event",
            "Health",
            "Safety",
            "Education",
            "Community",
            "Other"});
            this.cmbCategoryFilter.Location = new System.Drawing.Point(285, 17);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.Size = new System.Drawing.Size(150, 25);
            this.cmbCategoryFilter.TabIndex = 1;
            this.cmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.CmbCategoryFilter_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(455, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 2;
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
            this.btnRefresh.Location = new System.Drawing.Point(575, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvNews
            // 
            this.dgvNews.AllowUserToAddRows = false;
            this.dgvNews.AllowUserToDeleteRows = false;
            this.dgvNews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNews.BackgroundColor = System.Drawing.Color.White;
            this.dgvNews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvNews.ColumnHeadersHeight = 40;
            this.dgvNews.Location = new System.Drawing.Point(20, 145);
            this.dgvNews.Name = "dgvNews";
            this.dgvNews.ReadOnly = true;
            this.dgvNews.RowHeadersVisible = false;
            this.dgvNews.RowTemplate.Height = 35;
            this.dgvNews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNews.Size = new System.Drawing.Size(880, 445);
            this.dgvNews.TabIndex = 2;
            // 
            // actionsPanel
            // 
            this.actionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.actionsPanel.Controls.Add(this.btnViewDetails);
            this.actionsPanel.Controls.Add(this.btnDeleteNews);
            this.actionsPanel.Controls.Add(this.btnEditNews);
            this.actionsPanel.Controls.Add(this.btnAddNews);
            this.actionsPanel.Location = new System.Drawing.Point(20, 605);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Size = new System.Drawing.Size(880, 50);
            this.actionsPanel.TabIndex = 3;
            // 
            // btnAddNews
            // 
            this.btnAddNews.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAddNews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNews.FlatAppearance.BorderSize = 0;
            this.btnAddNews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNews.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddNews.ForeColor = System.Drawing.Color.White;
            this.btnAddNews.Location = new System.Drawing.Point(0, 5);
            this.btnAddNews.Name = "btnAddNews";
            this.btnAddNews.Size = new System.Drawing.Size(180, 40);
            this.btnAddNews.TabIndex = 0;
            this.btnAddNews.Text = "➕ Add News";
            this.btnAddNews.UseVisualStyleBackColor = false;
            this.btnAddNews.Click += new System.EventHandler(this.BtnAddNews_Click);
            // 
            // btnEditNews
            // 
            this.btnEditNews.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnEditNews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditNews.FlatAppearance.BorderSize = 0;
            this.btnEditNews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditNews.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditNews.ForeColor = System.Drawing.Color.White;
            this.btnEditNews.Location = new System.Drawing.Point(200, 5);
            this.btnEditNews.Name = "btnEditNews";
            this.btnEditNews.Size = new System.Drawing.Size(180, 40);
            this.btnEditNews.TabIndex = 1;
            this.btnEditNews.Text = "✏️ Edit News";
            this.btnEditNews.UseVisualStyleBackColor = false;
            this.btnEditNews.Click += new System.EventHandler(this.BtnEditNews_Click);
            // 
            // btnDeleteNews
            // 
            this.btnDeleteNews.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDeleteNews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteNews.FlatAppearance.BorderSize = 0;
            this.btnDeleteNews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteNews.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteNews.ForeColor = System.Drawing.Color.White;
            this.btnDeleteNews.Location = new System.Drawing.Point(400, 5);
            this.btnDeleteNews.Name = "btnDeleteNews";
            this.btnDeleteNews.Size = new System.Drawing.Size(180, 40);
            this.btnDeleteNews.TabIndex = 2;
            this.btnDeleteNews.Text = "🗑️ Delete";
            this.btnDeleteNews.UseVisualStyleBackColor = false;
            this.btnDeleteNews.Click += new System.EventHandler(this.BtnDeleteNews_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnViewDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(600, 5);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(180, 40);
            this.btnViewDetails.TabIndex = 3;
            this.btnViewDetails.Text = "👁️ View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.BtnViewDetails_Click);
            // 
            // NewsManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.actionsPanel);
            this.Controls.Add(this.dgvNews);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewsManagementForm";
            this.Load += new System.EventHandler(this.NewsManagementForm_Load);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).EndInit();
            this.actionsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}