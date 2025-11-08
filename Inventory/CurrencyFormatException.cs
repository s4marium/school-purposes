using System;

namespace Inventory
{
    public class CurrencyFormatException : Exception
    {
        public CurrencyFormatException(string varName) : base(varName)
        {
        }
    }
}