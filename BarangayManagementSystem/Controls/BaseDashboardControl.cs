using System;
using System.Drawing;
using System.Windows.Forms;
using BarangayManagementSystem.Models;

namespace BarangayManagementSystem.Controls
{
    public abstract class BaseDashboardControl : UserControl
    {
        protected User currentUser;

        public BaseDashboardControl(User user)
        {
            currentUser = user;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.AutoScroll = true;
            this.Padding = new Padding(20);
        }

        protected void DrawCardShadow(Panel card, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.FromArgb(222, 226, 230), 1))
            {
                Rectangle rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        protected Label CreateTitle(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(10, 10),
                AutoSize = true
            };
        }
    }
}