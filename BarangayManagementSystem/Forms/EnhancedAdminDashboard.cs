using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;
using BarangayManagementSystem.Controls; // Add this line at the top

namespace BarangayManagementSystem.Forms
{
    public partial class EnhancedAdminDashboard : Form
    {
        private User currentUser;
        private Panel contentPanel;
        private Panel sidebarPanel;
        private NotificationPanel notificationPanel;
        private Panel currentSelectedMenuItem;

        public EnhancedAdminDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            CreateModernLayout();
            ShowDashboardContent();
            
            EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Login", "Dashboard", "Admin logged in");
        }

        private void CreateModernLayout()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);

            // Modern Top Navigation Bar
            Panel topPanel = new Panel
            {
                Height = 70,
                Dock = DockStyle.Top,
                BackColor = Color.White
            };

            topPanel.Paint += (s, e) => {
                using (Pen pen = new Pen(Color.FromArgb(222, 226, 230), 1))
                {
                    e.Graphics.DrawLine(pen, 0, topPanel.Height - 1, topPanel.Width, topPanel.Height - 1);
                }
            };

            // Brand Section
            Label logoLabel = new Label
            {
                Text = "🏛️",
                Font = new Font("Segoe UI Emoji", 28F),
                Location = new Point(20, 15),
                Size = new Size(50, 40)
            };

            Label brandLabel = new Label
            {
                Text = "BARANGAY ADMIN",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(75, 18),
                AutoSize = true
            };

            Label versionLabel = new Label
            {
                Text = "Dashboard v2.0",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(75, 40),
                AutoSize = true
            };

            // Right Side Controls Container
            Panel rightPanel = new Panel
            {
                AutoSize = false,
                BackColor = Color.Transparent
            };

            Label userNameLabel = new Label
            {
                Text = currentUser.FullName,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleRight
            };

            Label roleLabel = new Label
            {
                Text = "Administrator",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(108, 117, 125),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleRight
            };

            // Notification Bell
            notificationPanel = new NotificationPanel(currentUser);
            Button notifBtn = new Button
            {
                Text = "🔔",
                Size = new Size(45, 45),
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(108, 117, 125),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Emoji", 16F),
                Cursor = Cursors.Hand
            };
            notifBtn.FlatAppearance.BorderSize = 0;
            notifBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 249, 250);
            notifBtn.Click += (s, e) => {
                var panel = new NotificationPanel(currentUser);
                panel.CreateNotificationButton().PerformClick();
            };

            // User Avatar
            Button avatarBtn = new Button
            {
                Text = currentUser.FullName.Substring(0, 1).ToUpper(),
                Size = new Size(45, 45),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
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

            // Window Controls
            Button minimizeBtn = new Button
            {
                Text = "─",
                Size = new Size(40, 40),
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(108, 117, 125),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 249, 250);
            minimizeBtn.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            Button closeBtn = new Button
            {
                Text = "✕",
                Size = new Size(40, 40),
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(220, 53, 69),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 240, 242);
            closeBtn.Click += CloseBtn_Click;

            // Position controls on resize
            this.Resize += (s, e) => {
                rightPanel.Location = new Point(this.Width - 360, 5);
                userNameLabel.Location = new Point(0, 15);
                roleLabel.Location = new Point(0, 35);
                notifBtn.Location = new Point(userNameLabel.Right + 20, 10);
                avatarBtn.Location = new Point(notifBtn.Right + 10, 10);
                minimizeBtn.Location = new Point(avatarBtn.Right + 10, 12);
                closeBtn.Location = new Point(minimizeBtn.Right + 5, 12);
            };

            rightPanel.Controls.AddRange(new Control[] { 
                userNameLabel, roleLabel, notifBtn, avatarBtn, minimizeBtn, closeBtn 
            });

            topPanel.Controls.AddRange(new Control[] { logoLabel, brandLabel, versionLabel, rightPanel });

            // Modern Sidebar
            sidebarPanel = new Panel
            {
                Width = 260,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(33, 37, 41)
            };

            CreateModernSidebarButtons();

            // Content Panel
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 242, 245),
                AutoScroll = true,
                Padding = new Padding(30, 20, 30, 20)
            };

            this.Controls.Add(contentPanel);
            this.Controls.Add(sidebarPanel);
            this.Controls.Add(topPanel);

            // Trigger initial resize
            this.PerformLayout();
        }

        private void CreateModernSidebarButtons()
        {
            Label menuLabel = new Label
            {
                Text = "MAIN MENU",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(134, 142, 150),
                Location = new Point(25, 25),
                Size = new Size(210, 20)
            };
            sidebarPanel.Controls.Add(menuLabel);

            var menuItems = new[]
            {
                new { Name = "btnDashboard", Icon = "📊", Text = "Dashboard", Action = new Action(ShowDashboardContent) },
                new { Name = "btnResidents", Icon = "👥", Text = "Residents", Action = new Action(ShowResidentManagement) },
                new { Name = "btnOfficials", Icon = "🏛️", Text = "Officials", Action = new Action(() => ShowOfficialsManagement()) },
                new { Name = "btnRequests", Icon = "📋", Text = "Requests", Action = new Action(ShowRequestsManagement) },
                new { Name = "btnReports", Icon = "📊", Text = "Reports", Action = new Action(ShowReportsManagement) },
                new { Name = "btnBlotter", Icon = "📝", Text = "Blotter", Action = new Action(ShowBlotterManagement) },
                new { Name = "btnNews", Icon = "📰", Text = "News", Action = new Action(() => ShowNewsManagement()) },
                new { Name = "btnPrinting", Icon = "🖨️", Text = "Print Docs", Action = new Action(ShowPrintingCenter) },
                new { Name = "btnSettings", Icon = "⚙️", Text = "Settings", Action = new Action(ShowSettings) }
            };

            int yPos = 60;
            foreach (var item in menuItems)
            {
                Panel menuItemPanel = CreateMenuItem(item.Icon, item.Text, item.Name, yPos, item.Action);
                sidebarPanel.Controls.Add(menuItemPanel);
                yPos += 55;
            }

            // Logout Button
            Panel logoutPanel = new Panel
            {
                Size = new Size(250, 55),
                Location = new Point(5, sidebarPanel.Height - 75),
                BackColor = Color.FromArgb(220, 53, 69),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
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

            sidebarPanel.Controls.Add(logoutPanel);

            // Highlight first item
            if (sidebarPanel.Controls.Count > 1)
            {
                foreach (Control ctrl in sidebarPanel.Controls)
                {
                    if (ctrl is Panel panel && panel.Name == "btnDashboard")
                    {
                        HighlightSelectedMenuItem(panel);
                        break;
                    }
                }
            }
        }

        private Panel CreateMenuItem(string icon, string text, string name, int yPos, Action action)
        {
            Panel menuItem = new Panel
            {
                Name = name,
                Size = new Size(250, 50),
                Location = new Point(5, yPos),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Tag = action
            };

            Label iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 16F),
                Location = new Point(20, 12),
                Size = new Size(35, 28),
                BackColor = Color.Transparent
            };

            Label textLabel = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                ForeColor = Color.FromArgb(222, 226, 230),
                Location = new Point(60, 14),
                Size = new Size(170, 24),
                BackColor = Color.Transparent
            };

            menuItem.Controls.AddRange(new Control[] { iconLabel, textLabel });

            // Hover effects
            menuItem.MouseEnter += (s, e) => {
                if (menuItem != currentSelectedMenuItem)
                    menuItem.BackColor = Color.FromArgb(52, 58, 64);
            };

            menuItem.MouseLeave += (s, e) => {
                if (menuItem != currentSelectedMenuItem)
                    menuItem.BackColor = Color.Transparent;
            };

            // Click handlers
            menuItem.Click += (s, e) => {
                HighlightSelectedMenuItem(menuItem);
                action.Invoke();
            };

            iconLabel.Click += (s, e) => {
                HighlightSelectedMenuItem(menuItem);
                action.Invoke();
            };
            textLabel.Click += (s, e) => {
                HighlightSelectedMenuItem(menuItem);
                action.Invoke();
            };

            return menuItem;
        }

        private void HighlightSelectedMenuItem(Panel selectedPanel)
        {
            foreach (Control control in sidebarPanel.Controls)
            {
                if (control is Panel panel && panel.Tag is Action)
                {
                    panel.BackColor = Color.Transparent;
                    foreach (Control child in panel.Controls)
                    {
                        if (child is Label lbl && lbl.Text.Length > 3)
                            lbl.ForeColor = Color.FromArgb(222, 226, 230);
                    }
                }
            }

            selectedPanel.BackColor = Color.FromArgb(0, 123, 255);
            foreach (Control child in selectedPanel.Controls)
            {
                if (child is Label lbl && lbl.Text.Length > 3)
                    lbl.ForeColor = Color.White;
            }
            currentSelectedMenuItem = selectedPanel;
        }

        #region Modern Dashboard Content

        private void ShowDashboardContent()
        {
            contentPanel.Controls.Clear();

            // Page Header
            Label pageTitle = new Label
            {
                Text = "Dashboard Overview",
                Font = new Font("Segoe UI", 26F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(0, 0),
                AutoSize = true
            };

            Label pageSubtitle = new Label
            {
                Text = $"Welcome back, {currentUser.FullName}! Here's what's happening today.",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(0, 40),
                Size = new Size(700, 30)
            };

            // Stats Cards Container
            FlowLayoutPanel statsFlow = new FlowLayoutPanel
            {
                Location = new Point(0, 90),
                Size = new Size(contentPanel.Width - 60, 150),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            var stats = new[]
            {
                new { Title = "Total Residents", Value = DatabaseHelper.GetUserCount().ToString(), Icon = "👥", Color = Color.FromArgb(0, 123, 255), Trend = "+12%" },
                new { Title = "Pending Requests", Value = DatabaseHelper.GetPendingRequestsCount().ToString(), Icon = "📋", Color = Color.FromArgb(255, 193, 7), Trend = "+5" },
                new { Title = "Open Reports", Value = DatabaseHelper.GetOpenReportsCount().ToString(), Icon = "📊", Color = Color.FromArgb(220, 53, 69), Trend = "-2" },
                new { Title = "Active Officials", Value = EnhancedDatabaseHelper.GetAllOfficials(true).Count.ToString(), Icon = "🏛️", Color = Color.FromArgb(40, 167, 69), Trend = "0" },
                new { Title = "News Published", Value = EnhancedDatabaseHelper.GetPublishedNews().Count.ToString(), Icon = "📰", Color = Color.FromArgb(111, 66, 193), Trend = "+3" }
            };

            int cardWidth = (contentPanel.Width - 120) / 5;
            foreach (var stat in stats)
            {
                Panel card = CreateModernStatCard(stat.Title, stat.Value, stat.Icon, stat.Color, stat.Trend, cardWidth);
                statsFlow.Controls.Add(card);
            }

            // Content Grid
            Panel contentGrid = new Panel
            {
                Location = new Point(0, 260),
                Size = new Size(contentPanel.Width - 60, 450),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            int halfWidth = (contentPanel.Width - 80) / 2;

            // Recent Activities
            Panel activitiesCard = CreateModernCard("Recent Activities", "📊", 0, 0, halfWidth, 430);
            ListBox activitiesList = new ListBox
            {
                Location = new Point(25, 70),
                Size = new Size(halfWidth - 50, 340),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                ItemHeight = 40
            };
            activitiesList.DrawMode = DrawMode.OwnerDrawFixed;
            activitiesList.DrawItem += (s, e) => {
                if (e.Index < 0) return;
                e.DrawBackground();
                using (Brush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(activitiesList.Items[e.Index].ToString(), 
                        e.Font, brush, e.Bounds.Left + 10, e.Bounds.Top + 10);
                }
            };
            LoadRecentActivities(activitiesList);
            activitiesCard.Controls.Add(activitiesList);

            // Quick Actions
            Panel actionsCard = CreateModernCard("Quick Actions", "⚡", halfWidth + 20, 0, halfWidth, 430);
            var actions = new[]
            {
                new { Text = "Add New Resident", Icon = "👤", Color = Color.FromArgb(0, 123, 255), Action = new Action(ShowResidentRegistration) },
                new { Text = "Create Announcement", Icon = "📢", Color = Color.FromArgb(255, 193, 7), Action = new Action(() => ShowNewsManagement(true)) },
                new { Text = "Add Official", Icon = "🏛️", Color = Color.FromArgb(40, 167, 69), Action = new Action(() => ShowOfficialsManagement(true)) },
                new { Text = "Print Certificate", Icon = "🖨️", Color = Color.FromArgb(111, 66, 193), Action = new Action(ShowPrintingCenter) }
            };

            int btnY = 75;
            foreach (var action in actions)
            {
                Button actionBtn = CreateModernActionButton(action.Text, action.Icon, action.Color);
                actionBtn.Location = new Point(25, btnY);
                actionBtn.Size = new Size(halfWidth - 50, 65);
                actionBtn.Click += (s, e) => action.Action.Invoke();
                actionsCard.Controls.Add(actionBtn);
                btnY += 80;
            }

            contentGrid.Controls.AddRange(new Control[] { activitiesCard, actionsCard });

            contentPanel.Controls.AddRange(new Control[] { pageTitle, pageSubtitle, statsFlow, contentGrid });
        }

        private Panel CreateModernStatCard(string title, string value, string icon, Color color, string trend, int width)
        {
            Panel card = new Panel
            {
                Size = new Size(width - 15, 130),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 15, 0)
            };

            card.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(233, 236, 239), 2))
                {
                    Rectangle rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };

            Label iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 30F),
                Location = new Point(20, 20),
                Size = new Size(55, 50),
                BackColor = Color.Transparent
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(85, 15),
                AutoSize = true
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(134, 142, 150),
                Location = new Point(20, 80),
                Size = new Size(width - 40, 22)
            };

            Label trendLabel = new Label
            {
                Text = trend,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = trend.StartsWith("+") ? Color.FromArgb(40, 167, 69) : 
                           trend.StartsWith("-") ? Color.FromArgb(220, 53, 69) : Color.FromArgb(108, 117, 125),
                Location = new Point(20, 100),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] { iconLabel, valueLabel, titleLabel, trendLabel });
            return card;
        }

        private Panel CreateModernCard(string title, string icon, int x, int y, int width, int height)
        {
            Panel card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Color.White
            };

            card.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(233, 236, 239), 2))
                {
                    Rectangle rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };

            Label iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 16F),
                Location = new Point(25, 22),
                Size = new Size(30, 25),
                BackColor = Color.Transparent
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(60, 20),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] { iconLabel, titleLabel });
            return card;
        }

        private Button CreateModernActionButton(string text, string icon, Color color)
        {
            Button btn = new Button
            {
                Text = $"{icon}  {text}",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(25, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => {
                btn.BackColor = ControlPaint.Dark(color, 0.05f);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = color;
            };

            return btn;
        }

        private void LoadRecentActivities(ListBox listBox)
        {
            listBox.Items.Clear();
            var activities = EnhancedDatabaseHelper.GetActivityLogs(null, 7);
            
            if (activities.Any())
            {
                foreach (var activity in activities.Take(8))
                {
                    listBox.Items.Add($"🕐 {activity.Description} • {activity.CreatedDate:MMM dd, HH:mm}");
                }
            }
            else
            {
                listBox.Items.Add("No recent activities");
            }
        }

        #endregion

        #region Officials Management

        private void ShowOfficialsManagement(bool showAddForm = false)
        {
            contentPanel.Controls.Clear();

            Label titleLabel = new Label
            {
                Text = "🏛️ Barangay Officials Management",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.FromArgb(52, 58, 64)
            };

            Button addOfficialBtn = new Button
            {
                Text = "➕ Add New Official",
                Size = new Size(160, 40),
                Location = new Point(10, 50),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            addOfficialBtn.FlatAppearance.BorderSize = 0;
            addOfficialBtn.Click += (s, e) => ShowAddOfficialForm();

            DataGridView dgvOfficials = new DataGridView
            {
                Location = new Point(10, 110),
                Size = new Size(contentPanel.Width - 50, contentPanel.Height - 220),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 35 },
                Font = new Font("Segoe UI", 10F)
            };

            dgvOfficials.EnableHeadersVisualStyles = false;
            dgvOfficials.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64);
            dgvOfficials.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOfficials.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            LoadOfficialsData(dgvOfficials);

            Panel actionPanel = new Panel
            {
                Location = new Point(10, contentPanel.Height - 80),
                Size = new Size(contentPanel.Width - 50, 60),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            Button editBtn = new Button
            {
                Text = "✏️ Edit",
                Size = new Size(100, 40),
                Location = new Point(0, 10),
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            editBtn.FlatAppearance.BorderSize = 0;

            Button deactivateBtn = new Button
            {
                Text = "❌ Deactivate",
                Size = new Size(120, 40),
                Location = new Point(110, 10),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            deactivateBtn.FlatAppearance.BorderSize = 0;

            actionPanel.Controls.AddRange(new Control[] { editBtn, deactivateBtn });

            contentPanel.Controls.AddRange(new Control[] { titleLabel, addOfficialBtn, dgvOfficials, actionPanel });

            if (showAddForm)
            {
                ShowAddOfficialForm();
            }
        }

        private void ShowAddOfficialForm()
        {
            Form addForm = new Form
            {
                Text = "Add New Official",
                Size = new Size(500, 600),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var fields = new Dictionary<string, TextBox>();
            var fieldNames = new[] { "FullName", "Position", "Department", "ContactNumber", "Email", "Address", "Responsibilities" };
            var labels = new[] { "Full Name:", "Position:", "Department:", "Contact Number:", "Email:", "Address:", "Responsibilities:" };

            int yPos = 30;
            for (int i = 0; i < fieldNames.Length; i++)
            {
                Label label = new Label
                {
                    Text = labels[i],
                    Location = new Point(30, yPos),
                    Size = new Size(120, 20),
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
                };

                TextBox textBox = new TextBox
                {
                    Name = fieldNames[i],
                    Location = new Point(160, yPos),
                    Size = new Size(280, 25),
                    Font = new Font("Microsoft Sans Serif", 10F)
                };

                if (fieldNames[i] == "Responsibilities")
                {
                    textBox.Multiline = true;
                    textBox.Size = new Size(280, 60);
                }

                fields[fieldNames[i]] = textBox;
                addForm.Controls.AddRange(new Control[] { label, textBox });

                yPos += fieldNames[i] == "Responsibilities" ? 80 : 40;
            }

            Button saveBtn = new Button
            {
                Text = "💾 Save Official",
                Size = new Size(120, 35),
                Location = new Point(160, yPos + 20),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            saveBtn.Click += (s, e) => {
                var official = new BarangayOfficial
                {
                    FullName = fields["FullName"].Text,
                    Position = fields["Position"].Text,
                    Department = fields["Department"].Text,
                    ContactNumber = fields["ContactNumber"].Text,
                    Email = fields["Email"].Text,
                    Address = fields["Address"].Text,
                    Responsibilities = fields["Responsibilities"].Text,
                    StartDate = DateTime.Now,
                    CreatedBy = currentUser.Id
                };

                if (EnhancedDatabaseHelper.CreateOfficial(official))
                {
                    MessageBox.Show("Official added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    addForm.Close();
                    ShowOfficialsManagement();
                }
                else
                {
                    MessageBox.Show("Error adding official.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Button cancelBtn = new Button
            {
                Text = "❌ Cancel",
                Size = new Size(80, 35),
                Location = new Point(290, yPos + 20),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            cancelBtn.Click += (s, e) => addForm.Close();

            addForm.Controls.AddRange(new Control[] { saveBtn, cancelBtn });
            addForm.ShowDialog();
        }

        private void LoadOfficialsData(DataGridView dgv)
        {
            var officials = EnhancedDatabaseHelper.GetAllOfficials();
            var dataTable = new DataTable();
            
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("FullName", typeof(string));
            dataTable.Columns.Add("Position", typeof(string));
            dataTable.Columns.Add("Department", typeof(string));
            dataTable.Columns.Add("ContactNumber", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("StartDate", typeof(DateTime));
            dataTable.Columns.Add("Status", typeof(string));

            foreach (var official in officials)
            {
                dataTable.Rows.Add(
                    official.Id,
                    official.FullName,
                    official.Position,
                    official.Department,
                    official.ContactNumber,
                    official.Email,
                    official.StartDate,
                    official.IsActive ? "Active" : "Inactive"
                );
            }

            dgv.DataSource = dataTable;
            if (dgv.Columns["Id"] != null)
                dgv.Columns["Id"].Visible = false;
        }

        #endregion

        #region Residents Management

        private void ShowResidentManagement()
        {
            contentPanel.Controls.Clear();

            Label titleLabel = new Label
            {
                Text = "👥 Resident Management",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.FromArgb(52, 58, 64)
            };

            Button btnAddResident = new Button
            {
                Text = "➕ Add New Resident",
                Size = new Size(160, 40),
                Location = new Point(10, 50),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnAddResident.FlatAppearance.BorderSize = 0;
            btnAddResident.Click += (s, e) => ShowResidentRegistration();

            DataGridView dgvUsers = new DataGridView
            {
                Location = new Point(10, 110),
                Size = new Size(contentPanel.Width - 50, contentPanel.Height - 220),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 40 },
                Font = new Font("Segoe UI", 10F)
            };

            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            LoadUsersData(dgvUsers);

            Panel actionPanel = new Panel
            {
                Location = new Point(10, contentPanel.Height - 90),
                Size = new Size(contentPanel.Width - 50, 70),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.Transparent
            };

            Button btnActivateUser = new Button
            {
                Text = "✅ Activate User",
                Size = new Size(160, 40),
                Location = new Point(0, 15),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnActivateUser.FlatAppearance.BorderSize = 0;
            btnActivateUser.Click += (s, e) => ToggleUserStatus(dgvUsers, true);

            Button btnDeactivateUser = new Button
            {
                Text = "❌ Deactivate User",
                Size = new Size(160, 40),
                Location = new Point(170, 15),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnDeactivateUser.FlatAppearance.BorderSize = 0;
            btnDeactivateUser.Click += (s, e) => ToggleUserStatus(dgvUsers, false);

            actionPanel.Controls.AddRange(new Control[] { btnActivateUser, btnDeactivateUser });

            contentPanel.Controls.AddRange(new Control[] { titleLabel, btnAddResident, dgvUsers, actionPanel });
        }

        private void LoadUsersData(DataGridView dgv)
        {
            var users = DatabaseHelper.GetAllUsers();
            var dataTable = new DataTable();
            
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("FullName", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("ContactNumber", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("CreatedDate", typeof(DateTime));
            dataTable.Columns.Add("Status", typeof(string));

            foreach (var resident in users)
            {
                dataTable.Rows.Add(resident.Id, resident.Username, resident.FullName, resident.Email, 
                    resident.ContactNumber, resident.Address, resident.CreatedDate, 
                    resident.IsActive ? "Active" : "Inactive");
            }

            dgv.DataSource = dataTable;
            if (dgv.Columns["Id"] != null)
                dgv.Columns["Id"].Visible = false;
        }

        private void ToggleUserStatus(DataGridView dgv, bool status)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                string currentStatus = dgv.SelectedRows[0].Cells["Status"].Value.ToString();
                
                if ((status && currentStatus == "Active") || (!status && currentStatus == "Inactive"))
                {
                    MessageBox.Show($"User is already {(status ? "active" : "inactive")}.", "Info", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (DatabaseHelper.UpdateUserStatus(userId, status))
                {
                    LoadUsersData(dgv);
                    MessageBox.Show($"User {(status ? "activated" : "deactivated")} successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to toggle status.", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Reports Management

        private void ShowReportsManagement()
        {
            contentPanel.Controls.Clear();
            
            Label titleLabel = new Label
            {
                Text = "📊 Reports Management",
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold),
                Location = new Point(30, 30),
                Size = new Size(400, 40),
                ForeColor = Color.FromArgb(52, 58, 64)
            };

            DataGridView dgvReports = new DataGridView
            {
                Location = new Point(30, 100),
                Size = new Size(contentPanel.Width - 80, 400),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            LoadReportsData(dgvReports);

            Button btnResolve = new Button
            {
                Text = "✅ Mark as Resolved",
                Location = new Point(30, 520),
                Size = new Size(140, 35),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };
            btnResolve.Click += (s, e) => ResolveReport(dgvReports);

            contentPanel.Controls.AddRange(new Control[] { titleLabel, dgvReports, btnResolve });
        }

        private void LoadReportsData(DataGridView dgv)
        {
            var reports = DatabaseHelper.GetAllReports();
            var dataTable = new DataTable();
            
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("UserName", typeof(string));
            dataTable.Columns.Add("ReportType", typeof(string));
            dataTable.Columns.Add("Subject", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Status", typeof(string));
            dataTable.Columns.Add("CreatedDate", typeof(DateTime));

            foreach (var report in reports)
            {
                dataTable.Rows.Add(report.Id, report.UserName, report.ReportType, 
                    report.Subject, report.Description, report.Status, report.CreatedDate);
            }

            dgv.DataSource = dataTable;
            if (dgv.Columns["Id"] != null)
                dgv.Columns["Id"].Visible = false;
        }

        private void ResolveReport(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int reportId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                string currentStatus = dgv.SelectedRows[0].Cells["Status"].Value.ToString();
                
                if (currentStatus == "Resolved")
                {
                    MessageBox.Show("This report is already resolved.", "Information", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                if (DatabaseHelper.ResolveReport(reportId, currentUser.Id))
                {
                    LoadReportsData(dgv);
                    MessageBox.Show("Report marked as resolved successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a report to resolve.", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Blotter Management

        private void ShowBlotterManagement()
        {
            contentPanel.Controls.Clear();
            
            Label titleLabel = new Label
            {
                Text = "📝 Blotter Records Management",
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold),
                Location = new Point(30, 30),
                Size = new Size(500, 40),
                ForeColor = Color.FromArgb(52, 58, 64)
            };

            // Action buttons
            Button addBlotterBtn = new Button
            {
                Text = "➕ Add New Blotter",
                Size = new Size(150, 35),
                Location = new Point(30, 80),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };
            addBlotterBtn.Click += (s, e) => ShowAddBlotterForm();

            // Filter panel
            Panel filterPanel = new Panel
            {
                Size = new Size(contentPanel.Width - 60, 50),
                Location = new Point(30, 125),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label filterLabel = new Label
            {
                Text = "Filter by Status:",
                Location = new Point(10, 15),
                Size = new Size(100, 20),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };

            ComboBox statusFilter = new ComboBox
            {
                Location = new Point(120, 12),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            statusFilter.Items.AddRange(new string[] { "All", "Filed", "Under Investigation", "Resolved", "Dismissed" });
            statusFilter.SelectedIndex = 0;

            filterPanel.Controls.AddRange(new Control[] { filterLabel, statusFilter });

            // Blotter grid
            DataGridView dgvBlotters = new DataGridView
            {
                Location = new Point(30, 185),
                Size = new Size(contentPanel.Width - 80, 350),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            LoadBlotterData(dgvBlotters);
            statusFilter.SelectedIndexChanged += (s, e) => LoadBlotterData(dgvBlotters, statusFilter.Text);

            // Action buttons for selected blotter
            Button updateStatusBtn = new Button
            {
                Text = "📋 Update Status",
                Size = new Size(120, 35),
                Location = new Point(30, 550),
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            updateStatusBtn.Click += (s, e) => UpdateBlotterStatus(dgvBlotters);

            Button viewDetailsBtn = new Button
            {
                Text = "👁️ View Details",
                Size = new Size(100, 35),
                Location = new Point(160, 550),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            viewDetailsBtn.Click += (s, e) => ViewBlotterDetails(dgvBlotters);

            Button printBlotterBtn = new Button
            {
                Text = "🖨️ Print",
                Size = new Size(80, 35),
                Location = new Point(270, 550),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            printBlotterBtn.Click += (s, e) => PrintBlotterRecord(dgvBlotters);

            contentPanel.Controls.AddRange(new Control[] { 
                titleLabel, addBlotterBtn, filterPanel, dgvBlotters, 
                updateStatusBtn, viewDetailsBtn, printBlotterBtn 
            });
        }

        private void ShowAddBlotterForm()
        {
            Form addForm = new Form
            {
                Text = "Add New Blotter Record",
                Size = new Size(600, 700),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var fields = new Dictionary<string, Control>();
            int yPos = 30;

            // Incident Type
            Label lblIncidentType = new Label
            {
                Text = "Incident Type:",
                Location = new Point(30, yPos),
                Size = new Size(120, 20),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };

            ComboBox cmbIncidentType = new ComboBox
            {
                Name = "IncidentType",
                Location = new Point(160, yPos),
                Size = new Size(280, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbIncidentType.Items.AddRange(new string[] {
                "Physical Injury", "Theft", "Domestic Violence", "Noise Complaint",
                "Property Damage", "Verbal Altercation", "Trespassing", "Other"
            });

            fields["IncidentType"] = cmbIncidentType;
            addForm.Controls.AddRange(new Control[] { lblIncidentType, cmbIncidentType });
            yPos += 40;

            // Description
            Label lblDescription = new Label
            {
                Text = "Description:",
                Location = new Point(30, yPos),
                Size = new Size(120, 20),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };

            TextBox txtDescription = new TextBox
            {
                Name = "Description",
                Location = new Point(160, yPos),
                Size = new Size(380, 80),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            fields["Description"] = txtDescription;
            addForm.Controls.AddRange(new Control[] { lblDescription, txtDescription });
            yPos += 100;

            // Incident Date
            Label lblIncidentDate = new Label
            {
                Text = "Incident Date:",
                Location = new Point(30, yPos),
                Size = new Size(120, 20),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };

            DateTimePicker dtpIncidentDate = new DateTimePicker
            {
                Name = "IncidentDate",
                Location = new Point(160, yPos),
                Size = new Size(200, 25),
                Format = DateTimePickerFormat.Short
            };

            fields["IncidentDate"] = dtpIncidentDate;
            addForm.Controls.AddRange(new Control[] { lblIncidentDate, dtpIncidentDate });
            yPos += 40;

            // Location
            Label lblLocation = new Label
            {
                Text = "Location:",
                Location = new Point(30, yPos),
                Size = new Size(120, 20),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };

            TextBox txtLocation = new TextBox
            {
                Name = "Location",
                Location = new Point(160, yPos),
                Size = new Size(280, 25)
            };

            fields["Location"] = txtLocation;
            addForm.Controls.AddRange(new Control[] { lblLocation, txtLocation });
            yPos += 40;

            // Complainant
            Label lblComplainant = new Label
            {
                Text = "Complainant:",
                Location = new Point(30, yPos),
                Size = new Size(120, 20),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };

            TextBox txtComplainant = new TextBox
            {
                Name = "Complainant",
                Location = new Point(160, yPos),
                Size = new Size(280, 25)
            };

            fields["Complainant"] = txtComplainant;
            addForm.Controls.AddRange(new Control[] { lblComplainant, txtComplainant });
            yPos += 40;

            // Complainant Contact
            Label lblComplainantContact = new Label
            {
                Text = "Complainant Contact:",
                Location = new Point(30, yPos),
                Size = new Size(120, 20),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };

            TextBox txtComplainantContact = new TextBox
            {
                Name = "ComplainantContact",
                Location = new Point(160, yPos),
                Size = new Size(280, 25)
            };

            fields["ComplainantContact"] = txtComplainantContact;
            addForm.Controls.AddRange(new Control[] { lblComplainantContact, txtComplainantContact });
            yPos += 40;

            // Respondent
            Label lblRespondent = new Label
            {
                Text = "Respondent:",
                Location = new Point(30, yPos),
                Size = new Size(120, 20),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };

            TextBox txtRespondent = new TextBox
            {
                Name = "Respondent",
                Location = new Point(160, yPos),
                Size = new Size(280, 25)
            };

            fields["Respondent"] = txtRespondent;
            addForm.Controls.AddRange(new Control[] { lblRespondent, txtRespondent });
            yPos += 40;

            // Respondent Contact
            Label lblRespondentContact = new Label
            {
                Text = "Respondent Contact:",
                Location = new Point(30, yPos),
                Size = new Size(120, 20),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
            };

            TextBox txtRespondentContact = new TextBox
            {
                Name = "RespondentContact",
                Location = new Point(160, yPos),
                Size = new Size(280, 25)
            };

            fields["RespondentContact"] = txtRespondentContact;
            addForm.Controls.AddRange(new Control[] { lblRespondentContact, txtRespondentContact });
            yPos += 60;

            // Buttons
            Button saveBtn = new Button
            {
                Text = "💾 Save Blotter",
                Size = new Size(120, 35),
                Location = new Point(200, yPos),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            saveBtn.Click += (s, e) => {
                var blotter = new Blotter
                {
                    IncidentType = ((ComboBox)fields["IncidentType"]).Text,
                    Description = ((TextBox)fields["Description"]).Text,
                    IncidentDate = ((DateTimePicker)fields["IncidentDate"]).Value,
                    Location = ((TextBox)fields["Location"]).Text,
                    Complainant = ((TextBox)fields["Complainant"]).Text,
                    ComplainantContact = ((TextBox)fields["ComplainantContact"]).Text,
                    Respondent = ((TextBox)fields["Respondent"]).Text,
                    RespondentContact = ((TextBox)fields["RespondentContact"]).Text,
                    CreatedBy = currentUser.Id
                };

                if (EnhancedDatabaseHelper.CreateBlotter(blotter))
                {
                    // Create notification for relevant users
                    var notification = new Notification
                    {
                        Title = "New Blotter Record Created",
                        Message = $"Incident: {blotter.IncidentType} - {blotter.Location}",
                        Type = "Info",
                        IsBroadcast = false,
                        Category = "Blotter",
                        CreatedBy = currentUser.Id
                    };
                    EnhancedDatabaseHelper.CreateNotification(notification);

                    MessageBox.Show("Blotter record created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    addForm.Close();
                    ShowBlotterManagement();
                }
                else
                {
                    MessageBox.Show("Error creating blotter record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Button cancelBtn = new Button
            {
                Text = "❌ Cancel",
                Size = new Size(80, 35),
                Location = new Point(330, yPos),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            cancelBtn.Click += (s, e) => addForm.Close();

            addForm.Controls.AddRange(new Control[] { saveBtn, cancelBtn });
            addForm.ShowDialog();
        }

        private void LoadBlotterData(DataGridView dgv, string statusFilter = "All")
        {
            var blotters = EnhancedDatabaseHelper.GetAllBlotters();
            if (statusFilter != "All")
                blotters = blotters.Where(b => b.Status == statusFilter).ToList();

            var dataTable = new DataTable();
            
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("IncidentType", typeof(string));
            dataTable.Columns.Add("Complainant", typeof(string));
            dataTable.Columns.Add("Respondent", typeof(string));
            dataTable.Columns.Add("Location", typeof(string));
            dataTable.Columns.Add("IncidentDate", typeof(DateTime));
            dataTable.Columns.Add("Status", typeof(string));
            dataTable.Columns.Add("CreatedDate", typeof(DateTime));

            foreach (var blotter in blotters)
            {
                dataTable.Rows.Add(
                    blotter.Id,
                    blotter.IncidentType,
                    blotter.Complainant,
                    blotter.Respondent,
                    blotter.Location,
                    blotter.IncidentDate,
                    blotter.Status,
                    blotter.CreatedDate
                );
            }

            dgv.DataSource = dataTable;
            if (dgv.Columns["Id"] != null)
                dgv.Columns["Id"].Visible = false;
        }

        private void UpdateBlotterStatus(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int blotterId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                string currentStatus = dgv.SelectedRows[0].Cells["Status"].Value.ToString();

                Form statusForm = new Form
                {
                    Text = "Update Blotter Status",
                    Size = new Size(400, 300),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog
                };

                Label lblStatus = new Label
                {
                    Text = "New Status:",
                    Location = new Point(30, 30),
                    Size = new Size(100, 20),
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
                };

                ComboBox cmbStatus = new ComboBox
                {
                    Location = new Point(140, 30),
                    Size = new Size(200, 25),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cmbStatus.Items.AddRange(new string[] { "Filed", "Under Investigation", "Resolved", "Dismissed" });
                cmbStatus.Text = currentStatus;

                Label lblResolution = new Label
                {
                    Text = "Resolution:",
                    Location = new Point(30, 70),
                    Size = new Size(100, 20),
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold)
                };

                TextBox txtResolution = new TextBox
                {
                    Location = new Point(30, 95),
                    Size = new Size(320, 80),
                    Multiline = true,
                    ScrollBars = ScrollBars.Vertical
                };

                Button updateBtn = new Button
                {
                    Text = "Update",
                    Size = new Size(100, 30),
                    Location = new Point(140, 200),
                    BackColor = Color.FromArgb(0, 123, 255),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                updateBtn.Click += (s, e) => {
                    if (EnhancedDatabaseHelper.UpdateBlotterStatus(blotterId, cmbStatus.Text, txtResolution.Text, currentUser.Id))
                    {
                        MessageBox.Show("Blotter status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        statusForm.Close();
                        ShowBlotterManagement();
                    }
                    else
                    {
                        MessageBox.Show("Error updating blotter status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                statusForm.Controls.AddRange(new Control[] { lblStatus, cmbStatus, lblResolution, txtResolution, updateBtn });
                statusForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a blotter record to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ViewBlotterDetails(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int blotterId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                var blotters = EnhancedDatabaseHelper.GetAllBlotters();
                var blotter = blotters.FirstOrDefault(b => b.Id == blotterId);

                if (blotter != null)
                {
                    Form detailsForm = new Form
                    {
                        Text = "Blotter Details",
                        Size = new Size(600, 500),
                        StartPosition = FormStartPosition.CenterParent,
                        FormBorderStyle = FormBorderStyle.FixedDialog
                    };

                    Panel panel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        AutoScroll = true,
                        Padding = new Padding(20)
                    };

                    string details = $@"
BLOTTER RECORD DETAILS

Incident Type: {blotter.IncidentType}
Date of Incident: {blotter.IncidentDate:MMMM dd, yyyy}
Location: {blotter.Location}
Status: {blotter.Status}

COMPLAINANT INFORMATION:
Name: {blotter.Complainant}
Contact: {blotter.ComplainantContact}

RESPONDENT INFORMATION:
Name: {blotter.Respondent}
Contact: {blotter.RespondentContact}

INCIDENT DESCRIPTION:
{blotter.Description}

RESOLUTION:
{blotter.Resolution ?? "No resolution yet."}

Record Created: {blotter.CreatedDate:MMMM dd, yyyy HH:mm}
{(blotter.ResolvedDate.HasValue ? $"Resolved: {blotter.ResolvedDate:MMMM dd, yyyy HH:mm}" : "")}
            ";

                    TextBox txtDetails = new TextBox
                    {
                        Text = details,
                        Multiline = true,
                        ReadOnly = true,
                        Dock = DockStyle.Fill,
                        ScrollBars = ScrollBars.Vertical,
                        Font = new Font("Courier New", 10F)
                    };

                    panel.Controls.Add(txtDetails);
                    detailsForm.Controls.Add(panel);
                    detailsForm.ShowDialog();
                }
            }
        }

        #endregion

        #region Requests Management

        private void ShowRequestsManagement()
        {
            contentPanel.Controls.Clear();

            Label titleLabel = new Label
            {
                Text = "📋 Manage Requests",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(30, 30),
                AutoSize = true,
                ForeColor = Color.FromArgb(52, 58, 64)
            };

            // Tab buttons
            string[] tabNames = { "All Requests", "Pending", "Approved", "Denied" };
            FlowLayoutPanel tabPanel = new FlowLayoutPanel
            {
                Location = new Point(30, 80),
                Size = new Size(contentPanel.Width - 60, 50),
                AutoSize = true,
                BackColor = Color.Transparent,
                Padding = new Padding(0)
            };

            foreach (var tab in tabNames)
            {
                Button tabButton = new Button
                {
                    Text = tab,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    Size = new Size(120, 40),
                    BackColor = Color.FromArgb(40, 167, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(0, 0, 10, 0)
                };
                tabButton.FlatAppearance.BorderSize = 0;
                tabButton.Click += (s, e) => LoadRequestsByStatus(tab);

                tabPanel.Controls.Add(tabButton);
            }

            contentPanel.Controls.AddRange(new Control[] { titleLabel, tabPanel });

            // Default load all requests
            LoadRequestsByStatus("All Requests");
        }

        private void LoadRequestsByStatus(string status)
        {
            // Remove existing request panels
            foreach (Control ctrl in contentPanel.Controls)
            {
                if (ctrl is Panel panel && panel.Name.StartsWith("requestPanel_"))
                {
                    contentPanel.Controls.Remove(panel);
                }
            }

            var requests = DatabaseHelper.GetAllRequests();
            if (status != "All Requests")
                requests = requests.Where(r => r.Status == status).ToList();

            int yPos = 140;
            foreach (var request in requests)
            {
                Panel requestPanel = new Panel
                {
                    Name = "requestPanel_" + request.Id,
                    Size = new Size(contentPanel.Width - 60, 100),
                    Location = new Point(30, yPos),
                    BackColor = Color.White,
                    Margin = new Padding(0, 0, 0, 10)
                };
                requestPanel.Paint += (s, e) => DrawCardShadow(requestPanel, e);

                Label lblType = new Label
                {
                    Text = request.RequestType,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 58, 64),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblStatus = new Label
                {
                    Text = request.Status,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = request.Status == "Approved" ? Color.FromArgb(40, 167, 69) :
                                request.Status == "Denied" ? Color.FromArgb(220, 53, 69) :
                                Color.FromArgb(108, 117, 125),
                    Location = new Point(10, 40),
                    AutoSize = true
                };

                Label lblDate = new Label
                {
                    Text = $"Submitted: {request.CreatedDate:MMMM dd, yyyy}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(158, 163, 173),
                    Location = new Point(10, 70),
                    AutoSize = true
                };

                requestPanel.Controls.AddRange(new Control[] { lblType, lblStatus, lblDate });

                // Clickable panel to view request details
                requestPanel.Click += (s, e) => {
                    ShowRequestDetails(request.Id);
                };

                contentPanel.Controls.Add(requestPanel);
                yPos += 110;
            }

            // No requests message
            if (requests.Count == 0)
            {
                Label lblMessage = new Label
                {
                    Text = "No requests found.",
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.FromArgb(108, 117, 125),
                    Location = new Point(30, yPos),
                    AutoSize = true
                };

                contentPanel.Controls.Add(lblMessage);
            }
        }

        #endregion

        #region Submit Request

        private void ShowSubmitRequest()
        {
            contentPanel.Controls.Clear();

            Label title = new Label
            {
                Text = "📝 Submit Document Request",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(30, 30),
                Size = new Size(500, 35)
            };

            Panel formPanel = new Panel
            {
                Location = new Point(30, 90),
                Size = new Size(700, 500),
                BackColor = Color.White
            };
            formPanel.Paint += (s, e) => DrawCardShadow(formPanel, e);

            Label lblType = new Label
            {
                Text = "Request Type *",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(30, 30),
                Size = new Size(150, 22)
            };

            ComboBox cmbRequestType = new ComboBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(30, 57),
                Size = new Size(640, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
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
                Size = new Size(150, 22)
            };

            TextBox txtPurpose = new TextBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(30, 137),
                Size = new Size(640, 30),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblDescription = new Label
            {
                Text = "Additional Details",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(30, 190),
                Size = new Size(200, 22)
            };

            TextBox txtDescription = new TextBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(30, 217),
                Size = new Size(640, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            Label lblFeeInfo = new Label
            {
                Text = "💰 Processing Fee: ₱50.00",
                Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = Color.FromArgb(40, 167, 69),
                Location = new Point(30, 335),
                Size = new Size(640, 22)
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
                Cursor = Cursors.Hand
            };
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Click += (s, e) => {
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
            };

            Button btnClear = new Button
            {
                Text = "Clear Form",
                Font = new Font("Segoe UI", 11F),
                Location = new Point(350, 380),
                Size = new Size(150, 45),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += (s, e) => {
                cmbRequestType.SelectedIndex = -1;
                txtPurpose.Clear();
                txtDescription.Clear();
            };

            formPanel.Controls.AddRange(new Control[] {
                lblType, cmbRequestType, lblPurpose, txtPurpose,
                lblDescription, txtDescription, lblFeeInfo, btnSubmit, btnClear
    });

    contentPanel.Controls.AddRange(new Control[] { title, formPanel });
}

#endregion

#region My Requests

private void ShowMyRequests()
{
    contentPanel.Controls.Clear();

    Label title = new Label
    {
        Text = "📋 My Document Requests",
        Font = new Font("Segoe UI", 20F, FontStyle.Bold),
        ForeColor = Color.FromArgb(52, 58, 64),
        Location = new Point(30, 30),
        Size = new Size(500, 35)
    };

    Panel filterPanel = new Panel
    {
        Location = new Point(30, 80),
        Size = new Size(contentPanel.Width - 60, 50),
        BackColor = Color.White,
        Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
    };
    filterPanel.Paint += (s, e) => DrawCardShadow(filterPanel, e);

    Label lblFilter = new Label
    {
        Text = "Filter:",
        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
        Location = new Point(20, 15),
        Size = new Size(50, 20)
    };

    ComboBox cmbFilter = new ComboBox
    {
        Font = new Font("Segoe UI", 10F),
        Location = new Point(80, 12),
        Size = new Size(150, 25),
        DropDownStyle = ComboBoxStyle.DropDownList
    };
    cmbFilter.Items.AddRange(new string[] { "All", "Pending", "Approved", "Rejected", "Processing" });
    cmbFilter.SelectedIndex = 0;

    filterPanel.Controls.AddRange(new Control[] { lblFilter, cmbFilter });

    DataGridView dgvRequests = new DataGridView
    {
        Location = new Point(30, 150),
        Size = new Size(contentPanel.Width - 60, contentPanel.Height - 270),
        Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
        BackgroundColor = Color.White,
        BorderStyle = BorderStyle.None,
        AllowUserToAddRows = false,
        ReadOnly = true,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        ColumnHeadersHeight = 40,
        RowTemplate = { Height = 35 },
        Font = new Font("Segoe UI", 10F)
    };

    dgvRequests.EnableHeadersVisualStyles = false;
    dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64);
    dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
    dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
    dgvRequests.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
    dgvRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

    LoadMyRequests(dgvRequests, "All");

    cmbFilter.SelectedIndexChanged += (s, e) => LoadMyRequests(dgvRequests, cmbFilter.Text);

    Button btnViewDetails = new Button
    {
        Text = "👁️ View Details",
        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
        Location = new Point(30, contentPanel.Height - 90),
        Size = new Size(150, 40),
        BackColor = Color.FromArgb(0, 123, 255),
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Cursor = Cursors.Hand,
        Anchor = AnchorStyles.Bottom | AnchorStyles.Left
    };
    btnViewDetails.FlatAppearance.BorderSize = 0;
    btnViewDetails.Click += (s, e) => {
        if (dgvRequests.SelectedRows.Count > 0)
        {
            int requestId = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["Id"].Value);
            ShowRequestDetails(requestId);
        }
    };

    contentPanel.Controls.AddRange(new Control[] {
        title, filterPanel, dgvRequests, btnViewDetails
    });
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
        dataTable.Columns.Add("Date Processed", typeof(DateTime));

        foreach (var request in requests)
        {
            dataTable.Rows.Add(
                request.Id,
                request.RequestType,
                request.Status,
                request.CreatedDate,
                request.ProcessedDate
            );
        }

        dgv.DataSource = dataTable;

        if (dgv.Columns["Id"] != null)
            dgv.Columns["Id"].Visible = false;

        // Color code status
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

private void ShowRequestDetails(int requestId)
{
    try
    {
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
                FlatStyle = FlatStyle.Flat
            };
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.Click += (s, e) => detailsForm.Close();

            detailsForm.Controls.AddRange(new Control[] { txtDetails, closeBtn });
            detailsForm.ShowDialog();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error showing request details: {ex.Message}", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

#endregion

#region File Report

private void ShowFileReport()
{
    contentPanel.Controls.Clear();

    Label title = new Label
    {
        Text = "📊 File a Report/Complaint",
        Font = new Font("Segoe UI", 20F, FontStyle.Bold),
        ForeColor = Color.FromArgb(52, 58, 64),
        Location = new Point(30, 30),
        Size = new Size(500, 35)
    };

    Panel formPanel = new Panel
    {
        Location = new Point(30, 90),
        Size = new Size(700, 500),
        BackColor = Color.White
    };
    formPanel.Paint += (s, e) => DrawCardShadow(formPanel, e);

    Label lblType = new Label
    {
        Text = "Report Type *",
        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
        ForeColor = Color.FromArgb(52, 58, 64),
        Location = new Point(30, 30),
        Size = new Size(150, 22)
    };

    ComboBox cmbReportType = new ComboBox
    {
        Font = new Font("Segoe UI", 11F),
        Location = new Point(30, 57),
        Size = new Size(640, 30),
        DropDownStyle = ComboBoxStyle.DropDownList
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
        Size = new Size(150, 22)
    };

    TextBox txtSubject = new TextBox
    {
        Name = "Subject",
        Location = new Point(120, 107),
        Size = new Size(640, 25),
        Font = new Font("Segoe UI", 10F)
    };

    Label lblDescription = new Label
    {
        Text = "Detailed Description *",
        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
        ForeColor = Color.FromArgb(52, 58, 64),
        Location = new Point(30, 150),
        Size = new Size(200, 22)
    };

    TextBox txtDescription = new TextBox
    {
        Name = "Description",
        Location = new Point(30, 177),
        Size = new Size(640, 150),
        Multiline = true,
        ScrollBars = ScrollBars.Vertical,
        Font = new Font("Segoe UI", 10F)
    };

    Button btnSubmit = new Button
    {
        Text = "📤 Submit Report",
        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
        Location = new Point(30, 340),
        Size = new Size(300, 45),
        BackColor = Color.FromArgb(220, 53, 69),
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Cursor = Cursors.Hand
    };
    btnSubmit.FlatAppearance.BorderSize = 0;
    btnSubmit.Click += (s, e) => {
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
    };

    Button btnClear = new Button
    {
        Text = "Clear Form",
        Font = new Font("Segoe UI", 11F),
        Location = new Point(350, 340),
        Size = new Size(150, 45),
        BackColor = Color.FromArgb(108, 117, 125),
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Cursor = Cursors.Hand
    };
    btnClear.FlatAppearance.BorderSize = 0;
    btnClear.Click += (s, e) => {
        cmbReportType.SelectedIndex = -1;
        txtSubject.Clear();
        txtDescription.Clear();
    };

    formPanel.Controls.AddRange(new Control[] {
        lblType, cmbReportType, lblSubject, txtSubject,
        lblDescription, txtDescription, btnSubmit, btnClear
    });

    contentPanel.Controls.AddRange(new Control[] { title, formPanel });
}

#endregion

#region My Reports

private void ShowMyReports()
{
    contentPanel.Controls.Clear();

    Label title = new Label
    {
        Text = "📈 My Reports & Complaints",
        Font = new Font("Segoe UI", 20F, FontStyle.Bold),
        ForeColor = Color.FromArgb(52, 58, 64),
        Location = new Point(30, 30),
        Size = new Size(500, 35)
    };

    DataGridView dgvReports = new DataGridView
    {
        Location = new Point(30, 90),
        Size = new Size(contentPanel.Width - 60, contentPanel.Height - 120),
        Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
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
        RowTemplate = { Height = 35 }
    };

    dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 53, 69);
    dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
    dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
    dgvReports.EnableHeadersVisualStyles = false;
    dgvReports.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

    LoadMyReports(dgvReports);

    contentPanel.Controls.AddRange(new Control[] { title, dgvReports });
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
        dataTable.Columns.Add("Date Resolved", typeof(DateTime));

        foreach (var report in reports)
        {
            dataTable.Rows.Add(
                report.Id,
                report.ReportType,
                report.Subject,
                report.Status,
                report.CreatedDate,
                report.ResolvedDate
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

#endregion

#region Profile

private void ShowProfile()
{
    contentPanel.Controls.Clear();

    Label title = new Label
    {
        Text = "👤 My Profile",
        Font = new Font("Segoe UI", 20F, FontStyle.Bold),
        ForeColor = Color.FromArgb(52, 58, 64),
        Location = new Point(30, 30),
        Size = new Size(500, 35)
    };

    Panel profilePanel = new Panel
    {
        Location = new Point(30, 90),
        Size = new Size(700, 450),
        BackColor = Color.White
    };
    profilePanel.Paint += (s, e) => DrawCardShadow(profilePanel, e);

    // Avatar
    Panel avatar = new Panel
    {
        Size = new Size(120, 120),
        Location = new Point(290, 30),
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
    contentPanel.Controls.AddRange(new Control[] { title, profilePanel });
}

private void CreateProfileField(Panel parent, string label, string value, int yPos)
{
    Label lblLabel = new Label
    {
        Text = label,
        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
        ForeColor = Color.FromArgb(52, 58, 64),
        Location = new Point(100, yPos),
        Size = new Size(140, 20),
        TextAlign = ContentAlignment.MiddleRight
    };

    Label lblValue = new Label
    {
        Text = value,
        Font = new Font("Segoe UI", 11F),
        ForeColor = Color.FromArgb(73, 80, 87),
        Location = new Point(250, yPos),
        Size = new Size(350, 20),
        TextAlign = ContentAlignment.MiddleLeft
    };

    parent.Controls.AddRange(new Control[] { lblLabel, lblValue });
}

#endregion

#region Helper Methods

private void DrawCardShadow(Panel card, PaintEventArgs e)
{
    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    using (Pen pen = new Pen(Color.FromArgb(222, 226, 230), 1))
    {
        Rectangle rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
        e.Graphics.DrawRectangle(pen, rect);
    }
}

private void PrintBlotterRecord(DataGridView dgv)
{
    if (dgv.SelectedRows.Count > 0)
    {
        int blotterId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
        MessageBox.Show("Printing functionality will be implemented in the Printing Center module.", 
            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        // You can redirect to printing center
        // ShowPrintingCenter();
    }
    else
    {
        MessageBox.Show("Please select a blotter record to print.", "Warning", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}

private void CloseBtn_Click(object sender, EventArgs e)
{
    DialogResult result = MessageBox.Show("Are you sure you want to exit?", 
        "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    
    if (result == DialogResult.Yes)
    {
        EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Logout", "Dashboard", "Admin closed application");
        Application.Exit();
    }
}

private void Logout()
{
    DialogResult result = MessageBox.Show("Are you sure you want to logout?", 
        "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    
    if (result == DialogResult.Yes)
    {
        EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Logout", "Dashboard", "Admin logged out");
        this.Hide();
        new LoginForm().Show();
    }
}

#endregion

#region Settings and Registration

private void ShowPrintingCenter()
{
    contentPanel.Controls.Clear();
    
    try
    {
        var printingCenter = new PrintingCenter(currentUser, contentPanel);
        printingCenter.ShowPrintingCenter();
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error loading printing center: {ex.Message}", "Error", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

private void ShowResidentRegistration()
{
    contentPanel.Controls.Clear();
    
    Label titleLabel = new Label
    {
        Text = "👤 Resident Registration",
        Font = new Font("Segoe UI", 20F, FontStyle.Bold),
        Location = new Point(10, 10),
        AutoSize = true,
        ForeColor = Color.FromArgb(52, 58, 64)
    };

    Panel registrationPanel = new Panel
    {
        Location = new Point(10, 70),
        Size = new Size(800, 500),
        BackColor = Color.White,
        BorderStyle = BorderStyle.FixedSingle
    };

    CreateRegistrationForm(registrationPanel);

    contentPanel.Controls.AddRange(new Control[] { titleLabel, registrationPanel });
}

private void CreateRegistrationForm(Panel parent)
{
    int y = 30;
    int spacing = 60;

    CreateFormField(parent, "Full Name:", "txtRegFullName", 30, y);
    y += spacing;
    CreateFormField(parent, "Username:", "txtRegUsername", 30, y);
    y += spacing;
    CreateFormField(parent, "Email:", "txtRegEmail", 30, y);
    y += spacing;
    CreateFormField(parent, "Contact Number:", "txtRegContact", 30, y);
    y += spacing;
    CreateFormField(parent, "Address:", "txtRegAddress", 30, y);
    y += spacing;

    Button btnRegisterResident = new Button
    {
        Text = "✅ Register Resident",
        Location = new Point(30, y),
        Size = new Size(180, 40),
        BackColor = Color.FromArgb(40, 167, 69),
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
        Cursor = Cursors.Hand
    };
    btnRegisterResident.FlatAppearance.BorderSize = 0;
    btnRegisterResident.Click += BtnRegisterResident_Click;

    parent.Controls.Add(btnRegisterResident);
}

private void CreateFormField(Panel parent, string labelText, string textBoxName, int x, int y)
{
    Label label = new Label
    {
        Text = labelText,
        Location = new Point(x, y),
        Size = new Size(140, 20),
        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
        ForeColor = Color.FromArgb(52, 58, 64)
    };

    TextBox textBox = new TextBox
    {
        Name = textBoxName,
        Location = new Point(x + 150, y),
        Size = new Size(400, 25),
        Font = new Font("Segoe UI", 10F),
        BorderStyle = BorderStyle.FixedSingle
    };

    parent.Controls.AddRange(new Control[] { label, textBox });
}

private void BtnRegisterResident_Click(object sender, EventArgs e)
{
    Panel parent = ((Button)sender).Parent as Panel;
    
    string fullName = GetTextBoxValue(parent, "txtRegFullName");
    string username = GetTextBoxValue(parent, "txtRegUsername");
    string email = GetTextBoxValue(parent, "txtRegEmail");
    string contact = GetTextBoxValue(parent, "txtRegContact");
    string address = GetTextBoxValue(parent, "txtRegAddress");

    if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username))
    {
        MessageBox.Show("Full Name and Username are required.", "Validation Error", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    var user = new User
    {
        Username = username,
        Password = "password123", // Default password
        FullName = fullName,
        Email = email,
        ContactNumber = contact,
        Address = address,
        UserType = "User"
    };

    if (DatabaseHelper.CreateUser(user))
    {
        MessageBox.Show($"Resident registered successfully!\n\nUsername: {username}\nDefault Password: password123\n\nPlease inform the resident to change their password.", 
            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        ClearFormFields(parent);
        
        EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Register Resident", "Users", 
            $"Registered new resident: {fullName}");
    }
    else
    {
        MessageBox.Show("Username already exists. Please choose a different username.", 
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

private string GetTextBoxValue(Panel parent, string textBoxName)
{
    foreach (Control control in parent.Controls)
    {
        if (control is TextBox textBox && textBox.Name == textBoxName)
        {
            return textBox.Text.Trim();
        }
    }
    return string.Empty;
}

private void ClearFormFields(Panel parent)
{
    foreach (Control control in parent.Controls)
    {
        if (control is TextBox textBox)
        {
            textBox.Text = string.Empty;
        }
    }
}

private void ShowSettings()
{
    contentPanel.Controls.Clear();
    
    Label titleLabel = new Label
    {
        Text = "⚙️ System Settings",
        Font = new Font("Segoe UI", 20F, FontStyle.Bold),
        Location = new Point(10, 10),
        AutoSize = true,
        ForeColor = Color.FromArgb(52, 58, 64)
    };

    Panel settingsPanel = new Panel
    {
        Location = new Point(10, 70),
        Size = new Size(900, 600),
        BackColor = Color.White,
        BorderStyle = BorderStyle.FixedSingle,
        AutoScroll = true
    };

    CreateSettingsForm(settingsPanel);

    contentPanel.Controls.AddRange(new Control[] { titleLabel, settingsPanel });
}

private void CreateSettingsForm(Panel parent)
{
    var settings = EnhancedDatabaseHelper.GetSystemSettings();
    int yPos = 30;

    // Barangay Information Section
    Label lblBarangayInfo = new Label
    {
        Text = "🏛️ Barangay Information",
        Font = new Font("Segoe UI", 14F, FontStyle.Bold),
        Location = new Point(30, yPos),
        Size = new Size(300, 25),
        ForeColor = Color.FromArgb(52, 58, 64)
    };
    parent.Controls.Add(lblBarangayInfo);
    yPos += 40;

    CreateSettingsField(parent, "Barangay Name:", "txtBarangayName", settings.BarangayName, 30, yPos);
    yPos += 40;
    CreateSettingsField(parent, "Address:", "txtAddress", settings.Address, 30, yPos);
    yPos += 40;
    CreateSettingsField(parent, "Contact Number:", "txtContactNumber", settings.ContactNumber, 30, yPos);
    yPos += 40;
    CreateSettingsField(parent, "Email:", "txtEmail", settings.Email, 30, yPos);
    yPos += 60;

    // Officials Section
    Label lblOfficials = new Label
    {
        Text = "👥 Key Officials",
        Font = new Font("Segoe UI", 14F, FontStyle.Bold),
        Location = new Point(30, yPos),
        Size = new Size(300, 25),
        ForeColor = Color.FromArgb(52, 58, 64)
    };
    parent.Controls.Add(lblOfficials);
    yPos += 40;

    CreateSettingsField(parent, "Barangay Captain:", "txtCaptain", settings.Captain, 30, yPos);
    yPos += 40;
    CreateSettingsField(parent, "Secretary:", "txtSecretary", settings.Secretary, 30, yPos);
    yPos += 40;
    CreateSettingsField(parent, "Treasurer:", "txtTreasurer", settings.Treasurer, 30, yPos);
    yPos += 60;

    // Save Button
    Button saveBtn = new Button
    {
        Text = "💾 Save Settings",
        Size = new Size(180, 45),
        Location = new Point(30, yPos),
        BackColor = Color.FromArgb(0, 123, 255),
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
        Cursor = Cursors.Hand
    };
    saveBtn.FlatAppearance.BorderSize = 0;
    saveBtn.Click += (s, e) => SaveSystemSettings(parent);
    parent.Controls.Add(saveBtn);
}

private void CreateSettingsField(Panel parent, string labelText, string textBoxName, string value, int x, int y)
{
    Label label = new Label
    {
        Text = labelText,
        Location = new Point(x, y),
        Size = new Size(150, 20),
        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
        ForeColor = Color.FromArgb(52, 58, 64)
    };

    TextBox textBox = new TextBox
    {
        Name = textBoxName,
        Text = value ?? "",
        Location = new Point(x + 180, y),
        Size = new Size(400, 25),
        Font = new Font("Segoe UI", 10F),
        BorderStyle = BorderStyle.FixedSingle
    };

    parent.Controls.AddRange(new Control[] { label, textBox });
}

private void SaveSystemSettings(Panel parent)
{
    var settings = EnhancedDatabaseHelper.GetSystemSettings();
    
    settings.BarangayName = GetTextBoxValue(parent, "txtBarangayName");
    settings.Address = GetTextBoxValue(parent, "txtAddress");
    settings.ContactNumber = GetTextBoxValue(parent, "txtContactNumber");
    settings.Email = GetTextBoxValue(parent, "txtEmail");
    settings.Captain = GetTextBoxValue(parent, "txtCaptain");
    settings.Secretary = GetTextBoxValue(parent, "txtSecretary");
    settings.Treasurer = GetTextBoxValue(parent, "txtTreasurer");
    settings.UpdatedBy = currentUser.Id;

    if (EnhancedDatabaseHelper.UpdateSystemSettings(settings))
    {
        MessageBox.Show("Settings saved successfully!", "Success", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Update Settings", "Settings", 
            "Updated system settings");
    }
    else
    {
        MessageBox.Show("Error saving settings.", "Error", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

#endregion

#region News Management

private void ShowNewsManagement(bool showAddForm = false)
{
    contentPanel.Controls.Clear();
    
    Label titleLabel = new Label
    {
        Text = "📰 News & Announcements Management",
        Font = new Font("Segoe UI", 20F, FontStyle.Bold),
        Location = new Point(10, 10),
        AutoSize = true,
        ForeColor = Color.FromArgb(52, 58, 64)
    };

    Button addNewsBtn = new Button
    {
        Text = "➕ Create News",
        Size = new Size(140, 40),
        Location = new Point(10, 60),
        BackColor = Color.FromArgb(40, 167, 69),
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
        Cursor = Cursors.Hand
    };
    addNewsBtn.FlatAppearance.BorderSize = 0;
    addNewsBtn.Click += (s, e) => ShowAddNewsForm();

    DataGridView dgvNews = new DataGridView
    {
        Location = new Point(10, 120),
        Size = new Size(contentPanel.Width - 50, contentPanel.Height - 220),
        Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
        BackgroundColor = Color.White,
        BorderStyle = BorderStyle.FixedSingle,
        AllowUserToAddRows = false,
        ReadOnly = true,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        ColumnHeadersHeight = 40,
        RowTemplate = { Height = 35 },
        Font = new Font("Segoe UI", 10F)
    };

    dgvNews.EnableHeadersVisualStyles = false;
    dgvNews.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64);
    dgvNews.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
    dgvNews.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

    LoadNewsData(dgvNews);

    Button togglePublishBtn = new Button
    {
        Text = "📝 Toggle Publish",
        Size = new Size(140, 40),
        Location = new Point(10, contentPanel.Height - 80),
        BackColor = Color.FromArgb(0, 123, 255),
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
        Cursor = Cursors.Hand,
        Anchor = AnchorStyles.Bottom | AnchorStyles.Left
    };
    togglePublishBtn.FlatAppearance.BorderSize = 0;
    togglePublishBtn.Click += (s, e) => ToggleNewsPublish(dgvNews);

    contentPanel.Controls.AddRange(new Control[] { titleLabel, addNewsBtn, dgvNews, togglePublishBtn });

    if (showAddForm)
    {
        ShowAddNewsForm();
    }
}

private void ShowAddNewsForm()
{
    Form addForm = new Form
    {
        Text = "Create News/Announcement",
        Size = new Size(700, 600),
        StartPosition = FormStartPosition.CenterParent,
        FormBorderStyle = FormBorderStyle.FixedDialog,
        MaximizeBox = false,
        MinimizeBox = false
    };

    var fields = new Dictionary<string, Control>();
    int yPos = 30;

    Label lblTitle = new Label
    {
        Text = "Title:",
        Location = new Point(30, yPos),
        Size = new Size(80, 20),
        Font = new Font("Segoe UI", 10F, FontStyle.Bold)
    };

    TextBox txtTitle = new TextBox
    {
        Name = "Title",
        Location = new Point(120, yPos),
        Size = new Size(520, 25),
        Font = new Font("Segoe UI", 10F)
    };
    fields["Title"] = txtTitle;
    addForm.Controls.AddRange(new Control[] { lblTitle, txtTitle });
    yPos += 40;

    Label lblCategory = new Label
    {
        Text = "Category:",
        Location = new Point(30, yPos),
        Size = new Size(80, 20),
        Font = new Font("Segoe UI", 10F, FontStyle.Bold)
    };

    ComboBox cmbCategory = new ComboBox
    {
        Name = "Category",
        Location = new Point(120, yPos),
        Size = new Size(200, 25),
        DropDownStyle = ComboBoxStyle.DropDownList
    };
    cmbCategory.Items.AddRange(new string[] { "News", "Announcement", "Event", "Emergency" });
    cmbCategory.SelectedIndex = 0;
    fields["Category"] = cmbCategory;
    addForm.Controls.AddRange(new Control[] { lblCategory, cmbCategory });
    yPos += 40;

    Label lblContent = new Label
    {
        Text = "Content:",
        Location = new Point(30, yPos),
        Size = new Size(80, 20),
        Font = new Font("Segoe UI", 10F, FontStyle.Bold)
    };

    TextBox txtContent = new TextBox
    {
        Name = "Content",
        Location = new Point(120, yPos),
        Size = new Size(520, 200),
        Multiline = true,
        ScrollBars = ScrollBars.Vertical
    };
    fields["Content"] = txtContent;
    addForm.Controls.AddRange(new Control[] { lblContent, txtContent });
    yPos += 220;

    CheckBox chkPublished = new CheckBox
    {
        Name = "IsPublished",
        Text = "Publish immediately",
        Location = new Point(120, yPos),
        Checked = true
    };
    fields["IsPublished"] = chkPublished;
    addForm.Controls.Add(chkPublished);
    yPos += 40;

    Button saveBtn = new Button
    {
        Text = "💾 Save",
        Size = new Size(100, 35),
        Location = new Point(300, yPos),
        BackColor = Color.FromArgb(40, 167, 69),
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat
    };
    saveBtn.FlatAppearance.BorderSize = 0;

    saveBtn.Click += (s, e) => {
        if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtContent.Text))
        {
            MessageBox.Show("Please fill in title and content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var news = new News
        {
            Title = txtTitle.Text,
            Category = cmbCategory.Text,
            Content = txtContent.Text,
            Summary = txtContent.Text.Length > 100 ? txtContent.Text.Substring(0, 100) : txtContent.Text,
            IsPublished = chkPublished.Checked,
            CreatedBy = currentUser.Id
        };

        EnhancedDatabaseHelper.CreateNews(news);

        // Also create a notification for all users (broadcast)
        var notification = new Notification
        {
            Title = "New News Announcement",
            Message = $"Check out the latest news: {news.Title}",
            Type = "Info",
            IsBroadcast = true,
            Category = "News",
            CreatedBy = currentUser.Id
        };
        EnhancedDatabaseHelper.CreateNotification(notification);

        MessageBox.Show("News created and published successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        addForm.Close();
        ShowNewsManagement();
    };

    Button cancelBtn = new Button
    {
        Text = "❌ Cancel",
        Size = new Size(80, 35),
        Location = new Point(410, yPos),
        BackColor = Color.FromArgb(108, 117, 125),
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat
    };
    cancelBtn.FlatAppearance.BorderSize = 0;
    cancelBtn.Click += (s, e) => addForm.Close();

    addForm.Controls.AddRange(new Control[] { saveBtn, cancelBtn });
    addForm.ShowDialog();
}

private void LoadNewsData(DataGridView dgv)
{
    var newsList = EnhancedDatabaseHelper.GetAllNews();
    var dataTable = new DataTable();

    dataTable.Columns.Add("Id", typeof(int));
    dataTable.Columns.Add("Title", typeof(string));
    dataTable.Columns.Add("Category", typeof(string));
    dataTable.Columns.Add("PublishDate", typeof(DateTime));
    dataTable.Columns.Add("IsPublished", typeof(bool));

    foreach (var news in newsList)
    {
        dataTable.Rows.Add(news.Id, news.Title, news.Category, news.PublishDate, news.IsPublished);
    }

    dgv.DataSource = dataTable;
    if (dgv.Columns["Id"] != null)
        dgv.Columns["Id"].Visible = false;
}

private void ToggleNewsPublish(DataGridView dgv)
{
    if (dgv.SelectedRows.Count > 0)
    {
        int newsId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
        bool currentStatus = Convert.ToBoolean(dgv.SelectedRows[0].Cells["IsPublished"].Value);

        var allNews = EnhancedDatabaseHelper.GetAllNews();
        var news = allNews.FirstOrDefault(n => n.Id == newsId);

        if (news != null)
        {
            news.IsPublished = !currentStatus;
            if (EnhancedDatabaseHelper.UpdateNews(news))
            {
                MessageBox.Show($"News {(news.IsPublished ? "published" : "unpublished")} successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNewsData(dgv);
            }
        }
    }
}

        #endregion
    }
}