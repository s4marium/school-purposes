using System;
using System.Collections.Generic;

namespace BarangayManagementSystem.Models
{
    // Notification System
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; } // Info, Warning, Success, Error
        public bool IsRead { get; set; }
        public bool IsBroadcast { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ReadDate { get; set; }
        public int CreatedBy { get; set; }
    }

    // Barangay Officials
    public class BarangayOfficial
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ProfileImage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public string Responsibilities { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }

    // Blotter Records
    public class Blotter
    {
        public int Id { get; set; }
        public string IncidentType { get; set; }
        public string Description { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Location { get; set; }
        public string Complainant { get; set; }
        public string ComplainantContact { get; set; }
        public string Respondent { get; set; }
        public string RespondentContact { get; set; }
        public string Status { get; set; } // Filed, Under Investigation, Resolved, Dismissed
        public string Resolution { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public int? ResolvedBy { get; set; }
        public string AttachedDocuments { get; set; }
        public string Witnesses { get; set; }
        public string Remarks { get; set; }
    }

    // News and Announcements
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string Category { get; set; } // Announcement, News, Event, Emergency
        public string FeaturedImage { get; set; }
        public List<string> Images { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsUrgent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ViewCount { get; set; }
        public string Tags { get; set; }
        public string TargetAudience { get; set; } // All, Residents, Businesses
    }

    // System Settings
    public class SystemSettings
    {
        public int Id { get; set; }
        public string BarangayName { get; set; }
        public string BarangayLogo { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Captain { get; set; }
        public string Secretary { get; set; }
        public string Treasurer { get; set; }
        public Dictionary<string, string> CertificateTemplates { get; set; }
        public Dictionary<string, decimal> ServiceFees { get; set; }
        public string SystemTheme { get; set; }
        public bool EnableNotifications { get; set; }
        public bool EnableSMSNotifications { get; set; }
        public bool EnableEmailNotifications { get; set; }
        public DateTime LastUpdated { get; set; }
        public int UpdatedBy { get; set; }
    }

    // Print Templates
    public class PrintTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Template { get; set; }
        public string Variables { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }

    // Activity Logs
    public class ActivityLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public string Module { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IPAddress { get; set; }
    }

    // Image Files
    public class ImageFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string ReferenceType { get; set; } // News, Official, Profile, etc.
        public int ReferenceId { get; set; }
        public DateTime UploadDate { get; set; }
        public int UploadedBy { get; set; }
    }
}