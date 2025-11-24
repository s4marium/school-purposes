using System.Drawing;
using System.Windows.Forms;

namespace BarangayManagementSystem.Forms.User
{
    partial class OfficialsViewForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private FlowLayoutPanel officialsFlowPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.officialsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(429, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏛️ Barangay Officials Directory";
            // 
            // officialsFlowPanel
            // 
            this.officialsFlowPanel.AutoScroll = true;
            this.officialsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.officialsFlowPanel.Location = new System.Drawing.Point(20, 70);
            this.officialsFlowPanel.Name = "officialsFlowPanel";
            this.officialsFlowPanel.Size = new System.Drawing.Size(880, 610);
            this.officialsFlowPanel.TabIndex = 1;
            this.officialsFlowPanel.WrapContents = true;
            // 
            // OfficialsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.officialsFlowPanel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OfficialsViewForm";
            this.Load += new System.EventHandler(this.OfficialsViewForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}