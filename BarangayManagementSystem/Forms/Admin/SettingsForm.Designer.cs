using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.Admin
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TabControl tabSettings;
        private TabPage tabGeneral;
        private TabPage tabFees;
        private TabPage tabSystem;
        private Label lblBarangayName;
        private TextBox txtBarangayName;
        private Label lblBarangayAddress;
        private TextBox txtBarangayAddress;
        private Label lblContactNumber;
        private TextBox txtContactNumber;
        private Label lblEmailAddress;
        private TextBox txtEmailAddress;
        private Button btnSaveGeneral;
        private Label lblFeesInfo;
        private DataGridView dgvFees;
        private Button btnUpdateFees;
        private Label lblSystemInfo;
        private Label lblVersion;
        private Label lblDatabase;
        private Button btnBackup;
        private Button btnRestore;

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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.btnSaveGeneral = new System.Windows.Forms.Button();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.lblContactNumber = new System.Windows.Forms.Label();
            this.txtBarangayAddress = new System.Windows.Forms.TextBox();
            this.lblBarangayAddress = new System.Windows.Forms.Label();
            this.txtBarangayName = new System.Windows.Forms.TextBox();
            this.lblBarangayName = new System.Windows.Forms.Label();
            this.tabFees = new System.Windows.Forms.TabPage();
            this.btnUpdateFees = new System.Windows.Forms.Button();
            this.dgvFees = new System.Windows.Forms.DataGridView();
            this.lblFeesInfo = new System.Windows.Forms.Label();
            this.tabSystem = new System.Windows.Forms.TabPage();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblSystemInfo = new System.Windows.Forms.Label();
            this.tabSettings.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabFees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).BeginInit();
            this.tabSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(214, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "?? Settings";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabGeneral);
            this.tabSettings.Controls.Add(this.tabFees);
            this.tabSettings.Controls.Add(this.tabSystem);
            this.tabSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabSettings.Location = new System.Drawing.Point(20, 70);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(880, 600);
            this.tabSettings.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.White;
            this.tabGeneral.Controls.Add(this.btnSaveGeneral);
            this.tabGeneral.Controls.Add(this.txtEmailAddress);
            this.tabGeneral.Controls.Add(this.lblEmailAddress);
            this.tabGeneral.Controls.Add(this.txtContactNumber);
            this.tabGeneral.Controls.Add(this.lblContactNumber);
            this.tabGeneral.Controls.Add(this.txtBarangayAddress);
            this.tabGeneral.Controls.Add(this.lblBarangayAddress);
            this.tabGeneral.Controls.Add(this.txtBarangayName);
            this.tabGeneral.Controls.Add(this.lblBarangayName);
            this.tabGeneral.Location = new System.Drawing.Point(4, 26);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(872, 570);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General Settings";
            // 
            // lblBarangayName
            // 
            this.lblBarangayName.AutoSize = true;
            this.lblBarangayName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBarangayName.Location = new System.Drawing.Point(30, 30);
            this.lblBarangayName.Name = "lblBarangayName";
            this.lblBarangayName.Size = new System.Drawing.Size(128, 20);
            this.lblBarangayName.TabIndex = 0;
            this.lblBarangayName.Text = "Barangay Name";
            // 
            // txtBarangayName
            // 
            this.txtBarangayName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarangayName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBarangayName.Location = new System.Drawing.Point(34, 57);
            this.txtBarangayName.Name = "txtBarangayName";
            this.txtBarangayName.Size = new System.Drawing.Size(400, 27);
            this.txtBarangayName.TabIndex = 1;
            // 
            // lblBarangayAddress
            // 
            this.lblBarangayAddress.AutoSize = true;
            this.lblBarangayAddress.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBarangayAddress.Location = new System.Drawing.Point(30, 100);
            this.lblBarangayAddress.Name = "lblBarangayAddress";
            this.lblBarangayAddress.Size = new System.Drawing.Size(145, 20);
            this.lblBarangayAddress.TabIndex = 2;
            this.lblBarangayAddress.Text = "Barangay Address";
            // 
            // txtBarangayAddress
            // 
            this.txtBarangayAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarangayAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBarangayAddress.Location = new System.Drawing.Point(34, 127);
            this.txtBarangayAddress.Multiline = true;
            this.txtBarangayAddress.Name = "txtBarangayAddress";
            this.txtBarangayAddress.Size = new System.Drawing.Size(400, 60);
            this.txtBarangayAddress.TabIndex = 3;
            // 
            // lblContactNumber
            // 
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblContactNumber.Location = new System.Drawing.Point(30, 210);
            this.lblContactNumber.Name = "lblContactNumber";
            this.lblContactNumber.Size = new System.Drawing.Size(133, 20);
            this.lblContactNumber.TabIndex = 4;
            this.lblContactNumber.Text = "Contact Number";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtContactNumber.Location = new System.Drawing.Point(34, 237);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(400, 27);
            this.txtContactNumber.TabIndex = 5;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmailAddress.Location = new System.Drawing.Point(30, 280);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(117, 20);
            this.lblEmailAddress.TabIndex = 6;
            this.lblEmailAddress.Text = "Email Address";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmailAddress.Location = new System.Drawing.Point(34, 307);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(400, 27);
            this.txtEmailAddress.TabIndex = 7;
            // 
            // btnSaveGeneral
            // 
            this.btnSaveGeneral.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnSaveGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveGeneral.FlatAppearance.BorderSize = 0;
            this.btnSaveGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGeneral.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveGeneral.ForeColor = System.Drawing.Color.White;
            this.btnSaveGeneral.Location = new System.Drawing.Point(34, 360);
            this.btnSaveGeneral.Name = "btnSaveGeneral";
            this.btnSaveGeneral.Size = new System.Drawing.Size(150, 40);
            this.btnSaveGeneral.TabIndex = 8;
            this.btnSaveGeneral.Text = "?? Save Settings";
            this.btnSaveGeneral.UseVisualStyleBackColor = false;
            this.btnSaveGeneral.Click += new System.EventHandler(this.BtnSaveGeneral_Click);
            // 
            // tabFees
            // 
            this.tabFees.BackColor = System.Drawing.Color.White;
            this.tabFees.Controls.Add(this.btnUpdateFees);
            this.tabFees.Controls.Add(this.dgvFees);
            this.tabFees.Controls.Add(this.lblFeesInfo);
            this.tabFees.Location = new System.Drawing.Point(4, 26);
            this.tabFees.Name = "tabFees";
            this.tabFees.Padding = new System.Windows.Forms.Padding(3);
            this.tabFees.Size = new System.Drawing.Size(872, 570);
            this.tabFees.TabIndex = 1;
            this.tabFees.Text = "Service Fees";
            // 
            // lblFeesInfo
            // 
            this.lblFeesInfo.AutoSize = true;
            this.lblFeesInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFeesInfo.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblFeesInfo.Location = new System.Drawing.Point(30, 30);
            this.lblFeesInfo.Name = "lblFeesInfo";
            this.lblFeesInfo.Size = new System.Drawing.Size(343, 20);
            this.lblFeesInfo.TabIndex = 0;
            this.lblFeesInfo.Text = "Configure service fees for document requests";
            // 
            // dgvFees
            // 
            this.dgvFees.BackgroundColor = System.Drawing.Color.White;
            this.dgvFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvFees.ColumnHeadersHeight = 35;
            this.dgvFees.Location = new System.Drawing.Point(34, 70);
            this.dgvFees.Name = "dgvFees";
            this.dgvFees.RowHeadersVisible = false;
            this.dgvFees.Size = new System.Drawing.Size(800, 400);
            this.dgvFees.TabIndex = 1;
            // 
            // btnUpdateFees
            // 
            this.btnUpdateFees.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnUpdateFees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateFees.FlatAppearance.BorderSize = 0;
            this.btnUpdateFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateFees.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdateFees.ForeColor = System.Drawing.Color.White;
            this.btnUpdateFees.Location = new System.Drawing.Point(34, 490);
            this.btnUpdateFees.Name = "btnUpdateFees";
            this.btnUpdateFees.Size = new System.Drawing.Size(150, 40);
            this.btnUpdateFees.TabIndex = 2;
            this.btnUpdateFees.Text = "?? Update Fees";
            this.btnUpdateFees.UseVisualStyleBackColor = false;
            this.btnUpdateFees.Click += new System.EventHandler(this.BtnUpdateFees_Click);
            // 
            // tabSystem
            // 
            this.tabSystem.BackColor = System.Drawing.Color.White;
            this.tabSystem.Controls.Add(this.btnRestore);
            this.tabSystem.Controls.Add(this.btnBackup);
            this.tabSystem.Controls.Add(this.lblDatabase);
            this.tabSystem.Controls.Add(this.lblVersion);
            this.tabSystem.Controls.Add(this.lblSystemInfo);
            this.tabSystem.Location = new System.Drawing.Point(4, 26);
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.Size = new System.Drawing.Size(872, 570);
            this.tabSystem.TabIndex = 2;
            this.tabSystem.Text = "System";
            // 
            // lblSystemInfo
            // 
            this.lblSystemInfo.AutoSize = true;
            this.lblSystemInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSystemInfo.Location = new System.Drawing.Point(30, 30);
            this.lblSystemInfo.Name = "lblSystemInfo";
            this.lblSystemInfo.Size = new System.Drawing.Size(164, 21);
            this.lblSystemInfo.TabIndex = 0;
            this.lblSystemInfo.Text = "System Information";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVersion.Location = new System.Drawing.Point(30, 70);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(356, 20);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version: 1.0.0 | .NET Framework 4.8 | Build 2025";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDatabase.Location = new System.Drawing.Point(30, 100);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(270, 20);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database: barangay_management_db";
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(34, 160);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(180, 45);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "?? Backup Database";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(234, 160);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(180, 45);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "?? Restore Database";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabSettings.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabFees.ResumeLayout(false);
            this.tabFees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).EndInit();
            this.tabSystem.ResumeLayout(false);
            this.tabSystem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}