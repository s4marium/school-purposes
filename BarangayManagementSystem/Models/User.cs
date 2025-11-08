using System;

namespace BarangayManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class Request
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RequestType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public int? ProcessedBy { get; set; }
        public string UserName { get; set; }
    }

    public class Report
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ReportType { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public int? ResolvedBy { get; set; }
        public string UserName { get; set; }
    }
}