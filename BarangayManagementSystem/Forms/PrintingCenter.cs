using System;
using System.Drawing;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Forms
{
    public class PrintingCenter
    {
        private Models.User currentUser;  // Changed from: private User currentUser;
        private Panel parentPanel;

        public PrintingCenter(Models.User user, Panel parent)  // Changed from: public PrintingCenter(User user, Panel parent)
        {
            currentUser = user;
            parentPanel = parent;
        }

        public void ShowPrintingCenter()
        {
            parentPanel.Controls.Clear();

            Label titleLabel = new Label
            {
                Text = "🖨️ Document Printing Center",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.FromArgb(52, 58, 64)
            };

            Label descLabel = new Label
            {
                Text = "Select a document type to print:",
                Font = new Font("Segoe UI", 12F),
                Location = new Point(10, 60),
                Size = new Size(500, 30),
                ForeColor = Color.FromArgb(108, 117, 125)
            };

            // Document types panel
            FlowLayoutPanel documentsFlow = new FlowLayoutPanel
            {
                Location = new Point(10, 110),
                Size = new Size(parentPanel.Width - 50, 500),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true
            };

            var documentTypes = new[]
            {
                new { Name = "Barangay Clearance", Icon = "📄", Description = "Print barangay clearance certificate" },
                new { Name = "Certificate of Residency", Icon = "🏠", Description = "Print certificate of residency" },
                new { Name = "Certificate of Indigency", Icon = "📝", Description = "Print certificate of indigency" },
                new { Name = "Business Permit", Icon = "💼", Description = "Print business permit" },
                new { Name = "Barangay ID", Icon = "🆔", Description = "Print barangay ID" },
                new { Name = "Blotter Report", Icon = "📋", Description = "Print blotter report" }
            };

            foreach (var doc in documentTypes)
            {
                Panel docCard = CreateDocumentCard(doc.Name, doc.Icon, doc.Description);
                documentsFlow.Controls.Add(docCard);
            }

            parentPanel.Controls.AddRange(new Control[] { titleLabel, descLabel, documentsFlow });
        }

        private Panel CreateDocumentCard(string name, string icon, string description)
        {
            Panel card = new Panel
            {
                Size = new Size(parentPanel.Width - 80, 100),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                Cursor = Cursors.Hand
            };

            Label iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 32F),
                Location = new Point(20, 20),
                Size = new Size(60, 60)
            };

            Label nameLabel = new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(100, 20),
                Size = new Size(400, 30)
            };

            Label descLabel = new Label
            {
                Text = description,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(100, 50),
                Size = new Size(400, 25)
            };

            Button printBtn = new Button
            {
                Text = "🖨️ Print",
                Size = new Size(120, 35),
                Location = new Point(card.Width - 140, 30),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            printBtn.FlatAppearance.BorderSize = 0;
            printBtn.Click += (s, e) => PrintDocument(name);

            card.Controls.AddRange(new Control[] { iconLabel, nameLabel, descLabel, printBtn });

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(248, 249, 250);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            return card;
        }

        private void PrintDocument(string documentType)
        {
            Form printForm = new Form
            {
                Text = $"Print {documentType}",
                Size = new Size(600, 500),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label titleLabel = new Label
            {
                Text = $"Print Preview: {documentType}",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(30, 30),
                Size = new Size(500, 35),
                ForeColor = Color.FromArgb(52, 58, 64)
            };

            Panel previewPanel = new Panel
            {
                Location = new Point(30, 80),
                Size = new Size(540, 300),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label previewLabel = new Label
            {
                Text = $@"
REPUBLIC OF THE PHILIPPINES
{EnhancedDatabaseHelper.GetSystemSettings().BarangayName}

{documentType.ToUpper()}

This is to certify that...

[Document content will appear here]

Date Issued: {DateTime.Now:MMMM dd, yyyy}
                ",
                Font = new Font("Courier New", 10F),
                Location = new Point(20, 20),
                Size = new Size(500, 260),
                TextAlign = ContentAlignment.TopLeft
            };

            previewPanel.Controls.Add(previewLabel);

            Button printBtn = new Button
            {
                Text = "🖨️ Print Document",
                Size = new Size(150, 40),
                Location = new Point(220, 400),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            printBtn.FlatAppearance.BorderSize = 0;
            printBtn.Click += (s, e) => {
                MessageBox.Show($"Printing {documentType}...\n\nThis feature will be integrated with your system printer.",
                    "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Print Document", "Printing",
                    $"Printed {documentType}");
                
                printForm.Close();
            };

            Button cancelBtn = new Button
            {
                Text = "Cancel",
                Size = new Size(100, 40),
                Location = new Point(380, 400),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            cancelBtn.FlatAppearance.BorderSize = 0;
            cancelBtn.Click += (s, e) => printForm.Close();

            printForm.Controls.AddRange(new Control[] { 
                titleLabel, previewPanel, printBtn, cancelBtn 
            });

            printForm.ShowDialog();
        }
    }
}