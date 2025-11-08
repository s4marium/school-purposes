using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Models;
using Newtonsoft.Json;

namespace BarangayManagementSystem.Data
{
    public static class EnhancedDatabaseHelper
    {
        private static string dataFolder = "Data";
        private static string notificationsFile = Path.Combine(dataFolder, "notifications.json");
        private static string newsFile = Path.Combine(dataFolder, "news.json");
        private static string officialsFile = Path.Combine(dataFolder, "officials.json");
        private static string activitiesFile = Path.Combine(dataFolder, "activities.json");
        private static string settingsFile = Path.Combine(dataFolder, "settings.json");
        private static string blottersFile = Path.Combine(dataFolder, "blotters.json");

        private static List<Notification> notifications = new List<Notification>();
        private static List<News> newsList = new List<News>();
        private static List<BarangayOfficial> officials = new List<BarangayOfficial>();
        private static List<ActivityLog> activities = new List<ActivityLog>();
        private static List<Blotter> blotters = new List<Blotter>();
        private static SystemSettings systemSettings;

        static EnhancedDatabaseHelper()
        {
            LoadAllData();
        }

        private static void LoadAllData()
        {
            try
            {
                if (!Directory.Exists(dataFolder))
                    Directory.CreateDirectory(dataFolder);

                LoadNotifications();
                LoadNews();
                LoadOfficials();
                LoadActivities();
                LoadSettings();
                LoadBlotters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading enhanced data: {ex.Message}", "Error");
            }
        }

        #region Notifications

        private static void LoadNotifications()
        {
            try
            {
                if (File.Exists(notificationsFile))
                {
                    var json = File.ReadAllText(notificationsFile);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        notifications = JsonConvert.DeserializeObject<List<Notification>>(json) ?? new List<Notification>();
                    }
                }
            }
            catch
            {
                notifications = new List<Notification>();
            }
        }

