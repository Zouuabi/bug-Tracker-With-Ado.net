using bug_Tracker.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using bug_Tracker.data;

namespace bug_Tracker.business_logic
{
    public class UserUseCases
    {
        // to do implement crendentials already exists

        private static bool IsValidEmail(string email)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private static bool IsPasswordWeak(string password)
        {
            if (password.Length < 8)
            {
                return true;
            }

            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUppercase = true;
                else if (char.IsLower(c)) hasLowercase = true;
                else if (char.IsDigit(c)) hasDigit = true;
            }

            if (hasUppercase && hasLowercase && hasDigit)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static String Login(string email , string password)
        {

            
                UserRepository repo = new();
            try
            {
                String? pass = repo.ReadUser(email);
                if (pass == password)
                {
                    return "You Are Logged In";
                }else if ( pass == null)
                {
                    return "Wrong email";

                }
                else {
                    return "Wrong Password ";
                }

            }
            catch(Exception e) 
            {
                return e.Message; 
            }

            

        }
        public static String Register(User user)

        {
            if (! IsValidEmail(user.Email))
            {
                return "Entered Email Is Not Valid";
            }else if (IsPasswordWeak(user.Password))
            {
                return "Weak Password";
            }else
            {
                UserRepository userRepository = new();
                try
                {
                    userRepository.CreateUser(user);
                    return "You Are Register ! ";


                }
                catch
                {
                    return "Something Wen Wrong Try Again";

                }
                
            }



        }
    }
}
