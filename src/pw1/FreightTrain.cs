using System;

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

        public int GetMaxWeight()
        {
            return this.maxWeight;
        }
        public string GetFreightType()
        {
            return this.freightType;
        }

        public override void ShowTrainsInfo()
        {
            base.ShowTrainsInfo();
            Console.WriteLine($"MaxWeight: {GetMaxWeight()} ; FreightType: {GetFreightType()}");
        }
    }
}