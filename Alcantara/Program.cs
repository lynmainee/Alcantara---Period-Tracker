using System;
using System.Collections.Generic;

namespace PeriodTracker
{
    class Program
    {
        static List<PeriodData> periodDataList = new List<PeriodData>();

        static void Main(string[] args)
        {
            bool proceed = true;
            while (proceed)
            {
                Console.WriteLine("\nPeriod Tracker");
                Console.WriteLine();

                Console.Write("Do you have a regular cycle? (yes/no): ");
                string response = Console.ReadLine();

                if (response.ToLower() == "no")
                {
                    Console.Write("Enter the first day of your last period (yyyy-mm-dd): ");
                    DateTime irregPeriod = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter the number of days of your last period: ");
                    int periodDays = int.Parse(Console.ReadLine());

                    PeriodData periodData = new PeriodData(irregPeriod, periodDays);
                    periodDataList.Add(periodData);

                    Console.WriteLine("\nHere are your current data:");
                    Console.WriteLine("Last Period: {0:MM-dd-yyyy}", periodData.LastPeriod);
                    Console.WriteLine("Number of Days: " + periodData.PeriodDays);
                }
                else if (response.ToLower() == "yes")
                {
                    Console.Write("Enter the average length of your menstrual cycle in days: ");
                    int cycleLength = int.Parse(Console.ReadLine());

                    Console.Write("Enter the first day of your last period (yyyy-mm-dd): ");
                    DateTime lastPeriod = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter the number of days of your last period: ");
                    int periodDays = int.Parse(Console.ReadLine());

                    DateTime nextPeriod = lastPeriod.AddDays(cycleLength);
                    DateTime fertileStart = nextPeriod.AddDays(-14);
                    DateTime fertileEnd = nextPeriod.AddDays(-9);

                    PeriodData periodData = new PeriodData(lastPeriod, periodDays, nextPeriod, fertileStart, fertileEnd);
                    periodDataList.Add(periodData);

                    Console.WriteLine("\nHere are your results:");
                    Console.WriteLine("Predicted date of next period: {0:MM-dd-yyyy}.", periodData.NextPeriod);
                    Console.WriteLine("Predicted date of fertile window: {0:MM-dd-yyyy} to {1:MM-dd-yyyy}.", periodData.FertileStart, periodData.FertileEnd);
                }

                Console.WriteLine("\nPress 0 to display all period data or any other key to continue.");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.D0)
                {
                    Console.WriteLine();
                    DisplayPeriodData();
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using this program.");
                    break;
                }
            }
        }

        static void DisplayPeriodData()
        {
            Console.WriteLine("\nPeriod Data:");

            if (periodDataList.Count == 0)
            {
                Console.WriteLine("No period data available.");
            }
            else
            {
                for (int i = 0; i < periodDataList.Count; i++)
                {
                    Console.WriteLine("\nCycle {0}:", i + 1);

                    if (periodDataList[i].NextPeriod == default(DateTime))
                    {
                        // Irregular cycle
                        Console.WriteLine("Last Period: {0:MM-dd-yyyy}", periodDataList[i].LastPeriod);
                        Console.WriteLine("Number of Days: " + periodDataList[i].PeriodDays);
                    }
                    else
                    {
                        // Regular cycle
                        Console.WriteLine("Last Period: {0:MM-dd-yyyy}", periodDataList[i].LastPeriod);
                        Console.WriteLine("Number of Days: " + periodDataList[i].PeriodDays);
                        Console.WriteLine("Predicted date of next period: {0:MM-dd-yyyy}.", periodDataList[i].NextPeriod);
                        Console.WriteLine("Predicted date of fertile window: {0:MM-dd-yyyy} to {1:MM-dd-yyyy}.", periodDataList[i].FertileStart, periodDataList[i].FertileEnd);
                    }

                    Console.WriteLine();
                }
            }
        }
    }

    class PeriodData
    {
        public DateTime LastPeriod { get; }
        public int PeriodDays { get; }
        public DateTime NextPeriod { get; }
        public DateTime FertileStart { get; }
        public DateTime FertileEnd { get; }

        public PeriodData(DateTime lastPeriod, int periodDays)
        {
            LastPeriod = lastPeriod;
            PeriodDays = periodDays;
        }

        public PeriodData(DateTime lastPeriod, int periodDays, DateTime nextPeriod, DateTime fertileStart, DateTime fertileEnd)
        {
            LastPeriod = lastPeriod;
            PeriodDays = periodDays;
            NextPeriod = nextPeriod;
            FertileStart = fertileStart;
            FertileEnd = fertileEnd;
        }
    }
}
