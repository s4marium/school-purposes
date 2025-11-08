using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Controls
{
    public class DashboardOverviewControl : UserControl
    {
        private User currentUser;
        private FlowLayoutPanel mainFlow;

        public event EventHandler<string> NavigationRequested;

        public DashboardOverviewControl(User user)
        {
            currentUser = user;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.AutoScroll = true;
            InitializeUI();
            this.Resize += DashboardOverviewControl_Resize;
        }

        private void DashboardOverviewControl_Resize(object sender, EventArgs e)
        {
            if (mainFlow != null && this.Width > 0)
            {
                RefreshLayout();
            }
        }

        private void RefreshLayout()
        {
            mainFlow.SuspendLayout();
            mainFlow.Controls.Clear();
            
            // Welcome Card
            Panel welcomeCard = CreateWelcomeCard();
            mainFlow.Controls.Add(welcomeCard);

            // Quick Stats
            Panel statsPanel = CreateQuickStatsPanel();
            mainFlow.Controls.Add(statsPanel);

            // Bottom container for Activity and Quick Actions
            int containerWidth = Math.Max(Math.Min(this.Width - 60, 1200), 600);
            Panel bottomContainer = new Panel
            {
                Width = containerWidth,
                Height = 400,
                Margin = new Padding(0, 10, 0, 20),
                BackColor = Color.Transparent
            };

            int halfWidth = Math.Max((containerWidth - 30) / 2, 280);
            Panel activityPanel = CreateRecentActivityPanel(halfWidth);
            activityPanel.Location = new Point(0, 0);

            Panel quickActionsPanel = CreateQuickActionsPanel(halfWidth);
            quickActionsPanel.Location = new Point(halfWidth + 20, 0);

            bottomContainer.Controls.AddRange(new Control[] { activityPanel, quickActionsPanel });
            mainFlow.Controls.Add(bottomContainer);

            mainFlow.ResumeLayout();
        }

        private void InitializeUI()
        {
            mainFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(20)
            };

            this.Controls.Add(mainFlow);
            RefreshLayout();
        }

        private Panel CreateWelcomeCard()
        {
            int width = Math.Max(Math.Min(this.Width - 60, 1200), 300);
            Panel card = new Panel
            {
                Width = width,
                Height = 160,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 20)
            };

            card.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid);
            };

            Label greeting = new Label
            {
                Text = $"Good {GetTimeOfDay()}, {currentUser.FullName}! 👋",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(30, 30),
                AutoSize = true,
                MaximumSize = new Size(width - 60, 0)
            };

            Label subtitle = new Label
            {
                Text = "Welcome to your Barangay Management Dashboard",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(30, 75),
                AutoSize = true
            };

            Label dateLabel = new Label
            {
                Text = DateTime.Now.ToString("MMMM dd, yyyy - dddd"),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(30, 110),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] { greeting, subtitle, dateLabel });
            return card;
        }

        private Panel CreateQuickStatsPanel()
        {
            int width = Math.Max(Math.Min(this.Width - 60, 1200), 300);
            Panel panel = new Panel
            {
                Width = width,
                Height = 180,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 20)
            };

            var stats = new[]
            {
                new { Icon = "📋", Label = "Pending Requests", Value = GetUserPendingRequestsCount().ToString(), Color = Color.FromArgb(255, 193, 7) },
                new { Icon = "✅", Label = "Approved Requests", Value = GetUserApprovedRequestsCount().ToString(), Color = Color.FromArgb(40, 167, 69) },
                new { Icon = "📊", Label = "Active Reports", Value = GetUserActiveReportsCount().ToString(), Color = Color.FromArgb(0, 123, 255) },
                new { Icon = "🔔", Label = "Notifications", Value = EnhancedDatabaseHelper.GetUnreadNotificationCount(currentUser.Id).ToString(), Color = Color.FromArgb(220, 53, 69) }
            };

            int cardWidth = Math.Max((width - 40) / 4, 180);
            int spacing = (width - (cardWidth * 4)) / 3;

            for (int i = 0; i < stats.Length; i++)
            {
                Panel statCard = CreateStatCard(stats[i].Icon, stats[i].Label, stats[i].Value, stats[i].Color, cardWidth);
                statCard.Location = new Point(i * (cardWidth + spacing), 0);
                panel.Controls.Add(statCard);
            }

            return panel;
        }

        private Panel CreateStatCard(string icon, string label, string value, Color color, int width)
        {
            Panel card = new Panel
            {
                Size = new Size(width, 170),
                BackColor = Color.White
            };

            card.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid);
            };

            Label iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 32F),
                Location = new Point(20, 20),
                AutoSize = true
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(20, 75),
                Size = new Size(width - 40, 45),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label labelLabel = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(20, 125),
                Size = new Size(width - 40, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            card.Controls.AddRange(new Control[] { iconLabel, valueLabel, labelLabel });
            return card;
        }

        private Panel CreateRecentActivityPanel(int width)
        {
            Panel panel = new Panel
            {
                Size = new Size(width, 380),
                BackColor = Color.White
            };

            panel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid);
            };

            Label title = new Label
            {
                Text = "📊 Recent Activity",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(20, 20),
                AutoSize = true
            };

            ListBox activityList = new ListBox
            {
                Location = new Point(20, 60),
                Size = new Size(width - 40, 300),
                BackColor = Color.FromArgb(248, 249, 250),
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10F),
                ItemHeight = 35,
                DrawMode = DrawMode.OwnerDrawFixed
            };
            activityList.DrawItem += (s, e) => {
                if (e.Index < 0) return;
                e.DrawBackground();
                using (Brush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(activityList.Items[e.Index].ToString(),
                        e.Font, brush, e.Bounds.Left + 5, e.Bounds.Top + 8);
                }
            };

            LoadRecentActivity(activityList);

            panel.Controls.AddRange(new Control[] { title, activityList });
            return panel;
        }

        private Panel CreateQuickActionsPanel(int width)
        {
            Panel panel = new Panel
            {
                Size = new Size(width, 380),
                BackColor = Color.White
            };

            panel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid);
            };

            Label title = new Label
            {
                Text = "⚡ Quick Actions",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(20, 20),
                AutoSize = true
            };
            panel.Controls.Add(title);

            var actions = new[]
            {
                new { Icon = "📝", Text = "Request Certificate", Color = Color.FromArgb(0, 123, 255), Handler = "SubmitRequest" },
                new { Icon = "📊", Text = "File a Report", Color = Color.FromArgb(220, 53, 69), Handler = "FileReport" },
                new { Icon = "📋", Text = "View My Requests", Color = Color.FromArgb(40, 167, 69), Handler = "MyRequests" },
                new { Icon = "📰", Text = "Read News", Color = Color.FromArgb(255, 193, 7), Handler = "News" }
            };

            int yPos = 70;
            foreach (var action in actions)
            {
                Button btn = new Button
                {
                    Text = $"{action.Icon}  {action.Text}",
                    Size = new Size(width - 40, 55),
                    Location = new Point(20, yPos),
                    BackColor = action.Color,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(15, 0, 0, 0),
                    Cursor = Cursors.Hand,
                    Tag = action.Handler
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += QuickAction_Click;
                btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Dark(action.Color, 0.1f);
                btn.MouseLeave += (s, e) => btn.BackColor = action.Color;

                panel.Controls.Add(btn);
                yPos += 70;
            }

            return panel;
        }

        private void QuickAction_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is string handler)
            {
                NavigationRequested?.Invoke(this, handler);
            }
        }

        private void LoadRecentActivity(ListBox listBox)
        {
            listBox.Items.Clear();
            var activities = new List<string>();

            try
            {
                var requests = DatabaseHelper.GetUserRequests(currentUser.Id)
                    .OrderByDescending(r => r.CreatedDate)
                    .Take(5);

                foreach (var req in requests)
                {
                    activities.Add($"📋 {req.RequestType} - {req.Status} ({req.CreatedDate:MMM dd})");
                }

                var reports = DatabaseHelper.GetUserReports(currentUser.Id)
                    .OrderByDescending(r => r.CreatedDate)
                    .Take(5);

                foreach (var rep in reports)
                {
                    activities.Add($"📊 {rep.ReportType} - {rep.Status} ({rep.CreatedDate:MMM dd})");
                }
            }
            catch (Exception ex)
            {
                activities.Add($"Error: {ex.Message}");
            }

            if (activities.Any())
            {
                foreach (var activity in activities.Take(8))
                {
                    listBox.Items.Add(activity);
                }
            }
            else
            {
                listBox.Items.Add("No recent activity");
            }
        }

        private int GetUserPendingRequestsCount()
        {
            try
            {
                return DatabaseHelper.GetUserRequests(currentUser.Id).Count(r => r.Status == "Pending");
            }
            catch { return 0; }
        }

        private int GetUserApprovedRequestsCount()
        {
            try
            {
                return DatabaseHelper.GetUserRequests(currentUser.Id).Count(r => r.Status == "Approved");
            }
            catch { return 0; }
        }

        private int GetUserActiveReportsCount()
        {
            try
            {
                return DatabaseHelper.GetUserReports(currentUser.Id).Count(r => r.Status == "Open");
            }
            catch { return 0; }
        }

        private string GetTimeOfDay()
        {
            int hour = DateTime.Now.Hour;
            if (hour < 12) return "Morning";
            if (hour < 17) return "Afternoon";
            return "Evening";
        }
    }
}