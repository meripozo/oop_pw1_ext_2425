using System;
/*MaxWeight (int): The maximum weight (in kilograms) the train is capable of transporting.
FreightType (string): Type of cargo being transported (e.g., containers, liquids, coal).*/
namespace PWTrainstation
{
    public class FreightTrain : Train
    {
        private int maxWeight;
        private string freightType;

        public FreightTrain(string id, int arrivalTime, string type, int maxWeight, string freightType) : base(id, arrivalTime, type)
        {
            this.maxWeight = maxWeight;
            this.freightType = freightType;
        }

        public int GeMaxWeight()
        {
            return this.maxWeight;
        }
        public void SetMaxWeight()
        {
            this.maxWeight = maxWeight;
        }
        public string GeFreightType()
        {
            return this.freightType;
        }
        public void SetFreightType()
        {
            this.freightType = freightType;
        }
    }
}