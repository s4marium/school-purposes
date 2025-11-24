using System.Collections.Generic;

namespace BarangayManagementSystem.Models
{
    public class SystemSettings
    {
        public string BarangayName { get; set; }
        public string BarangayAddress { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public Dictionary<string, decimal> ServiceFees { get; set; }
    }
}