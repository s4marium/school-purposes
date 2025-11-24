using System;
using System.Windows.Forms;
using BarangayManagementSystem.Forms;
using BarangayManagementSystem.Data;

namespace BarangayManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Initialize database - Commented out as method doesn't exist
            // DatabaseHelper.InitializeDatabase();
            
            // Create Images directory if it doesn't exist
            if (!System.IO.Directory.Exists("Images"))
            {
                System.IO.Directory.CreateDirectory("Images");
                System.IO.Directory.CreateDirectory("Images/Profiles");
                System.IO.Directory.CreateDirectory("Images/News");
                System.IO.Directory.CreateDirectory("Images/Officials");
                System.IO.Directory.CreateDirectory("Images/Documents");
            }

            // Run the login form
            Application.Run(new LoginForm());
        }
    }
}
