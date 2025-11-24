using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void LeftPanel_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                leftPanel.ClientRectangle,
                Color.FromArgb(0, 123, 255),
                Color.FromArgb(0, 86, 179),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, leftPanel.ClientRectangle);
            }
        }

        private void RegisterForm_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowError("Please fill in all required fields (Username, Password, Full Name).");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Passwords do not match.");
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                ShowError("Password must be at least 6 characters long.");
                return;
            }

            btnRegister.Enabled = false;
            btnRegister.Text = "⏳ Creating Account...";
            Application.DoEvents();

            try
            {
                Models.User newUser = new Models.User
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    ContactNumber = txtContact.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    UserType = "Resident",
                    IsActive = true
                };

                if (DatabaseHelper.RegisterUser(newUser))
                {
                    MessageBox.Show("Account created successfully! You can now login.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    ShowError("Failed to create account. Username may already exist.");
                    btnRegister.Enabled = true;
                    btnRegister.Text = "📝 REGISTER";
                }
            }
            catch (Exception ex)
            {
                ShowError($"Registration error: {ex.Message}");
                btnRegister.Enabled = true;
                btnRegister.Text = "📝 REGISTER";
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Registration Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}