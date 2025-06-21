using System;

namespace PWTrainstation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //variables I use for controlling flow of program
            bool exit = false;
            int option = 0;
            int numberPlatforms = 0;
            bool validInput = false;
            do
            {
                try
                {
                    Console.Write("To start the program, please enter the number of platforms in the Train Station: ");
                    numberPlatforms = Convert.ToInt32(Console.ReadLine());
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error, please enter a valid integer.");
                    validInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    validInput = false;
                }
            } while (!validInput);

            Station station = new Station(numberPlatforms);
            
            while (!exit || option != 3) 
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine();
                    Console.WriteLine("╔═══════════════════════════════════════╗");
                    Console.WriteLine("║    Train Station Simulation Menu:     ║");
                    Console.WriteLine("║                                       ║");
                    Console.WriteLine("║ 1. Load trains from file              ║");
                    Console.WriteLine("║ 2. Start simulation                   ║");
                    Console.WriteLine("║ 3. Exit                               ║");
                    Console.WriteLine("╚═══════════════════════════════════════╝");
                    Console.Write("Select an option: ");

                    option = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException)
                {
                    Console.WriteLine("Error, please enter the correct data type.");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                switch (option)
                {
                    case 1:
                        station.LoadTrainsFromFile();
                        Console.ReadLine();
                        break;
                    case 2:
                        station.StartSimulation();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please, select an option between 1 and 3.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}