using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApplication3
{
    public class GH_TV
    {
        public string[] PreviouslyWatched = new string[] { "", "", "", "", "" };
        public int Index = 0;

        public bool Contains(string URL)
        {
            foreach (string s in PreviouslyWatched)
            {
                if (URL == s)
                    return true;
            }
            return false;
        }

        public bool Save()
        {
            try {
                TextWriter TW = new StreamWriter(@"Videos.txt");
                foreach (string video in PreviouslyWatched)
                    TW.WriteLine(video);
                TW.WriteLine(Index.ToString());
                TW.Close();
                return true;
            }
            catch { return false; }
        }

        public static GH_TV Load()
        {
            GH_TV Watcher = new GH_TV();
            try {
                TextReader TR = new StreamReader(@"Videos.txt");
                for (int i = 0; i != 5; i++)
                    Watcher.PreviouslyWatched[i] = TR.ReadLine();
                Watcher.Index = Convert.ToInt32(TR.ReadLine()[0]);
                TR.Close();
            }
            catch { return null;  }
            return Watcher;
        }
    }
}
