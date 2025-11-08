using System;

namespace Inventory
{
    public class StringFormatException : Exception
    {
        public StringFormatException(string varName) : base(varName)
        {
        }
    }
}