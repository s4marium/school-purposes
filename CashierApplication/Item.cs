using System;

namespace CashierApplication.ItemNamespace
{
    public abstract class Item
    {
        protected string item_name;
        protected double item_price;
        protected int item_quantity;
        private double total_price;
        protected double TotalPrice
        {
            get { return total_price; }
            set { total_price = value; }
        }

        public Item(string name, double price, int quantity)
        {
            item_name = name;
            item_price = price;
            item_quantity = quantity;
        }

        public abstract double getTotalPrice();

        public virtual void setPayment(double amount)
        {

        }
    }
}