using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
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
            InitializeModernUI();
        }

        private void InitializeModernUI()
        {
            // Form properties
            this.Size = new Size(1000, 700);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(41, 44, 51);

            // Create main container
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Header panel
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(40, 167, 69)
            };
            headerPanel.Paint += (s, e) => {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    headerPanel.ClientRectangle,
                    Color.FromArgb(40, 167, 69),
                    Color.FromArgb(28, 117, 48),
                    LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, headerPanel.ClientRectangle);
                }
            };

            Label headerLabel = new Label
            {
                Text = "👤 Create New Account",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(50, 30),
                Size = new Size(700, 40)
            };

            Button btnClose = new Button
            {
                Text = "✕",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(940, 15),
                Size = new Size(40, 40),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += btnClose_Click;

            headerPanel.Controls.AddRange(new Control[] { headerLabel, btnClose });

            // Form content panel with scroll
            Panel contentPanel = new Panel
            {
                Location = new Point(0, 100),
                Size = new Size(1000, 600),
                BackColor = Color.White,
                AutoScroll = true
            };

            // Create form fields
            int yPos = 30;
            int leftCol = 80;
            int rightCol = 520;

            // Full Name
            CreateFormField(contentPanel, "Full Name *", txtFullName, leftCol, yPos, true);
            
            // Username
            CreateFormField(contentPanel, "Username *", txtUsername, rightCol, yPos, true);
            yPos += 80;

            // Email
            CreateFormField(contentPanel, "Email Address", txtEmail, leftCol, yPos, false, "email");
            
            // Contact Number
            CreateFormField(contentPanel, "Contact Number", txtContactNumber, rightCol, yPos, false, "phone");
            yPos += 80;

            // Password
            CreateFormField(contentPanel, "Password *", txtPassword, leftCol, yPos, true, "password");
            
            // Confirm Password
            CreateFormField(contentPanel, "Confirm Password *", txtConfirmPassword, rightCol, yPos, true, "password");
            yPos += 80;

            // Address
            Label lblAddress = new Label
            {
                Text = "Complete Address",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(leftCol, yPos),
                Size = new Size(200, 20)
            };

            txtAddress.Font = new Font("Segoe UI", 11F);
            txtAddress.Location = new Point(leftCol, yPos + 25);
            txtAddress.Size = new Size(840, 60);
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Multiline = true;

            contentPanel.Controls.AddRange(new Control[] { lblAddress, txtAddress });
            yPos += 110;

            // Password strength indicator
            Label lblPasswordStrength = new Label
            {
                Text = "Password Strength: ",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(leftCol, yPos),
                Size = new Size(400, 20)
            };
            contentPanel.Controls.Add(lblPasswordStrength);

            txtPassword.TextChanged += (s, e) => {
                string strength = GetPasswordStrength(txtPassword.Text);
                lblPasswordStrength.Text = $"Password Strength: {strength}";
                lblPasswordStrength.ForeColor = strength == "Strong" ? Color.Green : 
                                                strength == "Medium" ? Color.Orange : Color.Red;
            };

            yPos += 40;

            // Terms and conditions
            CheckBox chkTerms = new CheckBox
            {
                Text = "I agree to the Terms and Conditions and Privacy Policy",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(leftCol, yPos),
                Size = new Size(500, 25)
            };
            contentPanel.Controls.Add(chkTerms);

            yPos += 50;

            // Register button
            btnRegister.Text = "✅ CREATE ACCOUNT";
            btnRegister.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnRegister.Location = new Point(leftCol, yPos);
            btnRegister.Size = new Size(400, 50);
            btnRegister.BackColor = Color.FromArgb(40, 167, 69);
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.Enabled = false;
            btnRegister.FlatAppearance.BorderSize = 0;

            chkTerms.CheckedChanged += (s, e) => {
                btnRegister.Enabled = chkTerms.Checked;
            };

            // Back to login button
            btnBackToLogin.Text = "← Back to Login";
            btnBackToLogin.Font = new Font("Segoe UI", 11F);
            btnBackToLogin.Location = new Point(leftCol + 420, yPos);
            btnBackToLogin.Size = new Size(200, 50);
            btnBackToLogin.BackColor = Color.FromArgb(108, 117, 125);
            btnBackToLogin.ForeColor = Color.White;
            btnBackToLogin.FlatStyle = FlatStyle.Flat;
            btnBackToLogin.Cursor = Cursors.Hand;
            btnBackToLogin.FlatAppearance.BorderSize = 0;

            contentPanel.Controls.AddRange(new Control[] { btnRegister, btnBackToLogin });

            mainPanel.Controls.AddRange(new Control[] { headerPanel, contentPanel });
            this.Controls.Add(mainPanel);
        }

        private void CreateFormField(Panel parent, string labelText, TextBox textBox, 
            int x, int y, bool required, string type = "text")
        {
            Label lbl = new Label
            {
                Text = labelText,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(x, y),
                Size = new Size(350, 20)
            };

            textBox.Font = new Font("Segoe UI", 11F);
            textBox.Location = new Point(x, y + 25);
            textBox.Size = new Size(380, 35);
            textBox.BorderStyle = BorderStyle.FixedSingle;

            if (type == "password")
                textBox.UseSystemPasswordChar = true;

            if (type == "email")
            {
                TextBox capturedTextBox = textBox; // Capture to avoid ref issue
                textBox.Leave += (s, e) => {
                    if (!string.IsNullOrEmpty(capturedTextBox.Text) && !IsValidEmail(capturedTextBox.Text))
                    {
                        MessageBox.Show("Please enter a valid email address.", "Invalid Email", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (type == "phone")
            {
                textBox.KeyPress += (s, e) => {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && 
                        e.KeyChar != '-' && e.KeyChar != '+' && e.KeyChar != ' ')
                    {
                        e.Handled = true;
                    }
                };
            }

            parent.Controls.AddRange(new Control[] { lbl, textBox });
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validation
            if (!ValidateForm())
                return;

            // Create user
            var user = new User
            {
                FullName = txtFullName.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                Email = txtEmail.Text.Trim(),
                ContactNumber = txtContactNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                UserType = "User"
            };

            btnRegister.Enabled = false;
            btnRegister.Text = "⏳ Creating Account...";
            Application.DoEvents();

            if (DatabaseHelper.CreateUser(user))
            {
                // Log activity
                EnhancedDatabaseHelper.LogActivity(user.Id, "Register", "Authentication", 
                    $"New user {user.Username} registered successfully");

                MessageBox.Show("Registration successful! You can now login with your credentials.", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Hide();
                new LoginForm().Show();
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different username.", 
                    "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegister.Enabled = true;
                btnRegister.Text = "✅ CREATE ACCOUNT";
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowValidationError("Please enter your full name.");
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowValidationError("Please enter a username.");
                txtUsername.Focus();
                return false;
            }

            if (txtUsername.Text.Length < 4)
            {
                ShowValidationError("Username must be at least 4 characters long.");
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowValidationError("Please enter a password.");
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                ShowValidationError("Password must be at least 6 characters long.");
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowValidationError("Passwords do not match.");
                txtConfirmPassword.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                ShowValidationError("Please enter a valid email address.");
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void ShowValidationError(string message)
        {
            MessageBox.Show(message, "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        private string GetPasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "Weak";

            int score = 0;
            if (password.Length >= 8) score++;
            if (Regex.IsMatch(password, @"[a-z]")) score++;
            if (Regex.IsMatch(password, @"[A-Z]")) score++;
            if (Regex.IsMatch(password, @"\d")) score++;
            if (Regex.IsMatch(password, @"[^a-zA-Z0-9]")) score++;

            if (score >= 4) return "Strong";
            if (score >= 2) return "Medium";
            return "Weak";
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Event handlers required by Designer
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Form load logic already handled in InitializeModernUI
        }

        private void RegisterForm_Paint(object sender, PaintEventArgs e)
        {
            // Paint logic already handled by panels
        }
    }
}