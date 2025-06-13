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

        public Platform(string id) //no pongo sttus en parámetros delc ontructor pq inicialmente el platform está free por defecto (todos los trenes están EnRoute). Asímismo, dockingTime siempre tendrá valor de 2 ticks 
        {
            this.id = id;
            this.status = Status.Free;
            this.dockingTime = 2;
            this.currentTrain = null; //inicialmente no hay trenes (todos los trenes están EnRoute)
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
        public string GetCurrentTrainId()
        {

            return currentTrain.GetId();
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