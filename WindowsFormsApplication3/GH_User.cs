using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApplication3
{
    public class GH_User
    {
        public string Username = "";
        public string Password = "";
        public string Email = "naate@taloreal.com";
        public int HulkCoins = 0;

        public void Update(string User, string Pass, string email)
        {
            Username = User;
            Password = Pass;
            Email = email;
        }

        /// <summary>
        /// Loads a user accoutn previously saved.
        /// </summary>
        /// <returns>A new instance of a gifthulk user.</returns>
        public static GH_User LoadUser()
        {
            GH_User User = new GH_User();
            try
            {
                TextReader TR = new StreamReader("GHUser.txt");
                User.Username = TR.ReadLine();
                User.Password = TR.ReadLine();
                User.Email = TR.ReadLine();
                TR.Close();
                return User;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Saves the login info for a gifthulk user.
        /// </summary>
        /// <param name="User">The user object to save.</param>
        /// <returns>Returns weather the save was successful or not.</returns>
        public bool SaveUser()
        {
            try
            {
                TextWriter TW = new StreamWriter("GHUser.txt");
                TW.WriteLine(Username);
                TW.WriteLine(Password);
                TW.WriteLine(Email);
                TW.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}