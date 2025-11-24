using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Controls  // CHANGED: From .Forms to .Controls
{
    public class NotificationPanel
    {
        private User currentUser;
        private int unreadCount;

        public NotificationPanel(User user)
        {
            currentUser = user;
            RefreshUnreadCount();
        }

        public Button CreateNotificationButton()
        {
            Button notifBtn = new Button
            {
                Text = "🔔",
                Font = new Font("Segoe UI Emoji", 16F),
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(108, 117, 125),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Size = new Size(40, 40)
            };
            notifBtn.FlatAppearance.BorderSize = 0;

            // Add badge for unread notifications
            if (unreadCount > 0)
            {
                notifBtn.Paint += (s, e) => {
                    // Draw notification badge
                    using (Brush brush = new SolidBrush(Color.FromArgb(220, 53, 69)))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillEllipse(brush, 25, 5, 15, 15);
                    }
                    
                    using (Font font = new Font("Segoe UI", 8F, FontStyle.Bold))
                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        string badgeText = unreadCount > 9 ? "9+" : unreadCount.ToString();
                        SizeF textSize = e.Graphics.MeasureString(badgeText, font);
                        e.Graphics.DrawString(badgeText, font, textBrush,
                            32.5f - textSize.Width / 2, 12.5f - textSize.Height / 2);
                    }
                };
            }

            notifBtn.Click += (s, e) => ShowNotifications();
            return notifBtn;
        }

        private void RefreshUnreadCount()
        {
            try
            {
                unreadCount = EnhancedDatabaseHelper.GetUnreadNotificationCount(currentUser.Id);
            }
            catch
            {
                unreadCount = 0;
            }
        }

        public void ShowNotifications()
        {
            try
            {
                Form notifForm = new Form
                {
                    Text = "Notifications",
                    Size = new Size(500, 600),
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = Color.White
                };

                Panel headerPanel = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 60,
                    BackColor = Color.FromArgb(40, 167, 69)
                };

                Label headerLabel = new Label
                {
                    Text = "🔔 Notifications",
                    Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(20, 15),
                    Size = new Size(300, 30)
                };

                Button markAllReadBtn = new Button
                {
                    Text = "Mark All Read",
                    Font = new Font("Segoe UI", 9F),
                    Location = new Point(350, 15),
                    Size = new Size(120, 30),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(40, 167, 69),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                markAllReadBtn.FlatAppearance.BorderSize = 1;
                markAllReadBtn.Click += (s, e) => {
                    EnhancedDatabaseHelper.MarkAllNotificationsRead(currentUser.Id);
                    RefreshUnreadCount();
                    notifForm.Close();
                };

                headerPanel.Controls.AddRange(new Control[] { headerLabel, markAllReadBtn });

                FlowLayoutPanel notifFlow = new FlowLayoutPanel
                {
                    Location = new Point(0, 60),
                    Size = new Size(484, 480),
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    BackColor = Color.FromArgb(248, 249, 250)
                };

                var notifications = EnhancedDatabaseHelper.GetUserNotifications(currentUser.Id, false);
                // Limit to 20 most recent
                if (notifications != null && notifications.Count > 20)
                {
                    notifications = notifications.Take(20).ToList();
                }
                
                if (notifications != null && notifications.Count > 0)
                {
                    foreach (var notification in notifications)
                    {
                        Panel notifCard = CreateNotificationCard(notification);
                        notifFlow.Controls.Add(notifCard);
                    }
                }
                else
                {
                    Label noNotif = new Label
                    {
                        Text = "No notifications",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.FromArgb(108, 117, 125),
                        Location = new Point(20, 20),
                        Size = new Size(400, 30)
                    };
                    notifFlow.Controls.Add(noNotif);
                }

                notifForm.Controls.AddRange(new Control[] { headerPanel, notifFlow });
                notifForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading notifications: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateNotificationCard(Notification notification)
        {
            Panel card = new Panel
            {
                Size = new Size(460, 80),
                BackColor = notification.IsRead ? Color.White : Color.FromArgb(233, 246, 251),
                Margin = new Padding(10, 5, 10, 5),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label typeIcon = new Label
            {
                Text = GetNotificationIcon(notification.Type),
                Font = new Font("Segoe UI Emoji", 20F),
                Location = new Point(15, 15),
                Size = new Size(30, 30)
            };

            Label titleLabel = new Label
            {
                Text = notification.Title ?? "Notification",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(55, 10),
                Size = new Size(350, 20)
            };

            Label messageLabel = new Label
            {
                Text = notification.Message ?? "",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(55, 30),
                Size = new Size(350, 30),
                AutoEllipsis = true
            };

            Label dateLabel = new Label
            {
                Text = notification.CreatedDate.ToString("MMM dd, HH:mm"),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(173, 181, 189),
                Location = new Point(55, 55),
                Size = new Size(100, 15)
            };

            if (!notification.IsRead)
            {
                Panel unreadDot = new Panel
                {
                    Size = new Size(8, 8),
                    Location = new Point(420, 20),
                    BackColor = Color.FromArgb(220, 53, 69)
                };
                unreadDot.Paint += (s, e) => {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Brush brush = new SolidBrush(unreadDot.BackColor))
                    {
                        e.Graphics.FillEllipse(brush, 0, 0, unreadDot.Width, unreadDot.Height);
                    }
                };
                card.Controls.Add(unreadDot);
            }

            card.Controls.AddRange(new Control[] { typeIcon, titleLabel, messageLabel, dateLabel });

            card.Click += (s, e) => {
                if (!notification.IsRead)
                {
                    EnhancedDatabaseHelper.MarkNotificationRead(notification.Id);
                    RefreshUnreadCount();
                }
            };

            return card;
        }

        private string GetNotificationIcon(string type)
        {
            switch (type?.ToLower())
            {
                case "success": return "✅";
                case "warning": return "⚠️";
                case "error": return "❌";
                case "info": return "ℹ️";
                default: return "📢";
            }
        }
    }
}