using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_3_en
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable initialization
            int direction = 0; // 0: direction unknown, 1: up, -1: down
            uint changes = 0; // Counter for direction changes
            int new_direction = direction; // New direction
            uint prev, current; // Floor number where the elevator stopped
            bool b_done = false; // Flag variable for loop exit condition
            Console.WriteLine("Enter the floor numbers where the elevator stopped.");
            Console.WriteLine("0 - End of data input");
            // Read the first floor
            uint.TryParse(Console.ReadLine(), out prev);
            b_done = (prev == 0);
            // Loop for input and analysis
            // Data is entered until the number 0 is received
            while (!b_done)
            {
                uint.TryParse(Console.ReadLine(), out current); // Enter remaining floors
                b_done = (current == 0); // Exit loop if 0 is entered
                // If floors are the same, direction doesn't change;
                // simply skip
                if (!b_done && current != prev)
                {
                    // Determine the new current direction
                    // between prev and current
                    new_direction = 1;
                    if (current > prev)
                        new_direction = -1;
                }
                // If the direction was already known (not 0)
                // and it doesn't match the new direction, a change has occurred
                if (!b_done && direction != 0 && new_direction != direction)
                    changes += 1;
                // Update history for the next step
                direction = new_direction;
                prev = current;
            }
            //--- Output information to the screen ----
            Console.WriteLine($"Number of elevator direction changes: {changes}");
            Console.Read(); // Pause output until "Enter" key is pressed
        }
    }
}
