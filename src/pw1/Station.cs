using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
/*Platforms (List<Platform>): Collection of all platforms available in the station.
Trains (List<Train>): Collection of all trains being managed by the station (both en route and docked).

Methods:
DisplayStatus (void): This method displays the status of platforms and trains
AdvanceTick (void): This method advances time by 15 minutes, updating train arrival times
*/
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

        public void StartSimulation()
        {
            
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