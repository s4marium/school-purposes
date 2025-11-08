using System;

namespace Inventory
{
    public class NumberFormatException : Exception
    {
        public NumberFormatException(string varName) : base(varName)
        {
        }
    }
}