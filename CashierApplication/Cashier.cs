using System;

namespace CashierApplication.UserAccountNamespace
{
    public class Cashier : UserAccount
    {
        private string department;

        public Cashier(string name, string department, string uName, string password) 
            : base(name, uName, password)
        {
            this.department = department;
        }

        public override bool validateLogin(string uName, string password)
        {
            return user_name == uName && user_password == password;
        }

        public string getDepartment()
        {
            return department;
        }
    }
}