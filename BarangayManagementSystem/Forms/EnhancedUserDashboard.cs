using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;
using BarangayManagementSystem.Controls;

namespace BarangayManagementSystem.Forms
{
    public partial class EnhancedUserDashboard : Form
    {
        private User currentUser;
        private Panel contentPanel;
        private Panel sidebarPanel;
        private NotificationPanel notificationPanel;
        private Panel currentSelectedMenuItem;
        private Timer notificationRefreshTimer;
        private Panel profileDropdown;
        private bool isProfileDropdownVisible = false;

        public EnhancedUserDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimumSize = new Size(1024, 768);
            CreateModernLayout();
            ShowDashboard();

            notificationRefreshTimer = new Timer();
            notificationRefreshTimer.Interval = 30000;
            notificationRefreshTimer.Tick += (s, e) => UpdateNotificationBadge();
            notificationRefreshTimer.Start();

            EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Login", "Dashboard", "User logged in");
        }

        private void CreateModernLayout()
        {
            this.BackColor = Color.FromArgb(248, 249, 250);

            Panel topPanel = CreateTopNavigationBar();
            sidebarPanel = CreateSidebarNavigation();

            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(248, 249, 250),
                AutoScroll = true,
                Padding = new Padding(20)
            };

            this.Controls.Add(contentPanel);
            this.Controls.Add(sidebarPanel);
            this.Controls.Add(topPanel);

