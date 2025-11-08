using System;
using System.Windows.Forms;
using EmployeeNamespace;

namespace EmployeeApplication
{
    public partial class frmComputeSalary : Form
    {
        private PartTimeEmployee employee;
        public frmComputeSalary()
        {
            InitializeComponent();
        }
        private void btnComputeSalary_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtDepartment.Text) ||
                    string.IsNullOrWhiteSpace(txtJobTitle.Text) ||
                    string.IsNullOrWhiteSpace(txtRatePerHour.Text) ||
                    string.IsNullOrWhiteSpace(txtTotalHours.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double ratePerHour;
                int totalHours;

                if (!double.TryParse(txtRatePerHour.Text, out ratePerHour) || ratePerHour < 0)
                {
                    MessageBox.Show("Please enter a valid rate per hour.", "Input Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtTotalHours.Text, out totalHours) || totalHours < 0)
                {
                    MessageBox.Show("Please enter a valid number of hours worked.", "Input Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                employee = new PartTimeEmployee(
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    txtDepartment.Text.Trim(),
                    txtJobTitle.Text.Trim()
                );

                employee.computeSalary(totalHours, ratePerHour);

                lblFirstNameDisplay.Text = employee.FirstName;
                lblLastNameDisplay.Text = employee.LastName;
                lblBasicSalaryDisplay.Text = employee.getSalary().ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
