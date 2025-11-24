using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using BarangayManagementSystem.Models;
using Newtonsoft.Json;

namespace BarangayManagementSystem.Data
{
    public static class EnhancedDatabaseHelper
    {
        // ============================================
        // Barangay Officials Methods
        // ============================================

        public static List<BarangayOfficial> GetAllOfficials(bool activeOnly = false)
        {
            List<BarangayOfficial> officials = new List<BarangayOfficial>();
            string query = activeOnly 
                ? "SELECT * FROM BarangayOfficials WHERE IsActive = TRUE ORDER BY Position" 
                : "SELECT * FROM BarangayOfficials ORDER BY Position";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        officials.Add(new BarangayOfficial
                        {
                            Id = reader.GetInt32("Id"),
                            FullName = reader.GetString("FullName"),
                            Position = reader.GetString("Position"),
                            Department = reader.IsDBNull(reader.GetOrdinal("Department")) ? null : reader.GetString("Department"),
                            ContactNumber = reader.IsDBNull(reader.GetOrdinal("ContactNumber")) ? null : reader.GetString("ContactNumber"),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
                            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString("Address"),
                            StartDate = reader.GetDateTime("StartDate"),
                            EndDate = reader.IsDBNull(reader.GetOrdinal("EndDate")) ? (DateTime?)null : reader.GetDateTime("EndDate"),
                            IsActive = reader.GetBoolean("IsActive"),
                            Responsibilities = reader.IsDBNull(reader.GetOrdinal("Responsibilities")) ? null : reader.GetString("Responsibilities")
                        });
                    }
                }
            }
            return officials;
        }

        public static bool DeleteOfficial(int officialId)
        {
            string query = "DELETE FROM BarangayOfficials WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", officialId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool ToggleOfficialStatus(int officialId)
        {
            string query = "UPDATE BarangayOfficials SET IsActive = NOT IsActive WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", officialId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================
        // News Methods
        // ============================================

        public static List<News> GetAllNews()
        {
            List<News> newsList = new List<News>();
            string query = "SELECT * FROM News ORDER BY PublishedDate DESC";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        newsList.Add(new News
                        {
                            Id = reader.GetInt32("Id"),
                            Title = reader.GetString("Title"),
                            Content = reader.GetString("Content"),
                            Category = reader.GetString("Category"),
                            PublishedDate = reader.GetDateTime("PublishedDate"),
                            CreatedDate = reader.GetDateTime("CreatedDate"),
                            CreatedBy = reader.GetInt32("CreatedBy")
                        });
                    }
                }
            }
            return newsList;
        }

        public static bool DeleteNews(int newsId)
        {
            string query = "DELETE FROM News WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", newsId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================
        // Announcement Methods
        // ============================================

        public static List<Announcement> GetRecentAnnouncements(int count = 10)
        {
            List<Announcement> announcements = new List<Announcement>();
            string query = $"SELECT * FROM Announcements ORDER BY CreatedDate DESC LIMIT {count}";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        announcements.Add(new Announcement
                        {
                            Id = reader.GetInt32("Id"),
                            Title = reader.GetString("Title"),
                            Message = reader.GetString("Message"),
                            CreatedDate = reader.GetDateTime("CreatedDate"),
                            CreatedBy = reader.GetInt32("CreatedBy")
                        });
                    }
                }
            }
            return announcements;
        }

        public static bool CreateAnnouncement(Announcement announcement)
        {
            string query = @"INSERT INTO Announcements (Title, Message, CreatedBy) 
                            VALUES (@Title, @Message, @CreatedBy)";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", announcement.Title);
                    cmd.Parameters.AddWithValue("@Message", announcement.Message);
                    cmd.Parameters.AddWithValue("@CreatedBy", announcement.CreatedBy);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteAnnouncement(int announcementId)
        {
            string query = "DELETE FROM Announcements WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", announcementId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================
        // Notification Methods
        // ============================================

        public static bool CreateNotification(Notification notification)
        {
            string query = @"INSERT INTO Notifications (UserId, Title, Message, Type, Category, CreatedBy) 
                            VALUES (@UserId, @Title, @Message, @Type, @Category, @CreatedBy)";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", notification.UserId);
                    cmd.Parameters.AddWithValue("@Title", notification.Title);
                    cmd.Parameters.AddWithValue("@Message", notification.Message);
                    cmd.Parameters.AddWithValue("@Type", notification.Type);
                    cmd.Parameters.AddWithValue("@Category", notification.Category);
                    cmd.Parameters.AddWithValue("@CreatedBy", notification.CreatedBy);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Notification> GetUserNotifications(int userId, bool unreadOnly = false)
        {
            List<Notification> notifications = new List<Notification>();
            string query = unreadOnly 
                ? "SELECT * FROM Notifications WHERE UserId = @UserId AND IsRead = FALSE ORDER BY CreatedDate DESC" 
                : "SELECT * FROM Notifications WHERE UserId = @UserId ORDER BY CreatedDate DESC";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notifications.Add(new Notification
                            {
                                Id = reader.GetInt32("Id"),
                                UserId = reader.GetInt32("UserId"),
                                Title = reader.GetString("Title"),
                                Message = reader.GetString("Message"),
                                Type = reader.GetString("Type"),
                                Category = reader.GetString("Category"),
                                IsRead = reader.GetBoolean("IsRead"),
                                CreatedDate = reader.GetDateTime("CreatedDate"),
                                CreatedBy = reader.IsDBNull(reader.GetOrdinal("CreatedBy")) ? 0 : reader.GetInt32("CreatedBy")
                            });
                        }
                    }
                }
            }
            return notifications;
        }

        public static int GetUnreadNotificationCount(int userId)
        {
            string query = "SELECT COUNT(*) FROM Notifications WHERE UserId = @UserId AND IsRead = FALSE";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static bool MarkNotificationAsRead(int notificationId)
        {
            string query = "UPDATE Notifications SET IsRead = TRUE WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", notificationId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================
        // Additional Notification Methods
        // ============================================

        public static bool MarkAllNotificationsRead(int userId)
        {
            string query = "UPDATE Notifications SET IsRead = TRUE WHERE UserId = @UserId";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool MarkNotificationRead(int notificationId)
        {
            string query = "UPDATE Notifications SET IsRead = TRUE WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", notificationId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================
        // Additional News Methods
        // ============================================

        public static System.Collections.Generic.List<News> GetPublishedNews()
        {
            return GetAllNews().Where(n => n.PublishedDate <= DateTime.Now).ToList();
        }

        public static bool IncrementNewsViewCount(int newsId)
        {
            string query = "UPDATE News SET ViewCount = ViewCount + 1 WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", newsId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ============================================
        // Activity Log Methods
        // ============================================

        public static bool LogActivity(int userId, string action, string module, string description)
        {
            string query = @"INSERT INTO ActivityLogs (UserId, Action, Module, Description) 
                            VALUES (@UserId, @Action, @Module, @Description)";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@Module", module);
                    cmd.Parameters.AddWithValue("@Description", description);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<ActivityLog> GetRecentActivityLogs(int count = 10)
        {
            List<ActivityLog> logs = new List<ActivityLog>();
            string query = $"SELECT * FROM ActivityLogs ORDER BY CreatedDate DESC LIMIT {count}";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        logs.Add(new ActivityLog
                        {
                            Id = reader.GetInt32("Id"),
                            UserId = reader.GetInt32("UserId"),
                            Action = reader.GetString("Action"),
                            Module = reader.GetString("Module"),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                            CreatedDate = reader.GetDateTime("CreatedDate")
                        });
                    }
                }
            }
            return logs;
        }

        public static List<ActivityLog> GetActivityLogsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<ActivityLog> logs = new List<ActivityLog>();
            string query = "SELECT * FROM ActivityLogs WHERE CreatedDate BETWEEN @StartDate AND @EndDate ORDER BY CreatedDate DESC";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(new ActivityLog
                            {
                                Id = reader.GetInt32("Id"),
                                UserId = reader.GetInt32("UserId"),
                                Action = reader.GetString("Action"),
                                Module = reader.GetString("Module"),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                                CreatedDate = reader.GetDateTime("CreatedDate")
                            });
                        }
                    }
                }
            }
            return logs;
        }

        // ============================================
        // System Settings Methods
        // ============================================

        public static SystemSettings GetSystemSettings()
        {
            SystemSettings settings = new SystemSettings
            {
                ServiceFees = new Dictionary<string, decimal>()
            };

            string query = "SELECT SettingKey, SettingValue FROM SystemSettings";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string key = reader.GetString("SettingKey");
                        string value = reader.IsDBNull(reader.GetOrdinal("SettingValue")) ? null : reader.GetString("SettingValue");

                        switch (key)
                        {
                            case "BarangayName":
                                settings.BarangayName = value;
                                break;
                            case "BarangayAddress":
                                settings.BarangayAddress = value;
                                break;
                            case "ContactNumber":
                                settings.ContactNumber = value;
                                break;
                            case "EmailAddress":
                                settings.EmailAddress = value;
                                break;
                            case "ServiceFees":
                                if (!string.IsNullOrEmpty(value))
                                {
                                    try
                                    {
                                        settings.ServiceFees = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(value);
                                    }
                                    catch
                                    {
                                        settings.ServiceFees = new Dictionary<string, decimal>();
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            return settings;
        }

        public static bool UpdateSystemSettings(SystemSettings settings)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    
                    UpdateSetting(conn, "BarangayName", settings.BarangayName);
                    UpdateSetting(conn, "BarangayAddress", settings.BarangayAddress);
                    UpdateSetting(conn, "ContactNumber", settings.ContactNumber);
                    UpdateSetting(conn, "EmailAddress", settings.EmailAddress);
                    
                    if (settings.ServiceFees != null)
                    {
                        string serviceFeesJson = JsonConvert.SerializeObject(settings.ServiceFees);
                        UpdateSetting(conn, "ServiceFees", serviceFeesJson);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void UpdateSetting(MySqlConnection conn, string key, string value)
        {
            string query = @"UPDATE SystemSettings SET SettingValue = @Value WHERE SettingKey = @Key";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Key", key);
                cmd.Parameters.AddWithValue("@Value", value);
                cmd.ExecuteNonQuery();
            }
        }
    }
}