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
            Console.Write("Enter file path: ");
            string? filePath = Console.ReadLine();
            try
            {
                if (File.Exists(filePath))
                {
                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        //I make the split to read the values of the csv
                        string[] trainValues = line.Split(",");

                        if (trainValues[2] == "Freight")
                        {
                            trains.Add(new FreightTrain(trainValues[0],
                                        Convert.ToInt32(trainValues[1]),
                                                        trainValues[2],
                                        Convert.ToInt32(trainValues[3]),
                                                        trainValues[4]));
                        }
                        if (trainValues[2] == "Passenger")
                        {
                            trains.Add(new PassengerTrain(trainValues[0],
                                          Convert.ToInt32(trainValues[1]),
                                                          trainValues[2],
                                          Convert.ToInt32(trainValues[3]),
                                          Convert.ToInt32(trainValues[4])));
                        }
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
            catch (FormatException e)
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

        public void AdvanceTick()
        {
            //This method advances time by 15 minutes, updating train arrival times
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
        //In case the user doesn't know how many trains are in the CSV, when asked for the number of platforms,
        //they may not enter an adequate number of platforms so that all trains are docked at the same time on the platforms.
        //(they may not enter 15 platforms); That's why I do platform.SetCurrentTrain(null); platform.SetStatus(Platform.Status.Free);
        //to release the previous train that is already in the Docked state, to make way for the next train on the platform (without changing the state of the old train)
        public void CheckTrains()
        {
            foreach (Platform platform in platforms)
            {
                if (platform.GetStatus() == Platform.Status.Occupied)
                {
                    //solo cuando la plataforma está ocupada, entonces es cuando verifica si el tren está Docking, y además tengo que verificar que no esté null el tren de la plataforma, porque inicialmente están todas vacías(a null).
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
            foreach (Train train in trains)
            {
                if (train.GetArrivalTime() == 0 && (train.GetStatus() == Train.Status.EnRoute || train.GetStatus() == Train.Status.Waiting))
                {
                    bool platformOccupied = false;
                    foreach (Platform platform in platforms)
                    {
                        if (platform.GetStatus() == Platform.Status.Free)
                        {
                            platform.SetCurrentTrain(train);
                            train.SetStatus(Train.Status.Docking);
                            platform.SetStatus(Platform.Status.Occupied);
                            platform.SetDockingTime(2);
                            platformOccupied = true;
                            return;
                        }
                    }
                    if (!platformOccupied)
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
            //here I call DisplayStatus() again, in order to print the latest actualization of the list.
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