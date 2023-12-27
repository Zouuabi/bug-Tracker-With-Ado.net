using bug_Tracker.business_logic;
using bug_Tracker.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug_Tracker.presentation
{
    public class HomeScreen
    {
        private  readonly User user;
        public HomeScreen(User user) {
            this.user = user;
            Build();
        }


        public void Build()
        {
           
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                int pos = (Console.WindowWidth) / 2;
                Console.SetCursorPosition(pos, Console.CursorTop);
                Console.WriteLine("Bug Trucker");
                pos = (Console.WindowWidth) / 3;
                Console.SetCursorPosition(pos, Console.CursorTop);
                Console.WriteLine("Home");
                Console.ForegroundColor = ConsoleColor.Blue;

                pos = (Console.WindowWidth) / 4;
                Console.SetCursorPosition(pos, Console.CursorTop);
                Console.WriteLine(String.Format("You are Logged in As {0}",user.Email));
                Console.SetCursorPosition(pos, Console.CursorTop);



            List<Bug>?  bugs =  BugUsesCases.FetchBugs();

            Console.WriteLine(" Author\t\t\t Description\t\t\t\t\t\t Status ");

            for (int i = 0; i< bugs.Count; i++)
            {
                Console.WriteLine(String.Format("|{0}| \t\t\t| {1}\t\t\t\t\t\t |{3} ", bugs[i].Author, bugs[i].Description, bugs[i].Status)); 

            }
              
            Console.WriteLine("Press Any Key To logout");
                Console.ReadLine(); 


          

        }
    }
}
