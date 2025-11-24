using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LeftPanel_Paint(object sender, PaintEventArgs e)
        {
            // Gradient background for left panel
            using (LinearGradientBrush brush = new LinearGradientBrush(
                leftPanel.ClientRectangle,
                Color.FromArgb(40, 167, 69),
                Color.FromArgb(28, 117, 48),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, leftPanel.ClientRectangle);
            }
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            // Form border shadow
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Please enter both username and password.");
                return;
            }

            // Show loading
            btnLogin.Enabled = false;
            btnLogin.Text = "⏳ Logging in...";
            Application.DoEvents();

            try
            {
                Models.User user = DatabaseHelper.AuthenticateUser(txtUsername.Text.Trim(), txtPassword.Text);
                
                if (user != null)
                {
                    try
                    {
                        // Log activity
                        try
                        {
                            EnhancedDatabaseHelper.LogActivity(user.Id, "Login", "Authentication", 
                                $"User {user.Username} logged in successfully");
                        }
                        catch
                        {
                            // Ignore logging errors
                        }

                        // Hide login form
                        this.Hide();

                        // Open appropriate dashboard based on user type
                        if (user.UserType == "Admin")
                        {
                            try
                            {
                                BarangayManagementSystem.Forms.Admin.AdminMainDashboardForm adminDashboard = 
                                    new BarangayManagementSystem.Forms.Admin.AdminMainDashboardForm(user);
                                adminDashboard.FormClosed += (s, args) => {
                                    this.Show();
                                    btnLogin.Enabled = true;
                                    btnLogin.Text = "🔐 LOGIN";
                                    txtPassword.Clear();
                                };
                                adminDashboard.Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error opening admin dashboard:\n\n{ex.Message}", 
                                    "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Show();
                                btnLogin.Enabled = true;
                                btnLogin.Text = "🔐 LOGIN";
                            }
                        }
                        else
                        {
                            try
                            {
                                BarangayManagementSystem.Forms.User.MainDashboardForm userDashboard = 
                                    new BarangayManagementSystem.Forms.User.MainDashboardForm(user);
                                userDashboard.FormClosed += (s, args) => {
                                    this.Show();
                                    btnLogin.Enabled = true;
                                    btnLogin.Text = "🔐 LOGIN";
                                    txtPassword.Clear();
                                };
                                userDashboard.Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error opening user dashboard:\n\n{ex.Message}", 
                                    "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Show();
                                btnLogin.Enabled = true;
                                btnLogin.Text = "🔐 LOGIN";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError($"Error after login: {ex.Message}");
                        this.Show();
                        btnLogin.Enabled = true;
                        btnLogin.Text = "🔐 LOGIN";
                    }
                }
                else
                {
                    btnLogin.Enabled = true;
                    btnLogin.Text = "🔐 LOGIN";
                }
            }
            catch (Exception ex)
            {
                ShowError($"Login error: {ex.Message}\n\nStack trace: {ex.StackTrace}");
                btnLogin.Enabled = true;
                btnLogin.Text = "🔐 LOGIN";
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.FormClosed += (s, args) => this.Show();
            registerForm.Show();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Login Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}