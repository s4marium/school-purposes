using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class AnnouncementManagementForm : Form
    {
        private Models.User currentUser;

        public AnnouncementManagementForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void AnnouncementManagementForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadAnnouncements();
        }

        private void ConfigureDataGridView()
        {
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 193, 7);
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAnnouncements.EnableHeadersVisualStyles = false;
            dgvAnnouncements.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvAnnouncements.Font = new Font("Segoe UI", 10F);
        }

        private void LoadAnnouncements()
        {
            try
            {
                var announcements = EnhancedDatabaseHelper.GetRecentAnnouncements(20);

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Title", typeof(string));
                dataTable.Columns.Add("Message", typeof(string));
                dataTable.Columns.Add("Published Date", typeof(DateTime));

                foreach (var announcement in announcements)
                {
                    dataTable.Rows.Add(
                        announcement.Id,
                        announcement.Title,
                        announcement.Message.Length > 100 ? announcement.Message.Substring(0, 100) + "..." : announcement.Message,
                        announcement.CreatedDate
                    );
                }

                dgvAnnouncements.DataSource = dataTable;

                if (dgvAnnouncements.Columns["Id"] != null)
                    dgvAnnouncements.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading announcements: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var announcement = new Announcement
            {
                Title = txtTitle.Text.Trim(),
                Message = txtMessage.Text.Trim(),
                CreatedBy = currentUser.Id
            };

            if (EnhancedDatabaseHelper.CreateAnnouncement(announcement))
            {
                // Create notifications for all users
                var allUsers = DatabaseHelper.GetAllUsers().Where(u => u.UserType == "User").ToList();
                foreach (var user in allUsers)
                {
                    EnhancedDatabaseHelper.CreateNotification(new Notification
                    {
                        UserId = user.Id,
                        Title = announcement.Title,
                        Message = announcement.Message,
                        Type = "Info",
                        Category = "Announcement",
                        CreatedBy = currentUser.Id
                    });
                }

                EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Publish Announcement", "Announcements",
                    $"Published: {announcement.Title}");

                MessageBox.Show($"Announcement published successfully to {allUsers.Count} residents!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTitle.Clear();
                txtMessage.Clear();
                LoadAnnouncements();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnnouncements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an announcement to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int announcementId = Convert.ToInt32(dgvAnnouncements.SelectedRows[0].Cells["Id"].Value);
            string title = dgvAnnouncements.SelectedRows[0].Cells["Title"].Value.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete announcement '{title}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (EnhancedDatabaseHelper.DeleteAnnouncement(announcementId))
                {
                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Delete Announcement", "Announcements",
                        $"Deleted: {title}");
                    MessageBox.Show("Announcement deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAnnouncements();
                }
            }
        }
    }
}