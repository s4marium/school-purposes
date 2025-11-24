-- ============================================
-- Barangay Management System Database
-- MySQL 8.0+ Compatible
-- ============================================

DROP DATABASE IF EXISTS barangay_management_db;
CREATE DATABASE barangay_management_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE barangay_management_db;

-- ============================================
-- Table: Users
-- ============================================
CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    ContactNumber VARCHAR(20),
    Address TEXT,
    UserType ENUM('Admin', 'User') DEFAULT 'User',
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    ModifiedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_username (Username),
    INDEX idx_usertype (UserType)
) ENGINE=InnoDB;

-- ============================================
-- Table: Requests
-- ============================================
CREATE TABLE Requests (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    RequestType VARCHAR(100) NOT NULL,
    Description TEXT,
    Status ENUM('Pending', 'Processing', 'Approved', 'Rejected') DEFAULT 'Pending',
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    ProcessedDate DATETIME NULL,
    ProcessedBy INT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProcessedBy) REFERENCES Users(Id) ON DELETE SET NULL,
    INDEX idx_userid (UserId),
    INDEX idx_status (Status)
) ENGINE=InnoDB;

-- ============================================
-- Table: Reports
-- ============================================
CREATE TABLE Reports (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    ReportType VARCHAR(100) NOT NULL,
    Subject VARCHAR(200) NOT NULL,
    Description TEXT NOT NULL,
    Status ENUM('Open', 'Under Review', 'Resolved', 'Closed') DEFAULT 'Open',
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    ResolvedDate DATETIME NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    INDEX idx_userid (UserId),
    INDEX idx_status (Status)
) ENGINE=InnoDB;

-- ============================================
-- Table: BarangayOfficials
-- ============================================
CREATE TABLE BarangayOfficials (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Position VARCHAR(100) NOT NULL,
    Department VARCHAR(100),
    ContactNumber VARCHAR(20),
    Email VARCHAR(100),
    Address TEXT,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,
    IsActive BOOLEAN DEFAULT TRUE,
    Responsibilities TEXT,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_position (Position),
    INDEX idx_isactive (IsActive)
) ENGINE=InnoDB;

-- ============================================
-- Table: News
-- ============================================
CREATE TABLE News (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(200) NOT NULL,
    Content TEXT NOT NULL,
    Category VARCHAR(50) DEFAULT 'General',
    PublishedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    CreatedBy INT NOT NULL,
    FOREIGN KEY (CreatedBy) REFERENCES Users(Id) ON DELETE CASCADE,
    INDEX idx_category (Category),
    INDEX idx_published (PublishedDate)
) ENGINE=InnoDB;

-- ============================================
-- Table: Announcements
-- ============================================
CREATE TABLE Announcements (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(200) NOT NULL,
    Message TEXT NOT NULL,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    CreatedBy INT NOT NULL,
    FOREIGN KEY (CreatedBy) REFERENCES Users(Id) ON DELETE CASCADE,
    INDEX idx_created (CreatedDate)
) ENGINE=InnoDB;

-- ============================================
-- Table: Notifications
-- ============================================
CREATE TABLE Notifications (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    Title VARCHAR(200) NOT NULL,
    Message TEXT NOT NULL,
    Type ENUM('Info', 'Success', 'Warning', 'Error') DEFAULT 'Info',
    Category VARCHAR(50) DEFAULT 'General',
    IsRead BOOLEAN DEFAULT FALSE,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    CreatedBy INT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (CreatedBy) REFERENCES Users(Id) ON DELETE SET NULL,
    INDEX idx_userid_read (UserId, IsRead),
    INDEX idx_created (CreatedDate)
) ENGINE=InnoDB;

-- ============================================
-- Table: ActivityLogs
-- ============================================
CREATE TABLE ActivityLogs (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    Action VARCHAR(100) NOT NULL,
    Module VARCHAR(50) NOT NULL,
    Description TEXT,
    IpAddress VARCHAR(45),
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    INDEX idx_userid (UserId),
    INDEX idx_action (Action),
    INDEX idx_created (CreatedDate)
) ENGINE=InnoDB;

-- ============================================
-- Table: SystemSettings
-- ============================================
CREATE TABLE SystemSettings (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    SettingKey VARCHAR(100) NOT NULL UNIQUE,
    SettingValue TEXT,
    Description VARCHAR(255),
    ModifiedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_key (SettingKey)
) ENGINE=InnoDB;

-- ============================================
-- Insert Default Admin User
-- Password: admin123 (hashed)
-- ============================================
INSERT INTO Users (Username, Password, FullName, UserType, IsActive) VALUES
('admin', 'admin123', 'System Administrator', 'Admin', TRUE);

