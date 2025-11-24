using System;

namespace BarangayManagementSystem.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RequestType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Pending, Processing, Approved, Rejected
        public DateTime CreatedDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public int? ProcessedBy { get; set; }
    }
}