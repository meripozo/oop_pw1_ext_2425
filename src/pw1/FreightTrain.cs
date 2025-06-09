using System;
/*MaxWeight (int): The maximum weight (in kilograms) the train is capable of transporting.
FreightType (string): Type of cargo being transported (e.g., containers, liquids, coal).*/
namespace PWTrainstation
{
    public class FreightTrain : Train
    {
        public int maxWeight;
        public string freightType;

        public FreightTrain(int maxWeight, string freightType, string id, Status status, int arrivalTime, string type) : base(id, status, arrivalTime, type)
        {
            this.maxWeight = maxWeight;
            this.freightType = freightType;
        }
         
    }
}