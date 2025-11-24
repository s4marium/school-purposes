using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms.User
{
    public partial class OfficialsViewForm : Form
    {
        private Models.User currentUser;

        public OfficialsViewForm(Models.User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void OfficialsViewForm_Load(object sender, EventArgs e)
        {
            LoadOfficials();
        }

        private void LoadOfficials()
        {
            officialsFlowPanel.Controls.Clear();

            try
            {
                var officials = EnhancedDatabaseHelper.GetAllOfficials(true);

                if (officials != null && officials.Any())
                {
                    foreach (var official in officials)
                    {
                        Panel officialCard = CreateOfficialCard(official);
                        officialsFlowPanel.Controls.Add(officialCard);
                    }
                }
                else
                {
                    Label noOfficials = new Label
                    {
                        Text = "No officials information available.",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.FromArgb(108, 117, 125),
                        AutoSize = true,
                        Margin = new Padding(10)
                    };
                    officialsFlowPanel.Controls.Add(noOfficials);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading officials: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateOfficialCard(BarangayOfficial official)
        {
            Panel card = new Panel
            {
                Size = new Size(270, 320),
                BackColor = Color.White,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            Panel avatar = new Panel
            {
                Size = new Size(80, 80),
                Location = new Point(95, 20),
                BackColor = Color.FromArgb(40, 167, 69)
            };
            avatar.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(avatar.BackColor))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, avatar.Width, avatar.Height);
                }
                using (Font font = new Font("Segoe UI", 32F, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    string initial = (official.FullName ?? "?").Substring(0, 1).ToUpper();
                    SizeF textSize = e.Graphics.MeasureString(initial, font);
                    e.Graphics.DrawString(initial, font, textBrush,
                        (avatar.Width - textSize.Width) / 2, (avatar.Height - textSize.Height) / 2);
                }
            };

            Label nameLabel = new Label
            {
                Text = official.FullName ?? "Unknown",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(10, 115),
                Size = new Size(250, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label positionLabel = new Label
            {
                Text = official.Position ?? "Position",
                Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = Color.FromArgb(40, 167, 69),
                Location = new Point(10, 140),
                Size = new Size(250, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label deptLabel = new Label
            {
                Text = official.Department ?? "Department",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(10, 165),
                Size = new Size(250, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label contactLabel = new Label
            {
                Text = $"📞 {official.ContactNumber ?? "N/A"}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(10, 195),
                Size = new Size(250, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label emailLabel = new Label
            {
                Text = $"📧 {official.Email ?? "N/A"}",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(10, 218),
                Size = new Size(250, 18),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoEllipsis = true
            };

            Button viewDetailsBtn = new Button
            {
                Text = "View Profile",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(60, 250),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = official
            };
            viewDetailsBtn.FlatAppearance.BorderSize = 0;
            viewDetailsBtn.Click += ViewOfficialDetails_Click;

            card.Controls.AddRange(new Control[] {
                avatar, nameLabel, positionLabel, deptLabel, contactLabel, emailLabel, viewDetailsBtn
            });

            return card;
        }

        private void ViewOfficialDetails_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is BarangayOfficial official)
            {
                Form detailsForm = new Form
                {
                    Text = $"{official.FullName ?? "Official"} - Profile",
                    Size = new Size(600, 500),
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = Color.White
                };

                string details = $@"
OFFICIAL PROFILE

Name: {official.FullName ?? "N/A"}
Position: {official.Position ?? "N/A"}
Department: {official.Department ?? "N/A"}

Contact Information:
Phone: {official.ContactNumber ?? "N/A"}
Email: {official.Email ?? "N/A"}
Address: {official.Address ?? "N/A"}

Term Details:
Start Date: {official.StartDate:MMMM dd, yyyy}
Status: {(official.IsActive ? "Active" : "Inactive")}

Responsibilities:
{official.Responsibilities ?? "Not specified"}
                ";

                TextBox txtDetails = new TextBox
                {
                    Text = details,
                    Font = new Font("Consolas", 10F),
                    Location = new Point(30, 30),
                    Size = new Size(540, 380),
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Button closeBtn = new Button
                {
                    Text = "Close",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    Location = new Point(470, 420),
                    Size = new Size(100, 35),
                    BackColor = Color.FromArgb(108, 117, 125),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                closeBtn.FlatAppearance.BorderSize = 0;
                closeBtn.Click += (s, args) => detailsForm.Close();

                detailsForm.Controls.AddRange(new Control[] { txtDetails, closeBtn });
                detailsForm.ShowDialog();
            }
        }
    }
}