namespace FishingNet
{
    public class Fish
    {
        private string fishType;
        private double length;
        private double weight;
        public string FishType { get { return fishType; } set { fishType = value; } }
        public double Length { get { return length; } set { length = value; } }
        public double Weight { get { return weight; } set { weight = value; } }
        public Fish(string type, double length, double weight)
        {
            this.FishType = type;
            this.Length = length;
            this.Weight = weight;


        }

        public override string ToString()
        {
            return $"There is a {fishType}, {length} cm. long, and {weight} gr. in weight.";
        }
    }
}
