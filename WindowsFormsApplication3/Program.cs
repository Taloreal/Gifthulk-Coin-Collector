using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    static class Program
    {
        public static Announcer announcer = new Announcer();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            announcer.DoneSpeaking += Announcer_DoneSpeaking;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Announcer_DoneSpeaking() {
            Audio.SetApplicationMute("Form1", true);
        }

        public static void CloseAnnouncer() {
            announcer.Close();
        }
    }
}
