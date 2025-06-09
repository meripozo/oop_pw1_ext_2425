/*NumberOfCarriages (int): The total number of carriages attached to the passenger train
Capacity (int): The maximum number of passengers the train can carry.*/
using System;
namespace PWTrainstation
{
    public class PassengerTrain : Train
    {
        public int numberOfCarriages;
        public int capacity;

        public PassengerTrain(int numberOfCarriages, int capacity, string id, Status status, int arrivalTime, string type) : base(id, status, arrivalTime, type)
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }
    }
}