using System;

namespace BarangayManagementSystem.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ReportType { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Open, Under Review, Resolved, Closed
        public DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
    }
}