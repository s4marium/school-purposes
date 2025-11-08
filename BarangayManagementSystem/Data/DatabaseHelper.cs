using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Models;
using Newtonsoft.Json;

namespace BarangayManagementSystem.Data
{
    public static class DatabaseHelper
    {
        // FIXED: Use application directory for data folder
        private static string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private static string usersFile = Path.Combine(dataFolder, "users.json");
        private static string requestsFile = Path.Combine(dataFolder, "requests.json");
        private static string reportsFile = Path.Combine(dataFolder, "reports.json");

        private static List<User> users = new List<User>();
        private static List<Request> requests = new List<Request>();
        private static List<Report> reports = new List<Report>();

        public static void InitializeDatabase()
        {
            try
            {
                // Create data directory if it doesn't exist
                if (!Directory.Exists(dataFolder))
                {
                    Directory.CreateDirectory(dataFolder);
                    MessageBox.Show($"Created data folder at: {dataFolder}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
                CreateDefaultAdmin();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization error: {ex.Message}\n\nData folder: {dataFolder}\n\nStack trace: {ex.StackTrace}", "Error");
            }
        }

        private static void LoadData()
        {
            try
            {
                // Load users with null safety
                if (File.Exists(usersFile))
                {
                    var json = File.ReadAllText(usersFile);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                    }
                }

                // Load requests with null safety
                if (File.Exists(requestsFile))
                {
                    var json = File.ReadAllText(requestsFile);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        requests = JsonConvert.DeserializeObject<List<Request>>(json) ?? new List<Request>();
                    }
                }

                // Load reports with null safety
                if (File.Exists(reportsFile))
                {
                    var json = File.ReadAllText(reportsFile);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        reports = JsonConvert.DeserializeObject<List<Report>>(json) ?? new List<Report>();
                    }
                }

                // Ensure lists are never null
                users = users ?? new List<User>();
                requests = requests ?? new List<Request>();
                reports = reports ?? new List<Report>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}\n\nUsers file: {usersFile}\nExists: {File.Exists(usersFile)}", "Error");
                // Initialize empty lists on error
                users = new List<User>();
                requests = new List<Request>();
                reports = new List<Report>();
            }
        }

        private static void ReloadUsers()
        {
            try
            {
                if (File.Exists(usersFile))
                {
                    var json = File.ReadAllText(usersFile);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                    }
                }
                else
                {
                    users = new List<User>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reloading users: {ex.Message}", "Error");
                users = new List<User>();
            }
        }

        private static void SaveData()
        {
            try
            {
                // Ensure directory exists
                if (!Directory.Exists(dataFolder))
                    Directory.CreateDirectory(dataFolder);

                // Save with null safety
                var usersJson = JsonConvert.SerializeObject(users ?? new List<User>(), Formatting.Indented);
                var requestsJson = JsonConvert.SerializeObject(requests ?? new List<Request>(), Formatting.Indented);
                var reportsJson = JsonConvert.SerializeObject(reports ?? new List<Report>(), Formatting.Indented);

                File.WriteAllText(usersFile, usersJson);
                File.WriteAllText(requestsFile, requestsJson);
                File.WriteAllText(reportsFile, reportsJson);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}\n\nData folder: {dataFolder}", "Error");
            }
        }

        private static void CreateDefaultAdmin()
        {
            try
            {
                if (users == null)
                    users = new List<User>();

                if (!users.Any(u => u != null && u.Username == "admin"))
                {
                    users.Add(new User
                    {
                        Id = 1,
                        Username = "admin",
                        Password = "admin123",
                        FullName = "System Administrator",
                        Email = "admin@barangay.gov",
                        UserType = "Admin",
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    });
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating default admin: {ex.Message}", "Error");
            }
        }

        public static User AuthenticateUser(string username, string password)
        {
            try
            {
                // RELOAD users from file before authentication to get latest data
                ReloadUsers();

                if (users == null)
                {
                    MessageBox.Show("Users list is null!", "Error");
                    return null;
                }

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    return null; // Don't show error, let the calling method handle it
                }

                var user = users.FirstOrDefault(u => u != null && 
                    u.Username == username && 
                    u.Password == password && 
                    u.IsActive);

                // Only show diagnostic messages on FAILURE, not success
                if (user == null)
                {
                    // Check if username exists but password doesn't match
                    var userExists = users.Any(u => u != null && u.Username == username);
                    if (userExists)
                    {
                        MessageBox.Show($"Username found but password is incorrect.\n\nTotal users in database: {users.Count}", 
                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string userList = users.Count > 0 
                            ? string.Join("\n", users.Where(u => u != null).Select(u => $"- {u.Username} ({u.UserType})"))
                            : "No users in database";
                        
                        MessageBox.Show($"Username '{username}' not found in database.\n\nTotal users: {users.Count}\n\nAvailable usernames:\n{userList}",
                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // REMOVED: Success message - dashboard will open instead

                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Authentication error: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Error");
                return null;
            }
        }

        public static bool CreateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    MessageBox.Show("User object is null!", "Error");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(user.Username))
                {
                    MessageBox.Show("Username is empty!", "Error");
                    return false;
                }

                // RELOAD to get latest users
                ReloadUsers();

                if (users == null)
                    users = new List<User>();

                if (users.Any(u => u != null && u.Username == user.Username))
                {
                    MessageBox.Show($"Username '{user.Username}' already exists!", "Error");
                    return false;
                }

                user.Id = users.Count > 0 ? users.Max(u => u?.Id ?? 0) + 1 : 1;
                user.CreatedDate = DateTime.Now;
                user.IsActive = true;
                
                // Set default UserType if not specified
                if (string.IsNullOrWhiteSpace(user.UserType))
                    user.UserType = "User";

                users.Add(user);
                SaveData();
                
                MessageBox.Show($"User created successfully!\n\nUsername: {user.Username}\nUser ID: {user.Id}\nType: {user.UserType}\nTotal users now: {users.Count}\nSaved to: {usersFile}",
                    "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating user: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Error");
                return false;
            }
        }

        public static List<User> GetAllUsers()
        {
            try
            {
                ReloadUsers();
                
                if (users == null)
                    return new List<User>();

                return users.Where(u => u != null && u.UserType == "User").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting users: {ex.Message}", "Error");
                return new List<User>();
            }
        }

        public static bool UpdateUserStatus(int userId, bool isActive)
        {
            try
            {
                ReloadUsers();
                
                if (users == null)
                    return false;

                var user = users.FirstOrDefault(u => u != null && u.Id == userId);
                if (user != null)
                {
                    user.IsActive = isActive;
                    SaveData();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user status: {ex.Message}", "Error");
                return false;
            }
        }

        // Request operations
        public static bool CreateRequest(Request request)
        {
            try
            {
                if (request == null)
                    return false;

                if (requests == null)
                    requests = new List<Request>();

                request.Id = requests.Count > 0 ? requests.Max(r => r?.Id ?? 0) + 1 : 1;
                request.CreatedDate = DateTime.Now;
                request.Status = "Pending";
                requests.Add(request);
                SaveData();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating request: {ex.Message}", "Error");
                return false;
            }
        }

        public static List<Request> GetAllRequests()
        {
            try
            {
                if (requests == null || users == null)
                    return new List<Request>();

                // Create copies to avoid modifying original objects
                return requests.Where(r => r != null).Select(r => new Request
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    RequestType = r.RequestType,
                    Description = r.Description,
                    Status = r.Status,
                    CreatedDate = r.CreatedDate,
                    ProcessedDate = r.ProcessedDate,
                    ProcessedBy = r.ProcessedBy,
                    UserName = users.FirstOrDefault(u => u != null && u.Id == r.UserId)?.FullName ?? "Unknown"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting requests: {ex.Message}", "Error");
                return new List<Request>();
            }
        }

        public static List<Request> GetUserRequests(int userId)
        {
            try
            {
                if (requests == null)
                    return new List<Request>();

                return requests.Where(r => r != null && r.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting user requests: {ex.Message}", "Error");
                return new List<Request>();
            }
        }

        public static bool UpdateRequestStatus(int requestId, string status, int processedBy)
        {
            try
            {
                if (requests == null || string.IsNullOrWhiteSpace(status))
                    return false;

                var request = requests.FirstOrDefault(r => r != null && r.Id == requestId);
                if (request != null)
                {
                    request.Status = status;
                    request.ProcessedDate = DateTime.Now;
                    request.ProcessedBy = processedBy;
                    SaveData();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating request status: {ex.Message}", "Error");
                return false;
            }
        }

        // Report operations
        public static bool CreateReport(Report report)
        {
            try
            {
                if (report == null)
                    return false;

                if (reports == null)
                    reports = new List<Report>();

                report.Id = reports.Count > 0 ? reports.Max(r => r?.Id ?? 0) + 1 : 1;
                report.CreatedDate = DateTime.Now;
                report.Status = "Open";
                reports.Add(report);
                SaveData();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating report: {ex.Message}", "Error");
                return false;
            }
        }

        public static List<Report> GetAllReports()
        {
            try
            {
                if (reports == null || users == null)
                    return new List<Report>();

                // Create copies to avoid modifying original objects
                return reports.Where(r => r != null).Select(r => new Report
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    ReportType = r.ReportType,
                    Subject = r.Subject,
                    Description = r.Description,
                    Status = r.Status,
                    CreatedDate = r.CreatedDate,
                    ResolvedDate = r.ResolvedDate,
                    ResolvedBy = r.ResolvedBy,
                    UserName = users.FirstOrDefault(u => u != null && u.Id == r.UserId)?.FullName ?? "Unknown"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting reports: {ex.Message}", "Error");
                return new List<Report>();
            }
        }

        public static List<Report> GetUserReports(int userId)
        {
            try
            {
                if (reports == null)
                    return new List<Report>();

                return reports.Where(r => r != null && r.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting user reports: {ex.Message}", "Error");
                return new List<Report>();
            }
        }

        public static bool ResolveReport(int reportId, int resolvedBy)
        {
            try
            {
                if (reports == null)
                    return false;

                var report = reports.FirstOrDefault(r => r != null && r.Id == reportId);
                if (report != null)
                {
                    report.Status = "Resolved";
                    report.ResolvedDate = DateTime.Now;
                    report.ResolvedBy = resolvedBy;
                    SaveData();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resolving report: {ex.Message}", "Error");
                return false;
            }
        }

        // Statistics
        public static int GetUserCount()
        {
            try
            {
                if (users == null)
                    return 0;

                return users.Count(u => u != null && u.UserType == "User");
            }
            catch
            {
                return 0;
            }
        }

        public static int GetPendingRequestsCount()
        {
            try
            {
                if (requests == null)
                    return 0;

                return requests.Count(r => r != null && r.Status == "Pending");
            }
            catch
            {
                return 0;
            }
        }

        public static int GetOpenReportsCount()
        {
            try
            {
                if (reports == null)
                    return 0;

                return requests.Count(r => r != null && r.Status == "Open");
            }
            catch
            {
                return 0;
            }
        }

        public static int GetCertificatesCount()
        {
            try
            {
                if (requests == null)
                    return 0;

                return requests.Count(r => r != null && 
                    r.RequestType != null && 
                    r.RequestType.Contains("Certificate") && 
                    r.Status == "Approved");
            }
            catch
            {
                return 0;
            }
        }

        public static List<object> GetRecentActivities(int? userId = null)
        {
            try
            {
                var activities = new List<object>();

                if (requests != null && users != null)
                {
                    var recentRequests = requests
                        .Where(r => r != null && (userId == null || r.UserId == userId))
                        .Where(r => r.CreatedDate >= DateTime.Now.AddDays(-7))
                        .Select(r => new { 
                            Type = "Request", 
                            Subject = r.RequestType ?? "Unknown", 
                            Status = r.Status ?? "Unknown", 
                            CreatedDate = r.CreatedDate, 
                            UserName = users.FirstOrDefault(u => u != null && u.Id == r.UserId)?.FullName ?? "Unknown"
                        });

                    activities.AddRange(recentRequests);
                }

                if (reports != null && users != null)
                {
                    var recentReports = reports
                        .Where(r => r != null && (userId == null || r.UserId == userId))
                        .Where(r => r.CreatedDate >= DateTime.Now.AddDays(-7))
                        .Select(r => new { 
                            Type = "Report", 
                            Subject = r.Subject ?? "Unknown", 
                            Status = r.Status ?? "Unknown", 
                            CreatedDate = r.CreatedDate, 
                            UserName = users.FirstOrDefault(u => u != null && u.Id == r.UserId)?.FullName ?? "Unknown"
                        });

                    activities.AddRange(recentReports);
                }

                return activities.OrderByDescending(a => ((dynamic)a).CreatedDate).Take(10).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting recent activities: {ex.Message}", "Error");
                return new List<object>();
            }
        }

        public static List<dynamic> GetRecentActivities(int userId)
        {
            try
            {
                var activities = new List<dynamic>();
                
                if (requests != null)
                {
                    var userRequests = GetUserRequests(userId).OrderByDescending(r => r.CreatedDate).Take(5);
                    foreach (var req in userRequests)
                    {
                        if (req != null)
                        {
                            activities.Add(new {
                                Type = "Request",
                                Subject = req.RequestType ?? "Unknown",
                                Status = req.Status ?? "Unknown",
                                Date = req.CreatedDate
                            });
                        }
                    }
                }
                
                if (reports != null)
                {
                    var userReports = GetUserReports(userId).OrderByDescending(r => r.CreatedDate).Take(5);
                    foreach (var rep in userReports)
                    {
                        if (rep != null)
                        {
                            activities.Add(new {
                                Type = "Report",
                                Subject = rep.Subject ?? "Unknown",
                                Status = rep.Status ?? "Unknown",
                                Date = rep.CreatedDate
                            });
                        }
                    }
                }
                
                return activities.OrderByDescending(a => a.Date).Take(10).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting user activities: {ex.Message}", "Error");
                return new List<dynamic>();
            }
        }
    }
}