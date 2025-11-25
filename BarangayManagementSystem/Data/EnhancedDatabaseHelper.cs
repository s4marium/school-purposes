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

        public static BarangayOfficial GetOfficialById(int officialId)
        {
            string query = "SELECT * FROM BarangayOfficials WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", officialId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new BarangayOfficial
                            {
                                Id = reader.GetInt32("Id"),
                                FullName = reader.GetString("FullName"),
                                Position = reader.GetString("Position"),
                                Department = reader.IsDBNull(reader.GetOrdinal("Department")) ? null : reader.GetString("Department"),
                                ContactNumber = reader.IsDBNull(reader.GetOrdinal("ContactNumber")) ? null : reader.GetString("ContactNumber"),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString("Address"),
                                ProfileImage = reader.IsDBNull(reader.GetOrdinal("ProfileImage")) ? null : reader.GetString("ProfileImage"),
                                StartDate = reader.GetDateTime("StartDate"),
                                EndDate = reader.IsDBNull(reader.GetOrdinal("EndDate")) ? (DateTime?)null : reader.GetDateTime("EndDate"),
                                IsActive = reader.GetBoolean("IsActive"),
                                Responsibilities = reader.IsDBNull(reader.GetOrdinal("Responsibilities")) ? null : reader.GetString("Responsibilities"),
                                CreatedDate = reader.GetDateTime("CreatedDate"),
                                CreatedBy = reader.GetInt32("CreatedBy")
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool CreateOfficial(BarangayOfficial official)
        {
            string query = @"INSERT INTO BarangayOfficials 
                            (FullName, Position, Department, ContactNumber, Email, Address, ProfileImage, 
                             StartDate, EndDate, IsActive, Responsibilities, CreatedBy) 
                            VALUES (@FullName, @Position, @Department, @ContactNumber, @Email, @Address, 
                                    @ProfileImage, @StartDate, @EndDate, @IsActive, @Responsibilities, @CreatedBy)";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", official.FullName);
                    cmd.Parameters.AddWithValue("@Position", official.Position);
                    cmd.Parameters.AddWithValue("@Department", official.Department);
                    cmd.Parameters.AddWithValue("@ContactNumber", official.ContactNumber);
                    cmd.Parameters.AddWithValue("@Email", official.Email);
                    cmd.Parameters.AddWithValue("@Address", official.Address);
                    cmd.Parameters.AddWithValue("@ProfileImage", official.ProfileImage);
                    cmd.Parameters.AddWithValue("@StartDate", official.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", official.EndDate.HasValue ? (object)official.EndDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", official.IsActive);
                    cmd.Parameters.AddWithValue("@Responsibilities", official.Responsibilities);
                    cmd.Parameters.AddWithValue("@CreatedBy", official.CreatedBy);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateOfficial(BarangayOfficial official)
        {
            string query = @"UPDATE BarangayOfficials SET 
                            FullName = @FullName, Position = @Position, Department = @Department, 
                            ContactNumber = @ContactNumber, Email = @Email, Address = @Address, 
                            ProfileImage = @ProfileImage, StartDate = @StartDate, EndDate = @EndDate, 
                            IsActive = @IsActive, Responsibilities = @Responsibilities 
                            WHERE Id = @Id";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", official.Id);
                    cmd.Parameters.AddWithValue("@FullName", official.FullName);
                    cmd.Parameters.AddWithValue("@Position", official.Position);
                    cmd.Parameters.AddWithValue("@Department", official.Department);
                    cmd.Parameters.AddWithValue("@ContactNumber", official.ContactNumber);
                    cmd.Parameters.AddWithValue("@Email", official.Email);
                    cmd.Parameters.AddWithValue("@Address", official.Address);
                    cmd.Parameters.AddWithValue("@ProfileImage", official.ProfileImage);
                    cmd.Parameters.AddWithValue("@StartDate", official.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", official.EndDate.HasValue ? (object)official.EndDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", official.IsActive);
                    cmd.Parameters.AddWithValue("@Responsibilities", official.Responsibilities);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
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

        public static List<BarangayOfficial> GetOfficialsByDepartment(string department)
        {
            List<BarangayOfficial> officials = new List<BarangayOfficial>();
            string query = "SELECT * FROM BarangayOfficials WHERE Department = @Department ORDER BY Position";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Department", department);
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
            }
            return officials;
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
                            Summary = SafeGetString(reader, "Summary"),
                            Category = reader.GetString("Category"),
                            PublishedDate = reader.GetDateTime("PublishedDate"),
                            CreatedDate = reader.GetDateTime("CreatedDate"),
                            CreatedBy = reader.GetInt32("CreatedBy"),
                            ViewCount = reader.GetInt32("ViewCount")
                        });
                    }
                }
            }
            return newsList;
        }

        public static News GetNewsById(int newsId)
        {
            string query = "SELECT * FROM News WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", newsId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new News
                            {
                                Id = reader.GetInt32("Id"),
                                Title = reader.GetString("Title"),
                                Content = reader.GetString("Content"),
                                Summary = SafeGetString(reader, "Summary"),
                                Category = reader.GetString("Category"),
                                PublishedDate = reader.GetDateTime("PublishedDate"),
                                CreatedDate = reader.GetDateTime("CreatedDate"),
                                CreatedBy = reader.GetInt32("CreatedBy"),
                                ViewCount = reader.GetInt32("ViewCount")
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool CreateNews(News news)
        {
            string query = @"INSERT INTO News 
                            (Title, Content, Summary, Category, PublishedDate, CreatedBy) 
                            VALUES (@Title, @Content, @Summary, @Category, @PublishedDate, @CreatedBy)";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", news.Title);
                    cmd.Parameters.AddWithValue("@Content", news.Content);
                    cmd.Parameters.AddWithValue("@Summary", news.Summary);
                    cmd.Parameters.AddWithValue("@Category", news.Category);
                    cmd.Parameters.AddWithValue("@PublishedDate", news.PublishedDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", news.CreatedBy);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateNews(News news)
        {
            string query = @"UPDATE News SET 
                            Title = @Title, Content = @Content, Summary = @Summary, 
                            Category = @Category, PublishedDate = @PublishedDate 
                            WHERE Id = @Id";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", news.Id);
                    cmd.Parameters.AddWithValue("@Title", news.Title);
                    cmd.Parameters.AddWithValue("@Content", news.Content);
                    cmd.Parameters.AddWithValue("@Summary", news.Summary);
                    cmd.Parameters.AddWithValue("@Category", news.Category);
                    cmd.Parameters.AddWithValue("@PublishedDate", news.PublishedDate);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
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

        public static List<News> GetNewsByCategory(string category)
        {
            List<News> newsList = new List<News>();
            string query = "SELECT * FROM News WHERE Category = @Category ORDER BY PublishedDate DESC";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Category", category);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newsList.Add(new News
                            {
                                Id = reader.GetInt32("Id"),
                                Title = reader.GetString("Title"),
                                Content = reader.GetString("Content"),
                                Summary = SafeGetString(reader, "Summary"),
                                Category = reader.GetString("Category"),
                                PublishedDate = reader.GetDateTime("PublishedDate"),
                                CreatedDate = reader.GetDateTime("CreatedDate"),
                                CreatedBy = reader.GetInt32("CreatedBy"),
                                ViewCount = reader.GetInt32("ViewCount")
                            });
                        }
                    }
                }
            }
            return newsList;
        }

        public static List<News> GetPublishedNews()
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
        // Announcement Methods
        // ============================================

        public static List<Announcement> GetAllAnnouncements()
        {
            List<Announcement> announcements = new List<Announcement>();
            string query = "SELECT * FROM Announcements ORDER BY CreatedDate DESC";
            
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

        public static List<Announcement> GetRecentAnnouncements(int count = 10)
        {
            List<Announcement> announcements = new List<Announcement>();
            string query = "SELECT * FROM Announcements ORDER BY CreatedDate DESC LIMIT @Count";

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Count", count);
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
            }
            return announcements;
        }

        public static Announcement GetAnnouncementById(int announcementId)
        {
            string query = "SELECT * FROM Announcements WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", announcementId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Announcement
                            {
                                Id = reader.GetInt32("Id"),
                                Title = reader.GetString("Title"),
                                Message = reader.GetString("Message"),
                                CreatedDate = reader.GetDateTime("CreatedDate"),
                                CreatedBy = reader.GetInt32("CreatedBy")
                            };
                        }
                    }
                }
            }
            return null;
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

        public static bool UpdateAnnouncement(Announcement announcement)
        {
            string query = @"UPDATE Announcements SET 
                            Title = @Title, Message = @Message 
                            WHERE Id = @Id";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", announcement.Id);
                    cmd.Parameters.AddWithValue("@Title", announcement.Title);
                    cmd.Parameters.AddWithValue("@Message", announcement.Message);
                    
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
            string query = @"INSERT INTO Notifications (UserId, Title, Message, Type, Category, IsBroadcast, CreatedBy) 
                            VALUES (@UserId, @Title, @Message, @Type, @Category, @IsBroadcast, @CreatedBy)";
            
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
                    cmd.Parameters.AddWithValue("@IsBroadcast", notification.IsBroadcast);
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
                                IsBroadcast = SafeGetBoolean(reader, "IsBroadcast"),
                                CreatedDate = reader.GetDateTime("CreatedDate"),
                                CreatedBy = reader.IsDBNull(reader.GetOrdinal("CreatedBy")) ? 0 : reader.GetInt32("CreatedBy")
                            });
                        }
                    }
                }
            }
            return notifications;
        }

        public static Notification GetNotificationById(int notificationId)
        {
            string query = "SELECT * FROM Notifications WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", notificationId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Notification
                            {
                                Id = reader.GetInt32("Id"),
                                UserId = reader.GetInt32("UserId"),
                                Title = reader.GetString("Title"),
                                Message = reader.GetString("Message"),
                                Type = reader.GetString("Type"),
                                Category = reader.GetString("Category"),
                                IsRead = reader.GetBoolean("IsRead"),
                                IsBroadcast = SafeGetBoolean(reader, "IsBroadcast"),
                                CreatedDate = reader.GetDateTime("CreatedDate"),
                                CreatedBy = reader.IsDBNull(reader.GetOrdinal("CreatedBy")) ? 0 : reader.GetInt32("CreatedBy")
                            };
                        }
                    }
                }
            }
            return null;
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

        public static bool DeleteNotification(int notificationId)
        {
            string query = "DELETE FROM Notifications WHERE Id = @Id";
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

        public static bool CreateBroadcastNotification(string title, string message, string type, string category, int createdBy)
        {
            string query = @"INSERT INTO Notifications (UserId, Title, Message, Type, Category, IsBroadcast, CreatedBy) 
                            SELECT Id, @Title, @Message, @Type, @Category, TRUE, @CreatedBy FROM Users WHERE IsActive = TRUE";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Message", message);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Notification> GetNotificationsByCategory(int userId, string category)
        {
            List<Notification> notifications = new List<Notification>();
            string query = "SELECT * FROM Notifications WHERE UserId = @UserId AND Category = @Category ORDER BY CreatedDate DESC";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Category", category);
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
                                IsBroadcast = SafeGetBoolean(reader, "IsBroadcast"),
                                CreatedDate = reader.GetDateTime("CreatedDate"),
                                CreatedBy = reader.IsDBNull(reader.GetOrdinal("CreatedBy")) ? 0 : reader.GetInt32("CreatedBy")
                            });
                        }
                    }
                }
            }
            return notifications;
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

        public static bool LogActivityWithIP(int userId, string action, string module, string description, string ipAddress)
        {
            string query = @"INSERT INTO ActivityLogs (UserId, Action, Module, Description, IpAddress) 
                            VALUES (@UserId, @Action, @Module, @Description, @IpAddress)";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@Module", module);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@IpAddress", ipAddress);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<ActivityLog> GetRecentActivityLogs(int count = 10)
        {
            List<ActivityLog> logs = new List<ActivityLog>();
            string query = "SELECT * FROM ActivityLogs ORDER BY CreatedDate DESC LIMIT @Count";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Count", count);
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
                                IpAddress = reader.IsDBNull(reader.GetOrdinal("IpAddress")) ? null : reader.GetString("IpAddress"),
                                CreatedDate = reader.GetDateTime("CreatedDate")
                            });
                        }
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
                                IpAddress = reader.IsDBNull(reader.GetOrdinal("IpAddress")) ? null : reader.GetString("IpAddress"),
                                CreatedDate = reader.GetDateTime("CreatedDate")
                            });
                        }
                    }
                }
            }
            return logs;
        }

        public static List<ActivityLog> GetActivityLogsByUser(int userId)
        {
            List<ActivityLog> logs = new List<ActivityLog>();
            string query = "SELECT * FROM ActivityLogs WHERE UserId = @UserId ORDER BY CreatedDate DESC";
            
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
                            logs.Add(new ActivityLog
                            {
                                Id = reader.GetInt32("Id"),
                                UserId = reader.GetInt32("UserId"),
                                Action = reader.GetString("Action"),
                                Module = reader.GetString("Module"),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                                IpAddress = reader.IsDBNull(reader.GetOrdinal("IpAddress")) ? null : reader.GetString("IpAddress"),
                                CreatedDate = reader.GetDateTime("CreatedDate")
                            });
                        }
                    }
                }
            }
            return logs;
        }

        public static List<ActivityLog> GetActivityLogsByModule(string module)
        {
            List<ActivityLog> logs = new List<ActivityLog>();
            string query = "SELECT * FROM ActivityLogs WHERE Module = @Module ORDER BY CreatedDate DESC";
            
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Module", module);
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
                                IpAddress = reader.IsDBNull(reader.GetOrdinal("IpAddress")) ? null : reader.GetString("IpAddress"),
                                CreatedDate = reader.GetDateTime("CreatedDate")
                            });
                        }
                    }
                }
            }
            return logs;
        }

        public static bool DeleteActivityLog(int logId)
        {
            string query = "DELETE FROM ActivityLogs WHERE Id = @Id";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", logId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool ClearOldActivityLogs(int daysToKeep)
        {
            string query = "DELETE FROM ActivityLogs WHERE CreatedDate < @CutoffDate";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CutoffDate", DateTime.Now.AddDays(-daysToKeep));
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
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

        public static string GetSettingValue(string key)
        {
            string query = "SELECT SettingValue FROM SystemSettings WHERE SettingKey = @Key";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Key", key);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        public static bool UpdateSettingValue(string key, string value)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                UpdateSetting(conn, key, value);
                return true;
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

        private static string SafeGetString(MySqlDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        private static bool SafeGetBoolean(MySqlDataReader reader, string columnName, bool defaultValue = false)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                return reader.IsDBNull(ordinal) ? defaultValue : reader.GetBoolean(ordinal);
            }
            catch (IndexOutOfRangeException)
            {
                return defaultValue;
            }
        }
    }
}