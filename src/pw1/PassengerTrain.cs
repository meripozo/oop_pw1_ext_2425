/*NumberOfCarriages (int): The total number of carriages attached to the passenger train
Capacity (int): The maximum number of passengers the train can carry.*/
using System;
namespace PWTrainstation
{
    public class PassengerTrain : Train
    {
        private int numberOfCarriages;
        private int capacity;

        public PassengerTrain(string id, int arrivalTime, string type, int numberOfCarriages, int capacity) : base(id, arrivalTime, type)
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }

        public int GetNumberOfCarriages()
        {
            return this.numberOfCarriages;
        }
        public void SetNumberOfCarriages()
        {
            this.numberOfCarriages = numberOfCarriages;
        }
        public int GetCapacity()
        {
            return this.capacity;
        }
        public void SetCapacity()
        {
            this.capacity = capacity;
        }

        public override void ShowTrainsInfo()
        {
            base.ShowTrainsInfo();
            Console.WriteLine($"NumberOfCarriages: {GetNumberOfCarriages()} ; Capacity: {GetCapacity()}");
        }
    }
}