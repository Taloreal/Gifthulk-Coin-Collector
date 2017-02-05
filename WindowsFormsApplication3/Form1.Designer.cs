namespace WindowsFormsApplication3
{
    partial class Form1
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
            Program.CloseAnnouncer();
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
            this.components = new System.ComponentModel.Container();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.AutoPlay = new System.Windows.Forms.Timer(this.components);
            this.AutoWatchMaxWait = new System.Windows.Forms.Timer(this.components);
            this.TopMostOff = new System.Windows.Forms.Timer(this.components);
            this.DelayedClick = new System.Windows.Forms.Timer(this.components);
            this.ReportBug = new System.Windows.Forms.Button();
            this.L_SecsToFault = new System.Windows.Forms.Label();
            this.getUser1 = new WindowsFormsApplication3.GetUser();
            this.URLGO = new System.Windows.Forms.TextBox();
            this.GO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(881, 453);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.Url = new System.Uri("http://www.gifthulk.com/wp-login.php?", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // AutoPlay
            // 
            this.AutoPlay.Interval = 7000;
            this.AutoPlay.Tick += new System.EventHandler(this.AutoPlay_Tick);
            // 
            // AutoWatchMaxWait
            // 
            this.AutoWatchMaxWait.Interval = 3000;
            this.AutoWatchMaxWait.Tick += new System.EventHandler(this.AutoWatchMaxWait_Tick);
            // 
            // TopMostOff
            // 
            this.TopMostOff.Interval = 2000;
            this.TopMostOff.Tick += new System.EventHandler(this.TopMostOff_Tick);
            // 
            // DelayedClick
            // 
            this.DelayedClick.Interval = 3000;
            this.DelayedClick.Tick += new System.EventHandler(this.DelayedClick_Tick);
            // 
            // ReportBug
            // 
            this.ReportBug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportBug.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportBug.Location = new System.Drawing.Point(719, 409);
            this.ReportBug.Name = "ReportBug";
            this.ReportBug.Size = new System.Drawing.Size(135, 32);
            this.ReportBug.TabIndex = 5;
            this.ReportBug.Text = "Report a bug";
            this.ReportBug.UseVisualStyleBackColor = true;
            this.ReportBug.Click += new System.EventHandler(this.ReportBug_Click);
            // 
            // L_SecsToFault
            // 
            this.L_SecsToFault.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.L_SecsToFault.AutoSize = true;
            this.L_SecsToFault.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_SecsToFault.Location = new System.Drawing.Point(277, 9);
            this.L_SecsToFault.Name = "L_SecsToFault";
            this.L_SecsToFault.Size = new System.Drawing.Size(243, 24);
            this.L_SecsToFault.TabIndex = 6;
            this.L_SecsToFault.Text = "Seconds to TV fault catch: 0";
            // 
            // getUser1
            // 
            this.getUser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.getUser1.Location = new System.Drawing.Point(673, 286);
            this.getUser1.Name = "getUser1";
            this.getUser1.Size = new System.Drawing.Size(308, 117);
            this.getUser1.TabIndex = 4;
            // 
            // URLGO
            // 
            this.URLGO.Location = new System.Drawing.Point(12, 40);
            this.URLGO.Name = "URLGO";
            this.URLGO.Size = new System.Drawing.Size(716, 20);
            this.URLGO.TabIndex = 7;
            // 
            // GO
            // 
            this.GO.Location = new System.Drawing.Point(743, 37);
            this.GO.Name = "GO";
            this.GO.Size = new System.Drawing.Size(75, 23);
            this.GO.TabIndex = 8;
            this.GO.Text = "GO!";
            this.GO.UseVisualStyleBackColor = true;
            this.GO.Click += new System.EventHandler(this.GO_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 453);
            this.Controls.Add(this.GO);
            this.Controls.Add(this.URLGO);
            this.Controls.Add(this.L_SecsToFault);
            this.Controls.Add(this.ReportBug);
            this.Controls.Add(this.getUser1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer AutoPlay;
        private System.Windows.Forms.Timer AutoWatchMaxWait;
        private System.Windows.Forms.Timer TopMostOff;
        private GetUser getUser1;
        public System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Timer DelayedClick;
        private System.Windows.Forms.Button ReportBug;
        private System.Windows.Forms.Label L_SecsToFault;
        private System.Windows.Forms.TextBox URLGO;
        private System.Windows.Forms.Button GO;
    }
}

