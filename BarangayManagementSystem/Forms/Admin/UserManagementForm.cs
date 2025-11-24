using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class UserManagementForm : Form
    {
        private Models.User currentUser;

        public UserManagementForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            cmbFilter.SelectedIndex = 0;
            LoadUsers();
        }

        private void ConfigureDataGridView()
        {
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvUsers.Font = new Font("Segoe UI", 10F);
        }

        private void LoadUsers(string filter = "All Users", string searchText = "")
        {
            try
            {
                var users = DatabaseHelper.GetAllUsers();

                // Apply filter
                if (filter == "Residents")
                    users = users.Where(u => u.UserType == "User").ToList();
                else if (filter == "Administrators")
                    users = users.Where(u => u.UserType == "Admin").ToList();
                else if (filter == "Active")
                    users = users.Where(u => u.IsActive).ToList();
                else if (filter == "Inactive")
                    users = users.Where(u => !u.IsActive).ToList();

                // Apply search
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    users = users.Where(u =>
                        u.FullName.ToLower().Contains(searchText.ToLower()) ||
                        u.Username.ToLower().Contains(searchText.ToLower()) ||
                        (u.Email != null && u.Email.ToLower().Contains(searchText.ToLower()))
                    ).ToList();
                }

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Full Name", typeof(string));
                dataTable.Columns.Add("Username", typeof(string));
                dataTable.Columns.Add("Email", typeof(string));
                dataTable.Columns.Add("Contact", typeof(string));
                dataTable.Columns.Add("User Type", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Created Date", typeof(DateTime));

                foreach (var user in users.OrderByDescending(u => u.CreatedDate))
                {
                    dataTable.Rows.Add(
                        user.Id,
                        user.FullName,
                        user.Username,
                        user.Email ?? "N/A",
                        user.ContactNumber ?? "N/A",
                        user.UserType,
                        user.IsActive ? "Active" : "Inactive",
                        user.CreatedDate
                    );
                }

                dgvUsers.DataSource = dataTable;

                if (dgvUsers.Columns["Id"] != null)
                    dgvUsers.Columns["Id"].Visible = false;

                // Color code status
                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (status == "Active")
                        row.Cells["Status"].Style.ForeColor = Color.FromArgb(40, 167, 69);
                    else
                        row.Cells["Status"].Style.ForeColor = Color.FromArgb(220, 53, 69);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers(cmbFilter.Text, txtSearch.Text);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers(cmbFilter.Text, txtSearch.Text);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilter.SelectedIndex = 0;
            LoadUsers();
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add User functionality will be implemented with a dedicated form.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Edit User functionality will be implemented with a dedicated form.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            string userName = dgvUsers.SelectedRows[0].Cells["Full Name"].Value.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete user '{userName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (DatabaseHelper.DeleteUser(userId))
                {
                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Delete User", "User Management",
                        $"Deleted user: {userName}");
                    MessageBox.Show("User deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers(cmbFilter.Text, txtSearch.Text);
                }
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to view details.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            var users = DatabaseHelper.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                ShowUserDetails(user);
            }
        }

        private void ShowUserDetails(Models.User user)
        {
            Form detailsForm = new Form
            {
                Text = $"User Details - {user.FullName}",
                Size = new Size(600, 500),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            string details = $@"
USER DETAILS

Full Name: {user.FullName}
Username: {user.Username}
Email: {user.Email ?? "Not provided"}
Contact Number: {user.ContactNumber ?? "Not provided"}
Address: {user.Address ?? "Not provided"}

User Type: {user.UserType}
Status: {(user.IsActive ? "Active" : "Inactive")}

Account Created: {user.CreatedDate:MMMM dd, yyyy HH:mm}
Last Modified: {user.ModifiedDate:MMMM dd, yyyy HH:mm}
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
                Location = new Point(470, 425),
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

        private void BtnToggleStatus_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to toggle status.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            string userName = dgvUsers.SelectedRows[0].Cells["Full Name"].Value.ToString();
            string currentStatus = dgvUsers.SelectedRows[0].Cells["Status"].Value.ToString();

            string newStatus = currentStatus == "Active" ? "Inactive" : "Active";

            DialogResult result = MessageBox.Show($"Change user '{userName}' status to {newStatus}?",
                "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (DatabaseHelper.ToggleUserStatus(userId))
                {
                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Toggle User Status", "User Management",
                        $"Changed {userName} status to {newStatus}");
                    MessageBox.Show($"User status changed to {newStatus}!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers(cmbFilter.Text, txtSearch.Text);
                }
            }
        }
    }
}