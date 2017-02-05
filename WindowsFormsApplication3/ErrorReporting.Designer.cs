namespace WindowsFormsApplication3
{
    partial class ErrorReporting
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
            this.Hide();
            return;
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
            this.SendReport = new System.Windows.Forms.Button();
            this.Voluntary = new System.Windows.Forms.Label();
            this.L_ContactEmail = new System.Windows.Forms.Label();
            this.ContactEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorGroup = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.BugDetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SendReport
            // 
            this.SendReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendReport.Location = new System.Drawing.Point(12, 325);
            this.SendReport.Name = "SendReport";
            this.SendReport.Size = new System.Drawing.Size(445, 32);
            this.SendReport.TabIndex = 3;
            this.SendReport.Text = "Send bug Report";
            this.SendReport.UseVisualStyleBackColor = true;
            this.SendReport.Click += new System.EventHandler(this.SendReport_Click);
            // 
            // Voluntary
            // 
            this.Voluntary.AutoSize = true;
            this.Voluntary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Voluntary.Location = new System.Drawing.Point(12, 3);
            this.Voluntary.Name = "Voluntary";
            this.Voluntary.Size = new System.Drawing.Size(266, 24);
            this.Voluntary.TabIndex = 4;
            this.Voluntary.Text = "All information sent is voluntary";
            // 
            // L_ContactEmail
            // 
            this.L_ContactEmail.AutoSize = true;
            this.L_ContactEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ContactEmail.Location = new System.Drawing.Point(12, 33);
            this.L_ContactEmail.Name = "L_ContactEmail";
            this.L_ContactEmail.Size = new System.Drawing.Size(135, 24);
            this.L_ContactEmail.TabIndex = 5;
            this.L_ContactEmail.Text = "Contact Email: ";
            // 
            // ContactEmail
            // 
            this.ContactEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactEmail.Location = new System.Drawing.Point(143, 30);
            this.ContactEmail.Name = "ContactEmail";
            this.ContactEmail.Size = new System.Drawing.Size(314, 29);
            this.ContactEmail.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Section:";
            // 
            // ErrorGroup
            // 
            this.ErrorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorGroup.Items.Add("Login Automation");
            this.ErrorGroup.Items.Add("Guess The Card Automation");
            this.ErrorGroup.Items.Add("Gifthulk TV Automation");
            this.ErrorGroup.Location = new System.Drawing.Point(143, 71);
            this.ErrorGroup.Name = "ErrorGroup";
            this.ErrorGroup.Size = new System.Drawing.Size(314, 29);
            this.ErrorGroup.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Details (Provide as many as possible)";
            // 
            // BugDetails
            // 
            this.BugDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BugDetails.Location = new System.Drawing.Point(12, 138);
            this.BugDetails.Multiline = true;
            this.BugDetails.Name = "BugDetails";
            this.BugDetails.Size = new System.Drawing.Size(445, 181);
            this.BugDetails.TabIndex = 10;
            // 
            // ErrorReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 369);
            this.Controls.Add(this.BugDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ErrorGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ContactEmail);
            this.Controls.Add(this.L_ContactEmail);
            this.Controls.Add(this.Voluntary);
            this.Controls.Add(this.SendReport);
            this.MaximumSize = new System.Drawing.Size(485, 408);
            this.MinimumSize = new System.Drawing.Size(485, 408);
            this.Name = "ErrorReporting";
            this.Text = "Error Reporting";
            this.Load += new System.EventHandler(this.ErrorReporting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendReport;
        private System.Windows.Forms.Label Voluntary;
        private System.Windows.Forms.Label L_ContactEmail;
        public System.Windows.Forms.TextBox ContactEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DomainUpDown ErrorGroup;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox BugDetails;
    }
}