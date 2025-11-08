using System;
using System.Windows.Forms;
using CashierApplication.ItemNamespace;

namespace CashierApplication
{
    public partial class frmPurchaseDiscountedItem : Form
    {
        private DiscountedItem discountedItem;

        public frmPurchaseDiscountedItem()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                string itemName = txtItem.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);
                double discount = Convert.ToDouble(txtDiscount.Text);

                discountedItem = new DiscountedItem(itemName, price, quantity, discount);

                double totalAmount = discountedItem.getTotalPrice();

                txtTotalAmount.Text = totalAmount.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid values for price, quantity, and discount.", 
                              "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (discountedItem == null)
                {
                    MessageBox.Show("Please compute the total amount first.", 
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double paymentAmount = Convert.ToDouble(txtPaymentReceived.Text);

                discountedItem.setPayment(paymentAmount);

                double change = discountedItem.getChange();
                txtChange.Text = change.ToString("F2");

                if (change < 0)
                {
                    MessageBox.Show("Insufficient payment. Please enter a higher amount.", 
                                  "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid value for payment amount.", 
                              "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
