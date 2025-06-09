using System;
using System.Data.Common;
/*ID (string): Unique identifier of the train.
Status (enum): The possible values are EnRoute, Waiting, Docking, Docked.
ArrivalTime (int): Time remaining until arrival at the station.
Type (string): Train type stored as text (passenger, freight).*/
namespace PWTrainstation
{
    public class Train //no es abstracta pq Platform tiene un CurrentTrain??
    {
        public string id;

        public Status status;
        public int arrivalTime;
        public string type;


        public enum Status
        {
            EnRoute,
            Waiting,
            Docking,
            Docked
        }

        public Train(string id, Status status, int arrivalTime, string type)
        {
            this.id = id;
            this.status = status;
            this.arrivalTime = arrivalTime;
            this.type = type;
        }


         
    }
}