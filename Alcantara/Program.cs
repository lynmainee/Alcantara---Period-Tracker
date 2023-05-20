using System;

namespace PeriodTracker
{
    class Program
    {
        static void Main(string [] args)
        { bool proceed = true;
            while (proceed) 
            {
                Console.WriteLine();
                Console.WriteLine("Period Tracker");

            Console.Write("Do you have a regular cycle? (yes/no): ");
            string response = Console.ReadLine();

            if (response.ToLower() == "no")
            {
                Console.WriteLine("Enter the first day of your last period (yyyy-mm-ddd): ");
                DateTime irregPeriod = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of days of your last period: ");
                int periodDays = int.Parse(Console.ReadLine());

                Console.WriteLine("Here are your current data:");
                Console.WriteLine("Last Period: {0: MM-dd-yyyy}", irregPeriod);
                Console.WriteLine("Number of Days: " + periodDays);
                Console.WriteLine("Press 0 to return or any key to exit.");
                var key = Console.ReadKey().Key;
                if (key != ConsoleKey.D0)
                {
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using this program.");
                        break;
                }
                
            }
            else if (response.ToLower() == "yes")
            {
                Console.Write("Enter the average length of your menstrual cycle in days: ");
                int cycleLength = int.Parse(Console.ReadLine());

                Console.Write("Enter the first day of your last period (yyyy-mm-dd): ");
                DateTime lastPeriod = DateTime.Parse(Console.ReadLine());

                DateTime nextPeriod = lastPeriod.AddDays(cycleLength);
                DateTime fertileStart = nextPeriod.AddDays(-14);
                DateTime fertileEnd = nextPeriod.AddDays(-9);

                Console.WriteLine("Here are your results:");
                Console.WriteLine("Predicted date of next period: {0:MM-dd-yyyy}.", nextPeriod);
                Console.WriteLine("Predicted date of fertile window: {0:MM-dd-yyyy} to {1:MM-dd-yyyy}.", fertileStart, fertileEnd);
                Console.WriteLine("\nPress 0 to return or any key to exit.");
                var key = Console.ReadKey().Key;
                    if (key != ConsoleKey.D0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using this program.");
                        break;
                    }
                }
            }
        }
    }
}