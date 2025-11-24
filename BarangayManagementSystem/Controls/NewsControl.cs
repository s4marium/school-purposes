using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Controls
{
    public class NewsControl : UserControl
    {
        private User currentUser;
        private FlowLayoutPanel mainFlow;

        public NewsControl(User user)
        {
            currentUser = user;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.AutoScroll = true;
            InitializeUI();
            this.Resize += NewsControl_Resize;
        }

        private void NewsControl_Resize(object sender, EventArgs e)
        {
            if (mainFlow != null)
            {
                foreach (Control control in mainFlow.Controls)
                {
                    if (control is Panel && control.Tag is News)
                    {
                        int newWidth = Math.Max(Math.Min(this.Width - 60, 1200), 300);
                        control.Width = newWidth;
                        
                        // Update child control widths
                        foreach (Control child in control.Controls)
                        {
                            if (child is Label && child.Name != "categoryBadge")
                            {
                                child.Width = newWidth - 40;
                            }
                        }
                    }
                }
            }
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

            Label title = new Label
            {
                Text = "📰 News & Announcements",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 20)
            };
            mainFlow.Controls.Add(title);

            try
            {
                var newsList = EnhancedDatabaseHelper.GetPublishedNews();

                if (newsList != null && newsList.Any())
                {
                    int cardWidth = Math.Max(Math.Min(this.Width - 60, 1200), 300);
                    foreach (var news in newsList)
                    {
                        Panel newsCard = CreateNewsCard(news, cardWidth);
                        mainFlow.Controls.Add(newsCard);
                    }
                }
                else
                {
                    Label noNews = new Label
                    {
                        Text = "No news or announcements available at this time.",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.FromArgb(108, 117, 125),
                        AutoSize = true,
                        Margin = new Padding(0, 20, 0, 0)
                    };
                    mainFlow.Controls.Add(noNews);
                }
            }
            catch (Exception ex)
            {
                Label errorLabel = new Label
                {
                    Text = $"Error loading news: {ex.Message}",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.FromArgb(220, 53, 69),
                    AutoSize = true,
                    Margin = new Padding(0, 20, 0, 0)
                };
                mainFlow.Controls.Add(errorLabel);
            }

            this.Controls.Add(mainFlow);
        }

        private Panel CreateNewsCard(News news, int width)
        {
            Panel card = new Panel
            {
                Width = width,
                Height = 200,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 20),
                Tag = news
            };

            // Add shadow effect
            card.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid);
            };

            Label categoryBadge = new Label
            {
                Name = "categoryBadge",
                Text = news.Category?.ToUpper() ?? "NEWS",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = GetCategoryColor(news.Category ?? "News"),
                Location = new Point(20, 20),
                Size = new Size(120, 26),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label titleLabel = new Label
            {
                Text = news.Title ?? "No Title",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(20, 56),
                Size = new Size(width - 40, 35),
                AutoSize = false,
                AutoEllipsis = true
            };

            Label summaryLabel = new Label
            {
                Text = news.Summary ?? (news.Content != null && news.Content.Length > 150
                    ? news.Content.Substring(0, 150) + "..."
                    : news.Content ?? "No content available"),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(20, 96),
                Size = new Size(width - 40, 60),
                AutoSize = false
            };

            LinkLabel readMoreLink = new LinkLabel
            {
                Text = "Read more →",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                LinkColor = Color.FromArgb(0, 123, 255),
                Location = new Point(20, 165),
                AutoSize = true,
                Cursor = Cursors.Hand,
                Tag = news
            };
            readMoreLink.LinkClicked += ReadMoreLink_LinkClicked;

            card.Controls.AddRange(new Control[] { categoryBadge, titleLabel, summaryLabel, readMoreLink });
            return card;
        }

        private void ReadMoreLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender is LinkLabel link && link.Tag is News news)
            {
                ShowNewsDetails(news);
            }
        }

        private void ShowNewsDetails(News news)
        {
            try
            {
                EnhancedDatabaseHelper.IncrementNewsViewCount(news.Id);

                Form detailsForm = new Form
                {
                    Text = news.Title ?? "News Details",
                    Size = new Size(900, 700),
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = Color.White,
                    FormBorderStyle = FormBorderStyle.Sizable,
                    MinimumSize = new Size(700, 500)
                };

                Panel mainPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    BackColor = Color.White,
                    Padding = new Padding(40)
                };

                Label categoryLabel = new Label
                {
                    Text = (news.Category ?? "NEWS").ToUpper(),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = GetCategoryColor(news.Category ?? "News"),
                    Location = new Point(40, 40),
                    Size = new Size(130, 30),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label titleLabel = new Label
                {
                    Text = news.Title ?? "No Title",
                    Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 58, 64),
                    Location = new Point(40, 85),
                    AutoSize = true,
                    MaximumSize = new Size(800, 0)
                };

                Label dateLabel = new Label
                {
                    Text = $"Published on {news.PublishedDate:MMMM dd, yyyy} • {news.ViewCount} views",
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.FromArgb(108, 117, 125),
                    Location = new Point(40, titleLabel.Bottom + 10),
                    AutoSize = true
                };

                Panel separator = new Panel
                {
                    Location = new Point(40, dateLabel.Bottom + 20),
                    Size = new Size(800, 2),
                    BackColor = Color.FromArgb(222, 226, 230)
                };

                TextBox contentBox = new TextBox
                {
                    Text = news.Content ?? "No content available.",
                    Font = new Font("Segoe UI", 11F),
                    Location = new Point(40, separator.Bottom + 20),
                    Size = new Size(800, 400),
                    Multiline = true,
                    ReadOnly = true,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.White,
                    ScrollBars = ScrollBars.Vertical
                };

                Button closeBtn = new Button
                {
                    Text = "Close",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    Location = new Point(740, contentBox.Bottom + 20),
                    Size = new Size(120, 40),
                    BackColor = Color.FromArgb(108, 117, 125),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                closeBtn.FlatAppearance.BorderSize = 0;
                closeBtn.Click += (s, e) => detailsForm.Close();

                mainPanel.Controls.AddRange(new Control[] {
                    categoryLabel, titleLabel, dateLabel, separator, contentBox, closeBtn
                });
                detailsForm.Controls.Add(mainPanel);
                detailsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing news details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Color GetCategoryColor(string category)
        {
            switch (category?.ToLower())
            {
                case "news": return Color.FromArgb(0, 123, 255);
                case "announcement": return Color.FromArgb(255, 193, 7);
                case "event": return Color.FromArgb(40, 167, 69);
                case "emergency": return Color.FromArgb(220, 53, 69);
                default: return Color.FromArgb(108, 117, 125);
            }
        }
    }
}