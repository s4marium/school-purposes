namespace WordGuessApplication
{
    partial class frmGuessWord
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
            this.lblWordToGuess = new System.Windows.Forms.Label();
            this.txtGuessInput = new System.Windows.Forms.TextBox();
            this.btnGuess = new System.Windows.Forms.Button();
            this.listBoxWrongGuesses = new System.Windows.Forms.ListBox();
            this.lblWrongGuessHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWordToGuess
            // 
            this.lblWordToGuess.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblWordToGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWordToGuess.ForeColor = System.Drawing.Color.White;
            this.lblWordToGuess.Location = new System.Drawing.Point(50, 50);
            this.lblWordToGuess.Name = "lblWordToGuess";
            this.lblWordToGuess.Size = new System.Drawing.Size(300, 80);
            this.lblWordToGuess.TabIndex = 0;
            this.lblWordToGuess.Text = "c??????r";
            this.lblWordToGuess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGuessInput
            // 
            this.txtGuessInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuessInput.Location = new System.Drawing.Point(100, 150);
            this.txtGuessInput.Name = "txtGuessInput";
            this.txtGuessInput.Size = new System.Drawing.Size(200, 29);
            this.txtGuessInput.TabIndex = 1;
            // 
            // btnGuess
            // 
            this.btnGuess.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnGuess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuess.ForeColor = System.Drawing.Color.White;
            this.btnGuess.Location = new System.Drawing.Point(150, 200);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(100, 40);
            this.btnGuess.TabIndex = 2;
            this.btnGuess.Text = "Guess";
            this.btnGuess.UseVisualStyleBackColor = false;
            this.btnGuess.Click += new System.EventHandler(this.btnGuess_Click);
            // 
            // listBoxWrongGuesses
            // 
            this.listBoxWrongGuesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxWrongGuesses.FormattingEnabled = true;
            this.listBoxWrongGuesses.ItemHeight = 16;
            this.listBoxWrongGuesses.Location = new System.Drawing.Point(400, 80);
            this.listBoxWrongGuesses.Name = "listBoxWrongGuesses";
            this.listBoxWrongGuesses.Size = new System.Drawing.Size(180, 180);
            this.listBoxWrongGuesses.TabIndex = 3;
            // 
            // lblWrongGuessHeader
            // 
            this.lblWrongGuessHeader.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblWrongGuessHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrongGuessHeader.ForeColor = System.Drawing.Color.White;
            this.lblWrongGuessHeader.Location = new System.Drawing.Point(400, 50);
            this.lblWrongGuessHeader.Name = "lblWrongGuessHeader";
            this.lblWrongGuessHeader.Size = new System.Drawing.Size(180, 30);
            this.lblWrongGuessHeader.TabIndex = 4;
            this.lblWrongGuessHeader.Text = "Wrong guess";
            this.lblWrongGuessHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 311);
            this.Controls.Add(this.lblWrongGuessHeader);
            this.Controls.Add(this.listBoxWrongGuesses);
            this.Controls.Add(this.btnGuess);
            this.Controls.Add(this.txtGuessInput);
            this.Controls.Add(this.lblWordToGuess);
            this.Name = "Form1";
            this.Text = "Guess the Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWordToGuess;
        private System.Windows.Forms.TextBox txtGuessInput;
        private System.Windows.Forms.Button btnGuess;
        private System.Windows.Forms.ListBox listBoxWrongGuesses;
        private System.Windows.Forms.Label lblWrongGuessHeader;
    }
}

