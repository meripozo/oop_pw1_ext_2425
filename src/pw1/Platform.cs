using System;
using System.Net;
/*ID (string): Unique identifier of the platform.
Status (enum): Free, Occupied.
CurrentTrain (Train): The train stopped in the platform. 
DockingTime (int): Number of ticks required for docking (default: 2)
*/
namespace PWTrainstation
{
    public class Platform
    {
        public string id;
        public Status status;
        public Train CurrentTrain;
        public int dockingTime;

        public enum Status
        {
            Free,
            Occupied
        }
        public Platform()
        {
            this.CurrentTrain = new Train();
        }

        public Platform(string id, Status status, int dockingTime)
        {
            this.id = id;
            this.status = status;
            this.dockingTime = dockingTime;

        }

    }
}