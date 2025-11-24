using System;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.User
{
    public partial class SubmitRequestForm : Form
    {
        private Models.User currentUser;

        public SubmitRequestForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void SubmitRequestForm_Load(object sender, EventArgs e)
        {
            // Form is ready
        }

        private void CmbRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var settings = EnhancedDatabaseHelper.GetSystemSettings();
                if (settings != null && settings.ServiceFees != null && 
                    settings.ServiceFees.ContainsKey(cmbRequestType.Text))
                {
                    lblFeeInfo.Text = $"💰 Processing Fee: ₱{settings.ServiceFees[cmbRequestType.Text]:N2}";
                }
                else
                {
                    lblFeeInfo.Text = "💰 Processing Fee: ₱50.00";
                }
            }
            catch
            {
                lblFeeInfo.Text = "💰 Processing Fee: ₱50.00";
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbRequestType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a request type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPurpose.Text))
            {
                MessageBox.Show("Please enter the purpose of your request.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var request = new Request
            {
                UserId = currentUser.Id,
                RequestType = cmbRequestType.Text,
                Description = $"Purpose: {txtPurpose.Text}\n\nDetails: {txtDescription.Text}"
            };

            if (DatabaseHelper.CreateRequest(request))
            {
                EnhancedDatabaseHelper.CreateNotification(new Notification
                {
                    UserId = currentUser.Id,
                    Title = "Request Submitted",
                    Message = $"Your {request.RequestType} request has been submitted successfully.",
                    Type = "Success",
                    Category = "Request",
                    CreatedBy = currentUser.Id
                });

                EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Submit Request", "Requests",
                    $"Submitted {cmbRequestType.Text} request");

                MessageBox.Show("Request submitted successfully! You will be notified once processed.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to submit request. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cmbRequestType.SelectedIndex = -1;
            txtPurpose.Clear();
            txtDescription.Clear();
            lblFeeInfo.Text = "💰 Processing Fee: ₱50.00";
        }
    }
}