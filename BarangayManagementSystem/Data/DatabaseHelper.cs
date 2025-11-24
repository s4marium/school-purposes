using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Data
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Database=barangay_management_db;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static void SetConnectionString(string server, string database, string username, string password)
        {
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        // ============================================
        // User Methods
        // ============================================
        
        public static User AuthenticateUser(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password AND IsActive = TRUE";
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32("Id"),
                                Username = reader.GetString("Username"),
                                Password = reader.GetString("Password"),
                                FullName = reader.GetString("FullName"),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
                                ContactNumber = reader.IsDBNull(reader.GetOrdinal("ContactNumber")) ? null : reader.GetString("ContactNumber"),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString("Address"),
                                UserType = reader.GetString("UserType"),
                                IsActive = reader.GetBoolean("IsActive"),
                                CreatedDate = reader.GetDateTime("CreatedDate"),
                                ModifiedDate = reader.GetDateTime("ModifiedDate")
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool RegisterUser(User user)
        {
            string query = @"INSERT INTO Users (Username, Password, FullName, Email, ContactNumber, Address, UserType, IsActive) 
                            VALUES (@Username, @Password, @FullName, @Email, @ContactNumber, @Address, @UserType, @IsActive)";
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@FullName", user.FullName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@ContactNumber", user.ContactNumber);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@UserType", user.UserType);
                    cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users ORDER BY CreatedDate DESC";
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32("Id"),
                            Username = reader.GetString("Username"),
                            Password = reader.GetString("Password"),
                            FullName = reader.GetString("FullName"),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
                            ContactNumber = reader.IsDBNull(reader.GetOrdinal("ContactNumber")) ? null : reader.GetString("ContactNumber"),
                            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString("Address"),
                            UserType = reader.GetString("UserType"),
                            IsActive = reader.GetBoolean("IsActive"),
                            CreatedDate = reader.GetDateTime("CreatedDate"),
                            ModifiedDate = reader.GetDateTime("ModifiedDate")
                        });
                    }
                }
            }
            return users;
        }

        public static User GetUserById(int userId)
        {
            return GetAllUsers().FirstOrDefault(u => u.Id == userId);
        }

        public static bool DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE Id = @Id";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool ToggleUserStatus(int userId)
        {
            string query = "UPDATE Users SET IsActive = NOT IsActive WHERE Id = @Id";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================
        // Request Methods
        // ============================================

        public static bool CreateRequest(Request request)
        {
            string query = @"INSERT INTO Requests (UserId, RequestType, Description, Status) 
                            VALUES (@UserId, @RequestType, @Description, @Status)";
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", request.UserId);
                    cmd.Parameters.AddWithValue("@RequestType", request.RequestType ?? "General Request");
                    cmd.Parameters.AddWithValue("@Description", request.Description ?? "");
                    cmd.Parameters.AddWithValue("@Status", string.IsNullOrEmpty(request.Status) ? "Pending" : request.Status);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Request> GetAllRequests()
        {
            List<Request> requests = new List<Request>();
            string query = "SELECT * FROM Requests ORDER BY CreatedDate DESC";
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requests.Add(new Request
                        {
                            Id = reader.GetInt32("Id"),
                            UserId = reader.GetInt32("UserId"),
                            RequestType = reader.IsDBNull(reader.GetOrdinal("RequestType")) ? "N/A" : reader.GetString("RequestType"),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                            Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? "Pending" : reader.GetString("Status"),
                            CreatedDate = reader.GetDateTime("CreatedDate"),
                            ProcessedDate = reader.IsDBNull(reader.GetOrdinal("ProcessedDate")) ? (DateTime?)null : reader.GetDateTime("ProcessedDate"),
                            ProcessedBy = reader.IsDBNull(reader.GetOrdinal("ProcessedBy")) ? (int?)null : reader.GetInt32("ProcessedBy")
                        });
                    }
                }
            }
            return requests;
        }

        public static List<Request> GetUserRequests(int userId)
        {
            return GetAllRequests().Where(r => r.UserId == userId).ToList();
        }

        public static bool UpdateRequestStatus(int requestId, string status, int processedBy)
        {
            string query = @"UPDATE Requests 
                            SET Status = @Status, ProcessedDate = @ProcessedDate, ProcessedBy = @ProcessedBy 
                            WHERE Id = @Id";
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ProcessedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ProcessedBy", processedBy);
                    cmd.Parameters.AddWithValue("@Id", requestId);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================
        // Report Methods
        // ============================================

        public static bool CreateReport(Report report)
        {
            string query = @"INSERT INTO Reports (UserId, ReportType, Subject, Description, Status) 
                            VALUES (@UserId, @ReportType, @Subject, @Description, @Status)";
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", report.UserId);
                    cmd.Parameters.AddWithValue("@ReportType", report.ReportType);
                    cmd.Parameters.AddWithValue("@Subject", report.Subject);
                    cmd.Parameters.AddWithValue("@Description", report.Description);
                    cmd.Parameters.AddWithValue("@Status", report.Status);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Report> GetAllReports()
        {
            List<Report> reports = new List<Report>();
            string query = "SELECT * FROM Reports ORDER BY CreatedDate DESC";
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reports.Add(new Report
                        {
                            Id = reader.GetInt32("Id"),
                            UserId = reader.GetInt32("UserId"),
                            ReportType = reader.IsDBNull(reader.GetOrdinal("ReportType")) ? "General" : reader.GetString("ReportType"),
                            Subject = reader.IsDBNull(reader.GetOrdinal("Subject")) ? "No Subject" : reader.GetString("Subject"),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString("Description"),
                            Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? "Open" : reader.GetString("Status"),
                            CreatedDate = reader.GetDateTime("CreatedDate"),
                            ResolvedDate = reader.IsDBNull(reader.GetOrdinal("ResolvedDate")) ? (DateTime?)null : reader.GetDateTime("ResolvedDate")
                        });
                    }
                }
            }
            return reports;
        }

        public static List<Report> GetUserReports(int userId)
        {
            return GetAllReports().Where(r => r.UserId == userId).ToList();
        }

        public static bool UpdateReportStatus(int reportId, string status)
        {
            string query = @"UPDATE Reports 
                            SET Status = @Status, ResolvedDate = @ResolvedDate 
                            WHERE Id = @Id";
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ResolvedDate", 
                        (status == "Resolved" || status == "Closed") ? (object)DateTime.Now : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id", reportId);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}