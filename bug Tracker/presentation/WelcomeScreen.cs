using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bug_Tracker.presentation
{
    public class WelcomeScreen
    {

        public WelcomeScreen() {
            Build();
                }


       static public void  Build()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            int pos = (Console.WindowWidth) / 2;
            Console.SetCursorPosition(pos, Console.CursorTop);

            Console.WriteLine("Welcome to Bug Trucker");

            Console.ForegroundColor = ConsoleColor.Blue;

            pos = (Console.WindowWidth) / 3;

            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.WriteLine("1. Register");
           

            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.WriteLine("2. Login");

            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.WriteLine("3. Exit");

            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.Write(">>>");
           
            int option = int.Parse(Console.ReadLine());

            switch (option) {
                case 1:
                    new RegisterScreen();
                    break;
                case 2:
                    new LoginScreen();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default :
                    // code block
                    break;

            }
        }
    }
}
