using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.User
{
    partial class SubmitRequestForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel formPanel;
        private Label lblRequestType;
        private ComboBox cmbRequestType;
        private Label lblPurpose;
        private TextBox txtPurpose;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblFeeInfo;
        private Button btnSubmit;
        private Button btnClear;

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
            this.formPanel = new System.Windows.Forms.Panel();
            this.lblRequestType = new System.Windows.Forms.Label();
            this.cmbRequestType = new System.Windows.Forms.ComboBox();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblFeeInfo = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.formPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(382, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📝 Submit Document Request";
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.White;
            this.formPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formPanel.Controls.Add(this.btnClear);
            this.formPanel.Controls.Add(this.btnSubmit);
            this.formPanel.Controls.Add(this.lblFeeInfo);
            this.formPanel.Controls.Add(this.txtDescription);
            this.formPanel.Controls.Add(this.lblDescription);
            this.formPanel.Controls.Add(this.txtPurpose);
            this.formPanel.Controls.Add(this.lblPurpose);
            this.formPanel.Controls.Add(this.cmbRequestType);
            this.formPanel.Controls.Add(this.lblRequestType);
            this.formPanel.Location = new System.Drawing.Point(20, 70);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(760, 550);
            this.formPanel.TabIndex = 1;
            // 
            // lblRequestType
            // 
            this.lblRequestType.AutoSize = true;
            this.lblRequestType.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRequestType.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblRequestType.Location = new System.Drawing.Point(30, 30);
            this.lblRequestType.Name = "lblRequestType";
            this.lblRequestType.Size = new System.Drawing.Size(126, 20);
            this.lblRequestType.TabIndex = 0;
            this.lblRequestType.Text = "Request Type *";
            // 
            // cmbRequestType
            // 
            this.cmbRequestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequestType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbRequestType.FormattingEnabled = true;
            this.cmbRequestType.Items.AddRange(new object[] {
            "Barangay Clearance",
            "Certificate of Residency",
            "Certificate of Indigency",
            "Business Permit",
            "Barangay ID",
            "Other Documents"});
            this.cmbRequestType.Location = new System.Drawing.Point(30, 57);
            this.cmbRequestType.Name = "cmbRequestType";
            this.cmbRequestType.Size = new System.Drawing.Size(700, 28);
            this.cmbRequestType.TabIndex = 1;
            this.cmbRequestType.SelectedIndexChanged += new System.EventHandler(this.CmbRequestType_SelectedIndexChanged);
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPurpose.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblPurpose.Location = new System.Drawing.Point(30, 110);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(82, 20);
            this.lblPurpose.TabIndex = 2;
            this.lblPurpose.Text = "Purpose *";
            // 
            // txtPurpose
            // 
            this.txtPurpose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurpose.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPurpose.Location = new System.Drawing.Point(30, 137);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(700, 27);
            this.txtPurpose.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblDescription.Location = new System.Drawing.Point(30, 190);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(134, 20);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Additional Details";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDescription.Location = new System.Drawing.Point(30, 217);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(700, 120);
            this.txtDescription.TabIndex = 5;
            // 
            // lblFeeInfo
            // 
            this.lblFeeInfo.AutoSize = true;
            this.lblFeeInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblFeeInfo.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblFeeInfo.Location = new System.Drawing.Point(30, 360);
            this.lblFeeInfo.Name = "lblFeeInfo";
            this.lblFeeInfo.Size = new System.Drawing.Size(183, 19);
            this.lblFeeInfo.TabIndex = 6;
            this.lblFeeInfo.Text = "💰 Processing Fee: ₱50.00";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(30, 420);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(320, 50);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "✅ Submit Request";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(370, 420);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(160, 50);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // SubmitRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubmitRequestForm";
            this.Load += new System.EventHandler(this.SubmitRequestForm_Load);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}