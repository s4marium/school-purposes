using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.Admin
{
    public partial class RequestManagementForm : Form
    {
        private Models.User currentUser;

        public RequestManagementForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void RequestManagementForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            cmbStatusFilter.SelectedIndex = 0;
            cmbTypeFilter.SelectedIndex = 0;
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

        private void LoadRequests(string statusFilter = "All Status", string typeFilter = "All Types")
        {
            try
            {
                var requests = DatabaseHelper.GetAllRequests();

                // Apply filters
                if (statusFilter != "All Status")
                    requests = requests.Where(r => r.Status == statusFilter).ToList();

                if (typeFilter != "All Types")
                    requests = requests.Where(r => r.RequestType == typeFilter).ToList();

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("User", typeof(string));
                dataTable.Columns.Add("Request Type", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Date Submitted", typeof(DateTime));
                dataTable.Columns.Add("Date Processed", typeof(string));

                foreach (var request in requests.OrderByDescending(r => r.CreatedDate))
                {
                    var user = DatabaseHelper.GetUserById(request.UserId);
                    dataTable.Rows.Add(
                        request.Id,
                        user != null ? user.FullName : "Unknown",
                        request.RequestType,
                        request.Status,
                        request.CreatedDate,
                        request.ProcessedDate.HasValue ? request.ProcessedDate.Value.ToString("MMM dd, yyyy") : "Pending"
                    );
                }

                dgvRequests.DataSource = dataTable;

                if (dgvRequests.Columns["Id"] != null)
                    dgvRequests.Columns["Id"].Visible = false;

                // Color code status
                foreach (DataGridViewRow row in dgvRequests.Rows)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    switch (status)
                    {
                        case "Pending":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                            break;
                        case "Processing":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(209, 236, 241);
                            break;
                        case "Approved":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 218);
                            break;
                        case "Rejected":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(248, 215, 218);
                            break;
                    }
                }

                UpdateStatistics(requests);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading requests: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics(System.Collections.Generic.List<Request> requests)
        {
            int total = requests.Count;
            int pending = requests.Count(r => r.Status == "Pending");
            int today = requests.Count(r => r.CreatedDate.Date == DateTime.Now.Date);

            lblStats.Text = $"Total Requests: {total} | Pending: {pending} | Today: {today}";
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRequests(cmbStatusFilter.Text, cmbTypeFilter.Text);
        }

        private void CmbTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRequests(cmbStatusFilter.Text, cmbTypeFilter.Text);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            cmbStatusFilter.SelectedIndex = 0;
            cmbTypeFilter.SelectedIndex = 0;
            LoadRequests();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to approve.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int requestId = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["Id"].Value);
            string requestType = dgvRequests.SelectedRows[0].Cells["Request Type"].Value.ToString();
            string userName = dgvRequests.SelectedRows[0].Cells["User"].Value.ToString();

            DialogResult result = MessageBox.Show($"Approve '{requestType}' request from {userName}?",
                "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (DatabaseHelper.UpdateRequestStatus(requestId, "Approved", currentUser.Id))
                {
                    var request = DatabaseHelper.GetAllRequests().FirstOrDefault(r => r.Id == requestId);
                    if (request != null)
                    {
                        EnhancedDatabaseHelper.CreateNotification(new Notification
                        {
                            UserId = request.UserId,
                            Title = "Request Approved",
                            Message = $"Your {request.RequestType} request has been approved.",
                            Type = "Success",
                            Category = "Request",
                            CreatedBy = currentUser.Id
                        });
                    }

                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Approve Request", "Requests",
                        $"Approved {requestType} request from {userName}");

                    MessageBox.Show("Request approved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRequests(cmbStatusFilter.Text, cmbTypeFilter.Text);
                }
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to reject.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int requestId = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["Id"].Value);
            string requestType = dgvRequests.SelectedRows[0].Cells["Request Type"].Value.ToString();
            string userName = dgvRequests.SelectedRows[0].Cells["User"].Value.ToString();

            DialogResult result = MessageBox.Show($"Reject '{requestType}' request from {userName}?",
                "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (DatabaseHelper.UpdateRequestStatus(requestId, "Rejected", currentUser.Id))
                {
                    var request = DatabaseHelper.GetAllRequests().FirstOrDefault(r => r.Id == requestId);
                    if (request != null)
                    {
                        EnhancedDatabaseHelper.CreateNotification(new Notification
                        {
                            UserId = request.UserId,
                            Title = "Request Rejected",
                            Message = $"Your {request.RequestType} request has been rejected.",
                            Type = "Warning",
                            Category = "Request",
                            CreatedBy = currentUser.Id
                        });
                    }

                    EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Reject Request", "Requests",
                        $"Rejected {requestType} request from {userName}");

                    MessageBox.Show("Request rejected!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRequests(cmbStatusFilter.Text, cmbTypeFilter.Text);
                }
            }
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to process.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int requestId = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["Id"].Value);

            if (DatabaseHelper.UpdateRequestStatus(requestId, "Processing", currentUser.Id))
            {
                MessageBox.Show("Request status updated to Processing!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequests(cmbStatusFilter.Text, cmbTypeFilter.Text);
            }
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
            var requests = DatabaseHelper.GetAllRequests();
            var request = requests.FirstOrDefault(r => r.Id == requestId);

            if (request != null)
            {
                ShowRequestDetails(request);
            }
        }

        private void ShowRequestDetails(Request request)
        {
            var user = DatabaseHelper.GetUserById(request.UserId);

            Form detailsForm = new Form
            {
                Text = "Request Details",
                Size = new Size(650, 500),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            string details = $@"
REQUEST DETAILS

Request ID: #{request.Id}
Requested By: {user?.FullName ?? "Unknown"}
Contact: {user?.ContactNumber ?? "N/A"}

Request Type: {request.RequestType}
Status: {request.Status}

Date Submitted: {request.CreatedDate:MMMM dd, yyyy HH:mm}
{(request.ProcessedDate.HasValue ? $"Date Processed: {request.ProcessedDate:MMMM dd, yyyy HH:mm}" : "")}

Description:
{request.Description}
            ";

            TextBox txtDetails = new TextBox
            {
                Text = details,
                Font = new Font("Consolas", 10F),
                Location = new Point(30, 30),
                Size = new Size(590, 370),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button closeBtn = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(520, 415),
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