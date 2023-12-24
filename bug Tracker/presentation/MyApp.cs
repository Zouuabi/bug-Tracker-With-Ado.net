using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug_Tracker.presentation
{
    public class MyApp
    {
        public MyApp() {
            Build();
        }

        public void Build()
        {
            while (true) {
                new WelcomeScreen();
            }
        }

    }     
       
}
