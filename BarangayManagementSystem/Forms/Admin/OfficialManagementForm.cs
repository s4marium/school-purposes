using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class OfficialManagementForm : Form
    {
        private Models.User currentUser;

        public OfficialManagementForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void OfficialManagementForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadOfficials();
        }

        private void ConfigureDataGridView()
        {
            dgvOfficials.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(111, 66, 193);
            dgvOfficials.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOfficials.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvOfficials.EnableHeadersVisualStyles = false;
            dgvOfficials.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvOfficials.Font = new Font("Segoe UI", 10F);
        }

        private void LoadOfficials(string searchText = "")
        {
            try
            {
                var officials = EnhancedDatabaseHelper.GetAllOfficials();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    officials = officials.Where(o =>
                        o.FullName.ToLower().Contains(searchText.ToLower()) ||
                        o.Position.ToLower().Contains(searchText.ToLower()) ||
                        (o.Department != null && o.Department.ToLower().Contains(searchText.ToLower()))
                    ).ToList();
                }

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Full Name", typeof(string));
                dataTable.Columns.Add("Position", typeof(string));
                dataTable.Columns.Add("Department", typeof(string));
                dataTable.Columns.Add("Contact", typeof(string));
                dataTable.Columns.Add("Start Date", typeof(DateTime));
                dataTable.Columns.Add("Status", typeof(string));

                foreach (var official in officials.OrderByDescending(o => o.IsActive).ThenBy(o => o.Position))
                {
                    dataTable.Rows.Add(
                        official.Id,
                        official.FullName,
                        official.Position,
                        official.Department ?? "N/A",
                        official.ContactNumber ?? "N/A",
                        official.StartDate,
                        official.IsActive ? "Active" : "Inactive"
                    );
                }

                dgvOfficials.DataSource = dataTable;

                if (dgvOfficials.Columns["Id"] != null)
                    dgvOfficials.Columns["Id"].Visible = false;

                foreach (DataGridViewRow row in dgvOfficials.Rows)
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
                MessageBox.Show($"Error loading officials: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadOfficials(txtSearch.Text);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadOfficials();
        }

        private void BtnAddOfficial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Official functionality will be implemented with a dedicated form.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEditOfficial_Click(object sender, EventArgs e)
        {
            if (dgvOfficials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an official to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Edit Official functionality will be implemented with a dedicated form.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDeleteOfficial_Click(object sender, EventArgs e)
        {
            if (dgvOfficials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an official to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int officialId = Convert.ToInt32(dgvOfficials.SelectedRows[0].Cells["Id"].Value);
            string officialName = dgvOfficials.SelectedRows[0].Cells["Full Name"].Value.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete official '{officialName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (EnhancedDatabaseHelper.DeleteOfficial(officialId))
                {
                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Delete Official", "Officials",
                        $"Deleted official: {officialName}");
                    MessageBox.Show("Official deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOfficials(txtSearch.Text);
                }
            }
        }

        private void BtnToggleStatus_Click(object sender, EventArgs e)
        {
            if (dgvOfficials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an official to toggle status.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int officialId = Convert.ToInt32(dgvOfficials.SelectedRows[0].Cells["Id"].Value);
            string officialName = dgvOfficials.SelectedRows[0].Cells["Full Name"].Value.ToString();
            string currentStatus = dgvOfficials.SelectedRows[0].Cells["Status"].Value.ToString();
            string newStatus = currentStatus == "Active" ? "Inactive" : "Active";

            DialogResult result = MessageBox.Show($"Change '{officialName}' status to {newStatus}?",
                "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (EnhancedDatabaseHelper.ToggleOfficialStatus(officialId))
                {
                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Toggle Official Status", "Officials",
                        $"Changed {officialName} status to {newStatus}");
                    MessageBox.Show($"Official status changed to {newStatus}!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOfficials(txtSearch.Text);
                }
            }
        }
    }
}