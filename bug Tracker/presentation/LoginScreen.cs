﻿using bug_Tracker.business_logic;
using bug_Tracker.data.models;
using bug_Tracker.presentation.shared;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bug_Tracker.presentation
{
    public class LoginScreen
    {
        public LoginScreen() { Build(); }

        public void Build()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            int pos = (Console.WindowWidth) / 2;
            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.WriteLine("Welcome to Bug Trucker");
            pos = (Console.WindowWidth) / 3;
            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.WriteLine("Login");
            Console.ForegroundColor = ConsoleColor.Blue;

            pos = (Console.WindowWidth) / 4;
            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            
            String result = UserUseCases.Login(email,password);
            new ProgressIndicator();
            Console.SetCursorPosition(pos, Console.CursorTop);
            Console.WriteLine(result);
            Thread.Sleep(2000);

            if (result == "You Are Logged In")
            {
                // go to Home Screen
                new HomeScreen();
            }
            else
            {
                // Refresh Logi in Screen
                new LoginScreen();
            }
            
        }

    }

}



