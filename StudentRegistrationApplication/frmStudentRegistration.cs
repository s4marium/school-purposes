using System;
using System.Windows.Forms;

namespace StudentRegistrationApplication
{
    public partial class frmStudentRegistration : Form
    {
        public frmStudentRegistration()
        {
            InitializeComponent();
            dateOfBirth();
        }

        private void dateOfBirth()
        {
            for (int i = 1; i <= 31; i++)
            {
                cbDay.Items.Add(i.ToString());
            }

            for (int i = 1; i <= 12; i++)
            {
                cbMonth.Items.Add(i.ToString());
            }

            int currentYear = DateTime.Now.Year;
            for (int i = 1900; i <= currentYear; i++)
            {
                cbYear.Items.Add(i.ToString());
            }
        }

        private void btnRegisterStudent_Click(object sender, EventArgs e)
        {
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;

            string gender = "";
            if (rbMale.Checked)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked)
            {
                gender = "Female";
            }

            string day = cbDay.SelectedItem?.ToString() ?? "";
            string month = cbMonth.SelectedItem?.ToString() ?? "";
            string year = cbYear.SelectedItem?.ToString() ?? "";

            string message = $"Student name: {lastName} {firstName} {middleName}\n";
            message += $"Gender: {gender}\n";
            message += $"Date of birth: {month}/{day}/{year}";

            MessageBox.Show(message, "Student Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
