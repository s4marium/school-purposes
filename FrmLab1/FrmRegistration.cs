using System;
using System.IO;
using System.Windows.Forms;

namespace FrmLab1
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string fileName = txtStudentNo.Text + ".txt";
            string fullPath = Path.Combine(docPath, fileName);

            string[] registrationData = new string[]
            {
                "Student No.:" + txtStudentNo.Text,
                "Full Name:" + txtLastName.Text + ", " + txtFirstName.Text + ", " + txtMiddleInitial.Text + ".",
                "Program: " + cbProgram.Text,
                "Gender: " + cbGender.Text,
                "Age: " + txtAge.Text,
                "Birthday: " + dtpBirthday.Value.ToString("yyyy-MM-dd"),
                "Contact No." + txtContactNo.Text
            };

            using (StreamWriter outputFile = new StreamWriter(fullPath))
            {
                foreach (string line in registrationData)
                {
                    outputFile.WriteLine(line);
                }
            }

            MessageBox.Show("Registration saved successfully!\nFile: " + fileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}