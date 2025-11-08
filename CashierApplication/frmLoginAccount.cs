using System;
using System.Windows.Forms;
using CashierApplication.UserAccountNamespace;

namespace CashierApplication
{
    public partial class frmLoginAccount : Form
    {
        private Cashier cashier;

        public frmLoginAccount()
        {
            InitializeComponent();
            cashier = new Cashier("Samuel Polizon", "Finance", "finance@samuel", "123456");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (cashier.validateLogin(username, password))
            {
                string welcomeMessage = $"Welcome {cashier.getFullName()} of {cashier.getDepartment()}";
                MessageBox.Show(welcomeMessage, "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                frmPurchaseDiscountedItem purchaseForm = new frmPurchaseDiscountedItem();
                purchaseForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void frmLoginAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}