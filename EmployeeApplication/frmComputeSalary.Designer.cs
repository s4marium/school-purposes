namespace EmployeeApplication
{
    partial class frmComputeSalary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblJobTitle = new System.Windows.Forms.Label();
            this.lblRatePerHour = new System.Windows.Forms.Label();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.txtRatePerHour = new System.Windows.Forms.TextBox();
            this.txtTotalHours = new System.Windows.Forms.TextBox();
            this.btnComputeSalary = new System.Windows.Forms.Button();
            this.lblFirstNameResult = new System.Windows.Forms.Label();
            this.lblLastNameResult = new System.Windows.Forms.Label();
            this.lblBasicSalaryResult = new System.Windows.Forms.Label();
            this.lblFirstNameDisplay = new System.Windows.Forms.Label();
            this.lblLastNameDisplay = new System.Windows.Forms.Label();
            this.lblBasicSalaryDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(30, 30);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(250, 30);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last name";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(30, 80);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Department";
            // 
            // lblJobTitle
            // 
            this.lblJobTitle.AutoSize = true;
            this.lblJobTitle.Location = new System.Drawing.Point(250, 80);
            this.lblJobTitle.Name = "lblJobTitle";
            this.lblJobTitle.Size = new System.Drawing.Size(46, 13);
            this.lblJobTitle.TabIndex = 3;
            this.lblJobTitle.Text = "Job title";
            // 
            // lblRatePerHour
            // 
            this.lblRatePerHour.AutoSize = true;
            this.lblRatePerHour.Location = new System.Drawing.Point(30, 130);
            this.lblRatePerHour.Name = "lblRatePerHour";
            this.lblRatePerHour.Size = new System.Drawing.Size(72, 13);
            this.lblRatePerHour.TabIndex = 4;
            this.lblRatePerHour.Text = "Rate per hour";
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Location = new System.Drawing.Point(250, 130);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(95, 13);
            this.lblTotalHours.TabIndex = 5;
            this.lblTotalHours.Text = "Total hours worked";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(30, 50);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(150, 20);
            this.txtFirstName.TabIndex = 6;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(250, 50);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(150, 20);
            this.txtLastName.TabIndex = 7;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(30, 100);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(150, 20);
            this.txtDepartment.TabIndex = 8;
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(250, 100);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(150, 20);
            this.txtJobTitle.TabIndex = 9;
            // 
            // txtRatePerHour
            // 
            this.txtRatePerHour.Location = new System.Drawing.Point(30, 150);
            this.txtRatePerHour.Name = "txtRatePerHour";
            this.txtRatePerHour.Size = new System.Drawing.Size(150, 20);
            this.txtRatePerHour.TabIndex = 10;
            // 
            // txtTotalHours
            // 
            this.txtTotalHours.Location = new System.Drawing.Point(250, 150);
            this.txtTotalHours.Name = "txtTotalHours";
            this.txtTotalHours.Size = new System.Drawing.Size(150, 20);
            this.txtTotalHours.TabIndex = 11;
            // 
            // btnComputeSalary
            // 
            this.btnComputeSalary.Location = new System.Drawing.Point(175, 190);
            this.btnComputeSalary.Name = "btnComputeSalary";
            this.btnComputeSalary.Size = new System.Drawing.Size(100, 30);
            this.btnComputeSalary.TabIndex = 12;
            this.btnComputeSalary.Text = "Compute Salary";
            this.btnComputeSalary.UseVisualStyleBackColor = true;
            this.btnComputeSalary.Click += new System.EventHandler(this.btnComputeSalary_Click);
            // 
            // lblFirstNameResult
            // 
            this.lblFirstNameResult.AutoSize = true;
            this.lblFirstNameResult.Location = new System.Drawing.Point(30, 240);
            this.lblFirstNameResult.Name = "lblFirstNameResult";
            this.lblFirstNameResult.Size = new System.Drawing.Size(60, 13);
            this.lblFirstNameResult.TabIndex = 13;
            this.lblFirstNameResult.Text = "First name:";
            // 
            // lblLastNameResult
            // 
            this.lblLastNameResult.AutoSize = true;
            this.lblLastNameResult.Location = new System.Drawing.Point(30, 260);
            this.lblLastNameResult.Name = "lblLastNameResult";
            this.lblLastNameResult.Size = new System.Drawing.Size(61, 13);
            this.lblLastNameResult.TabIndex = 14;
            this.lblLastNameResult.Text = "Last name:";
            // 
            // lblBasicSalaryResult
            // 
            this.lblBasicSalaryResult.AutoSize = true;
            this.lblBasicSalaryResult.Location = new System.Drawing.Point(30, 280);
            this.lblBasicSalaryResult.Name = "lblBasicSalaryResult";
            this.lblBasicSalaryResult.Size = new System.Drawing.Size(71, 13);
            this.lblBasicSalaryResult.TabIndex = 15;
            this.lblBasicSalaryResult.Text = "Basic Salary:";
            // 
            // lblFirstNameDisplay
            // 
            this.lblFirstNameDisplay.AutoSize = true;
            this.lblFirstNameDisplay.Location = new System.Drawing.Point(120, 240);
            this.lblFirstNameDisplay.Name = "lblFirstNameDisplay";
            this.lblFirstNameDisplay.Size = new System.Drawing.Size(88, 13);
            this.lblFirstNameDisplay.TabIndex = 16;
            this.lblFirstNameDisplay.Text = "<first name here>";
            // 
            // lblLastNameDisplay
            // 
            this.lblLastNameDisplay.AutoSize = true;
            this.lblLastNameDisplay.Location = new System.Drawing.Point(120, 260);
            this.lblLastNameDisplay.Name = "lblLastNameDisplay";
            this.lblLastNameDisplay.Size = new System.Drawing.Size(89, 13);
            this.lblLastNameDisplay.TabIndex = 17;
            this.lblLastNameDisplay.Text = "<last name here>";
            // 
            // lblBasicSalaryDisplay
            // 
            this.lblBasicSalaryDisplay.AutoSize = true;
            this.lblBasicSalaryDisplay.Location = new System.Drawing.Point(120, 280);
            this.lblBasicSalaryDisplay.Name = "lblBasicSalaryDisplay";
            this.lblBasicSalaryDisplay.Size = new System.Drawing.Size(34, 13);
            this.lblBasicSalaryDisplay.TabIndex = 18;
            this.lblBasicSalaryDisplay.Text = "00.00";
            // 
            // frmComputeSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 350);
            this.Controls.Add(this.lblBasicSalaryDisplay);
            this.Controls.Add(this.lblLastNameDisplay);
            this.Controls.Add(this.lblFirstNameDisplay);
            this.Controls.Add(this.lblBasicSalaryResult);
            this.Controls.Add(this.lblLastNameResult);
            this.Controls.Add(this.lblFirstNameResult);
            this.Controls.Add(this.btnComputeSalary);
            this.Controls.Add(this.txtTotalHours);
            this.Controls.Add(this.txtRatePerHour);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblTotalHours);
            this.Controls.Add(this.lblRatePerHour);
            this.Controls.Add(this.lblJobTitle);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmComputeSalary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Salary Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblJobTitle;
        private System.Windows.Forms.Label lblRatePerHour;
        private System.Windows.Forms.Label lblTotalHours;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.TextBox txtRatePerHour;
        private System.Windows.Forms.TextBox txtTotalHours;
        private System.Windows.Forms.Button btnComputeSalary;
        private System.Windows.Forms.Label lblFirstNameResult;
        private System.Windows.Forms.Label lblLastNameResult;
        private System.Windows.Forms.Label lblBasicSalaryResult;
        private System.Windows.Forms.Label lblFirstNameDisplay;
        private System.Windows.Forms.Label lblLastNameDisplay;
        private System.Windows.Forms.Label lblBasicSalaryDisplay;
    }
}