            // Hide dropdown when clicking elsewhere
            contentPanel.Click += (s, e) => HideProfileDropdown();
            sidebarPanel.Click += (s, e) => HideProfileDropdown();
        }

        private Panel CreateTopNavigationBar()
        {
            Panel topPanel = new Panel
            {
                Height = 70,
                Dock = DockStyle.Top,
                BackColor = Color.White
            };

            topPanel.Paint += (s, e) => {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawLine(pen, 0, topPanel.Height - 1, topPanel.Width, topPanel.Height - 1);
                }
            };

            Label logoLabel = new Label
            {
                Text = "🏠",
                Font = new Font("Segoe UI Emoji", 24F),
                Location = new Point(20, 20),
                AutoSize = false,
                Size = new Size(40, 35)
            };

            Label brandLabel = new Label
            {
                Text = "BARANGAY PORTAL",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(65, 18),
                AutoSize = true
            };

            Label subtitleLabel = new Label
            {
                Text = "Resident Dashboard",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(65, 38),
                AutoSize = true
            };

            Panel rightPanel = new Panel
            {
                Height = 70,
                Dock = DockStyle.Right,
                Width = 350,
                BackColor = Color.Transparent
            };

            Label userNameLabel = new Label
            {
                Text = currentUser.FullName,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(10, 15),
                AutoSize = true
            };

            Label roleLabel = new Label
            {
                Text = "Resident",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(10, 35),
                AutoSize = true
            };

            notificationPanel = new NotificationPanel(currentUser);
            Button notifBtn = notificationPanel.CreateNotificationButton();
            notifBtn.Location = new Point(150, 15);

            Button avatarBtn = new Button
            {
                Text = currentUser.FullName.Substring(0, 1).ToUpper(),
                Size = new Size(40, 40),
                Location = new Point(200, 15),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            avatarBtn.FlatAppearance.BorderSize = 0;
            avatarBtn.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, avatarBtn.Width - 1, avatarBtn.Height - 1);
                    avatarBtn.Region = new Region(path);
                }
            };
            avatarBtn.Click += AvatarBtn_Click;

            Button minimizeBtn = new Button
            {
                Text = "─",
                Size = new Size(35, 35),
                Location = new Point(250, 17),
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(108, 117, 125),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            Button closeBtn = new Button
            {
                Text = "✕",
                Size = new Size(35, 35),
                Location = new Point(295, 17),
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(220, 53, 69),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.Click += (s, e) => Application.Exit();

            rightPanel.Controls.AddRange(new Control[] {
                userNameLabel, roleLabel, notifBtn, avatarBtn, minimizeBtn, closeBtn
            });

            topPanel.Controls.AddRange(new Control[] { logoLabel, brandLabel, subtitleLabel, rightPanel });

            // Create profile dropdown
            CreateProfileDropdown(topPanel, rightPanel);

            // Add click handlers to hide dropdown when clicking elsewhere
            topPanel.Click += (s, e) => HideProfileDropdown();

            return topPanel;
        }

        private Panel CreateSidebarNavigation()
        {
            Panel sidebar = new Panel
            {
                Width = 260,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(33, 37, 41),
                AutoScroll = true
            };

            Label menuLabel = new Label
            {
                Text = "MAIN MENU",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(134, 142, 150),
                Location = new Point(25, 25),
                Size = new Size(210, 20)
            };
            sidebar.Controls.Add(menuLabel);

            var menuItems = new[]
            {
                new { Name = "btnDashboard", Icon = "📊", Text = "Dashboard" },
                new { Name = "btnNews", Icon = "📰", Text = "News" },
                new { Name = "btnOfficials", Icon = "🏛️", Text = "Officials" },
                new { Name = "btnSubmitRequest", Icon = "📝", Text = "Submit Request" },
                new { Name = "btnMyRequests", Icon = "📋", Text = "My Requests" },
                new { Name = "btnFileReport", Icon = "📊", Text = "File Report" },
                new { Name = "btnMyReports", Icon = "📈", Text = "My Reports" },
                new { Name = "btnPrinting", Icon = "🖨️", Text = "Print Documents" }  // ADD THIS

            };

            int yPos = 60;
            Panel firstMenuItem = null;

            foreach (var item in menuItems)
            {
                Panel menuItemPanel = CreateMenuItem(item.Icon, item.Text, item.Name, yPos);
                sidebar.Controls.Add(menuItemPanel);

                if (firstMenuItem == null)
                    firstMenuItem = menuItemPanel;

                yPos += 55;
            }

            Panel logoutPanel = new Panel
            {
                Size = new Size(260, 55),
                Location = new Point(0, Math.Max(yPos + 20, sidebar.Height - 75)),
                BackColor = Color.FromArgb(220, 53, 69),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            Label logoutIcon = new Label
            {
                Text = "🚪",
                Font = new Font("Segoe UI Emoji", 16F),
                Location = new Point(20, 17),
                Size = new Size(35, 25),
                BackColor = Color.Transparent
            };

            Label logoutText = new Label
            {
                Text = "Logout",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(60, 17),
                Size = new Size(150, 22),
                BackColor = Color.Transparent
            };

            logoutPanel.Controls.AddRange(new Control[] { logoutIcon, logoutText });
            logoutPanel.Click += (s, e) => Logout();
            logoutIcon.Click += (s, e) => Logout();
            logoutText.Click += (s, e) => Logout();

            logoutPanel.MouseEnter += (s, e) => logoutPanel.BackColor = Color.FromArgb(200, 35, 51);
            logoutPanel.MouseLeave += (s, e) => logoutPanel.BackColor = Color.FromArgb(220, 53, 69);

            sidebar.Controls.Add(logoutPanel);

            if (firstMenuItem != null)
                HighlightSelectedMenuItem(firstMenuItem);

            return sidebar;
        }

        private Panel CreateMenuItem(string icon, string text, string name, int yPos)
        {
            Panel menuItem = new Panel
            {
                Name = name,
                Size = new Size(260, 50),
                Location = new Point(0, yPos),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            Label iconLabel = new Label
            {
                Text = icon ?? "•",
                Font = new Font("Segoe UI Emoji", 16F),
                Location = new Point(20, 12),
                Size = new Size(35, 28),
                BackColor = Color.Transparent
            };

            Label textLabel = new Label
            {
                Text = text ?? "Menu Item",
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                ForeColor = Color.FromArgb(222, 226, 230),
                Location = new Point(60, 14),
                Size = new Size(180, 24),
                BackColor = Color.Transparent
            };

            menuItem.Controls.AddRange(new Control[] { iconLabel, textLabel });

            menuItem.MouseEnter += (s, e) => {
                if (menuItem != currentSelectedMenuItem)
                    menuItem.BackColor = Color.FromArgb(52, 58, 64);
            };

            menuItem.MouseLeave += (s, e) => {
                if (menuItem != currentSelectedMenuItem)
                    menuItem.BackColor = Color.Transparent;
            };

            menuItem.Click += MenuItem_Click;
            iconLabel.Click += MenuItem_Click;
            textLabel.Click += MenuItem_Click;

            return menuItem;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            HideProfileDropdown(); // Hide dropdown when navigating
            
            Control control = sender as Control;
            Panel menuPanel = control as Panel ?? control.Parent as Panel;

            if (menuPanel != null)
            {
                HighlightSelectedMenuItem(menuPanel);
                NavigateToSection(menuPanel.Name);
            }
        }

        private void HighlightSelectedMenuItem(Panel selectedPanel)
        {
            if (selectedPanel == null) return;

            if (sidebarPanel != null && sidebarPanel.Controls != null)
            {
                foreach (Control control in sidebarPanel.Controls)
                {
                    if (control is Panel panel && panel.Name != null && panel.Name.StartsWith("btn"))
                    {
                        panel.BackColor = Color.Transparent;
                        foreach (Control child in panel.Controls)
                        {
                            if (child is Label lbl && lbl.Text != null && lbl.Text.Length > 3)
                                lbl.ForeColor = Color.FromArgb(222, 226, 230);
                        }
                    }
                }
            }

            selectedPanel.BackColor = Color.FromArgb(0, 123, 255);
            foreach (Control child in selectedPanel.Controls)
            {
                if (child is Label lbl && lbl.Text != null && lbl.Text.Length > 3)
                    lbl.ForeColor = Color.White;
            }

            currentSelectedMenuItem = selectedPanel;
        }

        private void NavigateToSection(string sectionName)
        {
            contentPanel.Controls.Clear();

            switch (sectionName)
            {
                case "btnDashboard":
                    ShowDashboard();
                    break;
                case "btnNews":
                    ShowNews();
                    break;
                case "btnOfficials":
                    ShowOfficials();
                    break;
                case "btnSubmitRequest":
                    ShowSubmitRequest();
                    break;
                case "btnMyRequests":
                    ShowMyRequests();
                    break;
                case "btnFileReport":
                    ShowFileReport();
                    break;
                case "btnMyReports":
                    ShowMyReports();
                    break;
                case "btnPrinting":
                    ShowPrintingCenter();
                    break;
            }
        }

        private void ShowDashboard()
        {
            contentPanel.Controls.Clear();
            DashboardOverviewControl dashboard = new DashboardOverviewControl(currentUser);
            dashboard.NavigationRequested += Dashboard_NavigationRequested;
            contentPanel.Controls.Add(dashboard);
        }

        private void Dashboard_NavigationRequested(object sender, string section)
        {
            foreach (Control control in sidebarPanel.Controls)
            {
                if (control is Panel panel && panel.Name == $"btn{section}")
                {
                    HighlightSelectedMenuItem(panel);
                    NavigateToSection(panel.Name);
                    break;
                }
            }
        }

        private void ShowNews()
        {
            contentPanel.Controls.Clear();
            NewsControl newsControl = new NewsControl(currentUser);
            contentPanel.Controls.Add(newsControl);
        }

        private void ShowOfficials()
        {
            contentPanel.Controls.Clear();
            
            FlowLayoutPanel mainFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            Label title = new Label
            {
                Text = "🏛️ Barangay Officials Directory",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 20)
            };
            mainFlow.Controls.Add(title);

            FlowLayoutPanel officialsFlow = new FlowLayoutPanel
            {
                Width = Math.Min(contentPanel.Width - 60, 1200),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };

            try
            {
                var officials = EnhancedDatabaseHelper.GetAllOfficials(true);

                if (officials != null && officials.Any())
                {
                    foreach (var official in officials)
                    {
                        Panel officialCard = CreateOfficialCard(official);
                        officialsFlow.Controls.Add(officialCard);
                    }
                }
                else
                {
                    Label noOfficials = new Label
                    {
                        Text = "No officials information available.",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.FromArgb(108, 117, 125),
                        AutoSize = true
                    };
                    officialsFlow.Controls.Add(noOfficials);
                }
            }
            catch (Exception ex)
            {
                Label errorLabel = new Label
                {
                    Text = $"Error loading officials: {ex.Message}",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.FromArgb(220, 53, 69),
                    AutoSize = true
                };
                officialsFlow.Controls.Add(errorLabel);
            }

            mainFlow.Controls.Add(officialsFlow);
            contentPanel.Controls.Add(mainFlow);
        }

        private Panel CreateOfficialCard(BarangayOfficial official)
        {
            Panel card = new Panel
            {
                Size = new Size(350, 280),
                BackColor = Color.White,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            Panel avatar = new Panel
            {
                Size = new Size(80, 80),
                Location = new Point(135, 20),
                BackColor = Color.FromArgb(40, 167, 69)
            };
            avatar.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(avatar.BackColor))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, avatar.Width, avatar.Height);
                }
                using (Font font = new Font("Segoe UI", 32F, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    string initial = (official.FullName ?? "?").Substring(0, 1).ToUpper();
                    SizeF textSize = e.Graphics.MeasureString(initial, font);
                    e.Graphics.DrawString(initial, font, textBrush,
                        (avatar.Width - textSize.Width) / 2, (avatar.Height - textSize.Height) / 2);
                }
            };

            Label nameLabel = new Label
            {
                Text = official.FullName ?? "Unknown",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(20, 110),
                Size = new Size(310, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label positionLabel = new Label
            {
                Text = official.Position ?? "Position",
                Font = new Font("Segoe UI", 11F, FontStyle.Italic),
                ForeColor = Color.FromArgb(40, 167, 69),
                Location = new Point(20, 135),
                Size = new Size(310, 22),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label deptLabel = new Label
            {
                Text = official.Department ?? "Department",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(20, 160),
                Size = new Size(310, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label contactLabel = new Label
            {
                Text = $"📞 {official.ContactNumber ?? "N/A"}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(20, 190),
                Size = new Size(310, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label emailLabel = new Label
            {
                Text = $"📧 {official.Email ?? "N/A"}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(20, 210),
                Size = new Size(310, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button viewDetailsBtn = new Button
            {
                Text = "View Full Profile",
                Font = new Font("Segoe UI", 10F),
                Location = new Point(75, 240),
                Size = new Size(200, 30),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = official
            };
            viewDetailsBtn.FlatAppearance.BorderSize = 0;
            viewDetailsBtn.Click += ViewOfficialDetails_Click;

            card.Controls.AddRange(new Control[] {
                avatar, nameLabel, positionLabel, deptLabel, contactLabel, emailLabel, viewDetailsBtn
            });

            return card;
        }

        private void ViewOfficialDetails_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is BarangayOfficial official)
            {
                Form detailsForm = new Form
                {
                    Text = $"{official.FullName ?? "Official"} - Profile",
                    Size = new Size(600, 500),
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = Color.White
                };

                string details = $@"
OFFICIAL PROFILE

Name: {official.FullName ?? "N/A"}
Position: {official.Position ?? "N/A"}
Department: {official.Department ?? "N/A"}

Contact Information:
Phone: {official.ContactNumber ?? "N/A"}
Email: {official.Email ?? "N/A"}
Address: {official.Address ?? "N/A"}

Term Details:
Start Date: {official.StartDate:MMMM dd, yyyy}
Status: {(official.IsActive ? "Active" : "Inactive")}

Responsibilities:
{official.Responsibilities ?? "Not specified"}
                ";

                TextBox txtDetails = new TextBox
                {
                    Text = details,
                    Font = new Font("Consolas", 10F),
                    Location = new Point(30, 30),
                    Size = new Size(540, 380),
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Button closeBtn = new Button
                {
                    Text = "Close",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    Location = new Point(470, 420),
                    Size = new Size(100, 35),
                    BackColor = Color.FromArgb(108, 117, 125),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                closeBtn.FlatAppearance.BorderSize = 0;
                closeBtn.Click += (s, args) => detailsForm.Close();

                detailsForm.Controls.AddRange(new Control[] { txtDetails, closeBtn });
                detailsForm.ShowDialog();
            }
        }

        private void ShowSubmitRequest()
        {
            contentPanel.Controls.Clear();

            FlowLayoutPanel mainFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            Label title = new Label
            {
                Text = "📝 Submit Document Request",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 20)
            };
            mainFlow.Controls.Add(title);

            Panel formPanel = new Panel
            {
                Width = Math.Min(contentPanel.Width - 40, 800),
                Height = 500,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 20)
            };

            Label lblType = new Label
            {
                Text = "Request Type *",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(30, 30),
                AutoSize = true
            };

            ComboBox cmbRequestType = new ComboBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(30, 57),
                Size = new Size(Math.Min(formPanel.Width - 60, 640), 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Name = "cmbRequestType"
            };
            cmbRequestType.Items.AddRange(new string[] {
                "Barangay Clearance",
                "Certificate of Residency",
                "Certificate of Indigency",
                "Business Permit",
                "Barangay ID",
                "Other Documents"
            });

            Label lblPurpose = new Label
            {
                Text = "Purpose *",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(30, 110),
                AutoSize = true
            };

            TextBox txtPurpose = new TextBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(30, 137),
                Size = new Size(Math.Min(formPanel.Width - 60, 640), 30),
                BorderStyle = BorderStyle.FixedSingle,
                Name = "txtPurpose"
            };

            Label lblDescription = new Label
            {
                Text = "Additional Details",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(30, 190),
                AutoSize = true
            };

            TextBox txtDescription = new TextBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(30, 217),
                Size = new Size(Math.Min(formPanel.Width - 60, 640), 100),
                BorderStyle = BorderStyle.FixedSingle,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Name = "txtDescription"
            };

            Label lblFeeInfo = new Label
            {
                Text = "💰 Processing Fee: ₱50.00",
                Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = Color.FromArgb(40, 167, 69),
                Location = new Point(30, 335),
                AutoSize = true,
                Name = "lblFeeInfo"
            };

            cmbRequestType.SelectedIndexChanged += (s, e) => {
                try
                {
                    var settings = EnhancedDatabaseHelper.GetSystemSettings();
                    if (settings != null && settings.ServiceFees != null && settings.ServiceFees.ContainsKey(cmbRequestType.Text))
                    {
                        lblFeeInfo.Text = $"💰 Processing Fee: ₱{settings.ServiceFees[cmbRequestType.Text]:N2}";
                    }
                }
                catch { }
            };

            Button btnSubmit = new Button
            {
                Text = "✅ Submit Request",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(30, 380),
                Size = new Size(300, 45),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = formPanel
            };
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Click += SubmitRequest_Click;

            Button btnClear = new Button
            {
                Text = "Clear Form",
                Font = new Font("Segoe UI", 11F),
                Location = new Point(350, 380),
                Size = new Size(150, 45),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = formPanel
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += ClearRequestForm_Click;

            formPanel.Controls.AddRange(new Control[] {
                lblType, cmbRequestType, lblPurpose, txtPurpose,
                lblDescription, txtDescription, lblFeeInfo, btnSubmit, btnClear
            });

            mainFlow.Controls.Add(formPanel);
            contentPanel.Controls.Add(mainFlow);
        }

        private void SubmitRequest_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Panel formPanel)
            {
                ComboBox cmbRequestType = formPanel.Controls.Find("cmbRequestType", false).FirstOrDefault() as ComboBox;
                TextBox txtPurpose = formPanel.Controls.Find("txtPurpose", false).FirstOrDefault() as TextBox;
                TextBox txtDescription = formPanel.Controls.Find("txtDescription", false).FirstOrDefault() as TextBox;

                if (cmbRequestType == null || txtPurpose == null || txtDescription == null)
                    return;

                if (cmbRequestType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a request type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPurpose.Text))
                {
                    MessageBox.Show("Please enter the purpose of your request.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var request = new Request
                {
                    UserId = currentUser.Id,
                    RequestType = cmbRequestType.Text,
                    Description = $"Purpose: {txtPurpose.Text}\n\nDetails: {txtDescription.Text}"
                };

                if (DatabaseHelper.CreateRequest(request))
                {
                    EnhancedDatabaseHelper.CreateNotification(new Notification
                    {
                        UserId = currentUser.Id,
                        Title = "Request Submitted",
                        Message = $"Your {request.RequestType} request has been submitted successfully.",
                        Type = "Success",
                        Category = "Request",
                        CreatedBy = currentUser.Id
                    });

                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Submit Request", "Requests",
                        $"Submitted {cmbRequestType.Text} request");

                    MessageBox.Show("Request submitted successfully! You will be notified once processed.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowMyRequests();
                }
            }
        }

        private void ClearRequestForm_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Panel formPanel)
            {
                ComboBox cmbRequestType = formPanel.Controls.Find("cmbRequestType", false).FirstOrDefault() as ComboBox;
                TextBox txtPurpose = formPanel.Controls.Find("txtPurpose", false).FirstOrDefault() as TextBox;
                TextBox txtDescription = formPanel.Controls.Find("txtDescription", false).FirstOrDefault() as TextBox;

                if (cmbRequestType != null) cmbRequestType.SelectedIndex = -1;
                if (txtPurpose != null) txtPurpose.Clear();
                if (txtDescription != null) txtDescription.Clear();
            }
        }

        private void ShowMyRequests()
        {
            contentPanel.Controls.Clear();

            FlowLayoutPanel mainFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            Label title = new Label
            {
                Text = "📋 My Document Requests",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 20)
            };
            mainFlow.Controls.Add(title);

            Panel filterPanel = new Panel
            {
                Width = Math.Min(contentPanel.Width - 40, 1200),
                Height = 50,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 10)
            };

            Label lblFilter = new Label
            {
                Text = "Filter:",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };

            ComboBox cmbFilter = new ComboBox
            {
                Font = new Font("Segoe UI", 10F),
                Location = new Point(80, 12),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Name = "cmbFilter"
            };
            cmbFilter.Items.AddRange(new string[] { "All", "Pending", "Approved", "Rejected", "Processing" });
            cmbFilter.SelectedIndex = 0;

            filterPanel.Controls.AddRange(new Control[] { lblFilter, cmbFilter });
            mainFlow.Controls.Add(filterPanel);

            DataGridView dgvRequests = new DataGridView
            {
                Width = Math.Min(contentPanel.Width - 40, 1200),
                Height = Math.Max(contentPanel.Height - 250, 300),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 10F),
                ColumnHeadersHeight = 40,
                Name = "dgvRequests"
            };
            dgvRequests.RowTemplate.Height = 35;

            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 167, 69);
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            LoadMyRequests(dgvRequests);

            cmbFilter.SelectedIndexChanged += (s, e) => LoadMyRequests(dgvRequests, cmbFilter.Text);

            mainFlow.Controls.Add(dgvRequests);

            Button btnViewDetails = new Button
            {
                Text = "👁️ View Details",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 10, 0, 0),
                Tag = dgvRequests
            };
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.Click += ViewRequestDetails_Click;
            mainFlow.Controls.Add(btnViewDetails);

            contentPanel.Controls.Add(mainFlow);
        }

        private void LoadMyRequests(DataGridView dgv, string filter = "All")
        {
            try
            {
                var requests = DatabaseHelper.GetUserRequests(currentUser.Id);

                if (filter != "All")
                    requests = requests.Where(r => r.Status == filter).ToList();

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Request Type", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Date Submitted", typeof(DateTime));
                dataTable.Columns.Add("Date Processed", typeof(string));

                foreach (var request in requests)
                {
                    dataTable.Rows.Add(
                        request.Id,
                        request.RequestType,
                        request.Status,
                        request.CreatedDate,
                        request.ProcessedDate.HasValue ? request.ProcessedDate.Value.ToString("MMM dd, yyyy") : "Pending"
                    );
                }

                dgv.DataSource = dataTable;

                if (dgv.Columns["Id"] != null)
                    dgv.Columns["Id"].Visible = false;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    switch (status)
                    {
                        case "Pending":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                            break;
                        case "Approved":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 218);
                            break;
                        case "Rejected":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(248, 215, 218);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading requests: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewRequestDetails_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is DataGridView dgv && dgv.SelectedRows.Count > 0)
            {
                int requestId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                var requests = DatabaseHelper.GetUserRequests(currentUser.Id);
                var request = requests.FirstOrDefault(r => r.Id == requestId);

                if (request != null)
                {
                    Form detailsForm = new Form
                    {
                        Text = "Request Details",
                        Size = new Size(600, 400),
                        StartPosition = FormStartPosition.CenterScreen,
                        BackColor = Color.White
                    };

                    string details = $@"
REQUEST DETAILS

Request ID: #{request.Id}
Type: {request.RequestType}
Status: {request.Status}

Date Submitted: {request.CreatedDate:MMMM dd, yyyy HH:mm}
{(request.ProcessedDate.HasValue ? $"Date Processed: {request.ProcessedDate:MMMM dd, yyyy HH:mm}" : "")}

Description:
{request.Description}

{(request.Status == "Approved" ? "✅ Your request has been approved. You may claim your document at the barangay office." : "")}
{(request.Status == "Rejected" ? "❌ Your request has been rejected. Please contact the barangay office for more information." : "")}
                    ";

                    TextBox txtDetails = new TextBox
                    {
                        Text = details,
                        Font = new Font("Consolas", 10F),
                        Location = new Point(30, 30),
                        Size = new Size(540, 280),
                        Multiline = true,
                        ReadOnly = true,
                        ScrollBars = ScrollBars.Vertical,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    Button closeBtn = new Button
                    {
                        Text = "Close",
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        Location = new Point(470, 320),
                        Size = new Size(100, 35),
                        BackColor = Color.FromArgb(108, 117, 125),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand
                    };
                    closeBtn.FlatAppearance.BorderSize = 0;
                    closeBtn.Click += (s, args) => detailsForm.Close();

                    detailsForm.Controls.AddRange(new Control[] { txtDetails, closeBtn });
                    detailsForm.ShowDialog();
                }
            }
        }

        private void ShowFileReport()
        {
            contentPanel.Controls.Clear();

            FlowLayoutPanel mainFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            Label title = new Label
            {
                Text = "📊 File a Report/Complaint",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 20)
            };
            mainFlow.Controls.Add(title);

            Panel formPanel = new Panel
            {
                Width = Math.Min(contentPanel.Width - 40, 800),
                Height = 500,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 20)
            };

            Label lblType = new Label
            {
                Text = "Report Type *",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(30, 30),
                AutoSize = true
            };

            ComboBox cmbReportType = new ComboBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(30, 57),
                Size = new Size(Math.Min(formPanel.Width - 60, 640), 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Name = "cmbReportType"
            };
            cmbReportType.Items.AddRange(new string[] {
                "Noise Complaint",
                "Illegal Parking",
                "Garbage Issues",
                "Street Light Problem",
                "Road Damage",
                "Water/Drainage Issue",
                "Security Concern",
                "Other Issues"
            });

            Label lblSubject = new Label
            {
                Text = "Subject *",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(30, 110),
                AutoSize = true
            };

            TextBox txtSubject = new TextBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(30, 137),
                Size = new Size(Math.Min(formPanel.Width - 60, 640), 30),
                BorderStyle = BorderStyle.FixedSingle,
                Name = "txtSubject"
            };

            Label lblDescription = new Label
            {
                Text = "Detailed Description *",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(30, 190),
                AutoSize = true
            };

            TextBox txtDescription = new TextBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(30, 217),
                Size = new Size(Math.Min(formPanel.Width - 60, 640), 150),
                BorderStyle = BorderStyle.FixedSingle,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Name = "txtDescription"
            };

            Button btnSubmit = new Button
            {
                Text = "📤 Submit Report",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(30, 390),
                Size = new Size(300, 45),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = formPanel
            };
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Click += SubmitReport_Click;

            Button btnClear = new Button
            {
                Text = "Clear Form",
                Font = new Font("Segoe UI", 11F),
                Location = new Point(350, 390),
                Size = new Size(150, 45),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = formPanel
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += ClearReportForm_Click;

            formPanel.Controls.AddRange(new Control[] {
                lblType, cmbReportType, lblSubject, txtSubject,
                lblDescription, txtDescription, btnSubmit, btnClear
            });

            mainFlow.Controls.Add(formPanel);
            contentPanel.Controls.Add(mainFlow);
        }

        private void SubmitReport_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Panel formPanel)
            {
                ComboBox cmbReportType = formPanel.Controls.Find("cmbReportType", false).FirstOrDefault() as ComboBox;
                TextBox txtSubject = formPanel.Controls.Find("txtSubject", false).FirstOrDefault() as TextBox;
                TextBox txtDescription = formPanel.Controls.Find("txtDescription", false).FirstOrDefault() as TextBox;

                if (cmbReportType == null || txtSubject == null || txtDescription == null)
                    return;

                if (cmbReportType.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtSubject.Text) ||
                    string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var report = new Report
                {
                    UserId = currentUser.Id,
                    ReportType = cmbReportType.Text,
                    Subject = txtSubject.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                if (DatabaseHelper.CreateReport(report))
                {
                    EnhancedDatabaseHelper.CreateNotification(new Notification
                    {
                        UserId = currentUser.Id,
                        Title = "Report Submitted",
                        Message = $"Your report about '{report.Subject}' has been submitted.",
                        Type = "Info",
                        Category = "Report",
                        CreatedBy = currentUser.Id
                    });

                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "File Report", "Reports",
                        $"Filed {cmbReportType.Text} report");

                    MessageBox.Show("Report submitted successfully! The barangay will review your concern.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowMyReports();
                }
            }
        }

        private void ClearReportForm_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Panel formPanel)
            {
                ComboBox cmbReportType = formPanel.Controls.Find("cmbReportType", false).FirstOrDefault() as ComboBox;
                TextBox txtSubject = formPanel.Controls.Find("txtSubject", false).FirstOrDefault() as TextBox;
                TextBox txtDescription = formPanel.Controls.Find("txtDescription", false).FirstOrDefault() as TextBox;

                if (cmbReportType != null) cmbReportType.SelectedIndex = -1;
                if (txtSubject != null) txtSubject.Clear();
                if (txtDescription != null) txtDescription.Clear();
            }
        }

        private void ShowMyReports()
        {
            contentPanel.Controls.Clear();

            FlowLayoutPanel mainFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            Label title = new Label
            {
                Text = "📈 My Reports & Complaints",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 20)
            };
            mainFlow.Controls.Add(title);

            DataGridView dgvReports = new DataGridView
            {
                Width = Math.Min(contentPanel.Width - 40, 1200),
                Height = Math.Max(contentPanel.Height - 150, 300),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 10F),
                ColumnHeadersHeight = 40
            };
            dgvReports.RowTemplate.Height = 35;

            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 53, 69);
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvReports.EnableHeadersVisualStyles = false;
            dgvReports.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            LoadMyReports(dgvReports);

            mainFlow.Controls.Add(dgvReports);
            contentPanel.Controls.Add(mainFlow);
        }

        private void LoadMyReports(DataGridView dgv)
        {
            try
            {
                var reports = DatabaseHelper.GetUserReports(currentUser.Id);

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Type", typeof(string));
                dataTable.Columns.Add("Subject", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Date Filed", typeof(DateTime));
                dataTable.Columns.Add("Date Resolved", typeof(string));

                foreach (var report in reports)
                {
                    dataTable.Rows.Add(
                        report.Id,
                        report.ReportType,
                        report.Subject,
                        report.Status,
                        report.CreatedDate,
                        report.ResolvedDate.HasValue ? report.ResolvedDate.Value.ToString("MMM dd, yyyy") : "Pending"
                    );
                }

                dgv.DataSource = dataTable;

                if (dgv.Columns["Id"] != null)
                    dgv.Columns["Id"].Visible = false;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (status == "Resolved")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 218);
                    else
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowProfile()
        {
            contentPanel.Controls.Clear();

            FlowLayoutPanel mainFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            Label title = new Label
            {
                Text = "👤 My Profile",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 20)
            };
            mainFlow.Controls.Add(title);

            Panel profilePanel = new Panel
            {
                Width = Math.Min(contentPanel.Width - 40, 800),
                Height = 450,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 20)
            };

            Panel avatar = new Panel
            {
                Size = new Size(120, 120),
                Location = new Point((profilePanel.Width - 120) / 2, 30),
                BackColor = Color.FromArgb(0, 123, 255)
            };
            avatar.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(avatar.BackColor))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, avatar.Width, avatar.Height);
                }
                using (Font font = new Font("Segoe UI", 48F, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    string initial = currentUser.FullName.Substring(0, 1).ToUpper();
                    SizeF textSize = e.Graphics.MeasureString(initial, font);
                    e.Graphics.DrawString(initial, font, textBrush,
                        (avatar.Width - textSize.Width) / 2, (avatar.Height - textSize.Height) / 2);
                }
            };

            int yPos = 170;
            CreateProfileField(profilePanel, "Full Name:", currentUser.FullName, yPos);
            yPos += 45;
            CreateProfileField(profilePanel, "Username:", currentUser.Username, yPos);
            yPos += 45;
            CreateProfileField(profilePanel, "Email:", currentUser.Email ?? "Not provided", yPos);
            yPos += 45;
            CreateProfileField(profilePanel, "Contact:", currentUser.ContactNumber ?? "Not provided", yPos);
            yPos += 45;
            CreateProfileField(profilePanel, "Address:", currentUser.Address ?? "Not provided", yPos);
            yPos += 45;
            CreateProfileField(profilePanel, "Member Since:", currentUser.CreatedDate.ToString("MMMM dd, yyyy"), yPos);

            profilePanel.Controls.Add(avatar);
            mainFlow.Controls.Add(profilePanel);
            contentPanel.Controls.Add(mainFlow);
        }

        private void CreateProfileField(Panel parent, string label, string value, int yPos)
        {
            Label lblLabel = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(100, yPos),
                Size = new Size(150, 22),
                TextAlign = ContentAlignment.MiddleRight
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(270, yPos),
                Size = new Size(parent.Width - 320, 22),
                AutoEllipsis = true
            };

            parent.Controls.AddRange(new Control[] { lblLabel, lblValue });
        }

        private void UpdateNotificationBadge()
        {
            if (notificationPanel != null)
            {
                notificationPanel = new NotificationPanel(currentUser);
            }
        }

        private void Logout()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Logout", "Dashboard", "User logged out");

                if (notificationRefreshTimer != null)
                {
                    notificationRefreshTimer.Stop();
                    notificationRefreshTimer.Dispose();
                }

                this.Close();
                new LoginForm().Show();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (notificationRefreshTimer != null)
            {
                notificationRefreshTimer.Stop();
                notificationRefreshTimer.Dispose();
            }
        }

        private void CreateProfileDropdown(Panel topPanel, Panel rightPanel)
        {
            profileDropdown = new Panel
            {
                Size = new Size(220, 130),
                BackColor = Color.White,
                Visible = false
            };

            // Position it below the avatar button
            profileDropdown.Location = new Point(this.Width - 390, 70);

            // Add shadow border
            profileDropdown.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, profileDropdown.ClientRectangle,
                    Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid);
            };

            // User info header
            Panel headerPanel = new Panel
            {
                Size = new Size(220, 55),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(248, 249, 250)
            };

            Label nameLabel = new Label
            {
                Text = currentUser.FullName,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(15, 10),
                Size = new Size(190, 20),
                AutoEllipsis = true
            };

            Label roleText = new Label
            {
                Text = "Resident",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(15, 30),
                AutoSize = true
            };

            headerPanel.Controls.AddRange(new Control[] { nameLabel, roleText });

            // My Profile button
            Button profileBtn = new Button
            {
                Text = "👤  My Profile",
                Size = new Size(220, 37),
                Location = new Point(0, 55),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(33, 37, 41),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            profileBtn.FlatAppearance.BorderSize = 0;
            profileBtn.Click += (s, e) => {
                HideProfileDropdown();
                ShowProfile();
                HighlightMenuItemByName("btnProfile");
            };
            profileBtn.MouseEnter += (s, e) => profileBtn.BackColor = Color.FromArgb(240, 240, 240);
            profileBtn.MouseLeave += (s, e) => profileBtn.BackColor = Color.White;

            // Logout button
            Button logoutBtn = new Button
            {
                Text = "🚪  Logout",
                Size = new Size(220, 38),
                Location = new Point(0, 92),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(220, 53, 69),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            logoutBtn.FlatAppearance.BorderSize = 0;
            logoutBtn.Click += (s, e) => {
                HideProfileDropdown();
                Logout();
            };
            logoutBtn.MouseEnter += (s, e) => logoutBtn.BackColor = Color.FromArgb(255, 230, 230);
            logoutBtn.MouseLeave += (s, e) => logoutBtn.BackColor = Color.White;

            profileDropdown.Controls.AddRange(new Control[] { headerPanel, profileBtn, logoutBtn });
            topPanel.Controls.Add(profileDropdown);
            profileDropdown.BringToFront();
        }

        private void AvatarBtn_Click(object sender, EventArgs e)
        {
            if (isProfileDropdownVisible)
            {
                HideProfileDropdown();
            }
            else
            {
                ShowProfileDropdown();
            }
        }

        private void ShowProfileDropdown()
        {
            if (profileDropdown != null)
            {
                // Update position in case window was resized
                profileDropdown.Location = new Point(this.Width - 390, 70);
                profileDropdown.Visible = true;
                profileDropdown.BringToFront();
                isProfileDropdownVisible = true;
            }
        }

        private void HideProfileDropdown()
        {
            if (profileDropdown != null && isProfileDropdownVisible)
            {
                profileDropdown.Visible = false;
                isProfileDropdownVisible = false;
            }
        }

        private void HighlightMenuItemByName(string menuName)
        {
            foreach (Control control in sidebarPanel.Controls)
            {
                if (control is Panel panel && panel.Name == menuName)
                {
                    HighlightSelectedMenuItem(panel);
                    break;
                }
            }
        }
        private void ShowPrintingCenter()
        {
            contentPanel.Controls.Clear();
            PrintingCenter printingCenter = new PrintingCenter(currentUser, contentPanel);
            printingCenter.ShowPrintingCenter();
        }
    }
}