using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class AdminProfileForm : Form
    {
        private Models.User currentUser;

        public AdminProfileForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void AdminProfileForm_Load(object sender, EventArgs e)
        {
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            lblFullNameValue.Text = currentUser.FullName;
            lblUsernameValue.Text = currentUser.Username;
            lblEmailValue.Text = currentUser.Email ?? "Not provided";
            lblRoleValue.Text = "Administrator";
            lblLastLoginValue.Text = DateTime.Now.ToString("MMMM dd, yyyy HH:mm");
        }

        private void AvatarPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            using (Brush brush = new SolidBrush(avatarPanel.BackColor))
            {
                e.Graphics.FillEllipse(brush, 0, 0, avatarPanel.Width, avatarPanel.Height);
            }
            
            using (Font font = new Font("Segoe UI", 42F, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.White))
            {
                string initial = currentUser.FullName.Substring(0, 1).ToUpper();
                SizeF textSize = e.Graphics.MeasureString(initial, font);
                e.Graphics.DrawString(initial, font, textBrush,
                    (avatarPanel.Width - textSize.Width) / 2, 
                    (avatarPanel.Height - textSize.Height) / 2);
            }
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Change Password functionality will be implemented soon.", 
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}