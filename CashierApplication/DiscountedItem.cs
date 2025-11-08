using System;

namespace CashierApplication.ItemNamespace
{
    public class DiscountedItem : Item
    {
        private double item_discount;
        private double discounted_price;
        private double payment_amount;
        private double change;

        public DiscountedItem(string name, double price, int quantity, double discount) 
            : base(name, price, quantity)
        {
            item_discount = discount;
        }

        public override double getTotalPrice()
        {
            discounted_price = item_price * (1 - item_discount / 100);
            TotalPrice = discounted_price * item_quantity;
            return TotalPrice;
        }

        public override void setPayment(double amount)
        {
            payment_amount = amount;
            change = payment_amount - TotalPrice;
        }

        public double getChange()
        {
            return change;
        }

        public string ItemName => item_name;
        public double ItemPrice => item_price;
        public int ItemQuantity => item_quantity;
        public double ItemDiscount => item_discount;
        public double DiscountedPrice => discounted_price;
        public double PaymentAmount => payment_amount;
        public double Change => change;
    }
}