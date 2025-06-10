using System;

namespace PWTrainstation
{
    public abstract class Train
    {
        protected string id;

        protected Status status;
        protected int arrivalTime;
        protected string type;

        public enum Status : int
        {
            EnRoute = 1,
            Waiting = 2,
            Docking = 3,
            Docked = 4
        }

        public Train(string id, int arrivalTime, string type)
        {
            this.id = id;
            this.status = Status.EnRoute;
            this.arrivalTime = arrivalTime;
            this.type = type;
        }

        public string GetId()
        {
            return this.id;
        }
        public int GetArrivalTime()
        {
            return this.arrivalTime;
        }
        public void SetArrivalTime(int arrivalTime)
        {
            this.arrivalTime = arrivalTime;
        }
        public string GetType()
        {
            return this.type;
        }
        public Status GetStatus()
        {
            return this.status;
        }
        public void SetStatus(Status status)
        {
            this.status = status;
        }

        public virtual void ShowTrainsInfo()
        {
            Console.Write($"Id: {GetId()} ; Status: {GetStatus()} ; Arrival Time: {GetArrivalTime()} ; Type: {GetType()}");
        }
    }
}