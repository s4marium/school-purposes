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