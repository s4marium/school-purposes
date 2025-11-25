using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BarangayManagementSystem.Data;
using BarangayManagementSystem.Models;
using UserModel = BarangayManagementSystem.Models.User; // alias added

namespace BarangayManagementSystem.Forms
{
    public partial class PrintingCenterForm : Form
    {
        private readonly UserModel currentUser; // changed User -> UserModel

        private readonly (string Name, string Icon, string Description)[] documentTypes = new[]
        {
            ("Barangay Clearance", "📄", "Print barangay clearance certificate"),
            ("Certificate of Residency", "🏠", "Print certificate of residency"),
            ("Certificate of Indigency", "📝", "Print certificate of indigency"),
            ("Business Permit", "💼", "Print business permit"),
            ("Barangay ID", "🆔", "Print barangay ID"),
            ("Blotter Report", "📋", "Print blotter report")
        };

        public PrintingCenterForm(UserModel user) // changed User -> UserModel
        {
            currentUser = user;
            InitializeComponent();
            LoadDocumentCards();
        }

        private void LoadDocumentCards()
        {
            flowDocuments.SuspendLayout();
            flowDocuments.Controls.Clear();

            foreach (var d in documentTypes)
            {
                flowDocuments.Controls.Add(CreateDocumentCard(d.Name, d.Icon, d.Description));
            }

            flowDocuments.ResumeLayout();
        }

        private Panel CreateDocumentCard(string name, string icon, string description)
        {
            int cardWidth = flowDocuments.ClientSize.Width - 30;

            Panel card = new Panel
            {
                Size = new Size(cardWidth, 95),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                Cursor = Cursors.Hand
            };

            Label iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 32F),
                Location = new Point(20, 15),
                Size = new Size(60, 60)
            };

            Label nameLabel = new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(100, 20),
                Size = new Size(cardWidth - 260, 30)
            };

            Label descLabel = new Label
            {
                Text = description,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(100, 50),
                Size = new Size(cardWidth - 260, 25)
            };

            Button printBtn = new Button
            {
                Text = "🖨️ Print",
                Size = new Size(120, 35),
                Location = new Point(cardWidth - 140, 30),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = name
            };
            printBtn.FlatAppearance.BorderSize = 0;
            printBtn.Click += PrintBtn_Click;

            card.Controls.AddRange(new Control[] { iconLabel, nameLabel, descLabel, printBtn });
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(248, 249, 250);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            return card;
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is string documentType)
            {
                using (var preview = new PrintPreviewForm(currentUser, documentType))
                {
                    preview.ShowDialog(this);
                }

                EnhancedDatabaseHelper.LogActivity(currentUser.Id, "Print Document", "Printing",
                    $"Printed {documentType}");
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            flowDocuments.SuspendLayout();

            int cardWidth = flowDocuments.ClientSize.Width - 30;
            // Adjust existing card widths on resize
            foreach (Panel Card in flowDocuments.Controls.OfType<Panel>())
            {
                Card.Width = cardWidth;


                Button btn = Card.Controls.OfType<Button>().FirstOrDefault();


                    foreach (Control child in Card.Controls)
                    {
                    if (child is Label lbl)
                        {
                            if (lbl.Left == 100)
                            {
                                lbl.Width = Card.Width - 260;
                            }
                        }
                    if (child is Button button)
                        {
                            btn.Location = new Point(Card.Width - 140, 30);
                        }
                    }
                
            }
            flowDocuments.ResumeLayout();
        }
    }
}