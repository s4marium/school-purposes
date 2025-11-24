using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.Admin
{
    partial class AnnouncementManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblInfo;
        private Panel formPanel;
        private Label lblAnnouncementTitle;
        private TextBox txtTitle;
        private Label lblMessage;
        private TextBox txtMessage;
        private Button btnPublish;
        private DataGridView dgvAnnouncements;
        private Button btnDelete;

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
            this.lblInfo = new System.Windows.Forms.Label();
            this.formPanel = new System.Windows.Forms.Panel();
            this.btnPublish = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblAnnouncementTitle = new System.Windows.Forms.Label();
            this.dgvAnnouncements = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnouncements)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(275, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📢 Announcements";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInfo.Location = new System.Drawing.Point(23, 62);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(396, 19);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Create and manage announcements for all barangay residents";
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.White;
            this.formPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formPanel.Controls.Add(this.btnPublish);
            this.formPanel.Controls.Add(this.txtMessage);
            this.formPanel.Controls.Add(this.lblMessage);
            this.formPanel.Controls.Add(this.txtTitle);
            this.formPanel.Controls.Add(this.lblAnnouncementTitle);
            this.formPanel.Location = new System.Drawing.Point(20, 95);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(880, 280);
            this.formPanel.TabIndex = 2;
            // 
            // lblAnnouncementTitle
            // 
            this.lblAnnouncementTitle.AutoSize = true;
            this.lblAnnouncementTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAnnouncementTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblAnnouncementTitle.Location = new System.Drawing.Point(20, 20);
            this.lblAnnouncementTitle.Name = "lblAnnouncementTitle";
            this.lblAnnouncementTitle.Size = new System.Drawing.Size(48, 20);
            this.lblAnnouncementTitle.TabIndex = 0;
            this.lblAnnouncementTitle.Text = "Title *";
            // 
            // txtTitle
            // 
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTitle.Location = new System.Drawing.Point(24, 47);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(830, 27);
            this.txtTitle.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblMessage.Location = new System.Drawing.Point(20, 90);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(80, 20);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message *";
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMessage.Location = new System.Drawing.Point(24, 117);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(830, 100);
            this.txtMessage.TabIndex = 3;
            // 
            // btnPublish
            // 
            this.btnPublish.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnPublish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPublish.FlatAppearance.BorderSize = 0;
            this.btnPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublish.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPublish.ForeColor = System.Drawing.Color.White;
            this.btnPublish.Location = new System.Drawing.Point(24, 230);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(200, 40);
            this.btnPublish.TabIndex = 4;
            this.btnPublish.Text = "📢 Publish";
            this.btnPublish.UseVisualStyleBackColor = false;
            this.btnPublish.Click += new System.EventHandler(this.BtnPublish_Click);
            // 
            // dgvAnnouncements
            // 
            this.dgvAnnouncements.AllowUserToAddRows = false;
            this.dgvAnnouncements.AllowUserToDeleteRows = false;
            this.dgvAnnouncements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnnouncements.BackgroundColor = System.Drawing.Color.White;
            this.dgvAnnouncements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvAnnouncements.ColumnHeadersHeight = 40;
            this.dgvAnnouncements.Location = new System.Drawing.Point(20, 390);
            this.dgvAnnouncements.Name = "dgvAnnouncements";
            this.dgvAnnouncements.ReadOnly = true;
            this.dgvAnnouncements.RowHeadersVisible = false;
            this.dgvAnnouncements.RowTemplate.Height = 35;
            this.dgvAnnouncements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnnouncements.Size = new System.Drawing.Size(880, 210);
            this.dgvAnnouncements.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(20, 615);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 40);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "🗑️ Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // AnnouncementManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvAnnouncements);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnnouncementManagementForm";
            this.Load += new System.EventHandler(this.AnnouncementManagementForm_Load);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnouncements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}