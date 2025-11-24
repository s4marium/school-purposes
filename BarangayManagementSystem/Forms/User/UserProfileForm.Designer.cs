using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.User
{
    partial class UserProfileForm
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
        private Label lblContact;
        private Label lblContactValue;
        private Label lblAddress;
        private Label lblAddressValue;
        private Label lblMemberSince;
        private Label lblMemberSinceValue;
        private Button btnEditProfile;
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
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.lblMemberSinceValue = new System.Windows.Forms.Label();
            this.lblMemberSince = new System.Windows.Forms.Label();
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblContactValue = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
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
            this.lblTitle.Size = new System.Drawing.Size(188, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👤 My Profile";
            // 
            // profilePanel
            // 
            this.profilePanel.BackColor = System.Drawing.Color.White;
            this.profilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profilePanel.Controls.Add(this.btnClose);
            this.profilePanel.Controls.Add(this.btnChangePassword);
            this.profilePanel.Controls.Add(this.btnEditProfile);
            this.profilePanel.Controls.Add(this.lblMemberSinceValue);
            this.profilePanel.Controls.Add(this.lblMemberSince);
            this.profilePanel.Controls.Add(this.lblAddressValue);
            this.profilePanel.Controls.Add(this.lblAddress);
            this.profilePanel.Controls.Add(this.lblContactValue);
            this.profilePanel.Controls.Add(this.lblContact);
            this.profilePanel.Controls.Add(this.lblEmailValue);
            this.profilePanel.Controls.Add(this.lblEmail);
            this.profilePanel.Controls.Add(this.lblUsernameValue);
            this.profilePanel.Controls.Add(this.lblUsername);
            this.profilePanel.Controls.Add(this.lblFullNameValue);
            this.profilePanel.Controls.Add(this.lblFullName);
            this.profilePanel.Controls.Add(this.avatarPanel);
            this.profilePanel.Location = new System.Drawing.Point(20, 70);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Size = new System.Drawing.Size(760, 550);
            this.profilePanel.TabIndex = 1;
            // 
            // avatarPanel
            // 
            this.avatarPanel.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
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
            this.lblFullName.Location = new System.Drawing.Point(150, 160);
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
            this.lblFullNameValue.Location = new System.Drawing.Point(310, 160);
            this.lblFullNameValue.Name = "lblFullNameValue";
            this.lblFullNameValue.Size = new System.Drawing.Size(400, 25);
            this.lblFullNameValue.TabIndex = 2;
            this.lblFullNameValue.Text = "John Doe";
            this.lblFullNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblUsername.Location = new System.Drawing.Point(150, 200);
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
            this.lblUsernameValue.Location = new System.Drawing.Point(310, 200);
            this.lblUsernameValue.Name = "lblUsernameValue";
            this.lblUsernameValue.Size = new System.Drawing.Size(400, 25);
            this.lblUsernameValue.TabIndex = 4;
            this.lblUsernameValue.Text = "johndoe";
            this.lblUsernameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblEmail.Location = new System.Drawing.Point(150, 240);
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
            this.lblEmailValue.Location = new System.Drawing.Point(310, 240);
            this.lblEmailValue.Name = "lblEmailValue";
            this.lblEmailValue.Size = new System.Drawing.Size(400, 25);
            this.lblEmailValue.TabIndex = 6;
            this.lblEmailValue.Text = "Not provided";
            this.lblEmailValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContact
            // 
            this.lblContact.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblContact.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblContact.Location = new System.Drawing.Point(150, 280);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(150, 25);
            this.lblContact.TabIndex = 7;
            this.lblContact.Text = "Contact:";
            this.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblContactValue
            // 
            this.lblContactValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblContactValue.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblContactValue.Location = new System.Drawing.Point(310, 280);
            this.lblContactValue.Name = "lblContactValue";
            this.lblContactValue.Size = new System.Drawing.Size(400, 25);
            this.lblContactValue.TabIndex = 8;
            this.lblContactValue.Text = "Not provided";
            this.lblContactValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblAddress.Location = new System.Drawing.Point(150, 320);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(150, 25);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAddressValue
            // 
            this.lblAddressValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAddressValue.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblAddressValue.Location = new System.Drawing.Point(310, 320);
            this.lblAddressValue.Name = "lblAddressValue";
            this.lblAddressValue.Size = new System.Drawing.Size(400, 25);
            this.lblAddressValue.TabIndex = 10;
            this.lblAddressValue.Text = "Not provided";
            this.lblAddressValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMemberSince
            // 
            this.lblMemberSince.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMemberSince.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblMemberSince.Location = new System.Drawing.Point(150, 360);
            this.lblMemberSince.Name = "lblMemberSince";
            this.lblMemberSince.Size = new System.Drawing.Size(150, 25);
            this.lblMemberSince.TabIndex = 11;
            this.lblMemberSince.Text = "Member Since:";
            this.lblMemberSince.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMemberSinceValue
            // 
            this.lblMemberSinceValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMemberSinceValue.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblMemberSinceValue.Location = new System.Drawing.Point(310, 360);
            this.lblMemberSinceValue.Name = "lblMemberSinceValue";
            this.lblMemberSinceValue.Size = new System.Drawing.Size(400, 25);
            this.lblMemberSinceValue.TabIndex = 12;
            this.lblMemberSinceValue.Text = "January 01, 2025";
            this.lblMemberSinceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnEditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditProfile.FlatAppearance.BorderSize = 0;
            this.btnEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProfile.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEditProfile.ForeColor = System.Drawing.Color.White;
            this.btnEditProfile.Location = new System.Drawing.Point(200, 440);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(160, 45);
            this.btnEditProfile.TabIndex = 13;
            this.btnEditProfile.Text = "✏️ Edit Profile";
            this.btnEditProfile.UseVisualStyleBackColor = false;
            this.btnEditProfile.Click += new System.EventHandler(this.BtnEditProfile_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(380, 440);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(180, 45);
            this.btnChangePassword.TabIndex = 14;
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
            this.btnClose.Location = new System.Drawing.Point(580, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 45);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.profilePanel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Profile";
            this.Load += new System.EventHandler(this.UserProfileForm_Load);
            this.profilePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}