-- ============================================
-- Insert Default System Settings
-- ============================================
INSERT INTO SystemSettings (SettingKey, SettingValue, Description) VALUES
('BarangayName', 'Barangay San Miguel', 'Official barangay name'),
('BarangayAddress', '123 Main Street, City, Province', 'Official barangay address'),
('ContactNumber', '+63 123 456 7890', 'Official contact number'),
('EmailAddress', 'barangay@example.com', 'Official email address'),
('ServiceFees', '{"Barangay Clearance":50,"Certificate of Residency":30,"Certificate of Indigency":0,"Business Permit":500,"Barangay ID":100}', 'Service fees in JSON format');

-- ============================================
-- Insert Sample Officials
-- ============================================
INSERT INTO BarangayOfficials (FullName, Position, Department, ContactNumber, Email, StartDate, IsActive) VALUES
('Juan Dela Cruz', 'Barangay Captain', 'Executive', '+63 912 345 6789', 'captain@barangay.com', '2023-01-01', TRUE),
('Maria Santos', 'Barangay Secretary', 'Administrative', '+63 912 345 6788', 'secretary@barangay.com', '2023-01-01', TRUE),
('Pedro Reyes', 'Barangay Treasurer', 'Finance', '+63 912 345 6787', 'treasurer@barangay.com', '2023-01-01', TRUE);

-- ============================================
-- Insert Sample News
-- ============================================
INSERT INTO News (Title, Content, Category, CreatedBy) VALUES
('Welcome to Barangay Management System', 'We are pleased to announce the launch of our new barangay management system. This platform will help streamline our services and improve communication with residents.', 'Announcement', 1),
('Community Clean-up Drive', 'Join us this Saturday for our monthly community clean-up drive. Let''s work together to keep our barangay clean and beautiful!', 'Event', 1);

-- ============================================
-- Create Views for Common Queries
-- ============================================

CREATE VIEW vw_PendingRequests AS
SELECT 
    r.Id,
    r.RequestType,
    r.Description,
    r.Status,
    r.CreatedDate,
    u.FullName AS RequesterName,
    u.ContactNumber AS RequesterContact
FROM Requests r
INNER JOIN Users u ON r.UserId = u.Id
WHERE r.Status = 'Pending'
ORDER BY r.CreatedDate DESC;

CREATE VIEW vw_OpenReports AS
SELECT 
    r.Id,
    r.ReportType,
    r.Subject,
    r.Status,
    r.CreatedDate,
    u.FullName AS ReporterName,
    u.ContactNumber AS ReporterContact
FROM Reports r
INNER JOIN Users u ON r.UserId = u.Id
WHERE r.Status = 'Open'
ORDER BY r.CreatedDate DESC;

CREATE VIEW vw_ActiveOfficials AS
SELECT 
    Id,
    FullName,
    Position,
    Department,
    ContactNumber,
    Email
FROM BarangayOfficials
WHERE IsActive = TRUE
ORDER BY 
    CASE Position
        WHEN 'Barangay Captain' THEN 1
        WHEN 'Barangay Secretary' THEN 2
        WHEN 'Barangay Treasurer' THEN 3
        ELSE 4
    END,
    FullName;

-- ============================================
-- Create Stored Procedures
-- ============================================

DELIMITER //

CREATE PROCEDURE sp_GetUserStatistics(IN userId INT)
BEGIN
    SELECT 
        (SELECT COUNT(*) FROM Requests WHERE UserId = userId AND Status = 'Pending') AS PendingRequests,
        (SELECT COUNT(*) FROM Requests WHERE UserId = userId AND Status = 'Approved') AS ApprovedRequests,
        (SELECT COUNT(*) FROM Reports WHERE UserId = userId AND Status = 'Open') AS OpenReports,
        (SELECT COUNT(*) FROM Notifications WHERE UserId = userId AND IsRead = FALSE) AS UnreadNotifications;
END //

CREATE PROCEDURE sp_GetAdminStatistics()
BEGIN
    SELECT 
        (SELECT COUNT(*) FROM Users WHERE IsActive = TRUE) AS TotalActiveUsers,
        (SELECT COUNT(*) FROM Requests WHERE Status = 'Pending') AS PendingRequests,
        (SELECT COUNT(*) FROM Reports WHERE Status = 'Open') AS OpenReports,
        (SELECT COUNT(*) FROM ActivityLogs WHERE DATE(CreatedDate) = CURDATE()) AS TodayActivities,
        (SELECT COUNT(*) FROM BarangayOfficials WHERE IsActive = TRUE) AS ActiveOfficials,
        (SELECT COUNT(*) FROM News) AS TotalNews;
END //

DELIMITER ;

-- ============================================
-- Database Setup Complete
-- ============================================

SELECT 'Database created successfully!' AS Status;
SELECT DATABASE() AS CurrentDatabase;
SHOW TABLES;