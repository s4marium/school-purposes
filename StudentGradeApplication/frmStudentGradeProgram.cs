using System;
using System.Windows.Forms;

namespace StudentGradeApplication
{
    public partial class frmStudentGradeProgram : Form
    {
        public frmStudentGradeProgram()
        {
            InitializeComponent();
        }

        private void btnGenerateAverage_Click(object sender, EventArgs e)
        {
            try
            {
                string studentName = txtName.Text;

                double english = double.Parse(txtEnglish.Text);
                double math = double.Parse(txtMath.Text);
                double science = double.Parse(txtScience.Text);
                double filipino = double.Parse(txtFilipino.Text);
                double history = double.Parse(txtHistory.Text);

                double average = (english + math + science + filipino + history) / 5;

                string result = (average >= 75.00) ? "The student passed." : "The student failed.";

                lblResult.Text = result + "\nThe general average of " + studentName + " is " + average.ToString("F2") + ".";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid grades for all subjects.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
