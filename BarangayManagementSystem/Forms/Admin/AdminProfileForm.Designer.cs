using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.Admin
{
    partial class AdminProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel profilePanel;
        private Panel avatarPanel;
        private Label lblFullName;
        private Label lblFullNameValue;
        private Label lblUsername;
        private Label lblUsernameValue;
        private Label lblEmail;
        private Label lblEmailValue;
        private Label lblRole;
        private Label lblRoleValue;
        private Label lblLastLogin;
        private Label lblLastLoginValue;
        private Button btnChangePassword;
        private Button btnClose;

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
            this.profilePanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lblLastLoginValue = new System.Windows.Forms.Label();
            this.lblLastLogin = new System.Windows.Forms.Label();
            this.lblRoleValue = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblEmailValue = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblUsernameValue = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblFullNameValue = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.avatarPanel = new System.Windows.Forms.Panel();
            this.profilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(264, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👤 Admin Profile";
            // 
            // profilePanel
            // 
            this.profilePanel.BackColor = System.Drawing.Color.White;
            this.profilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profilePanel.Controls.Add(this.btnClose);
            this.profilePanel.Controls.Add(this.btnChangePassword);
            this.profilePanel.Controls.Add(this.lblLastLoginValue);
            this.profilePanel.Controls.Add(this.lblLastLogin);
            this.profilePanel.Controls.Add(this.lblRoleValue);
            this.profilePanel.Controls.Add(this.lblRole);
            this.profilePanel.Controls.Add(this.lblEmailValue);
            this.profilePanel.Controls.Add(this.lblEmail);
            this.profilePanel.Controls.Add(this.lblUsernameValue);
            this.profilePanel.Controls.Add(this.lblUsername);
            this.profilePanel.Controls.Add(this.lblFullNameValue);
            this.profilePanel.Controls.Add(this.lblFullName);
            this.profilePanel.Controls.Add(this.avatarPanel);
            this.profilePanel.Location = new System.Drawing.Point(20, 70);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Size = new System.Drawing.Size(760, 500);
            this.profilePanel.TabIndex = 1;
            // 
            // avatarPanel
            // 
            this.avatarPanel.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.avatarPanel.Location = new System.Drawing.Point(330, 30);
            this.avatarPanel.Name = "avatarPanel";
            this.avatarPanel.Size = new System.Drawing.Size(100, 100);
            this.avatarPanel.TabIndex = 0;
            this.avatarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AvatarPanel_Paint);
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblFullName.Location = new System.Drawing.Point(180, 160);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(150, 25);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Full Name:";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameValue
            // 
            this.lblFullNameValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFullNameValue.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblFullNameValue.Location = new System.Drawing.Point(340, 160);
            this.lblFullNameValue.Name = "lblFullNameValue";
            this.lblFullNameValue.Size = new System.Drawing.Size(350, 25);
            this.lblFullNameValue.TabIndex = 2;
            this.lblFullNameValue.Text = "Administrator";
            this.lblFullNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblUsername.Location = new System.Drawing.Point(180, 200);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(150, 25);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsernameValue
            // 
            this.lblUsernameValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUsernameValue.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblUsernameValue.Location = new System.Drawing.Point(340, 200);
            this.lblUsernameValue.Name = "lblUsernameValue";
            this.lblUsernameValue.Size = new System.Drawing.Size(350, 25);
            this.lblUsernameValue.TabIndex = 4;
            this.lblUsernameValue.Text = "admin";
            this.lblUsernameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblEmail.Location = new System.Drawing.Point(180, 240);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(150, 25);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmailValue
            // 
            this.lblEmailValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEmailValue.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblEmailValue.Location = new System.Drawing.Point(340, 240);
            this.lblEmailValue.Name = "lblEmailValue";
            this.lblEmailValue.Size = new System.Drawing.Size(350, 25);
            this.lblEmailValue.TabIndex = 6;
            this.lblEmailValue.Text = "Not provided";
            this.lblEmailValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblRole.Location = new System.Drawing.Point(180, 280);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(150, 25);
            this.lblRole.TabIndex = 7;
            this.lblRole.Text = "Role:";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRoleValue
            // 
            this.lblRoleValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoleValue.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.lblRoleValue.Location = new System.Drawing.Point(340, 280);
            this.lblRoleValue.Name = "lblRoleValue";
            this.lblRoleValue.Size = new System.Drawing.Size(350, 25);
            this.lblRoleValue.TabIndex = 8;
            this.lblRoleValue.Text = "Administrator";
            this.lblRoleValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastLogin
            // 
            this.lblLastLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLastLogin.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblLastLogin.Location = new System.Drawing.Point(180, 320);
            this.lblLastLogin.Name = "lblLastLogin";
            this.lblLastLogin.Size = new System.Drawing.Size(150, 25);
            this.lblLastLogin.TabIndex = 9;
            this.lblLastLogin.Text = "Last Login:";
            this.lblLastLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastLoginValue
            // 
            this.lblLastLoginValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblLastLoginValue.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblLastLoginValue.Location = new System.Drawing.Point(340, 320);
            this.lblLastLoginValue.Name = "lblLastLoginValue";
            this.lblLastLoginValue.Size = new System.Drawing.Size(350, 25);
            this.lblLastLoginValue.TabIndex = 10;
            this.lblLastLoginValue.Text = "November 25, 2025";
            this.lblLastLoginValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(250, 400);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(180, 45);
            this.btnChangePassword.TabIndex = 11;
            this.btnChangePassword.Text = "🔒 Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(450, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 45);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // AdminProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.profilePanel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Profile";
            this.Load += new System.EventHandler(this.AdminProfileForm_Load);
            this.profilePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}