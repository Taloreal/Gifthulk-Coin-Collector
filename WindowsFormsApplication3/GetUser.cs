using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class GetUser : UserControl
    {
        public List<Form1> ParentF = new List<Form1>();
        public GetUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ParentF[0].webBrowser1.Document.GetElementById("user_login").SetAttribute("value", TB_Username.Text);
                ParentF[0].webBrowser1.Document.GetElementById("user_pass").SetAttribute("value", TB_Password.Text);
                ParentF[0].webBrowser1.Document.GetElementById("wp-submit").InvokeMember("click");
                ParentF[0].Tried = true;
                ParentF[0].Active_User = new GH_User();
                if (!tb_email.Enabled)
                    ParentF[0].Active_User.Update(TB_Username.Text, TB_Password.Text, "naate@taloreal.com");
                else
                    ParentF[0].Active_User.Update(TB_Username.Text, TB_Password.Text, tb_email.Text);
            }
            catch
            { return; }
        }

        public void Update(bool Escape, GH_User User)
        {
            if (Escape)
                return;
            TB_Username.Text = User.Username;
            TB_Password.Text = User.Password;
        }

        private void GetUser_Load(object sender, EventArgs e)
        {

        }

        private void CB_Log_CheckedChanged(object sender, EventArgs e)
        {
            tb_email.Enabled = CB_Log.Checked;
        }
    }
}
