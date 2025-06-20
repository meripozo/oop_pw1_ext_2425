using System;
using System.IO;

namespace PWTrainstation
{
    public class Station
    {
        private List<Platform> platforms;
        private List<Train> trains;

        public Station(int numberPlatforms) //como se pide al usuario el n plataformas, tendré que hacer un for aqui dentro
        {
            this.platforms = new List<Platform>();
            this.trains = new List<Train>();
            for (int i = 1; i <= numberPlatforms; i++)
            {
                platforms.Add(new Platform($"Platform-{i.ToString()}"));
            }
        }
        public void LoadTrainsFromFile()
        {
            Console.Write("Please enter the file path: ");
            string? filePath = Console.ReadLine();
            try
            {
                if (File.Exists(filePath))
                {
                    List<Train> tempTrains = new List<Train>();
                    string[] lines = File.ReadAllLines(filePath);

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        string[] trainValues = line.Split(",");
                        if (trainValues.Length != 5)
                        {
                            Console.WriteLine("Formatting error: Each line must have 5 values.");
                            return;
                        }
                        try
                        {
                            if (trainValues[2] == "Freight")
                            {
                                tempTrains.Add(new FreightTrain(trainValues[0],
                                    Convert.ToInt32(trainValues[1]),
                                    trainValues[2],
                                    Convert.ToInt32(trainValues[3]),
                                    trainValues[4]));
                            }
                            else if (trainValues[2] == "Passenger")
                            {
                                tempTrains.Add(new PassengerTrain(trainValues[0],
                                    Convert.ToInt32(trainValues[1]),
                                    trainValues[2],
                                    Convert.ToInt32(trainValues[3]),
                                    Convert.ToInt32(trainValues[4])));
                            }
                            else
                            {
                                Console.WriteLine($"Formatting error.");
                                Console.WriteLine("No trains were loaded.");
                                return;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Formatting error: Could not parse numeric values.");
                            return;
                        }
                    }
                    foreach (Train train in tempTrains)
                    {
                        trains.Add(train);
                    }
                    Console.WriteLine("Trains loaded successfully!");
                }
                else
                {
                    Console.WriteLine("File not found. Please check the file path and try again.");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        
        //In case the user doesn't know how many trains are in the CSV, when asked for the number of platforms,
        //they may not enter an adequate number of platforms so that all trains are docked at the same time on the platforms.
        //(they may not enter 15 platforms); That's why I do platform.SetCurrentTrain(null); platform.SetStatus(Platform.Status.Free);
        //to release the previous train that is already in the Docked state, to make way for the next train on the platform (without changing the state of the old train)
        public void AdvanceTick()
        {
            foreach (Train train in trains)
            {
                if (train.GetStatus() == Train.Status.EnRoute || train.GetStatus() == Train.Status.Waiting)
                {
                    int newArrival = train.GetArrivalTime() - 15;
                    if (newArrival < 0)
                    {
                        newArrival = 0;
                    }
                    train.SetArrivalTime(newArrival);
                }
            }
            CheckTrains();
        }

        public void CheckTrains()
        {
            //Liberar plataformas si el docking ha terminado
            foreach (Platform platform in platforms)
            {
                if (platform.GetStatus() == Platform.Status.Occupied)
                {
                    if (platform.GetCurrentTrain() != null && platform.GetCurrentTrain().GetStatus() == Train.Status.Docking)
                    {
                        platform.SetDockingTime(platform.GetDockingTime() - 1);
                        if (platform.GetDockingTime() <= 0)
                        {
                            platform.GetCurrentTrain().SetStatus(Train.Status.Docked);
                            platform.SetCurrentTrain(null);
                            platform.SetStatus(Platform.Status.Free);
                        }
                    }
                }
            }

            //Asignar plataformas a trenes que han llegado y están esperando o en ruta
            foreach (Train train in trains)
            {
                if (train.GetArrivalTime() == 0 && (train.GetStatus() == Train.Status.EnRoute || train.GetStatus() == Train.Status.Waiting))
                {
                    bool assigned = false;
                    foreach (Platform platform in platforms)
                    {
                        if (platform.GetStatus() == Platform.Status.Free)
                        {
                            platform.SetCurrentTrain(train);
                            train.SetStatus(Train.Status.Docking);
                            platform.SetStatus(Platform.Status.Occupied);
                            platform.SetDockingTime(2);
                            assigned = true;
                            return;
                        }
                    }
                    if (!assigned)
                    {
                        train.SetStatus(Train.Status.Waiting);
                    }
                }
            }
        }

        public void StartSimulation()
        {
            bool simulationStop = false;
            Console.WriteLine("The simulation is stating right now!");
            Console.ReadLine();

            while (!simulationStop)
            {
                Console.Clear();
                DisplayStatus();

                Console.WriteLine("Press any key to advance 1 tick.");
                Console.ReadKey();

                AdvanceTick();

                simulationStop = true;
                foreach (Train train in trains)
                {
                    if (train.GetStatus() != Train.Status.Docked)
                    {
                        simulationStop = false;
                    }
                }
            }
            Console.Clear();
            DisplayStatus();
            Console.WriteLine("All trains are docked. Exiting simulation...");
            Console.ReadLine();
        }
        public void DisplayStatus()
        {
            Console.Clear();
            Console.WriteLine("TRAIN STATION STATE:");
            Console.WriteLine("\nPLATFORMS:");
            foreach (Platform platform in platforms)
            {
                platform.ShowPlatformsInfo();
            }
            Console.WriteLine("\nTRAINS:");
            foreach (Train train in trains)
            {
                train.ShowTrainsInfo();
            }
        }
    }
}