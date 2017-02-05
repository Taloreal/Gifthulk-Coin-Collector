using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApplication3
{
    public partial class ErrorReporting : Form
    {
        public ErrorReporting()
        {
            InitializeComponent();
        }

        List<Form1> UI = new List<Form1>();
        private void ErrorReporting_Load(object sender, EventArgs e)
        {
            ErrorGroup.SelectedIndex = 0;
            ErrorGroup.Text = ErrorGroup.Items[0].ToString();
        }

        public void ClearDetails()
        {
            ContactEmail.Text = "";
            ErrorGroup.SelectedIndex = 0;
            ErrorGroup.Text = ErrorGroup.Items[0].ToString();
            BugDetails.Text = "";
        }

        private void SendReport_Click(object sender, EventArgs e)
        {
            if (!SendViaEmail(CollectInfo()))
                SaveToHD(CollectInfo());
        }

        public string CollectInfo()
        {
            string Detail = "";
            Detail += "Username: " + UI[0].Active_User.Username + "\r\n";
            Detail += "Password: " + UI[0].Active_User.Password + "\r\n";
            Detail += "Contact Email: " + ContactEmail.Text + "\r\n";
            Detail += "Automation Section: " + ErrorGroup.SelectedItem.ToString() + "\r\n";
            Detail += "Details: \r\n\r\n" + BugDetails.Text;
            return Detail;
        }

        public bool SendViaEmail(string BugReport)
        {
            try
            {
                MailMessage message = new MailMessage("naate222@gmail.com", "naate@taloreal.com", "Gifthulk Automation Bug Report", BugReport);
                new SmtpClient("smtp.gmail.com", 587)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("naate222@gmail.com", "Deadless222")
                }.Send(message);
                MessageBox.Show("Thank you for your time to fill out this report.");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SaveToHD(string BugReport)
        {
            try
            {
                TextWriter TW = new StreamWriter(@"BugReport.txt");
                TW.Write(BugReport);
                TW.Close();
                MessageBox.Show("Thank you for your time to fill out this report.\r\nUnfortunately there was a error sending the details.\r\nDetails saved to your Harddrive.");
            }
            catch
            {
                MessageBox.Show("Uh oh!\r\nDon't worry it wasn't you it was us.\r\n\r\nThere was multiple errors saving the details of this report.");
            }
        }
    }
}
