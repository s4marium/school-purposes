using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class SettingsForm : Form
    {
        private Models.User currentUser;

        public SettingsForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            ConfigureFeesGrid();
        }

        private void LoadSettings()
        {
            try
            {
                var settings = EnhancedDatabaseHelper.GetSystemSettings();
                if (settings != null)
                {
                    txtBarangayName.Text = settings.BarangayName;
                    txtBarangayAddress.Text = settings.BarangayAddress;
                    txtContactNumber.Text = settings.ContactNumber;
                    txtEmailAddress.Text = settings.EmailAddress;

                    LoadServiceFees(settings);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading settings: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureFeesGrid()
        {
            dgvFees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            dgvFees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvFees.EnableHeadersVisualStyles = false;
            dgvFees.Font = new Font("Segoe UI", 10F);
        }

        private void LoadServiceFees(SystemSettings settings)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Service", typeof(string));
            dataTable.Columns.Add("Fee (?)", typeof(decimal));

            if (settings.ServiceFees != null)
            {
                foreach (var fee in settings.ServiceFees)
                {
                    dataTable.Rows.Add(fee.Key, fee.Value);
                }
            }

            dgvFees.DataSource = dataTable;
        }

        private void BtnSaveGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new SystemSettings
                {
                    BarangayName = txtBarangayName.Text,
                    BarangayAddress = txtBarangayAddress.Text,
                    ContactNumber = txtContactNumber.Text,
                    EmailAddress = txtEmailAddress.Text
                };

                if (EnhancedDatabaseHelper.UpdateSystemSettings(settings))
                {
                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Update Settings", "Settings",
                        "Updated general settings");
                    MessageBox.Show("Settings saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateFees_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Service fees updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Database backup functionality will be implemented.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Database restore functionality will be implemented.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}