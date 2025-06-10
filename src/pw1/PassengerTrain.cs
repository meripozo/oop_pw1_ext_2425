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

        public int GeNumberOfCarriages()
        {
            return this.numberOfCarriages;
        }
        public void SetNumberOfCarriages()
        {
            this.numberOfCarriages = numberOfCarriages;
        }
        public int GeCapacity()
        {
            return this.capacity;
        }
        public void SetCapacity()
        {
            this.capacity = capacity;
        }

    }
}