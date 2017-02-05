namespace WindowsFormsApplication3
{
    partial class Breaker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Login = new System.Windows.Forms.CheckBox();
            this.CB_GuessCard = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "I want to break after :";
            // 
            // CB_Login
            // 
            this.CB_Login.AutoSize = true;
            this.CB_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Login.Location = new System.Drawing.Point(12, 36);
            this.CB_Login.Name = "CB_Login";
            this.CB_Login.Size = new System.Drawing.Size(76, 28);
            this.CB_Login.TabIndex = 2;
            this.CB_Login.Text = "Login";
            this.CB_Login.UseVisualStyleBackColor = true;
            // 
            // CB_GuessCard
            // 
            this.CB_GuessCard.AutoSize = true;
            this.CB_GuessCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_GuessCard.Location = new System.Drawing.Point(12, 70);
            this.CB_GuessCard.Name = "CB_GuessCard";
            this.CB_GuessCard.Size = new System.Drawing.Size(167, 28);
            this.CB_GuessCard.TabIndex = 3;
            this.CB_GuessCard.Text = "Guess The Card";
            this.CB_GuessCard.UseVisualStyleBackColor = true;
            // 
            // Breaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CB_GuessCard);
            this.Controls.Add(this.CB_Login);
            this.Controls.Add(this.label1);
            this.Name = "Breaker";
            this.Size = new System.Drawing.Size(198, 103);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox CB_Login;
        public System.Windows.Forms.CheckBox CB_GuessCard;
    }
}
