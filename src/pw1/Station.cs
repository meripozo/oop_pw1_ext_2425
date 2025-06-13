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
                    Train currentTrain = train;
                    CheckTrains(currentTrain);
                }
            }
        }
        //In case the user doesn't know how many trains are in the CSV, when asked for the number of platforms,
        //they may not enter an adequate number of platforms so that all trains are docked at the same time on the platforms.
        //(they may not enter 15 platforms); That's why I do platform.SetCurrentTrain(null); platform.SetStatus(Platform.Status.Free);
        //to release the previous train that is already in the Docked state, to make way for the next train on the platform (without changing the state of the old train)
        public void CheckTrains(Train currentTrain)
        {
            for (int i = 0; i < platforms.Count(); i++)
            {
                if (platforms[i] != null)
                {
                    if (platforms[i].GetStatus() == Platform.Status.Free)
                    {
                        if (platforms[i].GetCurrentTrainId() != currentTrain.GetId()) //da exception aqui pq siempre se inicializa a null
                        {
                            platforms[i].SetCurrentTrain(currentTrain); //here we occupy the platform

                            currentTrain.SetStatus(Train.Status.Docking);
                            platforms[i].SetStatus(Platform.Status.Occupied);

                            platforms[i].SetDockingTime(platforms[i].GetDockingTime() - 1);
                            if (platforms[i].GetDockingTime() == 0)
                            {
                                currentTrain.SetStatus(Train.Status.Docked);

                                Console.WriteLine("Releasing platform...");
                                Console.ReadLine();

                                platforms[i].SetCurrentTrain(null);
                                platforms[i].SetStatus(Platform.Status.Free);
                            }
                        }
                    }
                }
              
                        //Platform platforms[i] = platforms[i];
            }    
            currentTrain.SetStatus(Train.Status.Waiting);
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
                Console.ReadLine();

                AdvanceTick();
            }
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