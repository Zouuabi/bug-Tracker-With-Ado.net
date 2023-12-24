using bug_Tracker.business_logic;
using bug_Tracker.data.models;
using bug_Tracker.presentation.shared;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bug_Tracker.presentation
{
    public class RegisterScreen


    {

        public RegisterScreen() {
            Build();
        }
        
    

    public void Build() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            int pos = (Console.WindowWidth) / 2;

            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.WriteLine("Bug Trucker");

            pos = (Console.WindowWidth) / 3;

            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.WriteLine("Register");

            Console.ForegroundColor = ConsoleColor.Blue;
            pos = (Console.WindowWidth) / 4;

            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.Write("Enter your name: ");

            string name = Console.ReadLine();

            Console.SetCursorPosition(pos, Console.CursorTop);

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.SetCursorPosition(pos, Console.CursorTop);

            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            User user = new(name, email, password);
            String result = UserUseCases.Register(user);
            new ProgressIndicator();
            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.WriteLine(result);
            Thread.Sleep(2000);
            new WelcomeScreen();
        }

    }
}
