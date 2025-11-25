namespace BarangayManagementSystem.Forms
{
    partial class PrintingCenterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.FlowLayoutPanel flowDocuments;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.flowDocuments = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(380, 37);
            this.lblTitle.Text = "🖨️ Document Printing Center";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblDescription.Location = new System.Drawing.Point(12, 58);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(500, 30);
            this.lblDescription.Text = "Select a document type to print:";
            // 
            // flowDocuments
            // 
            this.flowDocuments.Anchor = (System.Windows.Forms.AnchorStyles.Top 
                | System.Windows.Forms.AnchorStyles.Bottom 
                | System.Windows.Forms.AnchorStyles.Left 
                | System.Windows.Forms.AnchorStyles.Right);
            this.flowDocuments.AutoScroll = true;
            this.flowDocuments.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowDocuments.Location = new System.Drawing.Point(12, 110);
            this.flowDocuments.Name = "flowDocuments";
            this.flowDocuments.Size = new System.Drawing.Size(760, 480);
            this.flowDocuments.WrapContents = false;
            // 
            // PrintingCenterForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.flowDocuments);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrintingCenterForm";
            this.Text = "PrintingCenterForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}