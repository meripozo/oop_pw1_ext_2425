using System;
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
        private List<Platform> Platforms;
        private List<Train> Trains; 

        public Station()
        {
            this.Platforms = 
            [
                new Platform(), //rellenar el contructr
                new Platform(),
                new Platform(),
            ];
            this.Trains = new List<Train>();
        }
    }
}