        private static void SaveNotifications()
        {
            try
            {
                var json = JsonConvert.SerializeObject(notifications, Formatting.Indented);
                File.WriteAllText(notificationsFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving notifications: {ex.Message}", "Error");
            }
        }

        public static bool CreateNotification(Notification notification)
        {
            try
            {
                notification.Id = notifications.Count > 0 ? notifications.Max(n => n.Id) + 1 : 1;
                notification.CreatedDate = DateTime.Now;
                notification.IsRead = false;

                notifications.Add(notification);
                SaveNotifications();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int GetUnreadNotificationCount(int userId)
        {
            try
            {
                return notifications.Count(n => n.UserId == userId && !n.IsRead);
            }
            catch
            {
                return 0;
            }
        }

        public static List<Notification> GetUserNotifications(int userId, int limit = 50)
        {
            try
            {
                return notifications.Where(n => n.UserId == userId)
                    .OrderByDescending(n => n.CreatedDate)
                    .Take(limit)
                    .ToList();
            }
            catch
            {
                return new List<Notification>();
            }
        }

        public static List<Notification> GetUserNotifications(int userId, bool unreadOnly)
        {
            try
            {
                var query = notifications.Where(n => n.UserId == userId);
                if (unreadOnly)
                    query = query.Where(n => !n.IsRead);

                return query.OrderByDescending(n => n.CreatedDate).ToList();
            }
            catch
            {
                return new List<Notification>();
            }
        }

        public static bool MarkNotificationRead(int notificationId)
        {
            try
            {
                var notification = notifications.FirstOrDefault(n => n.Id == notificationId);
                if (notification != null)
                {
                    notification.IsRead = true;
                    notification.ReadDate = DateTime.Now;
                    SaveNotifications();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool MarkNotificationAsRead(int notificationId, int userId)
        {
            try
            {
                var notification = notifications.FirstOrDefault(n => n.Id == notificationId && n.UserId == userId);
                if (notification != null)
                {
                    notification.IsRead = true;
                    notification.ReadDate = DateTime.Now;
                    SaveNotifications();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool MarkAllNotificationsRead(int userId)
        {
            try
            {
                var userNotifications = notifications.Where(n => n.UserId == userId && !n.IsRead);
                foreach (var notification in userNotifications)
                {
                    notification.IsRead = true;
                    notification.ReadDate = DateTime.Now;
                }
                SaveNotifications();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region News

        private static void LoadNews()
        {
            try
            {
                if (File.Exists(newsFile))
                {
                    var json = File.ReadAllText(newsFile);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        newsList = JsonConvert.DeserializeObject<List<News>>(json) ?? new List<News>();
                    }
                }
                else
                {
                    CreateSampleNews();
                }
            }
            catch
            {
                newsList = new List<News>();
                CreateSampleNews();
            }
        }

        private static void CreateSampleNews()
        {
            newsList = new List<News>
                {
                    new News
                    {
                        Id = 1,
                        Title = "Welcome to the New Barangay Portal",
                        Content = "We are excited to announce the launch of our new digital barangay management system. This platform will help residents access services more efficiently and stay updated with community news.",
                        Summary = "New digital platform launched for better community service.",
                        Category = "Announcement",
                        PublishDate = DateTime.Now.AddDays(-7),
                        CreatedDate = DateTime.Now.AddDays(-7),
                        IsPublished = true,
                        ViewCount = 25
                    },
                    new News
                    {
                        Id = 2,
                        Title = "Community Clean-up Drive This Weekend",
                        Content = "Join us this Saturday, 8:00 AM at the barangay hall for our monthly community clean-up drive. Bring your gloves and let's work together to keep our community clean and green!",
                        Summary = "Monthly community clean-up this Saturday.",
                        Category = "Event",
                        PublishDate = DateTime.Now.AddDays(-3),
                        CreatedDate = DateTime.Now.AddDays(-3),
                        IsPublished = true,
                        ViewCount = 18
                    }
                };
            SaveNews();
        }

        private static void SaveNews()
        {
            try
            {
                var json = JsonConvert.SerializeObject(newsList, Formatting.Indented);
                File.WriteAllText(newsFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving news: {ex.Message}", "Error");
            }
        }

        public static List<News> GetPublishedNews()
        {
            try
            {
                return newsList.Where(n => n.IsPublished)
                    .OrderByDescending(n => n.PublishDate)
                    .ToList();
            }
            catch
            {
                return new List<News>();
            }
        }

        public static List<News> GetAllNews()
        {
            try
            {
                return newsList.OrderByDescending(n => n.CreatedDate).ToList();
            }
            catch
            {
                return new List<News>();
            }
        }

        public static bool CreateNews(News news)
        {
            try
            {
                news.Id = newsList.Count > 0 ? newsList.Max(n => n.Id) + 1 : 1;
                news.CreatedDate = DateTime.Now;
                news.PublishDate = DateTime.Now;
                newsList.Add(news);
                SaveNews();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateNews(News news)
        {
            try
            {
                var existingNews = newsList.FirstOrDefault(n => n.Id == news.Id);
                if (existingNews != null)
                {
                    existingNews.Title = news.Title;
                    existingNews.Content = news.Content;
                    existingNews.Summary = news.Summary;
                    existingNews.Category = news.Category;
                    existingNews.IsPublished = news.IsPublished;
                    SaveNews();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IncrementNewsViewCount(int newsId)
        {
            try
            {
                var news = newsList.FirstOrDefault(n => n.Id == newsId);
                if (news != null)
                {
                    news.ViewCount++;
                    SaveNews();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Officials

        private static void LoadOfficials()
        {
            try
            {
                if (File.Exists(officialsFile))
                {
                    var json = File.ReadAllText(officialsFile);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        officials = JsonConvert.DeserializeObject<List<BarangayOfficial>>(json) ?? new List<BarangayOfficial>();
                    }
                }
                else
                {
                    CreateSampleOfficials();
                }
            }
            catch
            {
                officials = new List<BarangayOfficial>();
                CreateSampleOfficials();
            }
        }

        private static void CreateSampleOfficials()
        {
            officials = new List<BarangayOfficial>
                {
                    new BarangayOfficial
                    {
                        Id = 1,
                        FullName = "Juan dela Cruz",
                        Position = "Barangay Captain",
                        Department = "Executive",
                        ContactNumber = "0917-123-4567",
                        Email = "captain@barangay.gov",
                        Address = "123 Main Street",
                        StartDate = DateTime.Now.AddYears(-2),
                        IsActive = true,
                        Responsibilities = "Overall leadership and administration of barangay affairs",
                        CreatedDate = DateTime.Now.AddYears(-2)
                    },
                    new BarangayOfficial
                    {
                        Id = 2,
                        FullName = "Maria Santos",
                        Position = "Barangay Secretary",
                        Department = "Administrative",
                        ContactNumber = "0917-234-5678",
                        Email = "secretary@barangay.gov",
                        Address = "456 Second Street",
                        StartDate = DateTime.Now.AddYears(-2),
                        IsActive = true,
                        Responsibilities = "Record keeping and administrative support",
                        CreatedDate = DateTime.Now.AddYears(-2)
                    }
                };
            SaveOfficials();
        }

        private static void SaveOfficials()
        {
            try
            {
                var json = JsonConvert.SerializeObject(officials, Formatting.Indented);
                File.WriteAllText(officialsFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving officials: {ex.Message}", "Error");
            }
        }

        public static List<BarangayOfficial> GetAllOfficials(bool activeOnly = false)
        {
            try
            {
                return officials.Where(o => !activeOnly || o.IsActive)
                    .OrderBy(o => o.Id)
                    .ToList();
            }
            catch
            {
                return new List<BarangayOfficial>();
            }
        }

        public static bool CreateOfficial(BarangayOfficial official)
        {
            try
            {
                official.Id = officials.Count > 0 ? officials.Max(o => o.Id) + 1 : 1;
                official.CreatedDate = DateTime.Now;
                official.IsActive = true;
                officials.Add(official);
                SaveOfficials();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Blotters

        private static void LoadBlotters()
        {
            try
            {
                if (File.Exists(blottersFile))
                {
                    var json = File.ReadAllText(blottersFile);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        blotters = JsonConvert.DeserializeObject<List<Blotter>>(json) ?? new List<Blotter>();
                    }
                }
            }
            catch
            {
                blotters = new List<Blotter>();
            }
        }

        private static void SaveBlotters()
        {
            try
            {
                var json = JsonConvert.SerializeObject(blotters, Formatting.Indented);
                File.WriteAllText(blottersFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving blotters: {ex.Message}", "Error");
            }
        }

        public static bool CreateBlotter(Blotter blotter)
        {
            try
            {
                blotter.Id = blotters.Count > 0 ? blotters.Max(b => b.Id) + 1 : 1;
                blotter.CreatedDate = DateTime.Now;
                blotter.Status = "Filed";
                blotters.Add(blotter);
                SaveBlotters();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Blotter> GetAllBlotters()
        {
            try
            {
                return blotters.OrderByDescending(b => b.CreatedDate).ToList();
            }
            catch
            {
                return new List<Blotter>();
            }
        }

        public static bool UpdateBlotterStatus(int blotterId, string status, string resolution, int updatedBy)
        {
            try
            {
                var blotter = blotters.FirstOrDefault(b => b.Id == blotterId);
                if (blotter != null)
                {
                    blotter.Status = status;
                    blotter.Resolution = resolution;
                    if (status == "Resolved")
                    {
                        blotter.ResolvedDate = DateTime.Now;
                        blotter.ResolvedBy = updatedBy;
                    }
                    SaveBlotters();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Activities & Logging

        private static void LoadActivities()
        {
            try
            {
                if (File.Exists(activitiesFile))
                {
                    var json = File.ReadAllText(activitiesFile);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        activities = JsonConvert.DeserializeObject<List<ActivityLog>>(json) ?? new List<ActivityLog>();
                    }
                }
            }
            catch
            {
                activities = new List<ActivityLog>();
            }
        }

        private static void SaveActivities()
        {
            try
            {
                var json = JsonConvert.SerializeObject(activities, Formatting.Indented);
                File.WriteAllText(activitiesFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving activities: {ex.Message}", "Error");
            }
        }

        public static void LogActivity(int userId, string action, string category, string description)
        {
            try
            {
                var activity = new ActivityLog
                {
                    Id = activities.Count + 1,
                    UserId = userId,
                    Action = action,
                    Module = category,
                    Description = description,
                    CreatedDate = DateTime.Now
                };

                activities.Add(activity);

                // Keep only last 1000 activities
                if (activities.Count > 1000)
                {
                    activities = activities.Skip(activities.Count - 1000).ToList();
                }

                SaveActivities();
            }
            catch (Exception ex)
            {
                try
                {
                    File.AppendAllText(Path.Combine(dataFolder, "error.log"),
                        $"{DateTime.Now}: Error logging activity - {ex.Message}\n");
                }
                catch
                {
                    // Ignore if can't write to error log
                }
            }
        }

        public static List<ActivityLog> GetActivityLogs(int? userId = null, int days = 7)
        {
            try
            {
                var query = activities.AsQueryable();

                if (userId.HasValue)
                    query = query.Where(a => a.UserId == userId.Value);

                var fromDate = DateTime.Now.AddDays(-days);
                query = query.Where(a => a.CreatedDate >= fromDate);

                return query.OrderByDescending(a => a.CreatedDate).ToList();
            }
            catch
            {
                return new List<ActivityLog>();
            }
        }

        #endregion

        #region Settings

        private static void LoadSettings()
        {
            try
            {
                if (File.Exists(settingsFile))
                {
                    var json = File.ReadAllText(settingsFile);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        systemSettings = JsonConvert.DeserializeObject<SystemSettings>(json);
                    }
                }

                if (systemSettings == null)
                {
                    CreateDefaultSettings();
                }
            }
            catch
            {
                CreateDefaultSettings();
            }
        }

        private static void CreateDefaultSettings()
        {
            systemSettings = new SystemSettings
            {
                Id = 1,
                BarangayName = "Sample Barangay",
                Address = "123 Main Street, City, Province",
                ContactNumber = "0917-123-4567",
                Email = "info@barangay.gov",
                Captain = "Juan dela Cruz",
                Secretary = "Maria Santos",
                Treasurer = "Pedro Reyes",
                ServiceFees = new Dictionary<string, decimal>
                    {
                        { "Barangay Clearance", 50.00m },
                        { "Certificate of Residency", 30.00m },
                        { "Certificate of Indigency", 25.00m },
                        { "Business Permit", 100.00m },
                        { "Barangay ID", 75.00m },
                        { "Other Documents", 50.00m }
                    },
                EnableNotifications = true,
                EnableSMSNotifications = false,
                EnableEmailNotifications = false,
                LastUpdated = DateTime.Now,
                UpdatedBy = 1
            };
            SaveSettings();
        }

        private static void SaveSettings()
        {
            try
            {
                var json = JsonConvert.SerializeObject(systemSettings, Formatting.Indented);
                File.WriteAllText(settingsFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error");
            }
        }

        public static SystemSettings GetSystemSettings()
        {
            return systemSettings ?? new SystemSettings();
        }

        public static bool UpdateSystemSettings(SystemSettings settings)
        {
            try
            {
                settings.LastUpdated = DateTime.Now;
                systemSettings = settings;
                SaveSettings();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}