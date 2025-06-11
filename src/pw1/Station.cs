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
        public void LoadTrainsFromFile(string filePath)
        {
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
                train.SetArrivalTime(train.GetArrivalTime() - 15);
                if (train.GetArrivalTime() == 0)
                {
                    CheckTrains();

                }
            }
        }
        public void CheckTrains()
        {
            foreach (Train train in trains)
            {
                foreach (Platform platform in platforms)
                {
                    if (platform.GetStatus() == Platform.Status.Free)
                    {
                        train.SetStatus(Train.Status.Docking);
                        platform.SetStatus(Platform.Status.Occupied);

                        
                        platform.SetDockingTime(platform.GetDockingTime() - 1);
                        if (platform.GetDockingTime() == 0)
                        {
                            train.SetStatus(Train.Status.Docked);

                            Console.WriteLine("Releasing platform...");
                            Console.ReadLine();
                            //llamar aqui a ReleaseTrainFromPlatform()

                        }             
                    }
                }
                train.SetStatus(Train.Status.Waiting);
            }
            
        }

        public void StartSimulation()
        {
            bool simulationStop = false;
            Console.WriteLine("The simulation is stating right now!");

            while (!simulationStop)
            {
                Console.Clear();
                DisplayStatus();

                Console.WriteLine("Press any key to advance 1 tick.");
                Console.ReadLine();
                //AdvanceTick() here
            }
        }
        public void DisplayStatus()
        {
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