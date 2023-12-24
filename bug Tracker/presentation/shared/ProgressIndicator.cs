using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug_Tracker.presentation.shared
{
    public class ProgressIndicator
    {
        public ProgressIndicator()
        {
            Build();
        }
        private void DrawProgressBar(int progress, int total)
        {
            // Draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); // Start
            Console.CursorLeft = 32;
            Console.Write("]"); // End
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            // Draw filled part
            int position = 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            // Draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            // Draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    ");


        }
        public void Build()
        {
            Console.WriteLine("Loading... ");
            for (int i = 0; i <= 100; i++)
            {
                DrawProgressBar(i, 100);
                Thread.Sleep(10); // Simulate time-consuming task
            }
            Console.WriteLine("\n \n");
        }
    }
}
