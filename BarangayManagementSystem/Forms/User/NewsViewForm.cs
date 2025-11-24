using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.User
{
    public partial class NewsViewForm : Form
    {
        private Models.User currentUser;

        public NewsViewForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void NewsViewForm_Load(object sender, EventArgs e)
        {
            LoadNews();
        }

        private void LoadNews()
        {
            newsFlowPanel.Controls.Clear();

            try
            {
                var newsList = EnhancedDatabaseHelper.GetAllNews()
                    .OrderByDescending(n => n.PublishedDate)
                    .ToList();

                if (newsList.Any())
                {
                    foreach (var news in newsList)
                    {
                        Panel newsCard = CreateNewsCard(news);
                        newsFlowPanel.Controls.Add(newsCard);
                    }
                }
                else
                {
                    Label noNews = new Label
                    {
                        Text = "No news available at the moment.",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.FromArgb(108, 117, 125),
                        AutoSize = true,
                        Margin = new Padding(10)
                    };
                    newsFlowPanel.Controls.Add(noNews);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading news: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateNewsCard(News news)
        {
            Panel card = new Panel
            {
                Width = 840,
                Height = 180,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 15)
            };

            Label categoryLabel = new Label
            {
                Text = $"📌 {news.Category}",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 123, 255),
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label titleLabel = new Label
            {
                Text = news.Title,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(20, 40),
                Size = new Size(800, 30),
                AutoEllipsis = true
            };

            Label contentLabel = new Label
            {
                Text = news.Content.Length > 200 ? news.Content.Substring(0, 200) + "..." : news.Content,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(20, 75),
                Size = new Size(800, 50)
            };

            Label dateLabel = new Label
            {
                Text = $"📅 Published: {news.PublishedDate:MMMM dd, yyyy}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(20, 135),
                AutoSize = true
            };

            Button viewBtn = new Button
            {
                Text = "Read More →",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(700, 130),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = news
            };
            viewBtn.FlatAppearance.BorderSize = 0;
            viewBtn.Click += ViewNewsDetails_Click;

            card.Controls.AddRange(new Control[] {
                categoryLabel, titleLabel, contentLabel, dateLabel, viewBtn
            });

            return card;
        }

        private void ViewNewsDetails_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is News news)
            {
                Form detailsForm = new Form
                {
                    Text = news.Title,
                    Size = new Size(700, 600),
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = Color.White
                };

                Panel contentPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    Padding = new Padding(30)
                };

                Label categoryLbl = new Label
                {
                    Text = $"📌 {news.Category}",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 123, 255),
                    Location = new Point(30, 30),
                    AutoSize = true
                };

                Label titleLbl = new Label
                {
                    Text = news.Title,
                    Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 58, 64),
                    Location = new Point(30, 60),
                    Size = new Size(620, 40),
                    AutoSize = false
                };

                Label dateLbl = new Label
                {
                    Text = $"📅 {news.PublishedDate:MMMM dd, yyyy HH:mm}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(108, 117, 125),
                    Location = new Point(30, 105),
                    AutoSize = true
                };

                TextBox contentTxt = new TextBox
                {
                    Text = news.Content,
                    Font = new Font("Segoe UI", 11F),
                    Location = new Point(30, 140),
                    Size = new Size(620, 350),
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.White
                };

                Button closeBtn = new Button
                {
                    Text = "Close",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    Location = new Point(550, 510),
                    Size = new Size(100, 35),
                    BackColor = Color.FromArgb(108, 117, 125),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                closeBtn.FlatAppearance.BorderSize = 0;
                closeBtn.Click += (s, args) => detailsForm.Close();

                contentPanel.Controls.AddRange(new Control[] {
                    categoryLbl, titleLbl, dateLbl, contentTxt, closeBtn
                });

                detailsForm.Controls.Add(contentPanel);
                detailsForm.ShowDialog();
            }
        }
    }
}