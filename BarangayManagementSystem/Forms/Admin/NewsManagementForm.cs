using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class NewsManagementForm : Form
    {
        private Models.User currentUser;

        public NewsManagementForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void NewsManagementForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            cmbCategoryFilter.SelectedIndex = 0;
            LoadNews();
        }

        private void ConfigureDataGridView()
        {
            dgvNews.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 162, 184);
            dgvNews.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNews.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvNews.EnableHeadersVisualStyles = false;
            dgvNews.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvNews.Font = new Font("Segoe UI", 10F);
        }

        private void LoadNews(string category = "All Categories", string searchText = "")
        {
            try
            {
                var newsList = EnhancedDatabaseHelper.GetAllNews();

                if (category != "All Categories")
                    newsList = newsList.Where(n => n.Category == category).ToList();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    newsList = newsList.Where(n =>
                        n.Title.ToLower().Contains(searchText.ToLower()) ||
                        n.Content.ToLower().Contains(searchText.ToLower())
                    ).ToList();
                }

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Title", typeof(string));
                dataTable.Columns.Add("Category", typeof(string));
                dataTable.Columns.Add("Published Date", typeof(DateTime));
                dataTable.Columns.Add("Created By", typeof(string));

                foreach (var news in newsList.OrderByDescending(n => n.PublishedDate))
                {
                    var author = DatabaseHelper.GetUserById(news.CreatedBy);
                    dataTable.Rows.Add(
                        news.Id,
                        news.Title,
                        news.Category,
                        news.PublishedDate,
                        author != null ? author.FullName : "Unknown"
                    );
                }

                dgvNews.DataSource = dataTable;

                if (dgvNews.Columns["Id"] != null)
                    dgvNews.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading news: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNews(cmbCategoryFilter.Text, txtSearch.Text);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadNews(cmbCategoryFilter.Text, txtSearch.Text);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            LoadNews();
        }

        private void BtnAddNews_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add News functionality will be implemented with a dedicated form.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEditNews_Click(object sender, EventArgs e)
        {
            if (dgvNews.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a news item to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Edit News functionality will be implemented with a dedicated form.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDeleteNews_Click(object sender, EventArgs e)
        {
            if (dgvNews.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a news item to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int newsId = Convert.ToInt32(dgvNews.SelectedRows[0].Cells["Id"].Value);
            string title = dgvNews.SelectedRows[0].Cells["Title"].Value.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete news '{title}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (EnhancedDatabaseHelper.DeleteNews(newsId))
                {
                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Delete News", "News",
                        $"Deleted news: {title}");
                    MessageBox.Show("News deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNews(cmbCategoryFilter.Text, txtSearch.Text);
                }
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvNews.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a news item to view.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int newsId = Convert.ToInt32(dgvNews.SelectedRows[0].Cells["Id"].Value);
            var newsList = EnhancedDatabaseHelper.GetAllNews();
            var news = newsList.FirstOrDefault(n => n.Id == newsId);

            if (news != null)
            {
                ShowNewsDetails(news);
            }
        }

        private void ShowNewsDetails(News news)
        {
            var author = DatabaseHelper.GetUserById(news.CreatedBy);

            Form detailsForm = new Form
            {
                Text = news.Title,
                Size = new Size(700, 600),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
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
                Size = new Size(620, 40)
            };

            Label dateLbl = new Label
            {
                Text = $"📅 {news.PublishedDate:MMMM dd, yyyy HH:mm} | By: {author?.FullName ?? "Unknown"}",
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