using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.User
{
    public partial class MyRequestsForm : Form
    {
        private Models.User currentUser;

        public MyRequestsForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void MyRequestsForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            cmbFilter.SelectedIndex = 0; // Select "All"
            LoadRequests();
        }

        private void ConfigureDataGridView()
        {
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 167, 69);
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvRequests.Font = new Font("Segoe UI", 10F);
        }

        private void LoadRequests(string filter = "All")
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
                dataTable.Columns.Add("Date Processed", typeof(string));

                foreach (var request in requests.OrderByDescending(r => r.CreatedDate))
                {
                    dataTable.Rows.Add(
                        request.Id,
                        request.RequestType,
                        request.Status,
                        request.CreatedDate,
                        request.ProcessedDate.HasValue ? 
                            request.ProcessedDate.Value.ToString("MMM dd, yyyy") : "Pending"
                    );
                }

                dgvRequests.DataSource = dataTable;

                if (dgvRequests.Columns["Id"] != null)
                    dgvRequests.Columns["Id"].Visible = false;

                // Apply row colors based on status
                foreach (DataGridViewRow row in dgvRequests.Rows)
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
                        case "Processing":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(209, 236, 241);
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

        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRequests(cmbFilter.Text);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequests(cmbFilter.Text);
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to view details.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int requestId = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["Id"].Value);
            var requests = DatabaseHelper.GetUserRequests(currentUser.Id);
            var request = requests.FirstOrDefault(r => r.Id == requestId);

            if (request != null)
            {
                ShowRequestDetails(request);
            }
        }

        private void ShowRequestDetails(Request request)
        {
            Form detailsForm = new Form
            {
                Text = "Request Details",
                Size = new Size(650, 450),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
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
{(request.Status == "Pending" ? "⏳ Your request is pending review." : "")}
{(request.Status == "Processing" ? "🔄 Your request is currently being processed." : "")}
            ";

            TextBox txtDetails = new TextBox
            {
                Text = details,
                Font = new Font("Consolas", 10F),
                Location = new Point(30, 30),
                Size = new Size(590, 320),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button closeBtn = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(520, 365),
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
    }
}