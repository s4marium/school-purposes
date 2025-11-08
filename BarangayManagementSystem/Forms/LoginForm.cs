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
        private Panel loginPanel;

        public LoginForm()
        {
            InitializeComponent();
            InitializeModernUI();
        }

        private void InitializeModernUI()
        {
            // Form properties
            this.Size = new Size(900, 600);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(41, 44, 51);

            // Create main split panel
            Panel leftPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 450,
                BackColor = Color.FromArgb(40, 167, 69)
            };
            leftPanel.Paint += LeftPanel_Paint;

            // Logo and branding on left panel
            Label brandLabel = new Label
            {
                Text = "🏠",
                Font = new Font("Segoe UI Emoji", 72F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(175, 150),
                Size = new Size(150, 120),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label titleLabel = new Label
            {
                Text = "BARANGAY\nMANAGEMENT\nSYSTEM",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(50, 280),
                Size = new Size(350, 150),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label subtitleLabel = new Label
            {
                Text = "Empowering Communities Through Digital Solutions",
                Font = new Font("Segoe UI", 11F, FontStyle.Italic),
                ForeColor = Color.FromArgb(230, 245, 233),
                Location = new Point(50, 430),
                Size = new Size(350, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            leftPanel.Controls.AddRange(new Control[] { brandLabel, titleLabel, subtitleLabel });

            // Login panel on right
            loginPanel = new Panel
            {
                Location = new Point(450, 0),
                Size = new Size(450, 600),
                BackColor = Color.White
            };

            // Close button
            Button btnClose = CreateCloseButton();
            
            // Login header
            Label loginHeaderLabel = new Label
            {
                Text = "Welcome Back!",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(60, 80),
                Size = new Size(330, 40)
            };

            Label loginSubLabel = new Label
            {
                Text = "Please login to your account",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(60, 125),
                Size = new Size(330, 25)
            };

            // Username field
            Label lblUsername = new Label
            {
                Text = "Username",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(60, 180),
                Size = new Size(100, 20)
            };

            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(60, 205);
            txtUsername.Size = new Size(330, 35);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;

            // Password field
            Label lblPassword = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(60, 260),
                Size = new Size(100, 20)
            };

            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(60, 285);
            txtPassword.Size = new Size(330, 35);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.UseSystemPasswordChar = true;

            // Show/Hide password checkbox
            CheckBox chkShowPassword = new CheckBox
            {
                Text = "Show Password",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(60, 330),
                Size = new Size(150, 20)
            };
            chkShowPassword.CheckedChanged += (s, e) => {
                txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            };

            // Login button
            btnLogin.Text = "🔐 LOGIN";
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.Location = new Point(60, 380);
            btnLogin.Size = new Size(330, 45);
            btnLogin.BackColor = Color.FromArgb(40, 167, 69);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;

            // Register link
            LinkLabel linkRegister = new LinkLabel
            {
                Text = "Don't have an account? Register here",
                Font = new Font("Segoe UI", 10F),
                Location = new Point(60, 440),
                Size = new Size(330, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                LinkColor = Color.FromArgb(0, 123, 255),
                ActiveLinkColor = Color.FromArgb(0, 86, 179)
            };
            linkRegister.LinkClicked += (s, e) => btnRegister_Click(s, e);

            // Version label
            Label versionLabel = new Label
            {
                Text = "Version 2.0.0 © 2024",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(173, 181, 189),
                Location = new Point(60, 550),
                Size = new Size(330, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            loginPanel.Controls.AddRange(new Control[] {
                btnClose, loginHeaderLabel, loginSubLabel,
                lblUsername, txtUsername,
                lblPassword, txtPassword, chkShowPassword,
                btnLogin, linkRegister, versionLabel
            });

            this.Controls.AddRange(new Control[] { leftPanel, loginPanel });

            // Add shadow effect
            this.Paint += (s, e) => {
                using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            };
        }

        private void LeftPanel_Paint(object sender, PaintEventArgs e)
        {
            // Gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                ((Panel)sender).ClientRectangle,
                Color.FromArgb(40, 167, 69),
                Color.FromArgb(28, 117, 48),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, ((Panel)sender).ClientRectangle);
            }
        }

        private Button CreateCloseButton()
        {
            Button btnClose = new Button
            {
                Text = "✕",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(405, 15),
                Size = new Size(35, 35),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => Application.Exit();
            
            return btnClose;
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
                User user = DatabaseHelper.AuthenticateUser(txtUsername.Text.Trim(), txtPassword.Text);
                
                if (user != null)
                {
                    try
                    {
                        // Log activity - wrap in try-catch to prevent blocking login
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
                                EnhancedAdminDashboard adminDashboard = new EnhancedAdminDashboard(user);
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
                                MessageBox.Show($"Error opening admin dashboard:\n\n{ex.Message}\n\nStack trace:\n{ex.StackTrace}", 
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
                                EnhancedUserDashboard userDashboard = new EnhancedUserDashboard(user);
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
                                MessageBox.Show($"Error opening user dashboard:\n\n{ex.Message}\n\nStack trace:\n{ex.StackTrace}", 
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
                    // Authentication failed - error message already shown by AuthenticateUser
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

        private void btnRegister_Click(object sender, EventArgs e)
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