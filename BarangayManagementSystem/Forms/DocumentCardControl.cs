using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms
{
    public partial class DocumentCardControl : UserControl
    {
        public event EventHandler PrintRequested;

        public DocumentCardControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public string DocumentIcon
        {
            get => lblIcon.Text;
            set => lblIcon.Text = value;
        }

        [Browsable(true)]
        public string DocumentName
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        [Browsable(true)]
        public string DocumentDescription
        {
            get => lblDescription.Text;
            set => lblDescription.Text = value;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintRequested?.Invoke(this, EventArgs.Empty);
        }

        private void DocumentCardControl_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(248, 249, 250);
        }

        private void DocumentCardControl_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
    }
}