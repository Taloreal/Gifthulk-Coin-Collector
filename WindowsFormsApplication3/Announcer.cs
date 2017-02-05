using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
using System.Threading;

namespace WindowsFormsApplication3
{
    public delegate void FinishedAnnouncing();
    public class Announcer
    {
        public List<string> Messages = new List<string>();
        private bool CloseApp = false;
        public event FinishedAnnouncing DoneSpeaking;

        public Announcer() {
            new Thread(Start).Start();
        }

        private void Start() {
            SpeechSynthesizer speaker = new SpeechSynthesizer();
            while (!CloseApp) {
                while (Messages.Count == 0 && !CloseApp) { }
                if (CloseApp) { return; }
                speaker.Speak(Messages[0]);
                Messages.RemoveAt(0);
                if (Messages.Count == 0) { DoneSpeaking(); }
            }
        }

        public void Speek(string toSay) {
            Messages.Add(toSay);
        }

        public void Close() {
            CloseApp = true;
        }
    }
}
