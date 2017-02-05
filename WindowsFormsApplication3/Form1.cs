using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using System.Media;
using System.Diagnostics;
using System.Windows.Forms;
using System.Speech.Synthesis;
using Microsoft.Win32;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Counter = 0;
        bool Wait = true;
        bool once = false;
        bool Clos = false;
        //bool Break = false;
        string Coins = "0 HC";
        bool FirstSave = true;
        string Watch_Value = "";
        public bool Tried = false;
        bool StartWatching = false;
        public bool LogMeOn = false;
        public string Last_Video = "";
        GH_TV TVwatcher = new GH_TV();
        public GH_User Active_User = new GH_User();
        List<GH_Card> Results = new List<GH_Card>();
        ErrorReporting BugReport = new ErrorReporting();

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            AdjustInterface(!once);
            bool Home = webBrowser1.Url.ToString() == "http://www.gifthulk.com/";
            bool Login = webBrowser1.Url.ToString().Contains("www.gifthulk.com/wp-login.php");
            bool WrongLogon = Login && Tried;

            getUser1.WrongLogin.Visible = WrongLogon;
            LogMeOn = !WrongLogon && (Active_User != null);
            Tried = false;
            Coins = GetHulkCoins(!Home);
            getUser1.Visible = (Login && !LogMeOn) || WrongLogon;
            DelayedClick.Enabled = (Home && StartWatching);

            if (!DelayedClick.Enabled && Home)
                webBrowser1.Url = new Uri("http://www.gifthulk.com/guess-the-card/");
            RememberMe(!LogMeOn);
            SaveUser(Login);
            AutoPlay.Enabled = webBrowser1.Url.ToString().Contains("http://www.gifthulk.com/guess-the-card/");
            Clos = webBrowser1.Url.ToString().Contains("tv.gifthulk.com/watch/");
            Start_AutoWatch(!Clos);
        }

        string GetHulkCoins(bool Escape)
        {
            if (Escape)
                return Coins;
            try { return webBrowser1.Document.GetElementById("user-balance-count").InnerText; }
            catch { return Coins; }
        }

        void AdjustInterface(bool Escape)
        {
            if (Escape)
                return;
            once = false;
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Maximized;
            webBrowser1.Focus();
            TopMostOff.Enabled = true;
        }

        void RememberMe(bool Escape)
        {
            if (Escape)
                return;
            LogMeOn = webBrowser1.Url.ToString().Contains("http://www.gifthulk.com/wp-login.php");
            try {
                webBrowser1.Document.GetElementById("user_login").SetAttribute("value", Active_User.Username);
                webBrowser1.Document.GetElementById("user_pass").SetAttribute("value", Active_User.Password);
                webBrowser1.Document.GetElementById("wp-submit").InvokeMember("click");
                Tried = true;
            }
            catch { return; }
        }

        void SaveUser(bool Escape)
        {
            if (Escape || !FirstSave)
                return;
            Active_User.Username = getUser1.TB_Username.Text;
            Active_User.Password = getUser1.TB_Password.Text;
            Active_User.SaveUser();
            getUser1.Visible = false;
            FirstSave = false;
        }

        void Start_AutoWatch(bool Escape)
        {
            if (Escape)
                return;
            Wait = true;
            Clos = false;
            StartWatching = false;
            Watch_Value = "";
            AutoWatchMaxWait.Enabled = true;
            AutoWatchMaxWait.Interval = 3000;
            Counter = 0;
        }

        private void AutoPlay_Tick(object sender, EventArgs e)
        {
            Audio.SetApplicationVolume("Form1", 75);
            try
            {
                AutoPlay.Enabled = false;
                List<HtmlElement> Tab = ElementsByClass(webBrowser1.Document, "tab-guess-suit");
                foreach (HtmlElement HE in Tab)
                    HE.InvokeMember("click");
                webBrowser1.Document.GetElementById("card_suits").SetAttribute("value", "hearts");
                List<HtmlElement> TestCard = ElementsByClass(webBrowser1.Document, "opened-card");
                List<HtmlElement> TableMessages = ElementsByClass(webBrowser1.Document, "table-message");
                string TableMessage = "";
                if (TestCard.Count == 0) { DealCard(); return; }
                foreach (HtmlElement HE in TableMessages)
                    TableMessage += HE.InnerText + "\r\n";
                Results.Add(GH_Card.Card_LookUp(TestCard[0].GetAttribute("src"), TableMessage));
                DealCard();
            }
            catch
            {
                GH_Card.SaveResults(Active_User);
            }
        }

        bool DealCard()
        {
            try {
                if (webBrowser1.Document.GetElementById("daily_chips").InnerText != "0")
                {
                    webBrowser1.Document.GetElementById("game-lucky-button").InvokeMember("click");
                    GH_Card.NewCardDrawn();
                }
                else
                    SwitchToTV(true);
                return true;
            }
            catch { return false; }
        }

        void SwitchToTV(bool Save)
        {
            Audio.SetApplicationMute("Form1", false);
            Audio.SetApplicationVolume("Form1", 75);
            if (Save) {
                GH_Card.PlayRewards();
                GH_Card.SaveResults(Active_User);
            }
            webBrowser1.Url = new Uri("http://www.gifthulk.com/");
            StartWatching = true;
        }

        static List<HtmlElement> ElementsByClass(HtmlDocument doc, string className)
        {
            List<HtmlElement> Items = new List<HtmlElement>();
            foreach (HtmlElement e in doc.All)
                if (e.GetAttribute("className") == className)
                    Items.Add(e);
            return Items;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Audio.SetApplicationVolume("Form1", 75);
            Audio.SetApplicationMute("Form1", true);
            bool Setup = RegistryPresence(Process.GetCurrentProcess().ProcessName + ".exe");
            SetRegistry(Setup, Process.GetCurrentProcess().ProcessName + ".exe");
            Active_User = GH_User.LoadUser();
            LogMeOn = (Active_User != null);
            getUser1.Update(!LogMeOn, Active_User);
            getUser1.Visible = !(Active_User != null);
            getUser1.ParentF.Add(this);
            this.WindowState = FormWindowState.Maximized;
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        /// <summary>
        /// Plays an alarm when something happens.
        /// </summary>
        void playAlert()
        {
            if (!File.Exists("tada.wav"))
            {
                WebClient WC = new WebClient();
                WC.DownloadFile(new Uri("http://www.taloreal.com/tada.wav"), "tada.wav");
            }
            SoundPlayer SP = new SoundPlayer("tada.wav");
        }

        public int SecsLeft(int Count)
        {
            return (20 - Count) * 3;
        }

        private void AutoWatchMaxWait_Tick(object sender, EventArgs e)
        {
            bool NextVid = false;
            Counter++;
            try {
                NextVid = Watch_Value != webBrowser1.Document.GetElementById("progress-bar-current-progress").Style;
            }
            catch { Counter--; return; }
            L_SecsToFault.Text = "Seconds to TV fault catch: " + SecsLeft(Counter).ToString();
            if (Clos)
            {
                AutoWatchMaxWait.Enabled = false;
                Watch_Value = "";
                Clos = false;
                Wait = true;
            }
            else if (Wait)
            {
                Wait = false;
                Watch_Value = webBrowser1.Document.GetElementById("progress-bar-current-progress").Style;
                if (webBrowser1.Url.ToString() == Last_Video)
                    ElementsByClass(webBrowser1.Document, "orange-button")[0].InvokeMember("click");
                else
                    AutoWatchMaxWait.Interval = 3000;
            }
            else if (NextVid || Counter >= 20)
            {
                if (!webBrowser1.Document.GetElementById("progress-bar-current-progress").Style.Contains("100%"))
                {
                    once = true;
                    AutoWatchMaxWait.Enabled = false;
                    AutoWatchMaxWait.Interval = 3000;
                    Last_Video = webBrowser1.Url.ToString();
                    ElementsByClass(webBrowser1.Document, "orange-button")[0].InvokeMember("click");
                }
                else if (GetHulkCoins(false) != Coins)
                    Open_Captcha();
                else
                    BringWindowToFront();
            }
        }

        public void BringWindowToFront()
        {
            this.Show();
            this.BringToFront();
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
        }

        void Open_Captcha()
        {
            //SwitchToTV(false);
        }

        void OFD_ERROR(string Error_Message)
        {
            MessageBox.Show(Error_Message);
        }

        private void TopMostOff_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;
            TopMostOff.Enabled = false;
        }

        #region HTML Methods
        void RevealCaptcha(List<HtmlElement> Allowed)
        {
            foreach (HtmlElement H in Allowed)
                H.SetAttribute("NaatesTag", "Show");
            foreach (HtmlElement H in webBrowser1.Document.All)
                if (H.GetAttribute("NaatesTag") != "Show")
                    try { H.InnerHtml = ""; }
                    catch { continue; }
        }

        List<HtmlElement> RemoveLayer(HtmlElement LayerTop)
        {
            List<int> FailedIndexes = new List<int>();
            for (int i = LayerTop.Children.Count - 1; i >= 0; i--)
                if (String.IsNullOrEmpty(LayerTop.Children[i].GetAttribute("NaatesTag")))
                {
                    int i2 = 0;
                    i2 = i2 + i;
                    FailedIndexes.Add(i2);
                }
            foreach (int i in FailedIndexes)
                LayerTop.Children[i].InnerHtml = "";
            return null;
        }

        List<HtmlElement> GetParentsAndChildren(HtmlElement Original)
        {
            List<HtmlElement> Elements = new List<HtmlElement>();
            foreach (HtmlElement H in GetAllParents(Original))
                Elements.Add(H);
            foreach (HtmlElement H in GetAllSubElements(Original))
                Elements.Add(H);
            return Elements;
        }

        HtmlElement GetTopLevel(HtmlElement Original)
        {
            List<HtmlElement> Parents = new List<HtmlElement>();
            Parents.Add(Original);
            while (Parents.Last().Parent != null)
                Parents.Add(Parents.Last().Parent);
            return Parents[Parents.Count - 2].Parent;
        }

        List<HtmlElement> GetAllParents(HtmlElement Original)
        {
            List<HtmlElement> Parents = new List<HtmlElement>();
            Parents.Add(Original);
            while (Parents.Last().Parent != null)
                Parents.Add(Parents.Last().Parent);
            Parents.RemoveAt(0);
            return Parents;
        }

        List<HtmlElement> GetAllSubElements(HtmlElement Original)
        {
            List<HtmlElement> LevelItems = new List<HtmlElement>();
            LevelItems.Add(Original);
            foreach (HtmlElement H in Original.Children)
            {
                foreach (HtmlElement sub in GetAllSubElements(H))
                    LevelItems.Add(sub);
            }
            return LevelItems;
        }
        #endregion

        public bool RegistryPresence(string PName)
        {
            try { return ((int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", PName, null) == 9000); }
            catch { return false; }
        }

        public void SetRegistry(bool Escape, string PName)
        {
            if (Escape)
                return;
            try {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", PName, (object)(9000));
                MessageBox.Show("The program has to restart to initiate the newer version of IE compatability mode.  \r\nThis program will restart after you close this message.");
                Application.Restart();
            }
            catch {
                MessageBox.Show("Opps!  The program failed to set a registry key required to turn off compatability mode and will need to exit now.\r\nTry starting the program as administrator to fix this error.");
                Application.Exit();
            }
        }

        private void Captcha_Closed(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void DelayedClick_Tick(object sender, EventArgs e)
        {
            DelayedClick.Enabled = false;
            webBrowser1.Document.GetElementById("gifthulk-tv-href-2").InvokeMember("click");
        }

        private void ReportBug_Click(object sender, EventArgs e)
        {
            BugReport.ClearDetails();
            BugReport.Show();
        }

        private void GO_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(URLGO.Text);
        }
    }
}
