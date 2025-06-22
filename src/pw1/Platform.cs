using System;

namespace PWTrainstation
{
    public class Platform
    {
        private string id;
        private Status status;
        private Train? currentTrain;
        private int dockingTime;

        public enum Status : int
        {
            Free = 0,
            Occupied = 1
        }

        //I don't put status in the constructor parameters because initially the platform is free by default (all trains are EnRoute). 
        //Likewise, dockingTime will always have a value of 2 ticks
        public Platform(string id)
        {
            this.id = id;
            this.status = Status.Free;
            this.dockingTime = 2;
            this.currentTrain = null; //Initially there are no trains (all trains are EnRoute)
        }

        public string GetId()
        {
            return this.id;
        }
        public int GetDockingTime()
        {
            return this.dockingTime;
        }
        public void SetDockingTime(int dockingTime)
        {
            this.dockingTime = dockingTime;
        }
        public Train GetCurrentTrain()
        {
            return this.currentTrain;
        }
        public void SetCurrentTrain(Train currentTrain)
        {
            this.currentTrain = currentTrain;
        }
        public Status GetStatus()
        {
            return this.status;
        }
        public void SetStatus(Status status)
        {
            this.status = status;
        }

        public void ShowPlatformsInfo()
        {
            if (GetStatus() == Status.Free)
            {
                Console.WriteLine($"Id: {GetId()} ; Status: {GetStatus()}");
            }
            else
            {
                Console.WriteLine($"Id: {GetId()} ; Status: {GetStatus()} ; Current Train: {GetCurrentTrain().GetId()} ; Ticks Remaining: {GetDockingTime()}");
            }
        }
    }
}